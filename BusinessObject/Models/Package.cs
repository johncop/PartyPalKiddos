using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Package
    {
        public Package()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? OrderFoodId { get; set; }
        public int? OrderDrinkId { get; set; }
        public int? OrderServiceId { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public int? PackageCategoryId { get; set; }
        public int Status { get; set; }

        public virtual OrderDrink? OrderDrink { get; set; }
        public virtual OrderFood? OrderFood { get; set; }
        public virtual OrderService? OrderService { get; set; }
        public virtual PackageCategory? PackageCategory { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
