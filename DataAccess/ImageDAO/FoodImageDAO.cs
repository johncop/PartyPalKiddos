using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImageDAO
{
    public class FoodImageDAO
    {
        /*#region query
        public static List<FoodImage> GetFoodImages()
        {
            var listFoodImages = new List<FoodImage>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listFoodImages = context.FoodImages
                .Select(FoodImage => new FoodImage
                {
                    Id = FoodImage.Id,
                    ImgUrl = FoodImage.ImgUrl,
                    FoodId = FoodImage.FoodId
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listFoodImages;
        }

        public static FoodImage findFoodImageById(int id)
        {
            FoodImage d = new FoodImage();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.FoodImages
                .Select(FoodImage => new FoodImage
                {
                    Id = FoodImage.Id,
                    ImgUrl = FoodImage.ImgUrl,
                    FoodId = FoodImage.FoodId
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
        public static void SaveFoodImage(FoodImage d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.FoodImages.Add(d);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteFoodImage(FoodImage d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.FoodImages.SingleOrDefault(x => x.Id == d.Id);
                    context.FoodImages.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateFoodImage(FoodImage d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<FoodImage>(d).State =
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
