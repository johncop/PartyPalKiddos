namespace PartyKid;

public class ServiceCategory : BaseEntity
{
    public virtual ICollection<Service> Services { get; set; }
}
