using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FoodDAO
    {
        #region query
        public static List<Food> GetFoods()
        {
            var listFoods = new List<Food>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listFoods = context.Foods
                .Select(food => new Food
                {
                    Id = food.Id,
                    FoodName = food.FoodName,
                    Description = food.Description,
                    ImageUrl = food.ImageUrl,
                    FoodCategoryId = food.FoodCategoryId,
                    Price = food.Price,
                    FoodCategory = food.FoodCategory,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listFoods;
        }

        public static Food findFoodById(int id)
        {
            Food l = new Food();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    l = context.Foods
                .Select(food => new Food
                {
                    Id = food.Id,
                    FoodName = food.FoodName,
                    Description = food.Description,
                    ImageUrl = food.ImageUrl,
                    FoodCategoryId = food.FoodCategoryId,
                    Price = food.Price,
                    FoodCategory = food.FoodCategory,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return l;
        }

        public static List<Food> findFoodByName(string foodName)
        {
            List<Food> f = new List<Food>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    f = context.Foods
                     .Where(Food => Food.FoodName.Contains(foodName))
                .Select(food => new Food
                {
                    Id = food.Id,
                    FoodName = food.FoodName,
                    Description = food.Description,
                    ImageUrl = food.ImageUrl,
                    FoodCategoryId = food.FoodCategoryId,
                    Price = food.Price,
                    FoodCategory = food.FoodCategory,
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return f;
        }
        #endregion



        #region command
        public static void SaveFood(Food f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Foods.Add(f);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteFood(Food f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.Foods.SingleOrDefault(x => x.Id == f.Id);
                    context.Foods.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateFood(Food p)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<Food>(p).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
