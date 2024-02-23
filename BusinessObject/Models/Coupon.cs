using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            Orders = new HashSet<Order>();
        }

        public Coupon(string? couponName, decimal? discountAmount, string? description, int? typeId, int? quantity, DateTime? createdDate, DateTime? expiredDate, string? status)
        {
            CouponName = couponName;
            DiscountAmount = discountAmount;
            Description = description;
            TypeId = typeId;
            Quantity = quantity;
            CreatedDate = createdDate;
            ExpiredDate = expiredDate;
            Status = status;
        }

        public Coupon(int id, string? couponName, decimal? discountAmount, string? description, int? typeId, int? quantity, DateTime? createdDate, DateTime? expiredDate, string? status)
        {
            Id = id;
            CouponName = couponName;
            DiscountAmount = discountAmount;
            Description = description;
            TypeId = typeId;
            Quantity = quantity;
            CreatedDate = createdDate;
            ExpiredDate = expiredDate;
            Status = status;
        }

        public int Id { get; set; }
        public string? CouponName { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string? Description { get; set; }
        public int? TypeId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string? Status { get; set; }

        public virtual CouponType? Type { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
