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
    public class OrderServiceRepository : IOrderServiceRepository
    {
        public void addOrderService(OrderService oService) => OrderServiceDAO.SaveOrderService(oService);

        public List<OrderService> GetOrderService() => OrderServiceDAO.GetOrderServices();

        public OrderService GetOrderServiceByPackageId(int id) => OrderServiceDAO.findOrderServiceByPackageId(id);

        public void removeOrderService(OrderService oService) => OrderServiceDAO.DeleteOrderService(oService);

        public void UpdateOrderService(OrderService oService) => OrderServiceDAO.UpdateOrderService(oService);
    }
}
