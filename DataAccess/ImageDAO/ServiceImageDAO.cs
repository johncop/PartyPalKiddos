/*using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImageDAO
{
    public class ServiceImageDAO
    {
        #region query
        public static List<ServiceImage> GetServiceImages()
        {
            var listServiceImages = new List<ServiceImage>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listServiceImages = context.ServiceImages
                .Select(ServiceImage => new ServiceImage
                {
                    Id = ServiceImage.Id,
                    ImgUrl = ServiceImage.ImgUrl,
                    ServiceId = ServiceImage.ServiceId
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listServiceImages;
        }

        public static ServiceImage findServiceImageById(int id)
        {
            ServiceImage d = new ServiceImage();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    d = context.ServiceImages
                .Select(ServiceImage => new ServiceImage
                {
                    Id = ServiceImage.Id,
                    ImgUrl = ServiceImage.ImgUrl,
                    ServiceId = ServiceImage.ServiceId
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
        public static void SaveServiceImage(ServiceImage si)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.ServiceImages.Add(si);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteServiceImage(ServiceImage si)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.ServiceImages.SingleOrDefault(x => x.Id == si.Id);
                    context.ServiceImages.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateServiceImage(ServiceImage si)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<ServiceImage>(si).State =
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
*/