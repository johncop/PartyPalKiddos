using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServicePackageImage
    {
        public ServicePackageImage()
        {

        }
        public ServicePackageImage(string? imgUrl, byte[]? image, int? servicePackageId)
        {
            ImgUrl = imgUrl;
            Image = image;
            ServicePackageId = servicePackageId;
        }

        public ServicePackageImage(int id, string? imgUrl, byte[]? image, int? servicePackageId)
        {
            Id = id;
            ImgUrl = imgUrl;
            Image = image;
            ServicePackageId = servicePackageId;
        }

        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public byte[]? Image { get; set; }
        public int? ServicePackageId { get; set; }

        public virtual ServicePackage? ServicePackage { get; set; }
    }
}
