namespace PartyKid;

public interface IUserServices
{
    Task<ApplicationUser> GetById(string id);
}
