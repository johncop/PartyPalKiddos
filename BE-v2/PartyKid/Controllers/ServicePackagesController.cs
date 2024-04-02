using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/service-packages")]
public class ServicePackagesController : BaseApi
{
    private readonly IBaseServices<ServicePackage> _servicePackageService;
    public ServicePackagesController(IMapper mapper, IBaseServices<ServicePackage> servicePackageService) : base(mapper)
    {
        _servicePackageService = servicePackageService;
    }


    #region Queries

    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        return Success<IList<ServicePackageResponseDTO>>(data: await _servicePackageService.GetAllAsync<ServicePackageResponseDTO>());
    }

    [HttpGet]
    [Route("search")]
    public async Task<IResponse> Search([FromQuery] SearchServicePackageBindingModel request)
    {
        Expression<Func<ServicePackage, bool>>? filter = null;
        if (!string.IsNullOrEmpty(request.Name))
        {
            filter = x => x.Name.ToLower().Contains(request.Name.ToLower());
        }

        if (request.Price.HasValue)
        {
            filter = x => x.Price == request.Price;
        }

        return Success<IList<ServicePackageResponseDTO>>(data: await _servicePackageService.GetAllAsync<ServicePackageResponseDTO>(filter: filter));
    }

    [HttpGet]
    [Route("{Id:int}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        return Success<ServicePackageResponseDTO>(data: _mapper.Map<ServicePackageResponseDTO>(await _servicePackageService.Find(id)));
    }

    #endregion

    #region Commands

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] CreateServicePackageBindingModel request)
    {
        ServicePackage servicePackage = _mapper.Map<ServicePackage>(request);
        if (request.Images.Count > 0)
        {
            servicePackage.Images = new List<ServicePackageImage>();
            foreach (string imageUrl in request.Images)
            {
                servicePackage.Images.Add(new ServicePackageImage()
                {
                    ImageUrl = imageUrl
                });
            }
        }

        return Success(message: await _servicePackageService.Create(servicePackage));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("{Id:int}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateServicePackageBindingModel request)
    {
        ServicePackage servicePackage = await _servicePackageService.Find(id);
        if (servicePackage is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        servicePackage = _mapper.Map<ServicePackage>(request);
        if (request.Images.Count > 0)
        {
            servicePackage.Images = new List<ServicePackageImage>();
            foreach (string imageUrl in request.Images)
            {
                servicePackage.Images.Add(new ServicePackageImage()
                {
                    ImageUrl = imageUrl
                });
            }
        }

        ServicePackageResponseDTO response = _mapper.Map<ServicePackageResponseDTO>(await _servicePackageService.Update(servicePackage));
        return Success<ServicePackageResponseDTO>(data: response);
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("{Id:int}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        ServicePackage servicePackage = await _servicePackageService.Find(id);
        if (servicePackage is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }
        return Success(await _servicePackageService.Delete(id));
    }
    #endregion
}
