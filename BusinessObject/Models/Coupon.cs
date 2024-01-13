using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            CouponBanks = new HashSet<CouponBank>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string CouponName { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<CouponBank> CouponBanks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
