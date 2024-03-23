namespace PartyKid;

public class BookingDetail
{
    public int BookingId { get; set; }
    public Booking Booking { get; set; }

    public int FoodId { get; set; }
    public Food Food { get; set; }
    public int FoodQuantity { get; set; }

    public int ComboId { get; set; }
    public Combo Combo { get; set; }
    public int? ComboQuantity { get; set; }

    public int ServiceId { get; set; }
    public Service Service { get; set; }
    public int? ServiceQuantity { get; set; }

    public int ServicePackageId { get; set; }
    public ServicePackage ServicePackage { get; set; }
    public int? ServicePackageQuantity { get; set; }

}
