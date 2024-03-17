using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ComboFoodDetail
    {
        public ComboFoodDetail()
        {

        }

        public ComboFoodDetail(int? foodId, int? quantity)
        {
            FoodId = foodId;
            Quantity = quantity;
        }

        public ComboFoodDetail(int? comboId, int? foodId, int? quantity)
        {
            ComboId = comboId;
            FoodId = foodId;
            Quantity = quantity;
        }

        public int? ComboId { get; set; }
        public int? FoodId { get; set; }
        public int? Quantity { get; set; }

        public virtual Combo? Combo { get; set; }
        public virtual Food? Food { get; set; }
    }
}
