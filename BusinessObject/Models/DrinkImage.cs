using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class DrinkImage
    {
        
        public DrinkImage(string? imgUrl, int? drinkId)
        {
            ImgUrl = imgUrl;
            DrinkId = drinkId;
        }

        public DrinkImage() 
        {
        }

        public DrinkImage(int id, string? imgUrl, int? drinkId)
        {
            Id = id;
            ImgUrl = imgUrl;
            DrinkId = drinkId;
        }

        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? DrinkId { get; set; }

        public virtual Drink? Drink { get; set; }
    }
}
