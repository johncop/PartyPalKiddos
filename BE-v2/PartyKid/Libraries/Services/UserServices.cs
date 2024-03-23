using Microsoft.AspNetCore.Identity;

namespace PartyKid;

public class UserServices : IUserServices
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserServices(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser> GetById(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }
}
