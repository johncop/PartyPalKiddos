using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Location
    {
        public Location()
        {
            LocationImgs = new HashSet<LocationImg>();
            Packages = new HashSet<Package>();
        }

        public int Id { get; set; }
        public string? Address { get; set; }
        public int? DistrictId { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImgUrl { get; set; }

        public virtual District? District { get; set; }
        public virtual ICollection<LocationImg> LocationImgs { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
