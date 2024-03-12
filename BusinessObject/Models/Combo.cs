using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Combo
    {
        public int Id { get; set; }
        public string? ComboName { get; set; }
        public decimal? ComboPrice { get; set; }
        public int? HostId { get; set; }
        public string? ImgUrl { get; set; }
        public int? Status { get; set; }

        public virtual Host? Host { get; set; }
    }
}
