using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IHostRepository
    {
        void addHost(Host host);
        void removeHost(Host host);
        void UpdateHost(Host host);
        Host GetHostById(int id);
        List<Host> GetHostByName(string address);

        List<Host> GetAllHost();
    }
}
