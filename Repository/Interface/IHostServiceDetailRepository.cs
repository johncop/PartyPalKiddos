using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IHostServiceDetailRepository
    {
        void addHostServiceDetail(HostServiceDetail hfd);
        void removeHostServiceDetail(HostServiceDetail hfd);
        void UpdateHostServiceDetail(HostServiceDetail hfd);
        List<HostServiceDetail> GetAllHostServiceDetails();
        List<HostServiceDetail> GetHostServiceDetailById(int id);
        HostServiceDetail GetHostServiceDetailByIds(int hostId, int serviceId);
    }
}
