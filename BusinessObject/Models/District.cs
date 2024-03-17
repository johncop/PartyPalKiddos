using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class District
    {
        public District()
        {
            Venues = new HashSet<Venue>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Venue> Venues { get; set; }
    }
}
