namespace PartyKid;

public class TimeSlot : BaseEntity<int>
{
    public TimeSpan? Hours { get; set; }
    public string? Weekday { get; set; }
    public string? Status { get; set; }

    public ICollection<AvailableTimeSlot> AvailableTimeSlots { get; set; }
}
