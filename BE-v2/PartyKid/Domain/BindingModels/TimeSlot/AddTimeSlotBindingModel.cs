namespace PartyKid;

public class AddTimeSlotBindingModel
{
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Weekday { get; set; }
    public string Status { get; set; }
    public int VenueId { get; set; }
}
