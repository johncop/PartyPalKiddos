using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class HostServicePackageDetail
    {
        public HostServicePackageDetail(int? hostId, int? servicePackageId)
        {
            HostId = hostId;
            ServicePackageId = servicePackageId;
        }

        public int? HostId { get; set; }
        public int? ServicePackageId { get; set; }

        public virtual Host? Host { get; set; }
        public virtual ServicePackage? ServicePackage { get; set; }
    }
}
