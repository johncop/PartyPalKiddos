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
    public class HostFoodDetailRepository : IHostFoodDetailRepository
    {
        public void addHostFoodDetail(HostFoodDetail hfd) => HostFoodDetailDAO.SaveHostFoodDetail(hfd);

        public List<HostFoodDetail> GetAllHostFoodDetails() => HostFoodDetailDAO.GetHostFoodDetails();

        public List<HostFoodDetail> GetHostFoodDetailById(int id) => HostFoodDetailDAO.FindHostFoodDetailById(id);

        public HostFoodDetail GetHostFoodDetailByIds(int hostId, int foodId) => HostFoodDetailDAO.GetHostFoodDetailByIds(hostId, foodId);

        public void removeHostFoodDetail(HostFoodDetail hfd) => HostFoodDetailDAO.DeleteHostFoodDetail(hfd);

        public void UpdateHostFoodDetail(HostFoodDetail hfd) => HostFoodDetailDAO.UpdateHostFoodDetail(hfd);
    }
}
