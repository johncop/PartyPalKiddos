namespace PartyKid;

public class CouponType : BaseEntity
{
    public ICollection<Coupon> Coupons { get; set; }
}
