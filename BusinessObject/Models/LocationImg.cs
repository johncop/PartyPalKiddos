using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class LocationImg
    {
        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? LocationId { get; set; }

        public virtual Location? Location { get; set; }
    }
}
