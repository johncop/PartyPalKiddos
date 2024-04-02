using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[ApiController]
public class BaseApi : ControllerBase
{
    protected readonly IMapper _mapper;
    public BaseApi(IMapper mapper)
    {
        _mapper = mapper;
    }
    protected Response<T> Success<T>(string message = Constants.RequestHandling.Messages.Success, HttpStatusCode statusCode = HttpStatusCode.OK, T data = default)
    {
        return new Response<T>(message, statusCode, data: data);
    }

    protected Response Success(string message = Constants.RequestHandling.Messages.Success, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new Response(message, statusCode);
    }
}
