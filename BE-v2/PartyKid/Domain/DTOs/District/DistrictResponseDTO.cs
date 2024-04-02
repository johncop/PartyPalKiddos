namespace PartyKid;

public class DistrictResponseDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public IList<VenueResponseDTO> Venues { get; set; }
}
