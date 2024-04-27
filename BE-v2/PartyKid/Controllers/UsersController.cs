using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;

[Route("api/[controller]")]
public class UsersController : BaseApi
{
    private readonly IUserServices _userServices;
    private readonly UserManager<ApplicationUser> _userManager;

    public UsersController(IUserServices userServices, IMapper mapper, UserManager<ApplicationUser> userManager) : base(mapper)
    {
        _userServices = userServices;
        _userManager = userManager;
    }

    #region Query
    [Authorize(nameof(RoleCollection.Admin))]
    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        var users = await _userServices.GetAll();
        return Success(data: await users.ProjectTo<UserDTO>(_mapper.ConfigurationProvider).ToListAsync());
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        ApplicationUser user = await _userServices.GetById(id.ToString());
        IList<string> userRoles = await _userManager.GetRolesAsync(user);
        return Success<UserResponseDTO>(data: new UserResponseDTO(_mapper.Map<UserDTO>(user), userRoles));
    }

    [Authorize]
    [HttpGet]
    [Route("current")]
    public async Task<IResponse> GetCurrentUser()
    {
        ApplicationUser currUser = await _userServices.GetCurrentUser();
        IList<string> userRoles = await _userManager.GetRolesAsync(currUser);
        return Success<UserResponseDTO>(data: new UserResponseDTO(_mapper.Map<UserDTO>(currUser), userRoles));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpGet]
    [Route("roles")]
    public async Task<IResponse> GetRoles()
    {
        return Success<IList<RolesResponseDTO>>(data: await _userServices.GetRoles());
    }
    #endregion

    #region Command

    [HttpPost]
    [Route("change-password")]
    public async Task<IResponse> ChangePassword([FromBody] ChangePasswordBindingModel request)
    {
        return Success(message: await _userServices.ChangePassword(request));
    }

    [HttpPost]
    [Route("forgot-password")]
    public async Task<IResponse> ForgotPassword([FromBody] ForgotPasswordBindingModel request)
    {
        if (string.IsNullOrEmpty(request.Email))
        {
            throw new DomainException(Constants.UserHandling.Messages.EmailEmpty);
        }
        return Success(message: await _userServices.ForgotPassword(request.Email));
    }

    [Authorize]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateUserBindingModel request)
    {
        UserDTO user = await _userServices.Update(id.ToString(), request);
        return Success<UserDTO>(data: user);
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("add-role")]
    public async Task<IResponse> AddRole([FromBody] AddRoleToUserBindingModel request)
    {
        UserDTO user = await _userServices.AddRoleAsync(request.UserId, request.RoleName);
        return Success<UserDTO>(data: user);
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("delete/{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int userId)
    {
        return Success(message: await _userServices.Delete(userId.ToString()));
    }
    #endregion
}