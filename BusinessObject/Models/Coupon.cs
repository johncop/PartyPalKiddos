using System;
using System.Collections.Generic;
using System.Net;

namespace BusinessObject.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            Orders = new HashSet<Order>();
        }

        public Coupon(int id, string couponName, decimal discountAmount, string? description)
        {
            Id = id;
            CouponName = couponName;
            DiscountAmount = discountAmount;
            Description = description;
        }

        public Coupon(string couponName, decimal discountAmount, string? description)
        {
            CouponName = couponName;
            DiscountAmount = discountAmount;
            Description = description;
        }

        public int Id { get; set; }
        public string CouponName { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
