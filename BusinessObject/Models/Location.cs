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

        public Location(string? address, int? districtId, string? description, decimal? price)
        {
            Address = address;
            DistrictId = districtId;
            Description = description;
            Price = price;
        }

        public Location(int id, string? address, int? districtId, string? description, decimal? price)
        {
            Id = id;
            Address = address;
            DistrictId = districtId;
            Description = description;
            Price = price;
        }

        public int Id { get; set; }
        public string? Address { get; set; }
        public int? DistrictId { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }

        public virtual District? District { get; set; }
        public virtual ICollection<LocationImage> LocationImages { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
