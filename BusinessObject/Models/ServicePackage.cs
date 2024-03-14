using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServicePackage
    {
        public ServicePackage()
        {
            ServicePackageImages = new HashSet<ServicePackageImage>();
        }

        public ServicePackage(string? packageName, int? hostId, decimal? price, int? status)
        {
            PackageName = packageName;
            HostId = hostId;
            Price = price;
            Status = status;
        }

        public ServicePackage(int id, string? packageName, int? hostId, decimal? price, int? status)
        {
            Id = id;
            PackageName = packageName;
            HostId = hostId;
            Price = price;
            Status = status;
        }

        public int Id { get; set; }
        public string? PackageName { get; set; }
        public int? HostId { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }

        public virtual Host? Host { get; set; }
        public virtual ICollection<ServicePackageImage> ServicePackageImages { get; set; }
    }
}
