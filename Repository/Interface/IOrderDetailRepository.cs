using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOrderDetailRepository
    {
        void addOrderDetail(OrderDetail od);
        void removeOrderDetail(OrderDetail od);
        void UpdateOrderDetail(OrderDetail od);
        List<OrderDetail> GetOrderDetail();
    }
}
