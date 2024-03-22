using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[ApiController]
public class BaseApi : ControllerBase
{
    protected Response<T> Success<T>(string message = Constants.RequestHandling.Messages.Success, HttpStatusCode statusCode = HttpStatusCode.OK, T data = default)
    {
        return new Response<T>(message, statusCode, data: data);
    }

    protected Response Success(string message = Constants.RequestHandling.Messages.Success, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new Response(message, statusCode);
    }
}
