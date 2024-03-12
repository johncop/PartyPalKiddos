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
    public class HostImageRepository : IHostImageRepository
    {
        public void addHostImage(HostImage li) => HostImageDAO.SaveHostImage(li);

        public List<HostImage> GetAllHostImages() => HostImageDAO.GetHostImages();

        public HostImage GetHostImageById(int id) => HostImageDAO.findHostImageById(id);

        public void removeHostImage(HostImage li) => HostImageDAO.DeleteHostImage(li);

        public void UpdateHostImage(HostImage li) => HostImageDAO.UpdateHostImage(li);
    }
}
