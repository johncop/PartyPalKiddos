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

        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
