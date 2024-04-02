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
    private readonly IBaseServices<Combo> _comboService;
    private readonly AutoMapper.IConfigurationProvider _config;

    public VenuesController(IBaseServices<Venue> venueService,
                            IMapper mapper,
                            AutoMapper.IConfigurationProvider config,
                            IBaseServices<Combo> comboService) : base(mapper)
    {
        _venueService = venueService;
        _config = config;
        _comboService = comboService;
    }

    #region Query
    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        IList<VenueResponseDTO> venues = await _venueService.GetAllAsync<VenueResponseDTO>(filter: x => !x.IsDeleted,
                                                                                           includeEntities: x => x.VenueImages);
        return Success<IList<VenueResponseDTO>>(data: venues);
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

        return Success<IList<VenueResponseDTO>>(data:
                                            await venue.Include(x => x.VenueImages).ProjectTo<VenueResponseDTO>(_config).ToListAsync());
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
    [HttpPost]
    [Route("add-combo/{Id}")]
    public async Task<IResponse> AddCombo([FromRoute(Name = "Id")] int id, [FromBody] AddVenueComboBindingModel request)
    {
        request.VenueId = id;
        Venue venue = await _venueService.Find(id);
        if (request.Combos.Count > 0)
        {
            for (int i = request.Combos.Count - 1; i >= 0; --i)
            {
                Combo combo = await _comboService.Find(request.Combos[i]);
                if (combo == null)
                {
                    throw new Exception(Constants.Transactions.Messages.NotFound);
                }

                venue.VenueCombos.Add(new VenueCombo()
                {
                    Venue = venue,
                    Combo = combo
                });
            }
        }
        return Success<VenueResponseDTO>(data: _mapper.Map<VenueResponseDTO>(await _venueService.Update(venue)));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateVenueBindingModel request)
    {
        Venue venue = await _venueService.Find(id);
        if (venue is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        if (request.ImageUrls.Count > 0)
        {
            venue.VenueImages = new List<VenueImage>();
            foreach (string imageUrl in request.ImageUrls)
            {
                venue.VenueImages.Add(new VenueImage() { ImageUrl = imageUrl });
            }
        }

        venue = _mapper.Map<Venue>(request);
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
