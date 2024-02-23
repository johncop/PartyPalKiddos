using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Payment
    {
        public Payment(int? userId, string? paymentUrl, decimal amount, DateTime paymentDate, int? status, int? orderId)
        {
            UserId = userId;
            PaymentUrl = paymentUrl;
            Amount = amount;
            PaymentDate = paymentDate;
            Status = status;
            OrderId = orderId;
        }

        public Payment(int id, int? userId, string? paymentUrl, decimal amount, DateTime paymentDate, int? status, int? orderId)
        {
            Id = id;
            UserId = userId;
            PaymentUrl = paymentUrl;
            Amount = amount;
            PaymentDate = paymentDate;
            Status = status;
            OrderId = orderId;
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? PaymentUrl { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? Status { get; set; }
        public int? OrderId { get; set; }

        public virtual Order? Order { get; set; }
    }
}
