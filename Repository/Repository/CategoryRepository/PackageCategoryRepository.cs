using BusinessObject.Models;
using DataAccess.CategoryDAO;
using Repository.Interface.ICategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.CategoryRepository
{
    public class PackageCategoryRepository : IPackageCategoryRepository
    {
        public void addPackageCategory(PackageCategory dc) => PackageCategoryDAO.SavePackageCategory(dc);

        public List<PackageCategory> GetAllPackageCategory() => PackageCategoryDAO.GetPackageCategory();

        public PackageCategory GetPackageCategoryById(int id) => PackageCategoryDAO.findPackageCategoryById(id);

        public List<PackageCategory> GetPackageCategoryByName(string PackageCategoryName) => PackageCategoryDAO.findPackageCategoryByName(PackageCategoryName);

        public void removePackageCategory(PackageCategory dc) => PackageCategoryDAO.DeletePackageCategory(dc);

        public void UpdatePackageCategory(PackageCategory dc) => PackageCategoryDAO.UpdatePackageCategory(dc);
    }
}
