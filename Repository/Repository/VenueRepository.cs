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
    public class VenueRepository : IVenueRepository
    {
        public void addVenue(Venue Venue) => VenueDAO.SaveVenue(Venue);

        public List<Venue> GetAllVenue() => VenueDAO.GetVenues();

        public Venue GetVenueById(int id) => VenueDAO.findVenueById(id);

        public List<Venue> GetVenueByName(string address) => VenueDAO.findVenueByName(address);

        public void removeVenue(Venue Venue) => VenueDAO.DeleteVenue(Venue);

        public void UpdateVenue(Venue Venue) => VenueDAO.UpdateVenue(Venue);
    }
}
