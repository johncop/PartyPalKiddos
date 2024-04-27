namespace PartyKid;

public class TimeSlotsResponseDTO
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Weekday { get; set; }
    public string Status { get; set; }
}
