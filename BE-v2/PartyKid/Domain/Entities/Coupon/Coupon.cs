namespace PartyKid;

public class Coupon : BaseEntity
{
    public decimal DiscountAmount { get; set; }
    public decimal ConditionAmount { get; set; }
    public int Quantity { get; set; }
    public DateTime AvailableDate { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public CouponStatusCollection Status { get; set; }

    public int CouponTypeId { get; set; }
    public CouponType CouponType { get; set; }
}
