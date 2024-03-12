using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int UserId { get; set; }
        public decimal BookingDetailId { get; set; }
        public int? PaymentId { get; set; }
        public int? CouponId { get; set; }
        public int? NumberOfKids { get; set; }
        public int? NumberOfAdults { get; set; }
        public string? BookingStatus { get; set; }

        public virtual Coupon? Coupon { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
