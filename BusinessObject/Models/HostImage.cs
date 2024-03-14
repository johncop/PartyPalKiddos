using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class HostImage
    {
        public HostImage() { }
        public HostImage(string? imgUrl, int? locationId)
        {
            ImgUrl = imgUrl;
            HostId = locationId;
        }

        public HostImage(int id, string? imgUrl, int? locationId)
        {
            Id = id;
            ImgUrl = imgUrl;
            HostId = locationId;
        }

        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? HostId { get; set; }

        public virtual Host? Location { get; set; }
    }
}
