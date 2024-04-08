namespace PartyKid;

public class TimeSlot : BaseEntity<int>
{
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string? Weekday { get; set; }
    public string? Status { get; set; }

    public int VenueId { get; set; }
    public Venue Venue { get; set; }

    public ICollection<BookingTimeSlot> BookingTimeSlots { get; set; }
}
