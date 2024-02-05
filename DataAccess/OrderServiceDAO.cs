using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderServiceDAO
    {
        public static List<OrderService> GetOrderServices()
        {
            var listOrder = new List<OrderService>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listOrder = context.OrderServices
                .Select(order => new OrderService
                {
                    PackageId = order.PackageId,
                    ServiceId = order.ServiceId,
                    ServiceOptionId = order.ServiceOptionId,
                    Quantity = order.Quantity,
                }).ToList();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrder;
        }
        public static OrderService findOrderServiceByPackageId(int id)
        {
            OrderService p = new OrderService();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.OrderServices
                .Select(order => new OrderService
                {
                    PackageId = order.PackageId,
                    ServiceId = order.ServiceId,
                    ServiceOptionId = order.ServiceOptionId,
                    Quantity = order.Quantity,
                }).SingleOrDefault(x => x.PackageId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }
        public static void SaveOrderService(OrderService oService)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.OrderServices.Add(oService);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteOrderService(OrderService oService)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.OrderServices.SingleOrDefault(x => x.PackageId == oService.PackageId);
                    context.OrderServices.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateOrderService(OrderService oService)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<OrderService>(oService).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
