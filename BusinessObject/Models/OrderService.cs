using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderService
    {
        public OrderService()
        {
            Packages = new HashSet<Package>();
        }

        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public int Quantity { get; set; }

        public virtual Service? Service { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
