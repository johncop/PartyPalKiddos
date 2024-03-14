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
    public class FoodRepository : IFoodRepository
    {
        public void addFood(Food food) => FoodDAO.SaveFood(food);

        public List<Food> GetAllFoods() => FoodDAO.GetFoods();

        public Food GetFoodById(int id) => FoodDAO.findFoodById(id);

        public List<Food> GetFoodByName(string foodName) => FoodDAO.findFoodByName(foodName);

        public void removeFood(Food food) => FoodDAO.DeleteFood(food);

        public void UpdateFood(Food food) => FoodDAO.UpdateFood(food);
    }
}
