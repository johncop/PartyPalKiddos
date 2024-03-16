using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HostServiceDetailDAO
    {
        #region QUERY
        public static List<HostServiceDetail> GetHostServiceDetails()
        {
            var listHostServiceDetails = new List<HostServiceDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listHostServiceDetails = context.HostServiceDetails
                    .Select(hcd => new HostServiceDetail
                    {
                        HostId = hcd.HostId,
                        ServiceId= hcd.ServiceId,
                        Host = hcd.Host,
                        Service = hcd.Service,
                    })
                    .ToList();
                    return listHostServiceDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<HostServiceDetail> FindHostServiceDetailById(int hostId)
        {
            var listHostServiceDetails = new List<HostServiceDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listHostServiceDetails = context.HostServiceDetails
                        .Where(hcd => hcd.HostId == hostId)
                    .Select(hcd => new HostServiceDetail
                    {
                        HostId = hcd.HostId,
                        ServiceId = hcd.ServiceId,
                        Host = hcd.Host,
                        Service = hcd.Service,
                    })
                    .ToList();
                    return listHostServiceDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static HostServiceDetail GetHostServiceDetailByIds(int hostId, int foodId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var hcd = context.HostServiceDetails
                         .Where(hcd => hcd.HostId == hostId && hcd.ServiceId == foodId)
                     .Select(hcd => new HostServiceDetail
                     {
                         HostId = hcd.HostId,
                         ServiceId = hcd.ServiceId,
                         Host = hcd.Host,
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

        public static void SaveHostServiceDetail(HostServiceDetail HostServiceDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.HostServiceDetails.Add(HostServiceDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteHostServiceDetail(HostServiceDetail HostServiceDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.HostServiceDetails.SingleOrDefault(x => x.HostId == HostServiceDetail.HostId && x.FoodId == HostServiceDetail.FoodId);
                    context.HostServiceDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateHostServiceDetail(HostServiceDetail HostServiceDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<HostServiceDetail>(HostServiceDetail).State =
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
