using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            var listOrders = new List<Order>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listOrders = context.Orders
                .Select(order => new Order
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    UserId = order.UserId,
                    PaymentId = order.PaymentId,
                    CouponId = order.CouponId,
                    PackageId = order.PackageId,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listOrders;
        }

        public static Order findOrderById(int id)
        {
            Order l = new Order();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    l = context.Orders
                .Select(order => new Order
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    UserId = order.UserId,
                    PaymentId = order.PaymentId,
                    CouponId = order.CouponId,
                    PackageId = order.PackageId,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return l;
        }

        public static List<Order> findOrderByUserId(int userId)
        {
            List<Order> f = new List<Order>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    f = context.Orders
                     .Where(Order => Order.UserId == userId)
                .Select(order => new Order
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    UserId = order.UserId,
                    PaymentId = order.PaymentId,
                    CouponId = order.CouponId,
                    PackageId = order.PackageId,
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return f;
        }

        #region command
        public static void SaveOrder(Order o)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Orders.Add(o);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteOrder(Order o)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.Orders.SingleOrDefault(x => x.Id == o.Id);
                    context.Orders.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateOrder(Order o)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<Order>(o).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        #endregion

    }
}
