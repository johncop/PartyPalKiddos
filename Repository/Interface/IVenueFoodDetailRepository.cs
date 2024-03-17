using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IVenueFoodDetailRepository
    {
        void addVenueFoodDetail(VenueFoodDetail hfd);
        void removeVenueFoodDetail(VenueFoodDetail hfd);
        void UpdateVenueFoodDetail(VenueFoodDetail hfd);
        List<VenueFoodDetail> GetAllVenueFoodDetails();
        List<VenueFoodDetail> GetVenueFoodDetailById(int id);
        VenueFoodDetail GetVenueFoodDetailByIds(int VenueId, int foodId);
    }
}
