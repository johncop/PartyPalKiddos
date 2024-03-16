using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IHostServicePackageDetailRepository
    {
        void addHostServicePackageDetail(HostServicePackageDetail hostServicePackageDetail);
        void removeHostServicePackageDetail(HostServicePackageDetail hostServicePackageDetail);
        void UpdateHostServicePackageDetail(HostServicePackageDetail hostServicePackageDetail);
        List<HostServicePackageDetail> GetAllHostServicePackageDetails();
        List<HostServicePackageDetail> GetHostServicePackageDetailById(int id);
        HostServicePackageDetail GetHostServicePackageDetailByIds(int hostId, int servicePackageId);
    }
}
