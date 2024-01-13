using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Drink
    {
        public Drink()
        {
            OrderDrinks = new HashSet<OrderDrink>();
        }

        public int Id { get; set; }
        public string DrinkName { get; set; } = null!;
        public string? Description { get; set; }
        public int? DrinkCategoryId { get; set; }
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }

        public virtual DrinkCategory? DrinkCategory { get; set; }
        public virtual ICollection<OrderDrink> OrderDrinks { get; set; }
    }
}
