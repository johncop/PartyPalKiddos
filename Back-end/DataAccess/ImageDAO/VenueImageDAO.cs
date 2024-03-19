using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImageDAO
{
    public class VenueImageDAO
    {
        #region query
        public static List<VenueImage> GetVenueImages()
        {
            var listVenueImages = new List<VenueImage>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenueImages = context.VenueImages
                .Select(VenueImage => new VenueImage
                {
                    Id = VenueImage.Id,
                    ImgUrl = VenueImage.ImgUrl,
                    VenueId = VenueImage.VenueId
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listVenueImages;
        }

        public static VenueImage findVenueImageById(int id)
        {
            VenueImage d = new VenueImage();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    d = context.VenueImages
                .Select(VenueImage => new VenueImage
                {
                    Id = VenueImage.Id,
                    ImgUrl = VenueImage.ImgUrl,
                    VenueId = VenueImage.VenueId
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
        public static void SaveVenueImage(VenueImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.VenueImages.Add(li);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteVenueImage(VenueImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.VenueImages.SingleOrDefault(x => x.Id == li.Id);
                    context.VenueImages.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateVenueImage(VenueImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<VenueImage>(li).State =
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
