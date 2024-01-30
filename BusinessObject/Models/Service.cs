using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Service
    {
        public Service()
        {
            ServiceImages = new HashSet<ServiceImage>();
            ServiceOptions = new HashSet<ServiceOption>();
        }

        public Service(string serviceName, string? description, int? serviceCategoryId, decimal price)
        {
            ServiceName = serviceName;
            Description = description;
            ServiceCategoryId = serviceCategoryId;
            Price = price;
        }

        public Service(int id, string serviceName, string? description, int? serviceCategoryId, decimal price)
        {
            Id = id;
            ServiceName = serviceName;
            Description = description;
            ServiceCategoryId = serviceCategoryId;
            Price = price;
        }

        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? Description { get; set; }
        public int? ServiceCategoryId { get; set; }
        public decimal Price { get; set; }

        public virtual ServiceCategory? ServiceCategory { get; set; }
        public virtual ICollection<ServiceImage> ServiceImages { get; set; }
        public virtual ICollection<ServiceOption> ServiceOptions { get; set; }
    }
}
