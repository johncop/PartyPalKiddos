using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

public class ExceptionHandleMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var exceptionHandler = httpContext.RequestServices.GetExceptionHandler(exception);
        ProblemDetails problemDetails = null;
        if (exceptionHandler != null)
        {
            var method = exceptionHandler.GetType().GetMethod(nameof(IExceptionHandler<Exception, ProblemDetails>.Handle));
            if (method != null)
            {
                problemDetails = (ProblemDetails)method.Invoke(exceptionHandler, new object[] { exception });
            }
        }

        if (problemDetails == null)
        {
            problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = Constants.RequestHandling.Messages.UnhandledExceptionTitle,
                Detail = exception.Message
            };
        }

        problemDetails.Instance = httpContext.Request.Path;
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = problemDetails.Status.GetValueOrDefault((int)HttpStatusCode.BadRequest);
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize<object>(problemDetails));
    }
}
