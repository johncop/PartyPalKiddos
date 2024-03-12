using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IFoodRepository
    {
        void addFood(Food food);
        void removeFood(Food food);
        void UpdateFood(Food food);
        List<Food> GetAllFoods();
        Food GetFoodById(int id);
        List<Food> GetFoodByName(string foodName);
    }
}
