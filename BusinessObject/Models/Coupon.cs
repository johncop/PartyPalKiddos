using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            Bookings = new HashSet<Booking>();
        }

        public Coupon(string? couponName, decimal? discountAmount, decimal? conditionAmount, string? description, int? typeId, int? quantity, DateTime? createdDate, DateTime? availableDate, DateTime? expiredDate, string? status)
        {
            CouponName = couponName;
            DiscountAmount = discountAmount;
            ConditionAmount = conditionAmount;
            Description = description;
            TypeId = typeId;
            Quantity = quantity;
            CreatedDate = createdDate;
            AvailableDate = availableDate;
            ExpiredDate = expiredDate;
            Status = status;
        }

        public Coupon(int id, string? couponName, decimal? discountAmount, decimal? conditionAmount, string? description, int? typeId, int? quantity, DateTime? createdDate, DateTime? availableDate, DateTime? expiredDate, string? status)
        {
            Id = id;
            CouponName = couponName;
            DiscountAmount = discountAmount;
            ConditionAmount = conditionAmount;
            Description = description;
            TypeId = typeId;
            Quantity = quantity;
            CreatedDate = createdDate;
            AvailableDate = availableDate;
            ExpiredDate = expiredDate;
            Status = status;
        }

        public int Id { get; set; }
        public string? CouponName { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? ConditionAmount { get; set; }
        public string? Description { get; set; }
        public int? TypeId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? AvailableDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string? Status { get; set; }

        public virtual CouponType? Type { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
