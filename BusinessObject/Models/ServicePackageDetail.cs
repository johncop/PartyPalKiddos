using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServicePackageDetail
    {
        public ServicePackageDetail()
        {
                
        }
        public ServicePackageDetail(int servicePackageId, int? serviceId, int? quantity)
        {
            ServicePackageId = servicePackageId;
            ServiceId = serviceId;
            Quantity = quantity;
        }

        public int ServicePackageId { get; set; }
        public int? ServiceId { get; set; }
        public int? Quantity { get; set; }

        public virtual Service? Service { get; set; }
        public virtual ServicePackage ServicePackage { get; set; } = null!;
    }
}
