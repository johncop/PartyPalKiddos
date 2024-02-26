using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class PackageDetail
    {
        public PackageDetail() { }
        public PackageDetail(int? packageId, int? serviceId, int? quantity)
        {
            PackageId = packageId;
            ServiceId = serviceId;
            Quantity = quantity;
        }

        public int? PackageId { get; set; }
        public int? ServiceId { get; set; }
        public int? Quantity { get; set; }

        public virtual Package? Package { get; set; }
        public virtual Service? Service { get; set; }
    }
}
