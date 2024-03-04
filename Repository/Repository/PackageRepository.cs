using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PackageRepository : IPackageRepository
    {
        public void addPackage(Package p) => PackageDAO.SavePackage(p);

        public void ClonePackage(Package existingPackage, string? packageName, int? numberOfKid, int? numberOfAdult, int? userId, int? locationId,DateTime? startTime, DateTime? endTime, decimal? price)
            => PackageDAO.ClonePackage(existingPackage, packageName, numberOfKid, numberOfAdult, userId, locationId ,startTime, endTime, price);

        public List<Package> GetAllPackage() => PackageDAO.GetPackages();

        public Package GetPackageById(int id) => PackageDAO.findPackageById(id);

        public List<Package> GetPackagetByName(string packgakeName) => PackageDAO.findPackageByName(packgakeName);
        public List<Package> GetPackagetByUserId(int userId) => PackageDAO.findPackageByUserId(userId);

        public bool isTimeSlotAvaiable(int? locationId, DateTime? startTime, DateTime? endTime) 
            => PackageDAO.IsTimeSlotAvailable(locationId, startTime, endTime);

        public void removePackage(Package p) => PackageDAO.DeletePackage(p);

        public void UpdatePackage(Package p) => PackageDAO.UpdatePackage(p);


    }
}
