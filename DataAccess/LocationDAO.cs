using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LocationDAO
    {
        #region query
        public static List<Location> GetLocations()
        {
            var listLocations = new List<Location>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listLocations = context.Locations
                .Include(Location => Location.LocationImages)
                .Select(Location => new Location
                {
                    Id = Location.Id,
                    Address = Location.Address,
                    DistrictId = Location.DistrictId,
                    Description = Location.Description,                
                    Price = Location.Price,
                    LocationImages = Location.LocationImages
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listLocations;
        }

        public static Location findLocationById(int id)
        {
            Location l = new Location();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    l = context.Locations
                .Include(Location => Location.LocationImages)
                .Select(Location => new Location
                {
                    Id = Location.Id,
                    Address = Location.Address,
                    DistrictId = Location.DistrictId,
                    Description = Location.Description,
                    Price = Location.Price,
                    LocationImages = Location.LocationImages
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return l;
        }

        public static List<Location> findLocationByName(string address)
        {
            List<Location> f = new List<Location>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    f = context.Locations
                     .Include(Location => Location.LocationImages)
                     .Where(Location => Location.Address.Contains(address))
                .Select(Location => new Location
                {
                    Id = Location.Id,
                    Address = Location.Address,
                    DistrictId = Location.DistrictId,
                    Description = Location.Description,
                    Price = Location.Price,
                    LocationImages = Location.LocationImages
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return f;
        }
        #endregion



        #region command
        public static void SaveLocation(Location f)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Locations.Add(f);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteLocation(Location f)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.Locations.SingleOrDefault(x => x.Id == f.Id);
                    context.Locations.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateLocation(Location p)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<Location>(p).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
