﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class FoodCategory
    {
        public FoodCategory()
        {
            Foods = new HashSet<Food>();
        }

        public FoodCategory(string categoryName, string? description)
        {
            CategoryName = categoryName;
            Description = description;
        }

        public FoodCategory(int id, string categoryName, string? description)
        {
            Id = id;
            CategoryName = categoryName;
            Description = description;
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}