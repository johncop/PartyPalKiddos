using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderDrink
    {
        public OrderDrink()
        {
            Packages = new HashSet<Package>();
        }

        public int Id { get; set; }
        public int? DrinkId { get; set; }
        public int Quantity { get; set; }

        public virtual Drink? Drink { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
