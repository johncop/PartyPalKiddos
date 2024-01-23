using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class FoodImg
    {
        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? FoodId { get; set; }

        public virtual Food? Food { get; set; }
    }
}
