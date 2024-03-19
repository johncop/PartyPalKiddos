using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IServiceRepository
    {
        void addService(Service s);
        void removeService(Service s);
        void UpdateService(Service s);
        Service GetServiceById(int id);
        List<Service> GetServiceByName(string serviceName);

        List<Service> GetAllService();
    }
}
