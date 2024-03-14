using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.ICategoryRepository
{
    public interface IFoodCategoryRepository
    {
        void addFoodCategory(FoodCategory sc);
        void removeFoodCategory(FoodCategory sc);
        void UpdateFoodCategory(FoodCategory sc);
        FoodCategory GetFoodCategoryById(int id);
        List<FoodCategory> GetFoodCategoryByName(string foodCategoryName);
        List<FoodCategory> GetAllFoodCategory();
    }
}
