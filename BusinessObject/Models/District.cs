using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class District
    {
        public District()
        {
            Locations = new HashSet<Location>();
        }

        public District(string? address, string? description)
        {
            Address = address;
            Description = description;
        }

        public District(int id, string? address, string? description)
        {
            Id = id;
            Address = address;
            Description = description;
        }

        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
