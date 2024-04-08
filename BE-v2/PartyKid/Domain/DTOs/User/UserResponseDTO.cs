namespace PartyKid;

public class UserResponseDTO
{
    public UserResponseDTO(UserDTO user, IList<string> roles)
    {
        User = user;
        Roles = roles;
    }

    public UserDTO User { get; set; }
    public IList<string> Roles { get; set; }
}
