using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class FoodImage
    {
        public FoodImage() { }
        public FoodImage(string? imgUrl, int? foodId)
        {
            ImgUrl = imgUrl;
            FoodId = foodId;
        }

        public FoodImage(int id, string? imgUrl, int? foodId)
        {
            Id = id;
            ImgUrl = imgUrl;
            FoodId = foodId;
        }

        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? FoodId { get; set; }

        public virtual Food? Food { get; set; }
    }
}
