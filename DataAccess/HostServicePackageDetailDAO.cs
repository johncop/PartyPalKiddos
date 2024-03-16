using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HostServicePackageDetailDAO
    {
        #region QUERY
        public static List<HostServicePackageDetail> GetHostServicePackageDetails()
        {
            var listHostServicePackageDetails = new List<HostServicePackageDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listHostServicePackageDetails = context.HostServicePackageDetails
                    .Select(hcd => new HostServicePackageDetail
                    {
                        HostId = hcd.HostId,
                        ServicePackageId = hcd.ServicePackageId,
                        Host = hcd.Host,
                        ServicePackage = hcd.ServicePackage,
                    })
                    .ToList();
                    return listHostServicePackageDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<HostServicePackageDetail> FindHostServicePackageDetailById(int hostId)
        {
            var listHostServicePackageDetails = new List<HostServicePackageDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listHostServicePackageDetails = context.HostServicePackageDetails
                        .Where(hcd => hcd.HostId == hostId)
                    .Select(hcd => new HostServicePackageDetail
                    {
                        HostId = hcd.HostId,
                        ServicePackageId = hcd.ServicePackageId,
                        Host = hcd.Host,
                        ServicePackage = hcd.ServicePackage,
                    })
                    .ToList();
                    return listHostServicePackageDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static HostServicePackageDetail GetHostServicePackageDetailByIds(int hostId, int servicePackageId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var hcd = context.HostServicePackageDetails
                         .Where(hcd => hcd.HostId == hostId && hcd.ServicePackageId == servicePackageId)
                     .Select(hcd => new HostServicePackageDetail
                     {
                         HostId = hcd.HostId,
                         ServicePackageId = hcd.ServicePackageId,
                         Host = hcd.Host,
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

        public static void SaveHostServicePackageDetail(HostServicePackageDetail HostServicePackageDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.HostServicePackageDetails.Add(HostServicePackageDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteHostServicePackageDetail(HostServicePackageDetail HostServicePackageDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.HostServicePackageDetails.SingleOrDefault(x => x.HostId == HostServicePackageDetail.HostId && x.ServicePackageId == HostServicePackageDetail.ServicePackageId);
                    context.HostServicePackageDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateHostServicePackageDetail(HostServicePackageDetail HostServicePackageDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<HostServicePackageDetail>(HostServicePackageDetail).State =
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
