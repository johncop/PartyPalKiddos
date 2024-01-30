using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Drink
    {
        public Drink()
        {
            DrinkImages = new HashSet<DrinkImage>();
        }

        public Drink(string drinkName, string? description, int? drinkCategoryId, decimal price)
        {
            DrinkName = drinkName;
            Description = description;
            DrinkCategoryId = drinkCategoryId;
            Price = price;
        }

        public Drink(int id, string drinkName, string? description, int? drinkCategoryId, decimal price)
        {
            Id = id;
            DrinkName = drinkName;
            Description = description;
            DrinkCategoryId = drinkCategoryId;
            Price = price;
        }

        public int Id { get; set; }
        public string DrinkName { get; set; } = null!;
        public string? Description { get; set; }
        public int? DrinkCategoryId { get; set; }
        public decimal Price { get; set; }

        public virtual DrinkCategory? DrinkCategory { get; set; }
        public virtual ICollection<DrinkImage> DrinkImages { get; set; }
    }
}
