using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class addBooking
    {
        public DateTime BookingDate { get; set; }
        public int UserId { get; set; }
        public int? PaymentId { get; set; }
        public int? CouponId { get; set; }
        public int? NumberOfKids { get; set; }
        public int? NumberOfAdults { get; set; }
        public string? BookingStatus { get; set; }
        public virtual ICollection<BookingFoodDetail> BookingFoodDetails { get; set; }
        public virtual ICollection<BookingServiceDetail> BookingServiceDetails { get; set; }
    }
}
