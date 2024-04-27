namespace PartyKid;

public class BookingResponseDTO
{

    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public int? NumberOfKids { get; set; }
    public int? NumberOfAdults { get; set; }
    public string? BookingStatus { get; set; }
    public int UserId { get; set; }
    public VenuesResponseDTO Venue { get; set; }
    public BookingDetailResponseDTO BookingDetail { get; set; } = new BookingDetailResponseDTO();
    // public IList<FoodBookingResponseDTO> Foods { get; set; }
    // public IList<ComboBookingResponseDTO> Combos { get; set; }
    // public IList<BookingDetailResponseDTO> BookingDetails { get; set; }

}
