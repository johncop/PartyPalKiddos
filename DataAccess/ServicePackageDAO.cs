using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ServicePackageDAO
    {
        #region query
        public static List<ServicePackage> GetServicePackages()
        {
            var listServicePackage = new List<ServicePackage>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listServicePackage = context.ServicePackages
                        .Include(p => p.Host)
                        .Include(p => p.ServicePackageImages)
                .Select(ServicePackage => new ServicePackage
                {
                    Id = ServicePackage.Id,
                    PackageName = ServicePackage.PackageName,
                    Price = ServicePackage.Price,
                    HostId= ServicePackage.HostId,
                    Status= ServicePackage.Status,
                    Host = ServicePackage.Host,
                    ServicePackageImages= ServicePackage.ServicePackageImages,
                }).ToList();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listServicePackage;
        }


        public static ServicePackage findServicePackageById(int id)
        {
            ServicePackage p = new ServicePackage();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    p = context.ServicePackages
                .Select(ServicePackage => new ServicePackage
                {
                    Id = ServicePackage.Id,
                    PackageName = ServicePackage.PackageName,
                    Price = ServicePackage.Price,
                    HostId = ServicePackage.HostId,
                    Status = ServicePackage.Status,
                    Host = ServicePackage.Host,
                    ServicePackageImages = ServicePackage.ServicePackageImages,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static List<ServicePackage> findServicePackageByName(string ServicePackageName)
        {
            List<ServicePackage> p = new List<ServicePackage>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    p = context.ServicePackages
                .Where(ServicePackage => ServicePackage.PackageName.Contains(ServicePackageName))
                .Select(ServicePackage => new ServicePackage
                {
                    Id = ServicePackage.Id,
                    PackageName = ServicePackage.PackageName,
                    Price = ServicePackage.Price,
                    HostId = ServicePackage.HostId,
                    Status = ServicePackage.Status,
                    Host = ServicePackage.Host,
                    ServicePackageImages = ServicePackage.ServicePackageImages,
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }
        public static List<ServicePackage> findServicePackageByHostId(int hostId)
        {
            List<ServicePackage> p = new List<ServicePackage>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    p = context.ServicePackages
                .Where(ServicePackage => ServicePackage.HostId == hostId)
                .Select(ServicePackage => new ServicePackage
                {
                    Id = ServicePackage.Id,
                    PackageName = ServicePackage.PackageName,
                    Price = ServicePackage.Price,
                    HostId = ServicePackage.HostId,
                    Status = ServicePackage.Status,
                    Host = ServicePackage.Host,
                    ServicePackageImages = ServicePackage.ServicePackageImages,
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }
        #endregion

        #region command
        public static void SaveServicePackage(ServicePackage p)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.ServicePackages.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteServicePackage(ServicePackage p)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var ServicePackageDetails = context.ServicePackageDetails.Where(pd => pd.ServicePackageId == p.Id);
                    context.ServicePackageDetails.RemoveRange(ServicePackageDetails);

                    var p1 = context.ServicePackages.SingleOrDefault(x => x.Id == p.Id);
                    context.ServicePackages.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateServicePackage(ServicePackage p)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<ServicePackage>(p).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        /*public static ServicePackage CloneServicePackage(ServicePackage existingServicePackage, string? ServicePackageName, int? numberOfKid, int? numberOfAdult, int? userId, int? locationId, DateTime? startTime, DateTime? endTime, decimal? price)
        {
            var context = new PartyPalKiddosDBContext();
            // Create a new ServicePackage with the customized details
            ServicePackage newServicePackage = new ServicePackage()
            {
                ServicePackageName = ServicePackageName ?? existingServicePackage.ServicePackageName,
                NumberOfKids = numberOfKid ?? existingServicePackage.NumberOfKids,
                NumberOfAdults = numberOfAdult ?? existingServicePackage.NumberOfAdults,
                UserId = userId ?? existingServicePackage.UserId,
                LocationId = locationId ?? existingServicePackage.LocationId,
                StartTime = startTime ?? existingServicePackage.StartTime,
                EndTime = endTime ?? existingServicePackage.EndTime,
                Price = price ?? existingServicePackage.Price,
                Status = 2,
                ServicePackageDetails = new List<ServicePackageDetail>()
            };
            var ServicePackageDetails = context.ServicePackageDetails.Where(pd => pd.ServicePackageId == existingServicePackage.Id);
            foreach (var detail in ServicePackageDetails)
            {
                var clonedDetail = new ServicePackageDetail()
                {
                    ServiceId = detail.ServiceId,
                    Quantity = detail.Quantity,
                    ServicePackageId = detail.ServicePackageId,
                    // Clone additional fields if necessary
                };
                newServicePackage.ServicePackageDetails.Add(clonedDetail); // Add the cloned details to the new ServicePackage
            }

            return newServicePackage;
        }*/
        #endregion

        #region validation
        /*public static bool IsTimeSlotAvailable(int? locationId, DateTime? startTime, DateTime? endTime)
        {
            using (var context = new PartyPalKiddosDBContext())
            {
                return !context.ServicePackages.Any(p =>
                p.LocationId == locationId &&
                ((startTime >= p.StartTime && startTime < p.EndTime) ||
                (endTime > p.StartTime && endTime <= p.EndTime) ||
                (startTime <= p.StartTime && endTime >= p.EndTime)));
            }
        }*/
        #endregion
    }
}
