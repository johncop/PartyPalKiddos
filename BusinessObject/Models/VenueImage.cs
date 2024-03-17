using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class VenueImage
    {
        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? VenueId { get; set; }

        public virtual Venue? Venue { get; set; }
    }
}
