namespace PartyKid;

public class CouponResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal ConditionAmount { get; set; }
    public int Quantity { get; set; }
    public DateTime AvailableDate { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public CouponStatusCollection Status { get; set; }
    public CouponTypesResponseDTO CouponType { get; set; }
}
