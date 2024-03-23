namespace PartyKid;

public class ServicePackageDetail
{
    public int ServiceId { get; set; }
    public Service Service { get; set; }

    public int ServicePackageId { get; set; }
    public ServicePackage ServicePackage { get; set; }
}
