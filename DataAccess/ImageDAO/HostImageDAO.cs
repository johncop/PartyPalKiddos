using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImageDAO
{
    public class HostImageDAO
    {
        #region query
        public static List<HostImage> GetHostImages()
        {
            var listHostImages = new List<HostImage>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listHostImages = context.HostImages
                .Select(HostImage => new HostImage
                {
                    Id = HostImage.Id,
                    ImgUrl = HostImage.ImgUrl,
                    LocationId = HostImage.LocationId
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listHostImages;
        }

        public static HostImage findHostImageById(int id)
        {
            HostImage d = new HostImage();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    d = context.HostImages
                .Select(HostImage => new HostImage
                {
                    Id = HostImage.Id,
                    ImgUrl = HostImage.ImgUrl,
                    LocationId = HostImage.LocationId
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
        public static void SaveHostImage(HostImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.HostImages.Add(li);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteHostImage(HostImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.HostImages.SingleOrDefault(x => x.Id == li.Id);
                    context.HostImages.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateHostImage(HostImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<HostImage>(li).State =
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
