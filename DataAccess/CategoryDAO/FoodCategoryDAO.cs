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
        #region query
        public static List<FoodCategory> GetFoodCategorys()
        {
            var listFoodCategorys = new List<FoodCategory>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listFoodCategorys = context.FoodCategories
                        .Include(s => s.Foods)
                .Select(FoodCategory => new FoodCategory
                {
                    Id = FoodCategory.Id,
                    FoodCategoryName = FoodCategory.FoodCategoryName,
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
                using (var context = new PartyPalKiddosDBContext())
                {
                    d = context.FoodCategories
                        .Include(s => s.Foods)
                .Select(FoodCategory => new FoodCategory
                {
                    Id = FoodCategory.Id,
                    FoodCategoryName = FoodCategory.FoodCategoryName,
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
                using (var context = new PartyPalKiddosDBContext())
                {
                    d = context.FoodCategories
                     .Where(FoodCategory => FoodCategory.FoodCategoryName.Contains(FoodCategoryName))
                     .Include(s => s.Foods)
                .Select(FoodCategory => new FoodCategory
                {
                    Id = FoodCategory.Id,
                    FoodCategoryName = FoodCategory.FoodCategoryName,
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
        public static void SaveFoodCategory(FoodCategory footCate)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.FoodCategories.Add(footCate);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteFoodCategory(FoodCategory foodCate)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.ServiceCategories.SingleOrDefault(x => x.Id == foodCate.Id);
                    context.ServiceCategories.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateFoodCategory(FoodCategory foodCate)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<FoodCategory>(foodCate).State =
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
