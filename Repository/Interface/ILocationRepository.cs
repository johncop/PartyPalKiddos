using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ILocationRepository
    {
        void addLocation(Location l);
        void removeLocation(Location l);
        void UpdateLocation(Location l);
        Location GetLocationById(int id);
        List<Location> GetLocationByName(string address);

        List<Location> GetAllLocation();
    }
}
