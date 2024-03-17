using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VenueServiceDetailDAO
    {
        #region QUERY
        public static List<VenueServiceDetail> GetVenueServiceDetails()
        {
            var listVenueServiceDetails = new List<VenueServiceDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenueServiceDetails = context.VenueServiceDetails
                    .Select(hcd => new VenueServiceDetail
                    {
                        VenueId = hcd.VenueId,
                        ServiceId= hcd.ServiceId,
                        Venue = hcd.Venue,
                        Service = hcd.Service,
                    })
                    .ToList();
                    return listVenueServiceDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<VenueServiceDetail> FindVenueServiceDetailById(int VenueId)
        {
            var listVenueServiceDetails = new List<VenueServiceDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenueServiceDetails = context.VenueServiceDetails
                        .Where(hcd => hcd.VenueId == VenueId)
                    .Select(hcd => new VenueServiceDetail
                    {
                        VenueId = hcd.VenueId,
                        ServiceId = hcd.ServiceId,
                        Venue = hcd.Venue,
                        Service = hcd.Service,
                    })
                    .ToList();
                    return listVenueServiceDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static VenueServiceDetail GetVenueServiceDetailByIds(int VenueId, int foodId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var hcd = context.VenueServiceDetails
                         .Where(hcd => hcd.VenueId == VenueId && hcd.ServiceId == foodId)
                     .Select(hcd => new VenueServiceDetail
                     {
                         VenueId = hcd.VenueId,
                         ServiceId = hcd.ServiceId,
                         Venue = hcd.Venue,
                         Service = hcd.Service,
                     }).FirstOrDefault();
                    return hcd;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion



        #region COMMAND

        public static void SaveVenueServiceDetail(VenueServiceDetail VenueServiceDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.VenueServiceDetails.Add(VenueServiceDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteVenueServiceDetail(VenueServiceDetail VenueServiceDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.VenueServiceDetails.SingleOrDefault(x => x.VenueId == VenueServiceDetail.VenueId && x.ServiceId == VenueServiceDetail.ServiceId);
                    context.VenueServiceDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateVenueServiceDetail(VenueServiceDetail VenueServiceDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<VenueServiceDetail>(VenueServiceDetail).State =
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
