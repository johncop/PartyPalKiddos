using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class VenueFoodDetail
    {
        public int? VenueId { get; set; }
        public int? FoodId { get; set; }

        public virtual Food? Food { get; set; }
        public virtual Venue? Venue { get; set; }
    }
}
