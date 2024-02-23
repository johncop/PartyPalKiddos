﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string? TypeName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}