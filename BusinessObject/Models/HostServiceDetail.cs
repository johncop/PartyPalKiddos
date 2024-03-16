using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class HostServiceDetail
    {
        public HostServiceDetail(int? hostId, int? serviceId)
        {
            HostId = hostId;
            ServiceId = serviceId;
        }

        public int? HostId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Host? Host { get; set; }
        public virtual Service? Service { get; set; }
    }
}
