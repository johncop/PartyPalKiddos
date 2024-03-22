using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace PartyKid;

[Route("api/[controller]")]
public class AuthController : BaseApi
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly AppSettings _appSettings;

    public AuthController(UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager,
                          IMapper mapper,
                          IOptions<AppSettings> appSettings)
        : base(mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _appSettings = appSettings.Value;
    }

    [HttpPost]
    [Route("register")]
    public async Task<string> Register([FromBody] RegisterRequestDTO request)
    {
        ApplicationUser user = _mapper.Map<ApplicationUser>(request);
        IdentityResult registerResult = await _userManager.CreateAsync(user, request.Password);
        if (!registerResult.Succeeded)
        {
            throw new Exception("Register Error");
        }
        await _userManager.AddToRoleAsync(user, nameof(RoleCollection.User));
        return Constants.Transactions.Messages.AddComplete;
    }

    [HttpPost]
    [Route("login")]
    public async Task<LoginResponseDTO> Login([FromBody] LoginRequestDTO request)
    {
        ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new Exception(Constants.AuthHandling.Messages.NotFoundUser);
        }

        Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
        if (!signInResult.Succeeded)
        {
            var errMsg = Constants.AuthHandling.Messages.IsValid;
            if (signInResult.IsNotAllowed)
            {
                errMsg = Constants.AuthHandling.Messages.IsNotAllowed;
            }
            throw new Exception(errMsg);
        }

        IList<string> userRoles = await _userManager.GetRolesAsync(user);
        string token = TokenHelper.GenerateToken(user, userRoles, _appSettings.Secret);
        return new LoginResponseDTO(_mapper.Map<UserDTO>(user), userRoles, token);
    }
}
