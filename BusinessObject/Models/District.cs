using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class District
    {
        public District()
        {
            Hosts = new HashSet<Host>();
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

        public virtual ICollection<Host> Hosts { get; set; }
    }
}
