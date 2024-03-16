using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServicePackageImage
    {
        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? ServicePackageId { get; set; }

        public virtual ServicePackage? ServicePackage { get; set; }
    }
}
