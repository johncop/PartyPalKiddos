using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IVenueServiceDetailRepository
    {
        void addVenueServiceDetail(VenueServiceDetail hfd);
        void removeVenueServiceDetail(VenueServiceDetail hfd);
        void UpdateVenueServiceDetail(VenueServiceDetail hfd);
        List<VenueServiceDetail> GetAllVenueServiceDetails();
        List<VenueServiceDetail> GetVenueServiceDetailById(int id);
        VenueServiceDetail GetVenueServiceDetailByIds(int VenueId, int serviceId);
    }
}
