using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class DrinkCategory
    {
        public DrinkCategory()
        {
            Drinks = new HashSet<Drink>();
        }

        public DrinkCategory(string categoryName, string? description)
        {
            CategoryName = categoryName;
            Description = description;
        }

        public DrinkCategory(int id, string categoryName, string? description)
        {
            Id = id;
            CategoryName = categoryName;
            Description = description;
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Drink> Drinks { get; set; }
    }
}
