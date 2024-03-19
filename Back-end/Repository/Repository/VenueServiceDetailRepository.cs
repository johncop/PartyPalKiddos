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
    public class VenueServiceDetailRepository : IVenueServiceDetailRepository
    {
        public void addVenueServiceDetail(VenueServiceDetail hfd) => VenueServiceDetailDAO.SaveVenueServiceDetail(hfd);

        public List<VenueServiceDetail> GetAllVenueServiceDetails()=> VenueServiceDetailDAO.GetVenueServiceDetails();

        public List<VenueServiceDetail> GetVenueServiceDetailById(int id)
        => VenueServiceDetailDAO.FindVenueServiceDetailById(id);

        public VenueServiceDetail GetVenueServiceDetailByIds(int VenueId, int serviceId) => VenueServiceDetailDAO.GetVenueServiceDetailByIds(VenueId, serviceId);

        public void removeVenueServiceDetail(VenueServiceDetail hfd) => VenueServiceDetailDAO.DeleteVenueServiceDetail(hfd);

        public void UpdateVenueServiceDetail(VenueServiceDetail hfd) => VenueServiceDetailDAO.UpdateVenueServiceDetail(hfd);
    }
}
