using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VenueServicePackageDetailDAO
    {
        #region QUERY
        public static List<VenueServicePackageDetail> GetVenueServicePackageDetails()
        {
            var listVenueServicePackageDetails = new List<VenueServicePackageDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenueServicePackageDetails = context.VenueServicePackageDetails
                    .Select(hcd => new VenueServicePackageDetail
                    {
                        VenueId = hcd.VenueId,
                        ServicePackageId = hcd.ServicePackageId,
                        Venue = hcd.Venue,
                        ServicePackage = hcd.ServicePackage,
                    })
                    .ToList();
                    return listVenueServicePackageDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<VenueServicePackageDetail> FindVenueServicePackageDetailById(int VenueId)
        {
            var listVenueServicePackageDetails = new List<VenueServicePackageDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenueServicePackageDetails = context.VenueServicePackageDetails
                        .Where(hcd => hcd.VenueId == VenueId)
                    .Select(hcd => new VenueServicePackageDetail
                    {
                        VenueId = hcd.VenueId,
                        ServicePackageId = hcd.ServicePackageId,
                        Venue = hcd.Venue,
                        ServicePackage = hcd.ServicePackage,
                    })
                    .ToList();
                    return listVenueServicePackageDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static VenueServicePackageDetail GetVenueServicePackageDetailByIds(int VenueId, int servicePackageId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var hcd = context.VenueServicePackageDetails
                         .Where(hcd => hcd.VenueId == VenueId && hcd.ServicePackageId == servicePackageId)
                     .Select(hcd => new VenueServicePackageDetail
                     {
                         VenueId = hcd.VenueId,
                         ServicePackageId = hcd.ServicePackageId,
                         Venue = hcd.Venue,
                         ServicePackage = hcd.ServicePackage,
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

        public static void SaveVenueServicePackageDetail(VenueServicePackageDetail VenueServicePackageDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.VenueServicePackageDetails.Add(VenueServicePackageDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteVenueServicePackageDetail(VenueServicePackageDetail VenueServicePackageDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.VenueServicePackageDetails.SingleOrDefault(x => x.VenueId == VenueServicePackageDetail.VenueId && x.ServicePackageId == VenueServicePackageDetail.ServicePackageId);
                    context.VenueServicePackageDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateVenueServicePackageDetail(VenueServicePackageDetail VenueServicePackageDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<VenueServicePackageDetail>(VenueServicePackageDetail).State =
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
