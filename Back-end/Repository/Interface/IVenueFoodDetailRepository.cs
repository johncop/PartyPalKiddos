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
        void addVenueFoodDetailByCategory(int VenueId, int categoryId);
        void addVenueFoodDetailByCategoryAndVenueName(string venueName, int categoryId);
        void removeVenueFoodDetail(VenueFoodDetail hfd);
        void removeVenueFoodDetailById(int VenueId);
        void UpdateVenueFoodDetail(VenueFoodDetail hfd);
        List<VenueFoodDetail> GetAllVenueFoodDetails();
        List<VenueFoodDetail> GetVenueFoodDetailById(int id);
        VenueFoodDetail GetVenueFoodDetailByIds(int VenueId, int foodId);
    }
}
