using BusinessObject.Models;
using Repository.Interface.ICategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.CategoryRepository
{
    public class ServiceCategoryRepository : IServiceCategoryRepository
    {
        public void addServiceCategory(ServiceCategory sc)
        {
            throw new NotImplementedException();
        }

        public List<ServiceCategory> GetAllServiceCategory()
        {
            throw new NotImplementedException();
        }

        public ServiceCategory GetServiceCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ServiceCategory> GetServiceCategoryByName(string ServiceCategoryName)
        {
            throw new NotImplementedException();
        }

        public void removeServiceCategory(ServiceCategory sc)
        {
            throw new NotImplementedException();
        }

        public void UpdateServiceCategory(ServiceCategory sc)
        {
            throw new NotImplementedException();
        }
    }
}
