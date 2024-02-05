using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderFoodDAO
    {
        public static List<OrderFood> GetOrderFoods()
        {
            var listOrder = new List<OrderFood>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listOrder = context.OrderFoods
                .Select(order => new OrderFood
                {
                    PackageId = order.PackageId,
                    FoodId = order.FoodId,
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
        public static OrderFood findOrderFoodByPackageId(int id)
        {
            OrderFood p = new OrderFood();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.OrderFoods
                .Select(order => new OrderFood
                {
                    PackageId = order.PackageId,
                    FoodId = order.FoodId,
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
        public static void SaveOrderFood(OrderFood oFood)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.OrderFoods.Add(oFood);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteOrderFood(OrderFood oFood)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.OrderFoods.SingleOrDefault(x => x.PackageId == oFood.PackageId);
                    context.OrderFoods.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateOrderFood(OrderFood oFood)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<OrderFood>(oFood).State =
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
