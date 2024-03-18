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
                        .Include(p=>p.ServicePackage)
                        .Include(p=>p.Service)
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

        public static ServicePackageDetail GetServicePackageDetails(int servicePackageId, int serviceId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming BookingFoodDetail is a class that represents a single row in your database
                    var bookingFoodDetail = context.ServicePackageDetails
                        .Where(detail => detail.ServicePackageId == servicePackageId && detail.ServiceId == serviceId)
                        .Select(detail => new ServicePackageDetail
                        {
                            ServicePackageId = detail.ServicePackageId,
                            ServiceId = detail.ServiceId,
                            Quantity = detail.Quantity,
                        }).FirstOrDefault(); // Change this line

                    return bookingFoodDetail; // This now correctly matches the method signature
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message); // Consider specific exception handling or logging
            }
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
                    var p1 = context.ServicePackageDetails.SingleOrDefault(x => x.ServicePackageId == ServicePackageDetail.ServicePackageId && x.ServiceId == ServicePackageDetail.ServiceId);
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
