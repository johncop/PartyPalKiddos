using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CategoryDAO
{
    public class DrinkCategoryDAO
    {
        /*#region query
        public static List<DrinkCategory> GetDrinkCategorys()
        {
            var listDrinkCategorys = new List<DrinkCategory>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listDrinkCategorys = context.DrinkCategories
                        .Include(d => d.Drinks)
                .Select(DrinkCategory => new DrinkCategory
                {
                    Id = DrinkCategory.Id,
                    CategoryName = DrinkCategory.CategoryName,
                    Description = DrinkCategory.Description,
                    Drinks = DrinkCategory.Drinks,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listDrinkCategorys;
        }

        public static DrinkCategory findDrinkCategoryById(int id)
        {
            DrinkCategory d = new DrinkCategory();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.DrinkCategories
                        .Include(d => d.Drinks)
                .Select(DrinkCategory => new DrinkCategory
                {
                    Id = DrinkCategory.Id,
                    CategoryName = DrinkCategory.CategoryName,
                    Description = DrinkCategory.Description,
                    Drinks = DrinkCategory.Drinks
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return d;
        }

        public static List<DrinkCategory> findDrinkCategoryByName(string DrinkCategoryName)
        {
            List<DrinkCategory> d = new List<DrinkCategory>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.DrinkCategories
                     .Where(DrinkCategory => DrinkCategory.CategoryName.Contains(DrinkCategoryName))
                     .Include(d => d.Drinks)
                .Select(DrinkCategory => new DrinkCategory
                {
                    Id = DrinkCategory.Id,
                    CategoryName = DrinkCategory.CategoryName,
                    Description = DrinkCategory.Description,
                    Drinks = DrinkCategory.Drinks
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
        public static void SaveDrinkCategory(DrinkCategory d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.DrinkCategories.Add(d);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteDrinkCategory(DrinkCategory d)
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

        public static void UpdateDrinkCategory(DrinkCategory d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<DrinkCategory>(d).State =
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
