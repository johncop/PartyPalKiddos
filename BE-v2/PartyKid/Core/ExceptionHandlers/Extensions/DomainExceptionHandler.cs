using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

public sealed class DomainExceptionHandler : IExceptionHandler<DomainException, ProblemDetails>
{
    public ProblemDetails Handle(DomainException exception)
    {
        var errorCode = (int)HttpStatusCode.BadRequest;
        return new ProblemDetails
        {
            Status = errorCode,
            Title = Constants.RequestHandling.Messages.UnhandledExceptionTitle,
            Detail = exception.Message
        };
    }
}