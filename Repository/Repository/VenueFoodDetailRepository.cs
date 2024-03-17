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
    public class VenueFoodDetailRepository : IVenueFoodDetailRepository
    {
        public void addVenueFoodDetail(VenueFoodDetail hfd) => VenueFoodDetailDAO.SaveVenueFoodDetail(hfd);

        public List<VenueFoodDetail> GetAllVenueFoodDetails() => VenueFoodDetailDAO.GetVenueFoodDetails();

        public List<VenueFoodDetail> GetVenueFoodDetailById(int id) => VenueFoodDetailDAO.FindVenueFoodDetailById(id);

        public VenueFoodDetail GetVenueFoodDetailByIds(int VenueId, int foodId) => VenueFoodDetailDAO.GetVenueFoodDetailByIds(VenueId, foodId);

        public void removeVenueFoodDetail(VenueFoodDetail hfd) => VenueFoodDetailDAO.DeleteVenueFoodDetail(hfd);

        public void UpdateVenueFoodDetail(VenueFoodDetail hfd) => VenueFoodDetailDAO.UpdateVenueFoodDetail(hfd);
    }
}
