namespace PartyKid;

public class VenueSearchResponseDTO
{
    public IList<SearchItemResponseDTO> Venues { get; set; }
    public IList<SearchItemResponseDTO> Services { get; set; }
}
