using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class BookingServiceDetail
    {
        public int? BookingId { get; set; }
        public int? ServiceId { get; set; }
        public int? ServicePackageId { get; set; }
        public int? ServiceQuantity { get; set; }
        public int? ServicePackageQuantity { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Service? Service { get; set; }
        public virtual ServicePackage? ServicePackage { get; set; }
    }
}
