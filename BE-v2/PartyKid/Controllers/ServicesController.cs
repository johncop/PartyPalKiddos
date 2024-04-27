using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;

[Route("api/[controller]")]
public class ServicesController : BaseApi
{
    private readonly IBaseServices<Service> _serviceService;
    private readonly DbContext _dbContext;
    public ServicesController(IBaseServices<Service> serviceService, IMapper mapper, DbContext dbContext) : base(mapper)
    {
        _serviceService = serviceService;
        _dbContext = dbContext;
    }

    #region Query

    [HttpGet]
    public async Task<IResponse> GetAll() =>
                Success<IList<ServiceResponseDTO>>(data: await _serviceService.GetAllAsync<ServiceResponseDTO>(filter: x => !x.IsDeleted));

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        Service service = await _serviceService.Find(filter: x => x.Id == id);

        return Success<ServiceResponseDTO>(data: _mapper.Map<ServiceResponseDTO>(service));
    }

    #endregion

    #region Command

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] CreateServiceBindingModel request)
    {
        string result = await _serviceService.Create(_mapper.Map<Service>(request));
        return Success(message: result);
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateServiceBindingModel request)
    {
        request.Id = id;
        Service existingService = await _serviceService.Find(filter: x => x.Id == id);

        Service service = _mapper.Map(request, existingService);
        return Success<ServiceResponseDTO>(data: _mapper.Map<ServiceResponseDTO>(await _serviceService.Update(service)));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        Service service = await _serviceService.Find(filter: x => x.Id == id);

        await _dbContext.Entry(service).Collection(x => x.BookingDetails).LoadAsync();
        if (service.BookingDetails.Count > 0)
        {
            throw new DomainException(Constants.Transactions.Messages.DeleteFailure);
        }

        return Success(message: await _serviceService.Delete(service));
    }
    #endregion
}
