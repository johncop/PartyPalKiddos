using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IPackageDetailRepository
    {
        void addPackageDetail(PackageDetail pd);
        void removePackageDetail(PackageDetail pd);
        void UpdatePackageDetail(PackageDetail pd);
        List<PackageDetail> GetAllPackageDetail();
        PackageDetail GetPackageDetailByPackageId(int packageId);
        List<PackageDetail> GetServiceByPackageId(int packageId);
    }
}
