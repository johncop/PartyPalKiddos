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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void addOrderDetail(OrderDetail od) => OrderDetailDAO.SaveOrderDetail(od);

        public List<OrderDetail> GetOrderDetail() => OrderDetailDAO.GetOrderDetails();

        public void removeOrderDetail(OrderDetail od) => OrderDetailDAO.DeleteOrderDetail(od);

        public void UpdateOrderDetail(OrderDetail od) => OrderDetailDAO.UpdateOrderDetail(od);
    }
}
