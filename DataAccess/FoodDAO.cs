using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                using (var context = new PartyPalKiddosContext())
                {
                    listFoods = context.Foods
                .Include(food => food.FoodImages) 
                .Select(food => new Food
                {
                    Id = food.Id,
                    FoodName = food.FoodName,
                    Description = food.Description,
                    FoodCategoryId = food.FoodCategoryId,
                    Price = food.Price,
                    FoodImages = food.FoodImages 
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
            Food f = new Food();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    f = context.Foods
                .Include(food => food.FoodImages)
                .Select(food => new Food
                {
                    Id = food.Id,
                    FoodName = food.FoodName,
                    Description = food.Description,
                    FoodCategoryId = food.FoodCategoryId,
                    Price = food.Price,
                    FoodImages = food.FoodImages
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return f;
        }

        public static List<Food> findFoodByName(string foodName)
        {
            List<Food> f = new List<Food>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    f = context.Foods
                     .Include(food => food.FoodImages)
                     .Where(food => food.FoodName.Contains(foodName))
                .Select(food => new Food
                {
                    Id = food.Id,
                    FoodName = food.FoodName,
                    Description = food.Description,
                    FoodCategoryId = food.FoodCategoryId,
                    Price = food.Price,
                    FoodImages = food.FoodImages
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
                using (var context = new PartyPalKiddosContext())
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
                using (var context = new PartyPalKiddosContext())
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
                using (var context = new PartyPalKiddosContext())
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
