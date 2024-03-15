using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Host
    {
        public Host()
        {
            AvailableTimeSlots = new HashSet<AvailableTimeSlot>();
            HostImages = new HashSet<HostImage>();
        }

        public Host(string? hostName, string? address, int? capacity, int? districtId, string? description, decimal? price, string? status)
        {
            HostName = hostName;
            Address = address;
            Capacity = capacity;
            DistrictId = districtId;
            Description = description;
            Price = price;
            Status = status;
        }

        public Host(int id, string? hostName, string? address, int? capacity, int? districtId, string? description, decimal? price, string? status)
        {
            Id = id;
            HostName = hostName;
            Address = address;
            Capacity = capacity;
            DistrictId = districtId;
            Description = description;
            Price = price;
            Status = status;
        }

        public int Id { get; set; }
        public string? HostName { get; set; }
        public string? Address { get; set; }
        public int? Capacity { get; set; }
        public int? DistrictId { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }

        public virtual District? District { get; set; }
        public virtual ICollection<AvailableTimeSlot> AvailableTimeSlots { get; set; }
        public virtual ICollection<HostImage> HostImages { get; set; }
    }
}
