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
    public class HostRepository : IHostRepository
    {
        public void addHost(Host host) => HostDAO.SaveHost(host);

        public List<Host> GetAllHost() => HostDAO.GetHosts();

        public Host GetHostById(int id) => HostDAO.findHostById(id);

        public List<Host> GetHostByName(string address) => HostDAO.findHostByName(address);

        public void removeHost(Host host) => HostDAO.DeleteHost(host);

        public void UpdateHost(Host host) => HostDAO.UpdateHost(host);
    }
}
