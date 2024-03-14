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
    public class ServicePackageRepository : IServicePackageRepository
    {
        public void addServicePackage(ServicePackage p) => ServicePackageDAO.SaveServicePackage(p);

        public void removeServicePackage(ServicePackage p) => ServicePackageDAO.DeleteServicePackage(p);

        public void UpdateServicePackage(ServicePackage p) => ServicePackageDAO.UpdateServicePackage(p);

        public List<ServicePackage> GetAllServicePackage() => ServicePackageDAO.GetServicePackages();

        public ServicePackage GetServicePackageById(int id) => ServicePackageDAO.findServicePackageById(id);

        public List<ServicePackage> GetServicePackagetByName(string packgakeName) => ServicePackageDAO.findServicePackageByName(packgakeName);
        public List<ServicePackage> GetServicePackagetByHostId(int hostId) => ServicePackageDAO.findServicePackageByHostId(hostId);

       /* public bool isTimeSlotAvaiable(int? locationId, DateTime? startTime, DateTime? endTime)
            => ServicePackageDAO.IsTimeSlotAvailable(locationId, startTime, endTime);*/

        


    }
}
