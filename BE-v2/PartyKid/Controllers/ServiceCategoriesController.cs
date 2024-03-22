using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/service-categories")]
public class ServiceCategoriesController : BaseApi
{
    private readonly IBaseServices<ServiceCategory> _serviceCategoryService;
    private readonly IMapper _mapper;
    public ServiceCategoriesController(IBaseServices<ServiceCategory> serviceCategoryService, IMapper mapper)
    {
        _serviceCategoryService = serviceCategoryService;
        _mapper = mapper;
    }

    #region Query
    [HttpGet]
    public async Task<IResponse> GetAll() => Success<IList<ServiceCategoryResponseDTO>>(data:
                                                await _serviceCategoryService.GetAllAsync<ServiceCategoryResponseDTO>());

    [HttpGet]
    [Route("search")]
    public async Task<IResponse> Search([FromQuery] SearchServiceCategoryBindingModel request)
    {
        Expression<Func<ServiceCategory, bool>>? query = null;
        if (request.Id.HasValue)
        {
            query = x => x.Id == request.Id;
        }

        if (request.Name != null)
        {
            query = x => x.Name.ToLower().Contains(request.Name.ToLower());
        }

        return Success<IList<ServiceCategoryResponseDTO>>(data: await _serviceCategoryService.Search<ServiceCategoryResponseDTO>(filter: query));
    }
    #endregion

    #region Command

    [CustomAuthorize]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] CreateServiceBindingModel request)
    {
        string result = await _serviceCategoryService.Create(_mapper.Map<ServiceCategory>(request));
        return Success(message: result);
    }

    [CustomAuthorize]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateServiceBindingModel request)
    {
        request.Id = id;
        ServiceCategory? entity = await _serviceCategoryService.Update(_mapper.Map<ServiceCategory>(request));
        return Success<ServiceCategoryResponseDTO>(data: _mapper.Map<ServiceCategoryResponseDTO>(entity));
    }

    [CustomAuthorize]
    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        return Success(message: await _serviceCategoryService.Delete(id));
    }
    #endregion
}
