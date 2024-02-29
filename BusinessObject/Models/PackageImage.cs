using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class PackageImage
    {
        public PackageImage() { }
        public PackageImage(string? imgUrl, int? packageId)
        {
            ImgUrl = imgUrl;
            PackageId = packageId;
        }

        public PackageImage(int id, string? imgUrl, int? packageId)
        {
            Id = id;
            ImgUrl = imgUrl;
            PackageId = packageId;
        }

        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? PackageId { get; set; }

        public virtual Package? Package { get; set; }
    }
}
