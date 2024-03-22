namespace PartyKid;

public class LoginResponseDTO
{
    public LoginResponseDTO(UserDTO user, IList<string> roles, string token)
    {
        User = user;
        Token = token;
        Roles = roles;
    }
    public UserDTO User { get; set; }
    public string Token { get; set; }
    public IList<string> Roles { get; set; }
}
