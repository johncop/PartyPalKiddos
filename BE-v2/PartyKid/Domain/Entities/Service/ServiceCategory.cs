namespace PartyKid;

public class ServiceCategory : BaseEntity
{
    public ICollection<Service> Services { get; set; }
}
