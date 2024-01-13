using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Food
    {
        public Food()
        {
            OrderFoods = new HashSet<OrderFood>();
        }

        public int Id { get; set; }
        public string FoodName { get; set; } = null!;
        public string? Description { get; set; }
        public int? FoodCategoryId { get; set; }
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }

        public virtual FoodCategory? FoodCategory { get; set; }
        public virtual ICollection<OrderFood> OrderFoods { get; set; }
    }
}
