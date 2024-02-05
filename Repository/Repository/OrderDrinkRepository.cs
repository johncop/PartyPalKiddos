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
    public class OrderDrinkRepository : IOrderDrinkRepository
    {
        public void addOrderDrink(OrderDrink oDrink) => OrderDrinkDAO.SaveOrderDrink(oDrink);

        public List<OrderDrink> GetOrderDrink() => OrderDrinkDAO.GetOrderDrinks();

        public OrderDrink GetOrderDrinkByPackageId(int id) => OrderDrinkDAO.findOrderDrinkByPackageId(id);

        public void removeOrderDrink(OrderDrink oDrink) => OrderDrinkDAO.DeleteOrderDrink(oDrink);

        public void UpdateOrderDrink(OrderDrink oDrink) => OrderDrinkDAO.UpdateOrderDrink(oDrink);
    }
}
