using BusinessObject.Models;
using DataAccess.ImageDAO;
using Repository.Interface.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.ImageRepository
{
    public class VenueImageRepository : IVenueImageRepository
    {
        public void addVenueImage(VenueImage li) => VenueImageDAO.SaveVenueImage(li);

        public List<VenueImage> GetAllVenueImages() => VenueImageDAO.GetVenueImages();

        public VenueImage GetVenueImageById(int id) => VenueImageDAO.findVenueImageById(id);

        public void removeVenueImage(VenueImage li) => VenueImageDAO.DeleteVenueImage(li);

        public void UpdateVenueImage(VenueImage li) => VenueImageDAO.UpdateVenueImage(li);
    }
}
