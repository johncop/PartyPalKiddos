using BusinessObject.Models;
using DataAccess.CategoryDAO;
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
        public void addServiceCategory(ServiceCategory sc) => ServiceCategoryDAO.SaveServiceCategory(sc);

        public List<ServiceCategory> GetAllServiceCategory() => ServiceCategoryDAO.GetServiceCategorys();

        public ServiceCategory GetServiceCategoryById(int id) => ServiceCategoryDAO.findServiceCategoryById(id);

        public List<ServiceCategory> GetServiceCategoryByName(string ServiceCategoryName) => ServiceCategoryDAO.findServiceCategoryByName(ServiceCategoryName);

        public void removeServiceCategory(ServiceCategory sc) => ServiceCategoryDAO.DeleteServiceCategory(sc);

        public void UpdateServiceCategory(ServiceCategory sc) => ServiceCategoryDAO.UpdateServiceCategory(sc);
    }
}
