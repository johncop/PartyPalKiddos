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

        public CouponType(string? typeName)
        {
            TypeName = typeName;
        }

        public CouponType(int id, string? typeName)
        {
            Id = id;
            TypeName = typeName;
        }

        public int Id { get; set; }
        public string? TypeName { get; set; }

        public virtual ICollection<Coupon> Coupons { get; set; }
    }
}
