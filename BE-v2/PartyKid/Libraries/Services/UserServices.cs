using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;

public class UserServices : IUserServices
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly IEmailServices _emailServiecs;
    private readonly IMapper _mapper;
    private readonly IQueryRepository<ApplicationUser> _queryUserRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserServices(UserManager<ApplicationUser> userManager,
                        IEmailServices emailServices,
                        IMapper mapper,
                        IQueryRepository<ApplicationUser> queryUserRepository,
                        IHttpContextAccessor httpContextAccessor,
                        RoleManager<IdentityRole<int>> roleManager)
    {
        _userManager = userManager;
        _emailServiecs = emailServices;
        _mapper = mapper;
        _queryUserRepository = queryUserRepository;
        _httpContextAccessor = httpContextAccessor;
        _roleManager = roleManager;
    }

    #region Queries
    public async Task<IQueryable<ApplicationUser>> GetAll()
    {
        return _userManager.Users;
    }

    public async Task<ApplicationUser> GetById(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    public async Task<ApplicationUser> GetCurrentUser()
    {
        return await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.Items["User"].ToString());
    }

    public async Task<IList<RolesResponseDTO>> GetRoles()
    {
        return await _roleManager.Roles.ProjectTo<RolesResponseDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }

    #endregion

    #region Commands

    public async Task<UserDTO> Update(string userId, UpdateUserBindingModel model)
    {
        ApplicationUser user = string.IsNullOrEmpty(userId) ? await GetCurrentUser() : await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new DomainException(Constants.AuthHandling.Messages.NotFoundUser);
        }

        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.PhoneNumber = model.PhoneNumber;

        IdentityResult updateResult = await _userManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
        {
            throw new DomainException(Constants.UserHandling.Messages.UpdateUserFailure);
        }
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<string> ForgotPassword(string email)
    {
        ApplicationUser user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            throw new Exception(Constants.AuthHandling.Messages.NotFoundUser);
        }

        var newPassword = StringHelper.RandomPassword();
        string passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var changePassResult = await _userManager.ResetPasswordAsync(user, passwordToken, newPassword);
        if (!changePassResult.Succeeded)
        {
            throw new DomainException(Constants.UserHandling.Messages.ResetPasswordFailed);
        }
        await _emailServiecs.Send(user.Email!, "Reset Your Password", "New password is: " + newPassword);
        return Constants.UserHandling.Messages.ForgotPassword;
    }

    public async Task<string> ChangePassword(ChangePasswordBindingModel model)
    {
        ApplicationUser user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.Items["User"].ToString());
        if (user == null)
        {
            throw new DomainException(Constants.AuthHandling.Messages.NotFoundUser);
        }

        IdentityResult changePassResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        if (!changePassResult.Succeeded)
        {
            throw new DomainException(Constants.UserHandling.Messages.ChangePasswordFailed);
        }

        return Constants.UserHandling.Messages.ChangePassworSuccess;
    }

    public async Task<UserDTO> AddRoleAsync(string userId, string role)
    {
        ApplicationUser user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            throw new DomainException(Constants.AuthHandling.Messages.NotFoundUser);
        }

        IdentityRole<int> isRoleExisted = await _roleManager.FindByNameAsync(role);
        if (isRoleExisted is null)
        {
            throw new DomainException(Constants.UserHandling.Messages.RoleNotExisted);
        }

        IdentityResult addRoleResult = await _userManager.AddToRoleAsync(user, role);
        if (!addRoleResult.Succeeded)
        {
            throw new DomainException(Constants.UserHandling.Messages.AddRoleError);
        }

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<string> Delete(string userId)
    {
        ApplicationUser user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            throw new DomainException(Constants.AuthHandling.Messages.NotFoundUser);
        }

        user.IsDeleted = true;
        IdentityResult updateResult = await _userManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
        {
            throw new DomainException(Constants.UserHandling.Messages.DeleteUserFailure);
        }

        return Constants.UserHandling.Messages.DeleteUserSuccess;
    }

    #endregion

    #region SUPPORT FUNC
    private async Task<IList<string>> GetUserRoles(ApplicationUser user)
    {
        return new List<string>(await _userManager.GetRolesAsync(user));
    }
    #endregion
}
