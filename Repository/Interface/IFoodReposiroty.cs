using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IFoodReposiroty
    {
        void addFood(Food f);
        void removeFood(Food f);
        void UpdateFood(Food f);
        Food GetFoodById(int id);
        List<Food> GetFoodByName(string FoodName);

        List<Food> GetAllFoods();
    }
}
