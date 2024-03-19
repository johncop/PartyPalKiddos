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
    public class ServiceRepository : IServiceRepository
    {
        public void addService(Service s) => ServiceDAO.Saveservice(s);

        public List<Service> GetAllService() => ServiceDAO.Getservices();

        public Service GetServiceById(int id) => ServiceDAO.findserviceById(id);

        public List<Service> GetServiceByName(string serviceName) => ServiceDAO.findserviceByName(serviceName);

        public void removeService(Service s) => ServiceDAO.Deleteservice(s);

        public void UpdateService(Service s) => ServiceDAO.Updateservice(s);
    }
}
