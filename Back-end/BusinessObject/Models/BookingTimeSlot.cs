using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class BookingTimeSlot
    {
        public int? BookingId { get; set; }
        public int? AvailableTimeslotId { get; set; }

        public virtual AvailableTimeSlot? AvailableTimeslot { get; set; }
        public virtual Booking? Booking { get; set; }
    }
}
