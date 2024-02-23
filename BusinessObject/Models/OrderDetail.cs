using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderDetail
    {
        public int? OrderId { get; set; }
        public int? PackageId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Package? Package { get; set; }
    }
}
