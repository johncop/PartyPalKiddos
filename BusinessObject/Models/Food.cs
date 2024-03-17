using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Food
    {
        public int Id { get; set; }
        public string? FoodName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int? FoodCategoryId { get; set; }
        public decimal? Price { get; set; }

        public virtual FoodCategory? FoodCategory { get; set; }
    }
}
