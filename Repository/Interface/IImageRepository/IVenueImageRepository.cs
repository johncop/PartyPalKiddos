using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Image
{
    public interface IVenueImageRepository
    {
        void addVenueImage(VenueImage li);
        void removeVenueImage(VenueImage li);
        void UpdateVenueImage(VenueImage li);
        List<VenueImage> GetAllVenueImages();
        VenueImage GetVenueImageById(int id);
    }
}
