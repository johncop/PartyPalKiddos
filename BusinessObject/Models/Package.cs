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

        public Package(string? packageName, int? orderFoodId, int? orderDrinkId, int? orderServiceId, int? userId, int? packageCategoryId, int? status, decimal? price, int? locationId)
        {
            PackageName = packageName;
            OrderFoodId = orderFoodId;
            OrderDrinkId = orderDrinkId;
            OrderServiceId = orderServiceId;
            UserId = userId;
            PackageCategoryId = packageCategoryId;
            Status = status;
            Price = price;
            LocationId = locationId;
        }

        public Package(int id, string? packageName, int? orderFoodId, int? orderDrinkId, int? orderServiceId, int? userId, int? packageCategoryId, int? status, decimal? price, int? locationId)
        {
            Id = id;
            PackageName = packageName;
            OrderFoodId = orderFoodId;
            OrderDrinkId = orderDrinkId;
            OrderServiceId = orderServiceId;
            UserId = userId;
            PackageCategoryId = packageCategoryId;
            Status = status;
            Price = price;
            LocationId = locationId;
        }

        public int Id { get; set; }
        public string? PackageName { get; set; }
        public int? OrderFoodId { get; set; }
        public int? OrderDrinkId { get; set; }
        public int? OrderServiceId { get; set; }
        public int? UserId { get; set; }
        public int? PackageCategoryId { get; set; }
        public int? Status { get; set; }
        public decimal? Price { get; set; }
        public int? LocationId { get; set; }

        public virtual Location? Location { get; set; }
        public virtual OrderDrink? OrderDrink { get; set; }
        public virtual OrderFood? OrderFood { get; set; }
        public virtual OrderService? OrderService { get; set; }
        public virtual PackageCategory? PackageCategory { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
