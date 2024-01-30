using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DrinkDAO
    {
        #region query
        public static List<Drink> GetDrinks()
        {
            var listDrinks = new List<Drink>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listDrinks = context.Drinks
                .Include(Drink => Drink.DrinkImages)
                .Select(Drink => new Drink
                {
                    Id = Drink.Id,
                    DrinkName = Drink.DrinkName,
                    Description = Drink.Description,
                    DrinkCategoryId = Drink.DrinkCategoryId,
                    Price = Drink.Price,
                    DrinkImages = Drink.DrinkImages
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listDrinks;
        }

        public static Drink findDrinkById(int id)
        {
            Drink d = new Drink();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.Drinks
                .Include(Drink => Drink.DrinkImages)
                .Select(Drink => new Drink
                {
                    Id = Drink.Id,
                    DrinkName = Drink.DrinkName,
                    Description = Drink.Description,
                    DrinkCategoryId = Drink.DrinkCategoryId,
                    Price = Drink.Price,
                    DrinkImages = Drink.DrinkImages
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return d;
        }

        public static List<Drink> findDrinkByName(string DrinkName)
        {
            List<Drink> d = new List<Drink>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.Drinks
                     .Include(Drink => Drink.DrinkImages)
                     .Where(Drink => Drink.DrinkName.Contains(DrinkName))
                .Select(Drink => new Drink
                {
                    Id = Drink.Id,
                    DrinkName = Drink.DrinkName,
                    Description = Drink.Description,
                    DrinkCategoryId = Drink.DrinkCategoryId,
                    Price = Drink.Price,
                    DrinkImages = Drink.DrinkImages
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
        public static void SaveDrink(Drink d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Drinks.Add(d);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteDrink(Drink d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.Drinks.SingleOrDefault(x => x.Id == d.Id);
                    context.Drinks.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateDrink(Drink d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<Drink>(d).State =
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
