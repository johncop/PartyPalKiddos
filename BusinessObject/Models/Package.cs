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

        public Package(string? packageName, int? packageCategoryId, int? userId, int? locationId, decimal? price, int? status)
        {
            PackageName = packageName;
            PackageCategoryId = packageCategoryId;
            UserId = userId;
            LocationId = locationId;
            Price = price;
            Status = status;
        }

        public Package(int id, string? packageName, int? packageCategoryId, int? userId, int? locationId, decimal? price, int? status)
        {
            Id = id;
            PackageName = packageName;
            PackageCategoryId = packageCategoryId;
            UserId = userId;
            LocationId = locationId;
            Price = price;
            Status = status;
        }

        public int Id { get; set; }
        public string? PackageName { get; set; }
        public int? PackageCategoryId { get; set; }
        public int? UserId { get; set; }
        public int? LocationId { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }

        public virtual Location? Location { get; set; }
        public virtual PackageCategory? PackageCategory { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
