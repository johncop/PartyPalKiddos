using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ComboFoodDetail
    {
        public int? ComboId { get; set; }
        public int? FoodId { get; set; }
        public int? Quantity { get; set; }

        public virtual Combo? Combo { get; set; }
        public virtual Food? Food { get; set; }
    }
}
