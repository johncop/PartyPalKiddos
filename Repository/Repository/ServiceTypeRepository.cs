/*using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        public void addServiceType(ServiceType st) => ServiceTypeDAO.SaveServiceType(st);

        public List<ServiceType> GetAllServiceType()
=> ServiceTypeDAO.GetServiceTypes();

        public List<ServiceType> GetAllServiceTypeByName(string ServiceTypeName)
=> ServiceTypeDAO.findServiceTypeByName(ServiceTypeName);

        public ServiceType GetServiceTypeById(int id)
=> ServiceTypeDAO.findServiceTypeById(id);

        public void removeServiceType(ServiceType st)
=> ServiceTypeDAO.DeleteServiceType(st);

        public void updateServiceType(ServiceType st)
=> ServiceTypeDAO.UpdateServiceType(st);
    }
}
*/