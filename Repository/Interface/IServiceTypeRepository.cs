using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IServiceTypeRepository
    {
        void addServiceType(ServiceType st);
        void removeServiceType(ServiceType st);
        void updateServiceType(ServiceType st);
        List<ServiceType> GetAllServiceType();
        ServiceType GetServiceTypeById(int id);
        List<ServiceType> GetAllServiceTypeByName(string ServiceTypeName);
    }
}
