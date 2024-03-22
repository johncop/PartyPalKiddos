namespace PartyKid;

public class AddCouponBindingModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal ConditionAmount { get; set; }
    public int Quantity { get; set; }
    public DateTime AvailableDate { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public CouponStatusCollection Status { get; set; }
    public int CouponTypeId { get; set; }
}
