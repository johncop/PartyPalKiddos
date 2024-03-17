using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IVenueComboDetailRepository
    {
        void addVenueComboDetail(VenueComboDetail hcd);
        void removeVenueComboDetail(VenueComboDetail hcd);
        void UpdateVenueComboDetail(VenueComboDetail hcd);
        List<VenueComboDetail> GetAllVenueComboDetails();
        List<VenueComboDetail> GetVenueComboDetailById(int id);
        VenueComboDetail GetVenueComboDetailByIds(int VenueId, int comboId);
    }
}
