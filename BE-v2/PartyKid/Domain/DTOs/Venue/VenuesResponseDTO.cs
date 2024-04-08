namespace PartyKid;

public class VenuesResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DistrictDTO District { get; set; }
    public VenueImageDTO Image { get; set; }
}
