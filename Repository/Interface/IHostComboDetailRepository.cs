using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IHostComboDetailRepository
    {
        void addHostComboDetail(HostComboDetail hcd);
        void removeHostComboDetail(HostComboDetail hcd);
        void UpdateHostComboDetail(HostComboDetail hcd);
        List<HostComboDetail> GetAllHostComboDetails();
        List<HostComboDetail> GetHostComboDetailById(int id);
        HostComboDetail GetHostComboDetailByIds(int hostId, int comboId, int foodId);
    }
}
