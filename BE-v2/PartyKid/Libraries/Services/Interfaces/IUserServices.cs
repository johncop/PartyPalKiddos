namespace PartyKid;

public interface IUserServices
{
    Task<IList<UserDTO>> GetAll();
    Task<ApplicationUser> GetById(string id);
    Task<UserDTO> GetCurrentUser();
    Task<string> ForgotPassword(string email);
    Task<string> ChangePassword(ChangePasswordBindingModel model);
    Task<UserDTO> Update(string userId, UpdateUserBindingModel model);

}
