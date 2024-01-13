using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderFood
    {
        public OrderFood()
        {
            Packages = new HashSet<Package>();
        }

        public int Id { get; set; }
        public int? FoodId { get; set; }
        public int Quantity { get; set; }

        public virtual Food? Food { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
