using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PartyKid;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    // public void OnAuthorization(AuthorizationFilterContext context)
    // {
    //     var user = context.HttpContext.Items["User"];
    //     if (user == null)
    //     {
    //         // not logged in
    //         context.Result = new JsonResult(new
    //         {
    //             Status = (int)HttpStatusCode.Unauthorized,
    //             Title = Constants.AuthHandling.Messages.UnAuthorized,
    //             message = Constants.AuthHandling.Messages.UnAuthorized
    //         })
    //         { StatusCode = StatusCodes.Status401Unauthorized };
    //     }
    // }

    public CustomAuthorizeAttribute()
    {
        this.AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        // this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
    }
}
