using BusinessObject.Models;
using DataAccess.CategoryDAO;
using Repository.Interface.ICategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.CategoryRepository
{
    public class FoodCategoryRepository : IFoodCategoryRepository
    {
        public void addFoodCategory(FoodCategory foodCate) => FoodCategoryDAO.SaveFoodCategory(foodCate);

        public List<FoodCategory> GetAllFoodCategory() => FoodCategoryDAO.GetFoodCategorys();

        public FoodCategory GetFoodCategoryById(int id) => FoodCategoryDAO.findFoodCategoryById(id);

        public List<FoodCategory> GetFoodCategoryByName(string foodCategoryName)
        => FoodCategoryDAO.findFoodCategoryByName(foodCategoryName);

        public void removeFoodCategory(FoodCategory foodCate) => FoodCategoryDAO.DeleteFoodCategory(foodCate);

        public void UpdateFoodCategory(FoodCategory foodCate)
        => FoodCategoryDAO.UpdateFoodCategory(foodCate);
    }
}
