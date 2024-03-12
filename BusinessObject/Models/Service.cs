using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Service
    {
        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public int? ServiceCategoryId { get; set; }
        public string? ServiceImage { get; set; }
        public decimal? Price { get; set; }

        public virtual ServiceCategory? ServiceCategory { get; set; }
    }
}
