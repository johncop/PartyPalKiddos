namespace PartyKid;

public class ServicePackageImage : BaseEntity<int>
{
    public string ImageUrl { get; set; }

    public int ServicePackageId { get; set; }
    public ServicePackage ServicePackage { get; set; }
}
