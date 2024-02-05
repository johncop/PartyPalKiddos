using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImageDAO
{
    public class LocationImageDAO
    {
        #region query
        public static List<LocationImage> GetLocationImages()
        {
            var listLocationImages = new List<LocationImage>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listLocationImages = context.LocationImages
                .Select(LocationImage => new LocationImage
                {
                    Id = LocationImage.Id,
                    ImgUrl = LocationImage.ImgUrl,
                    LocationId = LocationImage.LocationId
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listLocationImages;
        }

        public static LocationImage findLocationImageById(int id)
        {
            LocationImage d = new LocationImage();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.LocationImages
                .Select(LocationImage => new LocationImage
                {
                    Id = LocationImage.Id,
                    ImgUrl = LocationImage.ImgUrl,
                    LocationId = LocationImage.LocationId
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
        public static void SaveLocationImage(LocationImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.LocationImages.Add(li);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteLocationImage(LocationImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.LocationImages.SingleOrDefault(x => x.Id == li.Id);
                    context.LocationImages.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateLocationImage(LocationImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<LocationImage>(li).State =
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
