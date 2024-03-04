using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Service
    {
        public Service()
        {
            ServiceImages = new HashSet<ServiceImage>();
        }

        public Service(string? serviceName, string? description, int? serviceCategoryId, decimal? price, decimal? discount)
        {
            ServiceName = serviceName;
            Description = description;
            ServiceCategoryId = serviceCategoryId;
            Price = price;
            Discount = discount;
        }

        public Service(int id, string? serviceName, string? description, int? serviceCategoryId, decimal? price, decimal? discount)
        {
            Id = id;
            ServiceName = serviceName;
            Description = description;
            ServiceCategoryId = serviceCategoryId;
            Price = price;
            Discount = discount;
        }

        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public int? ServiceCategoryId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }

        public virtual ServiceCategory? ServiceCategory { get; set; }
        public virtual ICollection<ServiceImage> ServiceImages { get; set; }
    }
}
