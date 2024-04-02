using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace PartyKid;

public class UserServices : IUserServices
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailServices _emailServiecs;
    private readonly IMapper _mapper;
    private readonly IQueryRepository<ApplicationUser> _queryUserRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserServices(UserManager<ApplicationUser> userManager,
                        IEmailServices emailServices,
                        IMapper mapper,
                        IQueryRepository<ApplicationUser> queryUserRepository,
                        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _emailServiecs = emailServices;
        _mapper = mapper;
        _queryUserRepository = queryUserRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    #region Queries
    public async Task<IList<UserDTO>> GetAll()
    {
        return await _queryUserRepository.GetAllAsync<UserDTO>();
    }

    public async Task<ApplicationUser> GetById(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    public async Task<UserDTO> GetCurrentUser()
    {
        ApplicationUser currUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.Items["User"].ToString());
        return _mapper.Map<UserDTO>(currUser);
    }

    #endregion

    #region Commands

    public async Task<UserDTO> Update(string userId, UpdateUserBindingModel model)
    {
        ApplicationUser user = await _userManager.FindByIdAsync(userId);
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

    #endregion
}
