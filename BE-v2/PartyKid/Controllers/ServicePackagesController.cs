using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;

[Route("api/service-packages")]
public class ServicePackagesController : BaseApi
{
    private readonly IBaseServices<ServicePackage> _servicePackageService;
    private readonly DbContext _dbContext;
    public ServicePackagesController(IMapper mapper, IBaseServices<ServicePackage> servicePackageService, DbContext dbContext) : base(mapper)
    {
        _servicePackageService = servicePackageService;
        _dbContext = dbContext;
    }


    #region Queries

    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        return Success<IList<ServicePackageResponseDTO>>(data:
                await _servicePackageService.GetAllAsync<ServicePackageResponseDTO>(filter: x => !x.IsDeleted, includeEntities: x => x.Services));
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
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        ServicePackageResponseDTO servicePackage = await _servicePackageService.Query(filter: x => x.Id == id,
                                                                                      includeEntities: x => x.Images)
                                                                                 .ProjectTo<ServicePackageResponseDTO>(_mapper.ConfigurationProvider)
                                                                                 .FirstOrDefaultAsync();
        if (servicePackage is not null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        return Success<ServicePackageResponseDTO>(data: servicePackage);
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

        if (request.Services.Count > 0)
        {
            servicePackage.Services = new List<ServicePackageDetail>();
            foreach (var service in request.Services)
            {
                servicePackage.Services.Add(new ServicePackageDetail()
                {
                    ServiceId = service,
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
        ServicePackage servicePackage = await _servicePackageService.Query(filter: x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();
        if (servicePackage is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        request.Id = id;
        if (request.Images is not null)
        {
            await _dbContext.Entry(servicePackage).Collection(x => x.Images).Query().ExecuteDeleteAsync();
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
        }

        if (request.Services is not null)
        {
            await _dbContext.Entry(servicePackage).Collection(x => x.Services).Query().ExecuteDeleteAsync();
            if (request.Services.Count > 0)
            {
                servicePackage.Services = new List<ServicePackageDetail>();
                foreach (var serviceId in request.Services)
                {
                    servicePackage.Services.Add(new ServicePackageDetail()
                    {
                        ServiceId = serviceId
                    });
                }
            }
        }

        servicePackage = _mapper.Map(request, servicePackage);
        await _servicePackageService.Update(servicePackage);

        return Success(message: Constants.Transactions.Messages.UpdateComplete);
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("{Id:int}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        ServicePackage servicePackage = await _servicePackageService.Find(filter: x => x.Id == id);

        await _dbContext.Entry(servicePackage).Collection(x => x.BookingDetails).LoadAsync();
        if (servicePackage.BookingDetails.Count > 0)
        {
            throw new DomainException(Constants.Transactions.Messages.DeleteFailure);
        }

        servicePackage.Services.Clear();
        return Success(await _servicePackageService.Delete(servicePackage));
    }
    #endregion
}
