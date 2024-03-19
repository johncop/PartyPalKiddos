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
    public class ServicePackageDetailRepository : IServicePackageDetailRepository
    {
        public void addServicePackageDetail(ServicePackageDetail ServicePackageDetail) 
            => ServicePackageDetailDAO.SaveServicePackageDetail(ServicePackageDetail);

        public List<ServicePackageDetail> GetAllServicePackageDetail() 
            => ServicePackageDetailDAO.GetServicePackageDetails();

        public List<ServicePackageDetail> GetServicePackageDetailByServicePackageId(int servicePackageId) 
            => ServicePackageDetailDAO.findServicePackageDetailServicePackageId(servicePackageId);

        public ServicePackageDetail GetServicePackageDetails(int servicePackageId, int serviceId)
            => ServicePackageDetailDAO.GetServicePackageDetails(servicePackageId, serviceId);

        public void removeServicePackageDetail(ServicePackageDetail ServicePackageDetail) 
            => ServicePackageDetailDAO.DeleteServicePackageDetail(ServicePackageDetail);

        public void UpdateServicePackageDetail(ServicePackageDetail ServicePackageDetail) 
            => ServicePackageDetailDAO.UpdateServicePackageDetail(ServicePackageDetail);
    }
}
