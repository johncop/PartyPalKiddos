using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PartyKid;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly IList<string> _roles;

    public AuthorizeAttribute(params string[] roles)
    {
        _roles = roles ?? new string[] { };
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // skip authorization if action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        // authorization
        var user = context.HttpContext.Items["User"];
        if (user == null)
        {
            // not logged in or role not authorized
            context.Result = new JsonResult(new
            {
                Status = HttpStatusCode.Unauthorized,
                Title = "Unauthorized",
                Detail = Constants.AuthHandling.Messages.UnAuthorized
            })
            { StatusCode = StatusCodes.Status401Unauthorized };
        }

        var userRole = context.HttpContext.Items["Role"];
        if (_roles.Count > 0 && !_roles.Contains(userRole.ToString()))
        {
            context.Result = new JsonResult(new
            {
                Status = HttpStatusCode.Forbidden,
                Title = "Forbidden",
                Detail = Constants.AuthHandling.Messages.Forbidden
            })
            { StatusCode = StatusCodes.Status403Forbidden };
        }
    }
}
