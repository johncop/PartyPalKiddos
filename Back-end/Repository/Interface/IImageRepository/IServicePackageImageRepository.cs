using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.IImageRepository
{
    public interface IServicePackageImageRepository
    {
        void addServicePackageImage(ServicePackageImage pi);
        void removeServicePackageImage(ServicePackageImage pi);
        void UpdateServicePackageImage(ServicePackageImage pi);
        List<ServicePackageImage> GetAllServicePackageImages();
        ServicePackageImage GetServicePackageImageById(int id);
    }
}
