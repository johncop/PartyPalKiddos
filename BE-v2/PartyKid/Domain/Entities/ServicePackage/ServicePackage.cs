namespace PartyKid;

public class ServicePackage : BaseEntity
{
    public decimal Price { get; set; }
    public ServicePackageStatusCollection Status { get; set; }

    #region One To Many Relationships
    public ICollection<ServicePackageImage> Images { get; set; }
    #endregion

    #region Many To Many Relationships
    public ICollection<VenueServicePackage> VenueServicePackages { get; set; }
    #endregion
}
