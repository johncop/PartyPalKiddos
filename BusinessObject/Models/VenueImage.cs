using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class VenueImage
    {
        public VenueImage()
        {

        }
        public VenueImage(string? imgUrl, int? venueId)
        {
            ImgUrl = imgUrl;
            VenueId = venueId;
        }

        public VenueImage(int id, string? imgUrl, int? venueId)
        {
            Id = id;
            ImgUrl = imgUrl;
            VenueId = venueId;
        }

        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? VenueId { get; set; }

        public virtual Venue? Venue { get; set; }
    }
}
