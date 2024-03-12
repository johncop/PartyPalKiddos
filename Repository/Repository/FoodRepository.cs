using BusinessObject.Models;
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
        public void addFood(Food food)
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

        public List<Food> GetFoodByName(string foodName)
        {
            throw new NotImplementedException();
        }

        public void removeFood(Food food)
        {
            throw new NotImplementedException();
        }

        public void UpdateFood(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
