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
    public class LocationRepository : ILocationRepository
    {
        public void addLocation(Location l) => LocationDAO.SaveLocation(l);

        public List<Location> GetAllLocation() => LocationDAO.GetLocations();

        public Location GetLocationById(int id) => LocationDAO.findLocationById(id);

        public List<Location> GetLocationByName(string address) => LocationDAO.findLocationByName(address);

        public void removeLocation(Location l) => LocationDAO.DeleteLocation(l);

        public void UpdateLocation(Location l) => LocationDAO.UpdateLocation(l);
    }
}
