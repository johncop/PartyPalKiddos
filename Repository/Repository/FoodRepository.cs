using BusinessObject.Models;
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
        public void addFood(Food f)
        {
            throw new NotImplementedException();
        }

        public List<Food> GetAllFoods()
        {
            throw new NotImplementedException();
        }

        public Food GetFoodById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Food> GetFoodByName(string FoodName)
        {
            throw new NotImplementedException();
        }

        public void removeFood(Food f)
        {
            throw new NotImplementedException();
        }

        public void UpdateFood(Food f)
        {
            throw new NotImplementedException();
        }
    }
}
