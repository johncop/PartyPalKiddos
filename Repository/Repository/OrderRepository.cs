/*using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void addOrder(Order o) => OrderDAO.SaveOrder(o);

        public List<Order> GetOrder() => OrderDAO.GetOrders();

        public Order GetOrderByOrderId(int id) => OrderDAO.findOrderById(id);

        public List<Order> GetOrderByUserId(int userId) => OrderDAO.findOrderByUserId(userId);

        public void removeOrder(Order o) => OrderDAO.DeleteOrder(o);

        public void UpdateOrder(Order o) => OrderDAO.UpdateOrder(o);
    }
}
*/