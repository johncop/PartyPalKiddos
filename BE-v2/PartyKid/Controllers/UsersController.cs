using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/[controller]")]
public class UsersController : BaseApi
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;

    public UsersController(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper) : base(mapper)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    #region Query
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = nameof(RoleCollection.Admin))]
    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        return Success();
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
        return Success<UserDTO>(data: _mapper.Map<UserDTO>(user));
    }

    [HttpGet]
    [Route("current")]
    public async Task<IResponse> GetCurrentUser()
    {
        ApplicationUser currUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
        return Success<UserDTO>(data: _mapper.Map<UserDTO>(currUser));
    }
    #endregion

    #region Command

    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateUserBindingModel request)
    {
        ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            throw new Exception(Constants.AuthHandling.Messages.NotFoundUser);
        }

        IdentityResult ressult = await _userManager.UpdateAsync(_mapper.Map<ApplicationUser>(request));
        if (!ressult.Succeeded)
        {
            throw new Exception(Constants.UserHandling.Messages.UpdateUserFailure);
        }
        return Success(message: Constants.UserHandling.Messages.UpdateUserSucceed);
    }
    #endregion
}