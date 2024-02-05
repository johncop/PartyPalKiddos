using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDrinkDAO
    {
        public static List<OrderDrink> GetOrderDrinks()
        {
            var listOrder = new List<OrderDrink>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listOrder = context.OrderDrinks
                .Select(order => new OrderDrink
                {
                    PackageId = order.PackageId,
                    DrinkId = order.DrinkId,
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
        public static OrderDrink findOrderDrinkByPackageId(int id)
        {
            OrderDrink p = new OrderDrink();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.OrderDrinks
                .Select(order => new OrderDrink
                {
                    PackageId = order.PackageId,
                    DrinkId = order.DrinkId,
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
        public static void SaveOrderDrink(OrderDrink oDrink)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.OrderDrinks.Add(oDrink);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteOrderDrink(OrderDrink oDrink)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.OrderDrinks.SingleOrDefault(x => x.PackageId == oDrink.PackageId);
                    context.OrderDrinks.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateOrderDrink(OrderDrink oDrink)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<OrderDrink>(oDrink).State =
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
