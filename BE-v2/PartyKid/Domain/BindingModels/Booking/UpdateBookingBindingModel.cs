namespace PartyKid;

public class UpdateBookingBindingModel
{
    public int Id { get; set; }
    public DateTime? BookingDate { get; set; }
    public int? NumberOfKids { get; set; }
    public int? NumberOfAdults { get; set; }
    public string? BookingStatus { get; set; }

    public ICollection<int>? BookingTimeSlots { get; set; }
    public ICollection<AddItemBookingBindingModel>? Combos { get; set; }
    public ICollection<AddItemBookingBindingModel>? Foods { get; set; }
    public ICollection<AddItemBookingBindingModel>? Services { get; set; }
    public ICollection<AddItemBookingBindingModel>? ServicePackages { get; set; }
}
