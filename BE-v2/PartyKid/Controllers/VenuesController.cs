using System.Threading.Tasks.Dataflow;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace PartyKid;

[Route("api/[controller]")]
public class VenuesController : BaseApi
{
    private readonly IBaseServices<Venue> _venueService;
    private readonly IBaseServices<Service> _serviceServices;
    private readonly PartyKidDbContext _dbContext;

    public VenuesController(IBaseServices<Venue> venueService,
                            IMapper mapper,
                            PartyKidDbContext dbContext,
                            IBaseServices<Service> serviceServices) : base(mapper)
    {
        _venueService = venueService;
        _dbContext = dbContext;
        _serviceServices = serviceServices;
    }

    #region Query
    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        IList<VenueResponseDTO> venues = await _venueService.Query(x => !x.IsDeleted)
                                                            .Include(x => x.VenueCombos)
                                                            .Include(x => x.VenueFoods)
                                                            .Include(x => x.VenueImages)
                                                            .Include(x => x.VenueServices)
                                                            .Include(x => x.TimeSlots)
                                                            .ProjectTo<VenueResponseDTO>(_mapper.ConfigurationProvider)
                                                            .ToListAsync();
        return Success<IList<VenueResponseDTO>>(data: venues);
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        Venue venue = await _venueService.Query(x => x.Id == id && !x.IsDeleted).AsTracking().FirstOrDefaultAsync();
        if (venue is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }
        await _dbContext.Entry(venue).Reference(x => x.District).LoadAsync();
        await _dbContext.Entry(venue).Collection(x => x.VenueImages).LoadAsync();
        await _dbContext.Entry(venue).Collection(x => x.VenueCombos).Query().Include(x => x.Combo).LoadAsync();
        await _dbContext.Entry(venue).Collection(x => x.VenueFoods).Query().Include(x => x.Food).ThenInclude(x => x.FoodCategory).LoadAsync();
        await _dbContext.Entry(venue).Collection(x => x.VenueServices).Query().Include(x => x.Service).LoadAsync();
        await _dbContext.Entry(venue).Collection(x => x.VenueServicePackages).Query().Include(x => x.ServicePackage).LoadAsync();
        await _dbContext.Entry(venue).Collection(x => x.TimeSlots).LoadAsync();

        VenueResponseDTO venueRes = _mapper.Map<VenueResponseDTO>(venue);
        return Success<VenueResponseDTO>(data: venueRes);
    }

    [HttpGet]
    [Route("search")]
    public async Task<IResponse> Search([FromQuery] SearchVenueBindingModel request)
    {
        var searchResult = new VenueSearchResponseDTO();
        if (request.DistrictId.HasValue)
        {
            searchResult.Venues = await _venueService.Query(filter: x => x.DistrictId == request.DistrictId.Value)
                                                    .ProjectTo<SearchItemResponseDTO>(_mapper.ConfigurationProvider)
                                                    .ToListAsync();
        }

        if (request.ServiceCategoryId.HasValue)
        {
            searchResult.Services = await _serviceServices.Query(filter: x => x.ServiceCategoryId == request.ServiceCategoryId.Value)
                                                            .ProjectTo<SearchItemResponseDTO>(_mapper.ConfigurationProvider)
                                                            .ToListAsync();
        }

        return Success<VenueSearchResponseDTO>(data: searchResult);
    }
    #endregion

    #region Command

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] AddVenueBindingModel request)
    {
        Venue venue = _mapper.Map<Venue>(request);
        if (request.ImageUrls.Count > 0)
        {
            venue.VenueImages = new List<VenueImage>();
            foreach (string imageUrl in request.ImageUrls)
            {
                venue.VenueImages.Add(new VenueImage() { ImageUrl = imageUrl });
            }
        }
        return Success(message: await _venueService.Create(venue));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateVenueBindingModel request)
    {
        Venue venue = await _venueService.Query(filter: x => x.Id == id).AsTracking().FirstOrDefaultAsync();
        if (venue is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        //Load related data using Explicit Loading
        await _dbContext.Entry(venue).Reference(x => x.District).LoadAsync();
        await _dbContext.Entry(venue).Collection(x => x.TimeSlots).LoadAsync();

        request.Id = id;
        if (request.ImageUrls is not null)
        {
            await _dbContext.Entry(venue).Collection(x => x.VenueImages).Query().ExecuteDeleteAsync();
            if (request.ImageUrls.Count > 0)
            {
                venue.VenueImages = new List<VenueImage>();
                foreach (string imageUrl in request.ImageUrls)
                {
                    venue.VenueImages.Add(new VenueImage() { ImageUrl = imageUrl });
                }
            }

        }

        if (request.Combos is not null)
        {
            await _dbContext.Entry(venue).Collection(x => x.VenueCombos).Query().ExecuteDeleteAsync();
            if (request.Combos.Count > 0)
            {
                venue.VenueCombos = new List<VenueCombo>();

                foreach (int comboId in request.Combos)
                {
                    venue.VenueCombos.Add(new VenueCombo()
                    {
                        ComboId = comboId
                    });
                }
            }
        }

        if (request.Foods is not null)
        {
            await _dbContext.Entry(venue).Collection(x => x.VenueFoods).Query().ExecuteDeleteAsync();
            if (request.Foods.Count > 0)
            {
                venue.VenueFoods = new List<VenueFood>();
                foreach (int foodId in request.Foods)
                {
                    venue.VenueFoods.Add(new VenueFood()
                    {
                        FoodId = foodId
                    });
                }
            }
        }

        if (request.Services is not null)
        {
            await _dbContext.Entry(venue).Collection(x => x.VenueServices).Query().ExecuteDeleteAsync();
            if (request.Services.Count > 0)
            {
                venue.VenueServices = new List<VenueService>();
                foreach (int serviceId in request.Services)
                {
                    venue.VenueServices.Add(new VenueService()
                    {
                        ServiceId = serviceId
                    });
                }
            }
        }

        if (request.ServicePackages is not null)
        {
            await _dbContext.Entry(venue).Collection(x => x.VenueServicePackages).Query().ExecuteDeleteAsync();
            if (request.ServicePackages.Count > 0)
            {
                venue.VenueServicePackages = new List<VenueServicePackage>();
                foreach (int servicePackageId in request.ServicePackages)
                {
                    venue.VenueServicePackages.Add(new VenueServicePackage()
                    {
                        ServicePackageId = servicePackageId
                    });
                }
            }

        }

        venue = _mapper.Map(request, venue);
        await _venueService.Update(venue);

        return Success(message: Constants.Transactions.Messages.UpdateComplete);
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        Venue venue = await _venueService.Find(filter: x => x.Id == id);

        venue.VenueCombos.Clear();
        venue.VenueFoods.Clear();
        venue.VenueImages.Clear();
        venue.VenueServicePackages.Clear();
        venue.VenueServices.Clear();
        return Success(message: await _venueService.Delete(venue));
    }
    #endregion
}
