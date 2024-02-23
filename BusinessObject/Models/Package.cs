using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Package
    {
        public int Id { get; set; }
        public string? PackageName { get; set; }
        public int? NumberOfKid { get; set; }
        public int? UserId { get; set; }
        public int? LocationId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }

        public virtual Location? Location { get; set; }
        public virtual User? User { get; set; }
    }
}
