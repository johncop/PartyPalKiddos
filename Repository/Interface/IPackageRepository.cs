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
        List<Package> GetAllPackage();
        Package GetPackageById(int id);
        List<Package> GetPackagetByName(string packgakeName);
        
    }
}
