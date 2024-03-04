using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderDetail
    {
        public OrderDetail() { }
        public OrderDetail(int? packageId)
        {
            PackageId = packageId;
        }

        public OrderDetail(int? orderId, int? packageId)
        {
            OrderId = orderId;
            PackageId = packageId;
        }

        public int? OrderId { get; set; }
        public int? PackageId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Package? Package { get; set; }
    }
}
