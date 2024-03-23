namespace PartyKid;

public class AvailableTimeSlot : BaseEntity<int>
{
    public AvailableTimeSlotStatusCollection Status { get; set; }

    public int VenueId { get; set; }
    public Venue Venue { get; set; }

    public int TimeSlotId { get; set; }
    public TimeSlot TimeSlot { get; set; }
}
