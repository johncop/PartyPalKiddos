using BusinessObject.Models;
using DataAccess.Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class VenueComboDetailRepository : IVenueComboDetailRepository
    {
        public void addVenueComboDetail(VenueComboDetail hcd) => VenueComboDetailDAO.SaveVenueComboDetail(hcd);

        public List<VenueComboDetail> GetAllVenueComboDetails() => VenueComboDetailDAO.GetVenueComboDetails();

        public VenueComboDetail GetVenueComboDetailByIds(int VenueId, int comboId) => VenueComboDetailDAO.GetVenueComboDetailByIds(VenueId, comboId);

        public List<VenueComboDetail> GetVenueComboDetailById(int id) => VenueComboDetailDAO.FindVenueComboDetailById(id);

        public void removeVenueComboDetail(VenueComboDetail hcd) => VenueComboDetailDAO.DeleteVenueComboDetail(hcd);

        public void UpdateVenueComboDetail(VenueComboDetail hcd) => VenueComboDetailDAO.UpdateVenueComboDetail(hcd);
    }
}
