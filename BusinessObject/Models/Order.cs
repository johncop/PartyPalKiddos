using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int? UserId { get; set; }
        public int? PaymentId { get; set; }
        public int? CouponId { get; set; }
        public int? PackageId { get; set; }

        public virtual Coupon? Coupon { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
