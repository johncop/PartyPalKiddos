using BusinessObject.Models;
using DataAccess.ImageDAO;
using Repository.Interface.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.ImageRepository
{
    public class ServiceImageRepository : IServiceImageRepository
    {
        public void addServiceImage(ServiceImage si) => ServiceImageDAO.SaveServiceImage(si);

        public List<ServiceImage> GetAllServiceImages() => ServiceImageDAO.GetServiceImages();

        public ServiceImage GetServiceImageById(int id) => ServiceImageDAO.findServiceImageById(id);

        public void removeServiceImage(ServiceImage si) => ServiceImageDAO.DeleteServiceImage(si);

        public void UpdateServiceImage(ServiceImage si) => ServiceImageDAO.UpdateServiceImage(si);
    }
}
