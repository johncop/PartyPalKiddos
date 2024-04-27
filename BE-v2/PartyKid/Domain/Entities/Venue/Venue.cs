namespace PartyKid;

public class Venue : BaseEntity
{
    public string Address { get; set; }
    public int Capacity { get; set; }
    public decimal Price { get; set; }
    public TimeSpan OpenHour { get; set; }
    public TimeSpan CloseHour { get; set; }

    #region One To Many Relationships
    public int DistrictId { get; set; }
    public District District { get; set; }
    #endregion

    #region Many To One Relationships
    public ICollection<VenueImage> VenueImages { get; set; }

    #endregion

    #region Many to Many Relationships
    public virtual ICollection<VenueService> VenueServices { get; set; }
    public virtual ICollection<VenueServicePackage> VenueServicePackages { get; set; }
    public virtual ICollection<VenueFood> VenueFoods { get; set; }
    public virtual ICollection<TimeSlot> TimeSlots { get; set; }
    public virtual ICollection<VenueCombo> VenueCombos { get; set; }
    #endregion
}
