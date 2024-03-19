using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class AvailableTimeSlot
    {
        public int Id { get; set; }
        public int? TimeslotId { get; set; }
        public int? VenueId { get; set; }
        public string? Status { get; set; }

        public virtual TimeSlot? Timeslot { get; set; }
        public virtual Venue? Venue { get; set; }
    }
}
