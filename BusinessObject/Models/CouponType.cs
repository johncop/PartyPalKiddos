using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class CouponType
    {
        public CouponType()
        {
            Coupons = new HashSet<Coupon>();
        }

        public int Id { get; set; }
        public string? TypeName { get; set; }

        public virtual ICollection<Coupon> Coupons { get; set; }
    }
}
