using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            AvailableTimeSlots = new HashSet<AvailableTimeSlot>();
        }

        public int Id { get; set; }
        public TimeSpan? Hours { get; set; }
        public string? Weekday { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<AvailableTimeSlot> AvailableTimeSlots { get; set; }
    }
}
