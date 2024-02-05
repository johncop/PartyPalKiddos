using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderDrink
    {
        public OrderDrink(int? packageId, int? drinkId, int? quantity)
        {
            PackageId = packageId;
            DrinkId = drinkId;
            Quantity = quantity;
        }

        public int? PackageId { get; set; }
        public int? DrinkId { get; set; }
        public int? Quantity { get; set; }

        public virtual Drink? Drink { get; set; }
        public virtual Package? Package { get; set; }
    }
}
