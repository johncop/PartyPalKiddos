namespace PartyKid;

public class VenueFood
{
    public int VenueId { get; set; }
    public Venue Venue { get; set; }

    public int FoodId { get; set; }
    public Food Food { get; set; }
}
