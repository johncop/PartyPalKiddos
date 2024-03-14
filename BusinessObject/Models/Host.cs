using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Host
    {
        public Host()
        {
            AvailableTimeSlots = new HashSet<AvailableTimeSlot>();
            Combos = new HashSet<Combo>();
            HostImages = new HashSet<HostImage>();
            ServicePackages = new HashSet<ServicePackage>();
        }

        public Host(string? address, int? capacity, int? districtId, string? description, decimal? price, string? status)
        {
            Address = address;
            Capacity = capacity;
            DistrictId = districtId;
            Description = description;
            Price = price;
            Status = status;
        }

        public Host(int id, string? address, int? capacity, int? districtId, string? description, decimal? price, string? status)
        {
            Id = id;
            Address = address;
            Capacity = capacity;
            DistrictId = districtId;
            Description = description;
            Price = price;
            Status = status;
        }

        public int Id { get; set; }
        public string? Address { get; set; }
        public int? Capacity { get; set; }
        public int? DistrictId { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }

        public virtual District? District { get; set; }
        public virtual ICollection<AvailableTimeSlot> AvailableTimeSlots { get; set; }
        public virtual ICollection<Combo> Combos { get; set; }
        public virtual ICollection<HostImage> HostImages { get; set; }
        public virtual ICollection<ServicePackage> ServicePackages { get; set; }
    }
}
