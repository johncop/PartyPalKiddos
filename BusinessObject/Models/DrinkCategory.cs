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

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Drink> Drinks { get; set; }
    }
}
