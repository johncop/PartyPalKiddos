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

        public Order(DateTime orderDate, decimal totalAmount, int? userId, int? paymentId, int? couponId, int? packageId)
        {
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            UserId = userId;
            PaymentId = paymentId;
            CouponId = couponId;
            PackageId = packageId;
        }

        public Order(int id, DateTime orderDate, decimal totalAmount, int? userId, int? paymentId, int? couponId, int? packageId)
        {
            Id = id;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            UserId = userId;
            PaymentId = paymentId;
            CouponId = couponId;
            PackageId = packageId;
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
