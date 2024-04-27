namespace PartyKid;

public interface IUserServices
{
    Task<IQueryable<ApplicationUser>> GetAll();
    Task<ApplicationUser> GetById(string id);
    Task<ApplicationUser> GetCurrentUser();
    Task<IList<RolesResponseDTO>> GetRoles();
    Task<string> ForgotPassword(string email);
    Task<string> ChangePassword(ChangePasswordBindingModel model);
    Task<UserDTO> Update(string userId, UpdateUserBindingModel model);
    Task<UserDTO> AddRoleAsync(string userId, string role);
    Task<string> Delete(string userId);
}
