using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/service-categories")]
public class ServiceCategoriesController : BaseApi
{
    private readonly IBaseServices<ServiceCategory> _serviceCategoryService;
    public ServiceCategoriesController(IBaseServices<ServiceCategory> serviceCategoryService, IMapper mapper) : base(mapper)
    {
        _serviceCategoryService = serviceCategoryService;
    }

    #region Query
    [HttpGet]
    public async Task<IResponse> GetAll() => Success<IList<ServiceCategoryResponseDTO>>(data:
                                                await _serviceCategoryService.GetAllAsync<ServiceCategoryResponseDTO>(filter: x => !x.IsDeleted));

    [HttpGet]
    [Route("search")]
    public async Task<IResponse> Search([FromQuery] SearchServiceCategoryBindingModel request)
    {
        Expression<Func<ServiceCategory, bool>>? filter = null;
        if (request.Id.HasValue)
        {
            filter = x => x.Id == request.Id;
        }

        if (request.Name != null)
        {
            filter = x => x.Name.ToLower().Contains(request.Name.ToLower());
        }

        return Success<IList<ServiceCategoryResponseDTO>>(data: await _serviceCategoryService.Search<ServiceCategoryResponseDTO>(filter: filter));
    }
    #endregion

    #region Command

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] CreateServiceCategoryBindingModel request)
    {
        string result = await _serviceCategoryService.Create(_mapper.Map<ServiceCategory>(request));
        return Success(message: result);
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateServiceCategoryBindingModel request)
    {
        ServiceCategory serviceCategory = await _serviceCategoryService.Find(filter: x => x.Id == id);
        if (serviceCategory is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        request.Id = serviceCategory.Id;
        serviceCategory = _mapper.Map(request, serviceCategory);
        ServiceCategoryResponseDTO response = _mapper.Map<ServiceCategoryResponseDTO>(await _serviceCategoryService.Update(serviceCategory));
        return Success<ServiceCategoryResponseDTO>(data: response);
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        ServiceCategory serviceCategory = await _serviceCategoryService.Find(filter: x => x.Id == id);
        return Success(message: await _serviceCategoryService.Delete(serviceCategory));
    }
    #endregion
}
