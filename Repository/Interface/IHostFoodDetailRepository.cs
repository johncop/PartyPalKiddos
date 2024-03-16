using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IHostFoodDetailRepository
    {
        void addHostFoodDetail(HostFoodDetail hfd);
        void removeHostFoodDetail(HostFoodDetail hfd);
        void UpdateHostFoodDetail(HostFoodDetail hfd);
        List<HostFoodDetail> GetAllHostFoodDetails();
        List<HostFoodDetail> GetHostFoodDetailById(int id);
        HostFoodDetail GetHostFoodDetailByIds(int hostId, int foodId);
    }
}
