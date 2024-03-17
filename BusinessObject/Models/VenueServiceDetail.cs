using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class VenueServiceDetail
    {
        public int? VenueId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Service? Service { get; set; }
        public virtual Venue? Venue { get; set; }
    }
}
