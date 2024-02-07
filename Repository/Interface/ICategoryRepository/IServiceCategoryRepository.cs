using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.ICategoryRepository
{
    public interface IServiceCategoryRepository
    {
        void addServiceCategory(ServiceCategory sc);
        void removeServiceCategory(ServiceCategory sc);
        void UpdateServiceCategory(ServiceCategory sc);
        ServiceCategory GetServiceCategoryById(int id);
        List<ServiceCategory> GetServiceCategoryByName(string ServiceCategoryName);
        List<ServiceCategory> GetAllServiceCategory();
    }
}
