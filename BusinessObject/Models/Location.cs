using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Location
    {
        public Location()
        {
            LocationImages = new HashSet<LocationImage>();
            Packages = new HashSet<Package>();
        }

        public int Id { get; set; }
        public string? Address { get; set; }
        public int? DistrictId { get; set; }
        public int? TypeId { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }

        public virtual District? District { get; set; }
        public virtual LocationType? Type { get; set; }
        public virtual ICollection<LocationImage> LocationImages { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
