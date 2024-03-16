using BusinessObject.Models;
using DataAccess.Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class HostComboDetailRepository : IHostComboDetailRepository
    {
        public void addHostComboDetail(HostComboDetail hcd) => HostComboDetailDAO.SaveHostComboDetail(hcd);

        public List<HostComboDetail> GetAllHostComboDetails() => HostComboDetailDAO.GetHostComboDetails();

        public HostComboDetail GetHostComboDetailByIds(int hostId, int comboId) => HostComboDetailDAO.GetHostComboDetailByIds(hostId, comboId);

        public List<HostComboDetail> GetHostComboDetailById(int id) => HostComboDetailDAO.FindHostComboDetailById(id);

        public void removeHostComboDetail(HostComboDetail hcd) => HostComboDetailDAO.DeleteHostComboDetail(hcd);

        public void UpdateHostComboDetail(HostComboDetail hcd) => HostComboDetailDAO.UpdateHostComboDetail(hcd);
    }
}
