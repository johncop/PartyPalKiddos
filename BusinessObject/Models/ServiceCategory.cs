﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServiceCategory
    {
        public ServiceCategory()
        {
            Services = new HashSet<Service>();
        }

        public ServiceCategory(string? categoryName, string? description, int? typeId)
        {
            CategoryName = categoryName;
            Description = description;
            TypeId = typeId;
        }

        public ServiceCategory(int id, string? categoryName, string? description, int? typeId)
        {
            Id = id;
            CategoryName = categoryName;
            Description = description;
            TypeId = typeId;
        }

        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public int? TypeId { get; set; }

        public virtual ServiceType? Type { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
