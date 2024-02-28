using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            ServiceCategories = new HashSet<ServiceCategory>();
        }

        public ServiceType(string? typeName, string? description)
        {
            TypeName = typeName;
            Description = description;
        }

        public ServiceType(int id, string? typeName, string? description)
        {
            Id = id;
            TypeName = typeName;
            Description = description;
        }

        public int Id { get; set; }
        public string? TypeName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ServiceCategory> ServiceCategories { get; set; }
    }
}
