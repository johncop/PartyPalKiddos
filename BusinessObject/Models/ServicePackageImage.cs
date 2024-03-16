using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServicePackageImage
    {
        public ServicePackageImage()
        {

        }
        public ServicePackageImage(string? imgUrl, int? servicePackageId)
        {
            ImgUrl = imgUrl;
            ServicePackageId = servicePackageId;
        }

        public ServicePackageImage(int id, string? imgUrl, int? servicePackageId)
        {
            Id = id;
            ImgUrl = imgUrl;
            ServicePackageId = servicePackageId;
        }

        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? ServicePackageId { get; set; }

        public virtual ServicePackage? ServicePackage { get; set; }
    }
}
