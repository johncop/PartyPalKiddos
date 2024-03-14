using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServiceCategory
    {
        public ServiceCategory()
        {
            Services = new HashSet<Service>();
        }

        public ServiceCategory(string? categoryName, string? description)
        {
            CategoryName = categoryName;
            Description = description;
        }

        public ServiceCategory(int id, string? categoryName, string? description)
        {
            Id = id;
            CategoryName = categoryName;
            Description = description;
        }

        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
