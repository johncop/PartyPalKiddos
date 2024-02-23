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

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
