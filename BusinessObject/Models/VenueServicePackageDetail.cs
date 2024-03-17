using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class VenueServicePackageDetail
    {
        public VenueServicePackageDetail()
        {

        }
        public VenueServicePackageDetail(int? venueId, int? servicePackageId)
        {
            VenueId = venueId;
            ServicePackageId = servicePackageId;
        }

        public int? VenueId { get; set; }
        public int? ServicePackageId { get; set; }

        public virtual ServicePackage? ServicePackage { get; set; }
        public virtual Venue? Venue { get; set; }
    }
}
