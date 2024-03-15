using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class HostServiceDetail
    {
        public HostServiceDetail()
        {

        }
        public HostServiceDetail(int? hostId, int? servicePackageId, int? serviceId)
        {
            HostId = hostId;
            ServicePackageId = servicePackageId;
            ServiceId = serviceId;
        }

        public int? HostId { get; set; }
        public int? ServicePackageId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Host? Host { get; set; }
        public virtual Service? Service { get; set; }
        public virtual ServicePackage? ServicePackage { get; set; }
    }
}
