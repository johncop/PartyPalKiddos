using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class VenueServiceDetail
    {
        public VenueServiceDetail()
        {

        }
        public VenueServiceDetail(int? venueId, int? serviceId)
        {
            VenueId = venueId;
            ServiceId = serviceId;
        }

        public int? VenueId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Service? Service { get; set; }
        public virtual Venue? Venue { get; set; }
    }
}
