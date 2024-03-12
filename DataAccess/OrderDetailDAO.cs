/*using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        #region query
        public static List<OrderDetail> GetOrderDetails()
        {
            var listOrderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listOrderDetails = context.OrderDetails
                .Select(OrderDetail => new OrderDetail
                {
                    OrderId = OrderDetail.OrderId,
                    PackageId = OrderDetail.PackageId,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listOrderDetails;
        }

        public static OrderDetail findOrderDetailById(int id)
        {
            OrderDetail p = new OrderDetail();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    p = context.OrderDetails
                .Select(OrderDetail => new OrderDetail
                {
                    OrderId = OrderDetail.OrderId,
                    PackageId = OrderDetail.PackageId,
                }).SingleOrDefault(x => x.OrderId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        #endregion



        #region command
        public static void SaveOrderDetail(OrderDetail f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.OrderDetails.Add(f);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteOrderDetail(OrderDetail f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.OrderDetails.SingleOrDefault(x => x.OrderId == f.OrderId);
                    context.OrderDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateOrderDetail(OrderDetail p)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<OrderDetail>(p).State =
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
*/