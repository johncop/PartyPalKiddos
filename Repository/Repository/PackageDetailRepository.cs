/*using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PackageDetailRepository : IPackageDetailRepository
    {
        public void addPackageDetail(PackageDetail pd) => PackageDetailDAO.SavePackageDetail(pd);

        public List<PackageDetail> GetAllPackageDetail() => PackageDetailDAO.GetPackageDetails();

        public PackageDetail GetPackageDetailByPackageId(int packageId) => PackageDetailDAO.findPackageDetailByPackageId(packageId);

        public List<PackageDetail> GetServiceByPackageId(int packageId) => PackageDetailDAO.findServiceByPackageId(packageId);

        public void removePackageDetail(PackageDetail pd) => PackageDetailDAO.DeletePackageDetail(pd);

        public void UpdatePackageDetail(PackageDetail pd) => PackageDetailDAO.UpdatePackageDetail(pd);
    }
}
*/