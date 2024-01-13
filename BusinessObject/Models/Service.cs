using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderServices = new HashSet<OrderService>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? Description { get; set; }
        public int? ServiceCategoryId { get; set; }
        public int? ServiceOptionId { get; set; }
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }

        public virtual ServiceCategory? ServiceCategory { get; set; }
        public virtual ServiceOption? ServiceOption { get; set; }
        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
