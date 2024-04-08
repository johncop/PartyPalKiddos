namespace PartyKid;

public class Combo : BaseEntity
{
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public ComboStatusCollection Status { get; set; }

    public ICollection<ComboFood> ComboFoods { get; set; }
    public ICollection<VenueCombo> VenueCombos { get; set; }
    public ICollection<BookingDetail> BookingDetails { get; set; }
}
