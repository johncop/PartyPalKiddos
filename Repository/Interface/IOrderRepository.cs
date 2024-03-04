using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOrderRepository
    {
        void addOrder(Order o);
        void removeOrder(Order o);
        void UpdateOrder(Order o);
        List<Order> GetOrder();
        List<Order> GetOrderByUserId(int userId);
        Order GetOrderByOrderId(int id);
    }
}
