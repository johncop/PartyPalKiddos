using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class PackageCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
