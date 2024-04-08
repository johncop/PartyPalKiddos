namespace PartyKid;

public class BookingTimeSlot
{
    public int BookingId { get; set; }
    public Booking Booking { get; set; }

    public int TimeSlotId { get; set; }
    public TimeSlot TimeSlot { get; set; }
}
