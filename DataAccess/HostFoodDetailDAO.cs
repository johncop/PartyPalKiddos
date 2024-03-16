using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HostFoodDetailDAO
    {
        #region QUERY
        public static List<HostFoodDetail> GetHostFoodDetails()
        {
            var listHostFoodDetails = new List<HostFoodDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listHostFoodDetails = context.HostFoodDetails
                    .Select(hcd => new HostFoodDetail
                    {
                        HostId = hcd.HostId,
                        FoodId = hcd.FoodId,
                    })
                    .ToList();
                    return listHostFoodDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<HostFoodDetail> FindHostFoodDetailById(int hostId)
        {
            var listHostFoodDetails = new List<HostFoodDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listHostFoodDetails = context.HostFoodDetails
                        .Where(hcd => hcd.HostId == hostId)
                    .Select(hcd => new HostFoodDetail
                    {
                        HostId = hcd.HostId,
                        FoodId = hcd.FoodId,
                    })
                    .ToList();
                    return listHostFoodDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static HostFoodDetail GetHostFoodDetailByIds(int hostId, int foodId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var hcd = context.HostFoodDetails
                         .Where(hcd => hcd.HostId == hostId && hcd.FoodId == foodId)
                     .Select(hcd => new HostFoodDetail
                     {
                         HostId = hcd.HostId,
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

        public static void SaveHostFoodDetail(HostFoodDetail HostFoodDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.HostFoodDetails.Add(HostFoodDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteHostFoodDetail(HostFoodDetail HostFoodDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.HostFoodDetails.SingleOrDefault(x => x.HostId == HostFoodDetail.HostId && x.FoodId == HostFoodDetail.FoodId);
                    context.HostFoodDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateHostFoodDetail(HostFoodDetail HostFoodDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<HostFoodDetail>(HostFoodDetail).State =
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
