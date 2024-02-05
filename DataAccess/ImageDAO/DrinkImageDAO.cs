using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImageDAO
{
    public class DrinkImageDAO
    {
        #region query
        public static List<DrinkImage> GetDrinkImages()
        {
            var listDrinkImages = new List<DrinkImage>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listDrinkImages = context.DrinkImages
                .Select(drinkImage => new DrinkImage
                {
                    Id = drinkImage.Id,
                    ImgUrl = drinkImage.ImgUrl,
                    DrinkId= drinkImage.DrinkId
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listDrinkImages;
        }

        public static DrinkImage findDrinkImageById(int id)
        {
            DrinkImage d = new DrinkImage();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.DrinkImages
                .Select(drinkImage => new DrinkImage
                {
                    Id = drinkImage.Id,
                    ImgUrl = drinkImage.ImgUrl,
                    DrinkId = drinkImage.DrinkId
                }).SingleOrDefault(x => x.Id == id);
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
        public static void SaveDrinkImage(DrinkImage di)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.DrinkImages.Add(di);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteDrinkImage(DrinkImage di)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.DrinkImages.SingleOrDefault(x => x.Id == di.Id);
                    context.DrinkImages.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateDrinkImage(DrinkImage di)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<DrinkImage>(di).State =
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
