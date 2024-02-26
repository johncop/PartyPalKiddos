using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CategoryDAO
{
    public class FoodCategoryDAO
    {
        /*#region query
        public static List<FoodCategory> GetFoodCategorys()
        {
            var listFoodCategorys = new List<FoodCategory>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listFoodCategorys = context.FoodCategories
                        .Include(f => f.Foods)
                .Select(FoodCategory => new FoodCategory
                {
                    Id = FoodCategory.Id,
                    CategoryName = FoodCategory.CategoryName,
                    Description = FoodCategory.Description,
                    Foods = FoodCategory.Foods,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listFoodCategorys;
        }

        public static FoodCategory findFoodCategoryById(int id)
        {
            FoodCategory d = new FoodCategory();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.FoodCategories
                        .Include(f => f.Foods)
                .Select(FoodCategory => new FoodCategory
                {
                    Id = FoodCategory.Id,
                    CategoryName = FoodCategory.CategoryName,
                    Description = FoodCategory.Description,
                    Foods = FoodCategory.Foods,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return d;
        }

        public static List<FoodCategory> findFoodCategoryByName(string FoodCategoryName)
        {
            List<FoodCategory> d = new List<FoodCategory>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.FoodCategories
                     .Where(FoodCategory => FoodCategory.CategoryName.Contains(FoodCategoryName))
                     .Include(f => f.Foods)
                .Select(FoodCategory => new FoodCategory
                {
                    Id = FoodCategory.Id,
                    CategoryName = FoodCategory.CategoryName,
                    Description = FoodCategory.Description,
                    Foods = FoodCategory.Foods,
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return d;
        }
        #endregion



        #region command
        public static void SaveFoodCategory(FoodCategory d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.FoodCategories.Add(d);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteFoodCategory(FoodCategory d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.FoodCategories.SingleOrDefault(x => x.Id == d.Id);
                    context.FoodCategories.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateFoodCategory(FoodCategory d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<FoodCategory>(d).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        #endregion*/
    }
}
