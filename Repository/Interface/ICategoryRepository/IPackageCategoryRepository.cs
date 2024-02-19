using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.ICategoryRepository
{
    public interface IPackageCategoryRepository
    {
        void addPackageCategory(PackageCategory dc);
        void removePackageCategory(PackageCategory dc);
        void UpdatePackageCategory(PackageCategory dc);
        PackageCategory GetPackageCategoryById(int id);
        List<PackageCategory> GetPackageCategoryByName(string PackageCategoryName);
        List<PackageCategory> GetAllPackageCategory();
    }
}
