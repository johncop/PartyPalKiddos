using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Venue
    {
        public Venue()
        {
            AvailableTimeSlots = new HashSet<AvailableTimeSlot>();
            VenueImages = new HashSet<VenueImage>();
        }

        public Venue(string? venueName, string? address, int? capacity, int? districtId, string? description, TimeSpan? openHour, TimeSpan? closeHour, string? status)
        {
            VenueName = venueName;
            Address = address;
            Capacity = capacity;
            DistrictId = districtId;
            Description = description;
            OpenHour = openHour;
            CloseHour = closeHour;
            Status = status;
        }

        public Venue(int id, string? venueName, string? address, int? capacity, int? districtId, string? description, TimeSpan? openHour, TimeSpan? closeHour, string? status)
        {
            Id = id;
            VenueName = venueName;
            Address = address;
            Capacity = capacity;
            DistrictId = districtId;
            Description = description;
            OpenHour = openHour;
            CloseHour = closeHour;
            Status = status;
        }

        public int Id { get; set; }
        public string? VenueName { get; set; }
        public string? Address { get; set; }
        public int? Capacity { get; set; }
        public int? DistrictId { get; set; }
        public string? Description { get; set; }
        public TimeSpan? OpenHour { get; set; }
        public TimeSpan? CloseHour { get; set; }
        public string? Status { get; set; }

        public virtual District? District { get; set; }
        public virtual ICollection<AvailableTimeSlot> AvailableTimeSlots { get; set; }
        public virtual ICollection<VenueImage> VenueImages { get; set; }
    }
}
