namespace PartyKid;

public class VenueResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public int Capacity { get; set; }
    public decimal Price { get; set; }
    public TimeSpan OpenHour { get; set; }
    public TimeSpan CloseHour { get; set; }
    public DistrictDTO District { get; set; }
    public IList<VenueImageDTO> VenueImages { get; set; }
    public IList<ComboDTO>? Combos { get; set; }
    public IList<FoodResponseDTO>? Foods { get; set; }
    public IList<ServiceResponseDTO> Services { get; set; }
    public IList<ServicePackageDTO> ServicePackages { get; set; }
    public IList<TimeSlotsResponseDTO> TimeSlots { get; set; }
}
