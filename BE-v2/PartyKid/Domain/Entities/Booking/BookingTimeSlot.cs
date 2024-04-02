namespace PartyKid;

public class BookingTimeSlot
{
    public int BookingId { get; set; }
    public Booking Booking { get; set; }

    public int AvailableTimeSlotId { get; set; }
    public AvailableTimeSlot AvailableTimeSlot { get; set; }
}
