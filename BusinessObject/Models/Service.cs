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

        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public int? ServiceCategoryId { get; set; }
        public int? TypeId { get; set; }
        public decimal? Price { get; set; }

        public virtual ServiceCategory? ServiceCategory { get; set; }
        public virtual ServiceType? Type { get; set; }
        public virtual ICollection<ServiceImage> ServiceImages { get; set; }
    }
}
