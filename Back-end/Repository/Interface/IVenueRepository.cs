using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IVenueRepository
    {
        void addVenue(Venue venue);
        void removeVenue(Venue venue);
        void UpdateVenue(Venue venue);
        Venue GetVenueById(int id);
        List<Venue> GetVenueByName(string address);
        List<Venue> GetVenueByDistrict(int id);
        List<Venue> GetAllVenue();
    }
}
