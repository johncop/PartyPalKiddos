using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServiceOption
    {
        public ServiceOption()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public string? OptionName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
