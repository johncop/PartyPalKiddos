namespace PartyKid;

public class VenueImage : BaseEntity<int>
{
    public string ImageUrl { get; set; }

    public int VenueId { get; set; }
    public Venue Venue { get; set; }
}
