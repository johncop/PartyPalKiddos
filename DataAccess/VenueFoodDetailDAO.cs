using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VenueFoodDetailDAO
    {
        #region QUERY
        public static List<VenueFoodDetail> GetVenueFoodDetails()
        {
            var listVenueFoodDetails = new List<VenueFoodDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenueFoodDetails = context.VenueFoodDetails
                    .Select(hcd => new VenueFoodDetail
                    {
                        VenueId = hcd.VenueId,
                        FoodId = hcd.FoodId,
                    })
                    .ToList();
                    return listVenueFoodDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<VenueFoodDetail> FindVenueFoodDetailById(int VenueId)
        {
            var listVenueFoodDetails = new List<VenueFoodDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenueFoodDetails = context.VenueFoodDetails
                        .Where(hcd => hcd.VenueId == VenueId)
                    .Select(hcd => new VenueFoodDetail
                    {
                        VenueId = hcd.VenueId,
                        FoodId = hcd.FoodId,
                    })
                    .ToList();
                    return listVenueFoodDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static VenueFoodDetail GetVenueFoodDetailByIds(int VenueId, int foodId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var hcd = context.VenueFoodDetails
                         .Where(hcd => hcd.VenueId == VenueId && hcd.FoodId == foodId)
                     .Select(hcd => new VenueFoodDetail
                     {
                         VenueId = hcd.VenueId,
                         FoodId = hcd.FoodId
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

        public static void SaveVenueFoodDetail(VenueFoodDetail VenueFoodDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.VenueFoodDetails.Add(VenueFoodDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteVenueFoodDetail(VenueFoodDetail VenueFoodDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.VenueFoodDetails.SingleOrDefault(x => x.VenueId == VenueFoodDetail.VenueId && x.FoodId == VenueFoodDetail.FoodId);
                    context.VenueFoodDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateVenueFoodDetail(VenueFoodDetail VenueFoodDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<VenueFoodDetail>(VenueFoodDetail).State =
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
