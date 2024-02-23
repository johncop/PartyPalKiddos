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
