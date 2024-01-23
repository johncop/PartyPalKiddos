using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class DrinkImg
    {
        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        public int? DrinkId { get; set; }

        public virtual Drink? Drink { get; set; }
    }
}
