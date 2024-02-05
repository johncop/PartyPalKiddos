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
    public class FoodRepository : IFoodReposiroty
    {
        public void addFood(Food f) => FoodDAO.SaveFood(f);

        public List<Food> GetAllFoods() => FoodDAO.GetFoods();

        public Food GetFoodById(int id) => FoodDAO.findFoodById(id);

        public List<Food> GetFoodByName(string FoodName) => FoodDAO.findFoodByName(FoodName);

        public void removeFood(Food f) => FoodDAO.DeleteFood(f);

        public void UpdateFood(Food f) => FoodDAO.UpdateFood(f);
    }
}
