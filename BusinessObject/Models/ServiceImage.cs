using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServiceImage
    {
        public ServiceImage(string? imgUrl, int? serviceId)
        {
            ImgUrl = imgUrl;
            ServiceId = serviceId;
        }

        public ServiceImage(int id, string? imgUrl, int? serviceId)
        {
            Id = id;
            ImgUrl = imgUrl;
            ServiceId = serviceId;
        }

        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? ServiceId { get; set; }

        public virtual Service? Service { get; set; }
    }
}
