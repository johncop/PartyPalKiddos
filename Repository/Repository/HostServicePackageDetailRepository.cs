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
    public class HostServicePackageDetailRepository : IHostServicePackageDetailRepository
    {
        public void addHostServicePackageDetail(HostServicePackageDetail hostServicePackageDetail)
            => HostServicePackageDetailDAO.SaveHostServicePackageDetail(hostServicePackageDetail);

        public List<HostServicePackageDetail> GetAllHostServicePackageDetails() => HostServicePackageDetailDAO.GetHostServicePackageDetails();

        public List<HostServicePackageDetail> GetHostServicePackageDetailById(int id) => HostServicePackageDetailDAO.FindHostServicePackageDetailById(id);

        public HostServicePackageDetail GetHostServicePackageDetailByIds(int hostId, int servicePackageId) => HostServicePackageDetailDAO.GetHostServicePackageDetailByIds(hostId, servicePackageId);

        public void removeHostServicePackageDetail(HostServicePackageDetail hostServicePackageDetail) => HostServicePackageDetailDAO.DeleteHostServicePackageDetail(hostServicePackageDetail);

        public void UpdateHostServicePackageDetail(HostServicePackageDetail hostServicePackageDetail) => HostServicePackageDetailDAO.UpdateHostServicePackageDetail(hostServicePackageDetail);
    }
}
