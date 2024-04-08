using System.Reflection.Metadata;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/[controller]")]
public class DistrictsController : BaseApi
{
    private readonly IBaseServices<District> _districtService;
    public DistrictsController(IBaseServices<District> districtService, IMapper mapper) : base(mapper)
    {
        _districtService = districtService;
    }

    #region Query
    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        return Success<IList<DistrictResponseDTO>>(data: await _districtService.GetAllAsync<DistrictResponseDTO>(filter: x => !x.IsDeleted));
    }

    [HttpGet]
    [Route("search/{Id:int}")]
    public async Task<IResponse> Search([FromRoute(Name = "Id")] int id)
    {
        return Success<DistrictResponseDTO>(data: _mapper.Map<DistrictResponseDTO>(await _districtService.Find(id)));
    }
    #endregion

    #region Commands

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] AddDistrictBindingModel request)
    {
        District district = _mapper.Map<District>(request);
        return Success(message: await _districtService.Create(district));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("{Id:int}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateDistrictBindingModel request)
    {
        District district = await _districtService.Find(id);
        if (district is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        district = _mapper.Map<District>(request);
        return Success<DistrictResponseDTO>(data: _mapper.Map<DistrictResponseDTO>(await _districtService.Update(district)));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("{Id:int}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        return Success(message: await _districtService.Delete(id));
    }
    #endregion
}
