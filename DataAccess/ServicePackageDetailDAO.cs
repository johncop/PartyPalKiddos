using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ServicePackageDetailDAO
    {
        #region query
        public static List<ServicePackageDetail> GetServicePackageDetails()
        {
            var listServicePackageDetails = new List<ServicePackageDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listServicePackageDetails = context.ServicePackageDetails
                .Select(ServicePackageDetail => new ServicePackageDetail
                {
                    ServicePackageId = ServicePackageDetail.ServicePackageId,
                    ServiceId = ServicePackageDetail.ServiceId,
                    Quantity = ServicePackageDetail.Quantity,
                    ServicePackage = ServicePackageDetail.ServicePackage,
                    Service = ServicePackageDetail.Service,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listServicePackageDetails;
        }

        public static List<ServicePackageDetail> findServicePackageDetailServicePackageId(int servicePackageId)
        {
            List<ServicePackageDetail> f = new List<ServicePackageDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    f = context.ServicePackageDetails
                     .Where(ServicePackageDetail => ServicePackageDetail.ServicePackageId == servicePackageId)
                .Select(ServicePackageDetail => new ServicePackageDetail
                {
                    ServicePackageId = ServicePackageDetail.ServicePackageId,
                    ServiceId = ServicePackageDetail.ServiceId,
                    Quantity = ServicePackageDetail.Quantity,
                    ServicePackage = ServicePackageDetail.ServicePackage,
                    Service = ServicePackageDetail.Service,
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
        public static void SaveServicePackageDetail(ServicePackageDetail f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.ServicePackageDetails.Add(f);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteServicePackageDetail(ServicePackageDetail ServicePackageDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.ServicePackageDetails.SingleOrDefault(x => x.ServicePackageId == ServicePackageDetail.ServicePackageId);
                    context.ServicePackageDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateServicePackageDetail(ServicePackageDetail ServicePackageDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<ServicePackageDetail>(ServicePackageDetail).State =
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
