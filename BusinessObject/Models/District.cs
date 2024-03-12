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

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Host> Hosts { get; set; }
    }
}
