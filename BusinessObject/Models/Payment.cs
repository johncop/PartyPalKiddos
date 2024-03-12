using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? PaymentUrl { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? Status { get; set; }
        public int? OrderId { get; set; }

        public virtual Booking? Order { get; set; }
    }
}
