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

        public District(int id, string? description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public District(string? description)
        {
            Description = description;
        }

        public virtual ICollection<Venue> Venues { get; set; }
    }
}
