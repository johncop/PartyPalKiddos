using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class PackageTag
    {
        public PackageTag() { }
        public PackageTag(int? packageId, int? categoryId, string? description)
        {
            PackageId = packageId;
            CategoryId = categoryId;
            Description = description;
        }

        public int? PackageId { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }

        public virtual PackageCategory? Category { get; set; }
        public virtual Package? Package { get; set; }
    }
}
