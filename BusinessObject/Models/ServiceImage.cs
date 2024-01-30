using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ServiceImage
    {
        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? ServiceId { get; set; }

        public virtual Service? Service { get; set; }
    }
}
