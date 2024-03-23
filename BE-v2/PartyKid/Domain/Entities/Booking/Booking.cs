namespace PartyKid;

public class Booking : BaseEntity<int>
{
    public DateTime BookingDate { get; set; }
    public int? NumberOfKids { get; set; }
    public int? NumberOfAdults { get; set; }
    public string? BookingStatus { get; set; }

    public int UserId { get; set; }
    public ApplicationUser User { get; set; }
    public int? CouponId { get; set; }
    public Coupon Coupon { get; set; }
}
