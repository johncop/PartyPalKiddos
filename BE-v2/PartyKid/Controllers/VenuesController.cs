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
    private readonly PartyKidDbContext _dbContext;

    public VenuesController(IBaseServices<Venue> venueService, IMapper mapper, PartyKidDbContext dbContext) : base(mapper)
    {
        _venueService = venueService;
        _dbContext = dbContext;
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
                                                            .ProjectTo<VenueResponseDTO>(_mapper.ConfigurationProvider)
                                                            .ToListAsync();
        return Success<IList<VenueResponseDTO>>(data: venues);
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        Venue venue = await _venueService.Query(x => x.Id == id && !x.IsDeleted, disableChangeTracker: true).AsTracking().FirstOrDefaultAsync();
        if (venue is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        await _dbContext.Entry(venue).Collection(x => x.VenueCombos).LoadAsync();
        await _dbContext.Entry(venue).Collection(x => x.VenueFoods).LoadAsync();
        await _dbContext.Entry(venue).Collection(x => x.VenueServices).LoadAsync();
        await _dbContext.Entry(venue).Collection(x => x.VenueServicePackages).LoadAsync();

        VenueResponseDTO venueRes = _mapper.Map<VenueResponseDTO>(venue);
        return Success<VenueResponseDTO>(data: venueRes);
    }

    [HttpGet]
    [Route("search")]
    public async Task<IResponse> Search([FromQuery] SearchVenueBindingModel request)
    {
        var venue = _venueService.Query();
        if (request.Id.HasValue)
        {
            venue.Where(x => x.Id == request.Id);
        }

        if (request.DisctrictId.HasValue)
        {
            venue.Where(x => x.DistrictId == request.DisctrictId);
        }

        if (!request.Address.IsNullOrEmpty())
        {
            venue.Where(x => x.Address.ToLower().Contains(request.Address.ToLower()));
        }

        return Success<IList<VenueResponseDTO>>(data: await venue.Include(x => x.VenueImages)
                                                                .ProjectTo<VenueResponseDTO>(_mapper.ConfigurationProvider)
                                                                .ToListAsync());
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
        Venue venue = await _venueService.Query(filter: x => x.Id == id)
                                        .Include(x => x.VenueCombos)
                                        .Include(x => x.VenueFoods)
                                        .Include(x => x.VenueServices)
                                        .Include(x => x.VenueServicePackages)
                                        .FirstOrDefaultAsync();
        if (venue is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        request.Id = id;
        if (request.ImageUrls is not null && request.ImageUrls.Count > 0)
        {
            venue.VenueImages = new List<VenueImage>();
            foreach (string imageUrl in request.ImageUrls)
            {
                venue.VenueImages.Add(new VenueImage() { ImageUrl = imageUrl });
            }
        }

        if (request.Combos is not null && request.Combos.Count > 0)
        {
            venue.VenueCombos = venue.VenueCombos.Count < 0 ? new List<VenueCombo>() : venue.VenueCombos;
            foreach (int comboId in request.Combos)
            {
                VenueCombo comboExisted = venue.VenueCombos.FirstOrDefault(x => x.ComboId == comboId);
                if (comboExisted is null)
                {
                    venue.VenueCombos.Add(new VenueCombo()
                    {
                        ComboId = comboId
                    });
                }
            }
        }

        if (request.Foods is not null && request.Foods.Count > 0)
        {
            venue.VenueFoods = venue.VenueFoods.Count < 0 ? new List<VenueFood>() : venue.VenueFoods;
            foreach (int foodId in request.Foods)
            {
                VenueFood venueFoodExisted = venue.VenueFoods.FirstOrDefault(x => x.FoodId == foodId && x.VenueId == venue.Id);
                if (venueFoodExisted is null)
                {
                    venue.VenueFoods.Add(new VenueFood()
                    {
                        FoodId = foodId
                    });
                }
            }
        }

        if (request.Services is not null && request.Services.Count > 0)
        {
            venue.VenueServices = venue.VenueServices.Count < 0 ? new List<VenueService>() : venue.VenueServices;
            foreach (int serviceId in request.Services)
            {
                VenueService venueServiceExisted = venue.VenueServices.FirstOrDefault(x => x.ServiceId == serviceId);
                if (venueServiceExisted is null)
                {
                    venue.VenueServices.Add(new VenueService()
                    {
                        ServiceId = serviceId
                    });
                }
            }
        }

        if (request.ServicePackages is not null && request.ServicePackages.Count > 0)
        {
            venue.VenueServicePackages = venue.VenueServicePackages.Count < 0 ? new List<VenueServicePackage>() : venue.VenueServicePackages;
            foreach (int servicePackageId in request.ServicePackages)
            {
                VenueServicePackage venueServicePackageExisted = venue.VenueServicePackages.FirstOrDefault(x => x.ServicePackageId == servicePackageId);
                if (venueServicePackageExisted is null)
                {
                    venue.VenueServicePackages.Add(new VenueServicePackage()
                    {
                        ServicePackageId = servicePackageId
                    });
                }
            }
        }

        venue = _mapper.Map(request, venue);
        return Success<VenueResponseDTO>(data: _mapper.Map<VenueResponseDTO>(await _venueService.Update(venue)));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        return Success(message: await _venueService.Delete(id));
    }
    #endregion
}
