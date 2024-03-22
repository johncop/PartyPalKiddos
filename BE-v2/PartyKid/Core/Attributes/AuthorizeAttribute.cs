using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PartyKid;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    public CustomAuthorizeAttribute(params RoleCollection[] roles)
    {
        this.AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
    }
}
