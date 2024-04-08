using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/[controller]")]
public class ServicesController : BaseApi
{
    private readonly IBaseServices<Service> _serviceService;
    public ServicesController(IBaseServices<Service> serviceService, IMapper mapper) : base(mapper)
    {
        _serviceService = serviceService;
    }

    #region Query

    [HttpGet]
    public async Task<IResponse> GetAll() =>
                Success<IList<ServiceResponseDTO>>(data: await _serviceService.GetAllAsync<ServiceResponseDTO>());

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        Service service = await _serviceService.Find(id);
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
        Service existingService = await _serviceService.Find(id);
        if (existingService is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        Service service = _mapper.Map(request, existingService);
        return Success<ServiceResponseDTO>(data: _mapper.Map<ServiceResponseDTO>(await _serviceService.Update(service)));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        string result = await _serviceService.Delete(id);
        return Success(message: result);
    }
    #endregion
}
