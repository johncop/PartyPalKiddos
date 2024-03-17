using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Food
    {
        public Food()
        {

        }
        public Food(string? foodName, string? description, string? imageUrl, byte[]? image, int? foodCategoryId, decimal? price)
        {
            FoodName = foodName;
            Description = description;
            ImageUrl = imageUrl;
            Image = image;
            FoodCategoryId = foodCategoryId;
            Price = price;
        }

        public Food(int id, string? foodName, string? description, string? imageUrl, byte[]? image, int? foodCategoryId, decimal? price)
        {
            Id = id;
            FoodName = foodName;
            Description = description;
            ImageUrl = imageUrl;
            Image = image;
            FoodCategoryId = foodCategoryId;
            Price = price;
        }

        public int Id { get; set; }
        public string? FoodName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public byte[]? Image { get; set; }
        public int? FoodCategoryId { get; set; }
        public decimal? Price { get; set; }

        public virtual FoodCategory? FoodCategory { get; set; }
    }
}
