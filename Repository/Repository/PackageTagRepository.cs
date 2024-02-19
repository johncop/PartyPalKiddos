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
    public class PackageTagRepository : IPackageTagRepository
    {
        public void addPackageTag(PackageTag pt) => PackageTagDAO.SavePackageTag(pt);

        public List<PackageTag> GetCategoryByPackageId(int packageId) => PackageTagDAO.findCategoryByPackageId(packageId);

        public List<PackageTag> GetPackageByCategoryId(int categoryId) => PackageTagDAO.findPackageByCategoryId(categoryId);

        public List<PackageTag> GetPackageTag() => PackageTagDAO.GetPackageTags();

        public PackageTag GetPackageTagByPackageId(int id) => PackageTagDAO.findPackageTagByPackageId(id);

        public void removePackageTag(PackageTag pt) => PackageTagDAO.DeletePackageTag(pt);

        public void UpdatePackageTag(PackageTag pt) => PackageTagDAO.UpdatePackageTag(pt);
    }
}
