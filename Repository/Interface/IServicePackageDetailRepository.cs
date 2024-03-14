 using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IServicePackageDetailRepository
    {
        void addServicePackageDetail(ServicePackageDetail ServicePackageDetail);
        void removeServicePackageDetail(ServicePackageDetail ServicePackageDetail);
        void UpdateServicePackageDetail(ServicePackageDetail ServicePackageDetail);
        List<ServicePackageDetail> GetServicePackageDetailByServicePackageId(int servicePackageId);
        List<ServicePackageDetail> GetAllServicePackageDetail();
    }
}
