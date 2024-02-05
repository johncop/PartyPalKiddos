using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOrderDrinkRepository
    {
        void addOrderDrink(OrderDrink oDrink);
        void removeOrderDrink(OrderDrink oDrink);
        void UpdateOrderDrink(OrderDrink oDrink);
        OrderDrink GetOrderDrinkByPackageId(int id);
        List<OrderDrink> GetOrderDrink();
    }
}
