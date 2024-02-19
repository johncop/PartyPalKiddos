using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IPackageTagRepository
    {
        void addPackageTag(PackageTag pt);
        void removePackageTag(PackageTag pt);
        void UpdatePackageTag(PackageTag pt);
        List<PackageTag> GetPackageTag();
        List<PackageTag> GetPackageByCategoryId(int categoryId);
        List<PackageTag> GetCategoryByPackageId(int packageId);
        PackageTag GetPackageTagByPackageId(int id);
    }
}
