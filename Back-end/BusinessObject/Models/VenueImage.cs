using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class VenueImage
    {
        public VenueImage()
        {

        }

        public VenueImage(string? imgUrl, int? venueId, byte[]? image)
        {
            ImgUrl = imgUrl;
            VenueId = venueId;
            Image = image;
        }

        public VenueImage(int id, string? imgUrl, int? venueId, byte[]? image)
        {
            Id = id;
            ImgUrl = imgUrl;
            VenueId = venueId;
            Image = image;
        }

        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? VenueId { get; set; }
        public byte[]? Image { get; set; }

        public virtual Venue? Venue { get; set; }
    }
}
