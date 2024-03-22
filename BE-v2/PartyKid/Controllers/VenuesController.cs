using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace PartyKid;

[Route("api/[controller]")]
public class VenuesController : BaseApi
{
    private readonly IBaseServices<Venue> _venueService;
    private readonly IMapper _mapper;
    private readonly AutoMapper.IConfigurationProvider _config;

    public VenuesController(IBaseServices<Venue> venueService, IMapper mapper, AutoMapper.IConfigurationProvider config)
    {
        _venueService = venueService;
        _mapper = mapper;
        _config = config;
    }

    #region Query

    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        var entity = await _venueService.Query()
                                        .Include(x => x.VenueImages)
                                        .ProjectTo<VenueResponseDTO>(_config)
                                        .ToListAsync();
        return Success<IList<VenueResponseDTO>>(data: entity);
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

    [HttpPost]
    public async Task<IResponse> Create([FromBody] CreateVenueBindingModel request)
    {
        Venue entity = _mapper.Map<Venue>(request);
        return Success(message: await _venueService.Create(entity));
    }

    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] CreateVenueBindingModel request)
    {
        Venue venue = _mapper.Map<Venue>(request);
        return Success<VenueResponseDTO>(data: _mapper.Map<VenueResponseDTO>(await _venueService.Update(venue)));
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        return Success(message: await _venueService.Delete(id));
    }
    #endregion
}
