using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class LocationType
    {
        public LocationType()
        {
            Locations = new HashSet<Location>();
        }

        public LocationType(string? description)
        {
            Description = description;
        }

        public LocationType(int id, string? description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
