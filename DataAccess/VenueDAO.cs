using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VenueDAO
    {
        #region query
        public static List<Venue> GetVenues()
        {
            var listVenues = new List<Venue>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenues = context.Venues
                .Include(Venue => Venue.VenueImages)
                .Select(Venue => new Venue
                {
                    Id = Venue.Id,
                    VenueName = Venue.VenueName,
                    Address = Venue.Address,
                    Capacity = Venue.Capacity,
                    DistrictId = Venue.DistrictId,
                    Description = Venue.Description,                
                    //Price = Venue.Price,
                    VenueImages = Venue.VenueImages,
                    District = Venue.District,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listVenues;
        }

        public static Venue findVenueById(int id)
        {
            Venue l = new Venue();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    l = context.Venues
                .Include(Venue => Venue.VenueImages)
                .Select(Venue => new Venue
                {
                    Id = Venue.Id,
                    VenueName = Venue.VenueName,
                    Address = Venue.Address,
                    Capacity = Venue.Capacity,
                    DistrictId = Venue.DistrictId,
                    Description = Venue.Description,
                    //Price = Venue.Price,
                    VenueImages = Venue.VenueImages,
                    District = Venue.District,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return l;
        }

        public static List<Venue> findVenueByName(string address)
        {
            List<Venue> f = new List<Venue>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    f = context.Venues
                     .Include(Venue => Venue.VenueImages)
                     .Where(Venue => Venue.Address.Contains(address))
                .Select(Venue => new Venue
                {
                    Id = Venue.Id,
                    VenueName = Venue.VenueName,
                    Address = Venue.Address,
                    Capacity = Venue.Capacity,
                    DistrictId = Venue.DistrictId,
                    Description = Venue.Description,
                   // Price = Venue.Price,
                    VenueImages = Venue.VenueImages,
                    District = Venue.District,
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
        public static void SaveVenue(Venue f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Venues.Add(f);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteVenue(Venue f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.Venues.SingleOrDefault(x => x.Id == f.Id);
                    context.Venues.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateVenue(Venue p)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<Venue>(p).State =
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
