using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class PackageCategory
    {
        public PackageCategory(string categoryName, string? description)
        {
            CategoryName = categoryName;
            Description = description;
        }

        public PackageCategory(int id, string categoryName, string? description)
        {
            Id = id;
            CategoryName = categoryName;
            Description = description;
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
