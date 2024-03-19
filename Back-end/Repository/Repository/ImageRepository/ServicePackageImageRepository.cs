using BusinessObject.Models;
using DataAccess.ImageDAO;
using Repository.Interface.IImageRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.ImageRepository
{
    public class ServicePackageImageRepository : IServicePackageImageRepository
    {
        public void addServicePackageImage(ServicePackageImage pi) => ServicePackageImageDAO.SaveServicePackageImage(pi);

        public List<ServicePackageImage> GetAllServicePackageImages() => ServicePackageImageDAO.GetServicePackageImages();

        public ServicePackageImage GetServicePackageImageById(int id) => ServicePackageImageDAO.findServicePackageImageById(id);

        public void removeServicePackageImage(ServicePackageImage pi) => ServicePackageImageDAO.DeleteServicePackageImage(pi);

        public void UpdateServicePackageImage(ServicePackageImage pi) => ServicePackageImageDAO.UpdateServicePackageImage(pi);
    }
}
