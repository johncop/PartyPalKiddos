using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IServicePackageRepository
    {
        void addServicePackage(ServicePackage p);
        void removeServicePackage(ServicePackage p);
        void UpdateServicePackage(ServicePackage p);
        //void CloneServicePackage(ServicePackage existingServicePackage, string? ServicePackageName, int? numberOfKid, int? numberOfAdult, int? userId, int? locationId ,DateTime? startTime, DateTime? endTime, decimal? price);
        List<ServicePackage> GetAllServicePackage();
        ServicePackage GetServicePackageById(int id);
        List<ServicePackage> GetServicePackagetByName(string packgakeName);
        //List<ServicePackage> GetServicePackagetByHostId(int hostId);
        //bool isTimeSlotAvaiable(int? locationId, DateTime? startTime, DateTime? endTime);
    }
}
