using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PackageDAO
    {
        #region query
        public static List<Package> GetPackages()
        {
            var listPackage = new List<Package>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listPackage = context.Packages
                        .Include(p => p.PackageDetails)
                        .ThenInclude(pd => pd.Service)
                        .Include(p => p.PackageImages)
                .Select(package => new Package
                {
                    Id = package.Id,
                    PackageName = package.PackageName,
                    NumberOfKids = package.NumberOfKids,
                    NumberOfAdults= package.NumberOfAdults,
                    StartTime = package.StartTime,
                    EndTime = package.EndTime,
                    UserId = package.UserId,
                    LocationId= package.LocationId,
                    Price = package.Price,
                    Status = package.Status,
                    PackageImages = package.PackageImages,
                    PackageDetails = package.PackageDetails.Select(pd => new PackageDetail
                    {
                        // Assuming PackageDetail has a ServiceId and a Quantity property
                        ServiceId = pd.ServiceId,
                        Quantity = pd.Quantity,
                        // Map the Service properties you need
                        Service = new Service
                        {
                            Id = pd.Service.Id,
                            ServiceName = pd.Service.ServiceName,
                            // ... include other properties as needed
                        }
                    }).ToList()
                }).ToList();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listPackage;
        }
    

        public static Package findPackageById(int id)
        {
            Package p = new Package();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.Packages
                .Select(package => new Package
                {
                    Id = package.Id,
                    PackageName = package.PackageName,
                    NumberOfKids = package.NumberOfKids,
                    NumberOfAdults = package.NumberOfAdults,
                    StartTime = package.StartTime,
                    EndTime = package.EndTime,
                    UserId = package.UserId,
                    LocationId = package.LocationId,
                    Price = package.Price,
                    Status = package.Status,
                    PackageDetails = package.PackageDetails.Select(pd => new PackageDetail
                    {
                        // Assuming PackageDetail has a ServiceId and a Quantity property
                        ServiceId = pd.ServiceId,
                        Quantity = pd.Quantity,
                        // Map the Service properties you need
                        Service = new Service
                        {
                            Id = pd.Service.Id,
                            ServiceName = pd.Service.ServiceName,
                            // ... include other properties as needed
                        }
                    }).ToList()
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static List<Package> findPackageByName(string packageName)
        {
            List<Package> p = new List<Package>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.Packages
                .Where(package => package.PackageName.Contains(packageName))
                .Select(package => new Package
                {
                    Id = package.Id,
                    PackageName = package.PackageName,
                    NumberOfKids = package.NumberOfKids,
                    NumberOfAdults = package.NumberOfAdults,
                    StartTime = package.StartTime,
                    EndTime = package.EndTime,
                    UserId = package.UserId,
                    LocationId = package.LocationId,
                    Price = package.Price,
                    Status = package.Status,
                    PackageDetails = package.PackageDetails.Select(pd => new PackageDetail
                    {
                        // Assuming PackageDetail has a ServiceId and a Quantity property
                        ServiceId = pd.ServiceId,
                        Quantity = pd.Quantity,
                        // Map the Service properties you need
                        Service = new Service
                        {
                            Id = pd.Service.Id,
                            ServiceName = pd.Service.ServiceName,
                            // ... include other properties as needed
                        }
                    }).ToList()
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }
        public static List<Package> findPackageByUserId(int id)
        {
            List<Package> p = new List<Package>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.Packages
                .Where(package => package.UserId == id)
                .Select(package => new Package
                {
                    Id = package.Id,
                    PackageName = package.PackageName,
                    NumberOfKids = package.NumberOfKids,
                    NumberOfAdults = package.NumberOfAdults,
                    StartTime = package.StartTime,
                    EndTime = package.EndTime,
                    UserId = package.UserId,
                    LocationId = package.LocationId,
                    Price = package.Price,
                    Status = package.Status,
                    PackageDetails = package.PackageDetails.Select(pd => new PackageDetail
                    {
                        // Assuming PackageDetail has a ServiceId and a Quantity property
                        ServiceId = pd.ServiceId,
                        Quantity = pd.Quantity,
                        // Map the Service properties you need
                        Service = new Service
                        {
                            Id = pd.Service.Id,
                            ServiceName = pd.Service.ServiceName,
                            // ... include other properties as needed
                        }
                    }).ToList()
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
        public static void SavePackage(Package p)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Packages.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeletePackage(Package p)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var packageDetails = context.PackageDetails.Where(pd => pd.PackageId == p.Id).ToList();
                    context.PackageDetails.RemoveRange(packageDetails);

                    var p1 = context.Packages.SingleOrDefault(x => x.Id == p.Id);
                    context.Packages.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdatePackage(Package p)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<Package>(p).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static Package ClonePackage(Package existingPackage, string? packageName, int? numberOfKid, int? numberOfAdult, int? userId, int? locationId, DateTime? startTime, DateTime? endTime, decimal? price)
        {
            var context = new PartyPalKiddosContext();
            // Create a new package with the customized details
            Package newPackage = new Package()
            {
                PackageName = packageName ?? existingPackage.PackageName,
                NumberOfKids = numberOfKid ?? existingPackage.NumberOfKids,
                NumberOfAdults = numberOfAdult ?? existingPackage.NumberOfAdults,
                UserId = userId ?? existingPackage.UserId,
                LocationId = locationId ?? existingPackage.LocationId,
                StartTime = startTime ?? existingPackage.StartTime,
                EndTime = endTime ?? existingPackage.EndTime,
                Price = price ?? existingPackage.Price,
                Status = 2,
                PackageDetails = new List<PackageDetail>()
            };
            var packageDetails = context.PackageDetails.Where(pd => pd.PackageId == existingPackage.Id);
            foreach (var detail in packageDetails)
            {
                var clonedDetail = new PackageDetail()
                {
                    ServiceId = detail.ServiceId,
                    Quantity = detail.Quantity,
                    PackageId= detail.PackageId,
                    // Clone additional fields if necessary
                };
                newPackage.PackageDetails.Add(clonedDetail); // Add the cloned details to the new package
            }

            return newPackage;
        }
        #endregion

        #region validation
        public static bool IsTimeSlotAvailable(int? locationId, DateTime? startTime, DateTime? endTime)
        {
            using (var context = new PartyPalKiddosContext())
            {
                return !context.Packages.Any(p =>
                p.LocationId == locationId &&
                ((startTime >= p.StartTime && startTime < p.EndTime) ||
                (endTime > p.StartTime && endTime <= p.EndTime) ||
                (startTime <= p.StartTime && endTime >= p.EndTime)));
            }           
        }
        #endregion
    }
}
