using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class VenueServicePackageDetailRepository : IVenueServicePackageDetailRepository
    {
        public void addVenueServicePackageDetail(VenueServicePackageDetail VenueServicePackageDetail)
            => VenueServicePackageDetailDAO.SaveVenueServicePackageDetail(VenueServicePackageDetail);

        public List<VenueServicePackageDetail> GetAllVenueServicePackageDetails() => VenueServicePackageDetailDAO.GetVenueServicePackageDetails();

        public List<VenueServicePackageDetail> GetVenueServicePackageDetailById(int id) => VenueServicePackageDetailDAO.FindVenueServicePackageDetailById(id);

        public VenueServicePackageDetail GetVenueServicePackageDetailByIds(int VenueId, int servicePackageId) => VenueServicePackageDetailDAO.GetVenueServicePackageDetailByIds(VenueId, servicePackageId);

        public void removeVenueServicePackageDetail(VenueServicePackageDetail VenueServicePackageDetail) => VenueServicePackageDetailDAO.DeleteVenueServicePackageDetail(VenueServicePackageDetail);

        public void UpdateVenueServicePackageDetail(VenueServicePackageDetail VenueServicePackageDetail) => VenueServicePackageDetailDAO.UpdateVenueServicePackageDetail(VenueServicePackageDetail);
    }
}
