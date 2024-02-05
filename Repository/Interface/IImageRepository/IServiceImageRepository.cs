using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Image
{
    public interface IServiceImageRepository
    {
        void addServiceImage(ServiceImage si);
        void removeServiceImage(ServiceImage si);
        void UpdateServiceImage(ServiceImage si);
        List<ServiceImage> GetAllServiceImages();
        ServiceImage GetServiceImageById(int id);
    }
}
