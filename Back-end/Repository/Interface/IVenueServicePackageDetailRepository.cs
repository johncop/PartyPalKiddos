using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IVenueServicePackageDetailRepository
    {
        void addVenueServicePackageDetail(VenueServicePackageDetail VenueServicePackageDetail);
        void removeVenueServicePackageDetail(VenueServicePackageDetail VenueServicePackageDetail);
        void UpdateVenueServicePackageDetail(VenueServicePackageDetail VenueServicePackageDetail);
        List<VenueServicePackageDetail> GetAllVenueServicePackageDetails();
        List<VenueServicePackageDetail> GetVenueServicePackageDetailById(int id);
        VenueServicePackageDetail GetVenueServicePackageDetailByIds(int VenueId, int servicePackageId);
    }
}
