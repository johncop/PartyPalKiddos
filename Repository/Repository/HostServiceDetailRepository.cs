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
    public class HostServiceDetailRepository : IHostServiceDetailRepository
    {
        public void addHostServiceDetail(HostServiceDetail hfd) => HostServiceDetailDAO.SaveHostServiceDetail(hfd);

        public List<HostServiceDetail> GetAllHostServiceDetails()=> HostServiceDetailDAO.GetHostServiceDetails();

        public List<HostServiceDetail> GetHostServiceDetailById(int id)
        => HostServiceDetailDAO.FindHostServiceDetailById(id);

        public HostServiceDetail GetHostServiceDetailByIds(int hostId, int serviceId) => HostServiceDetailDAO.GetHostServiceDetailByIds(hostId, serviceId);

        public void removeHostServiceDetail(HostServiceDetail hfd) => HostServiceDetailDAO.DeleteHostServiceDetail(hfd);

        public void UpdateHostServiceDetail(HostServiceDetail hfd) => HostServiceDetailDAO.UpdateHostServiceDetail(hfd);
    }
}
