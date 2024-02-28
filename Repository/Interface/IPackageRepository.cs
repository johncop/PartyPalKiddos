using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IPackageRepository
    {
        void addPackage(Package p);
        void removePackage(Package p);
        void UpdatePackage(Package p);
        void ClonePackage(Package existingPackage, string? packageName, int? numberOfKid, int? numberOfAdult, int? userId, int locationId ,DateTime? startTime, DateTime? endTime, decimal? price);
        List<Package> GetAllPackage();
        Package GetPackageById(int id);
        List<Package> GetPackagetByName(string packgakeName);
        List<Package> GetPackagetByUserId(int userId);
        bool isTimeSlotAvaiable(int? locationId, DateTime? startTime, DateTime? endTime);
    }
}
