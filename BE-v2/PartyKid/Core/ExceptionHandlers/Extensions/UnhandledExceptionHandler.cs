using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

public sealed class UnhandledExceptionHandler : IExceptionHandler<Exception, ProblemDetails>
{
    public ProblemDetails Handle(Exception exception)
    {
        var errorCode = (int)HttpStatusCode.InternalServerError;

        if (exception is BadHttpRequestException)
        {
            errorCode = (int)typeof(BadHttpRequestException).GetProperty(nameof(BadHttpRequestException.StatusCode),
                                                                         BindingFlags.Public | BindingFlags.Instance)
                                                            .GetValue(exception);
        }

        return new ProblemDetails
        {
            Status = errorCode,
            Title = Constants.RequestHandling.Messages.UnhandledExceptionTitle,
            Detail = exception.Message
        };
    }
}
