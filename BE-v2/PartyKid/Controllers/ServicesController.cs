using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/[controller]")]
public class ServicesController : BaseApi
{
    private readonly IBaseServices<Service> _serviceService;
    private readonly IMapper _mapper;
    public ServicesController(IBaseServices<Service> serviceService, IMapper mapper)
    {
        _serviceService = serviceService;
        _mapper = mapper;
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

    [HttpPost]
    public async Task<IResponse> Create([FromBody] CreateServiceBindingModel request)
    {
        string result = await _serviceService.Create(_mapper.Map<Service>(request));
        return Success(message: result);
    }

    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateServiceBindingModel request)
    {
        request.Id = id;
        Service entity = await _serviceService.Update(_mapper.Map<Service>(request));
        return Success<ServiceResponseDTO>(data: _mapper.Map<ServiceResponseDTO>(entity));
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        string result = await _serviceService.Delete(id);
        return Success(message: result);
    }
    #endregion
}
