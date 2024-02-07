using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderService
    {
        public OrderService(int? packageId, int? serviceId, int? serviceOptionId, int? quantity)
        {
            PackageId = packageId;
            ServiceId = serviceId;
            ServiceOptionId = serviceOptionId;
            Quantity = quantity;
        }

        public OrderService() { }

        public int? PackageId { get; set; }
        public int? ServiceId { get; set; }
        public int? ServiceOptionId { get; set; }
        public int? Quantity { get; set; }

        public virtual Package? Package { get; set; }
        public virtual Service? Service { get; set; }
        public virtual ServiceOption? ServiceOption { get; set; }
    }
}
