namespace PartyKid;

public class BookingDetailResponseDTO
{
    public IList<ComboBookingResponseDTO>? Combos { get; set; }
    public IList<FoodBookingResponseDTO>? Foods { get; set; }
    public IList<ServiceBookingResponseDTO>? Services { get; set; }
    public IList<ServiceBookingResponseDTO>? ServicePackages { get; set; }
}
