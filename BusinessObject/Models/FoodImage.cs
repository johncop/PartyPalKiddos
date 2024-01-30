using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class FoodImage
    {
        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? FoodId { get; set; }

        public virtual Food? Food { get; set; }
    }
}
