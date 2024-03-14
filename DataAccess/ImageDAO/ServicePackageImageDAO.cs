using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImageDAO
{
    public class ServicePackageImageDAO
    {
        #region query
        public static List<ServicePackageImage> GetServicePackageImages()
        {
            var listServicePackageImages = new List<ServicePackageImage>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listServicePackageImages = context.ServicePackageImages
                .Select(ServicePackageImage => new ServicePackageImage
                {
                    Id = ServicePackageImage.Id,
                    ImgUrl = ServicePackageImage.ImgUrl,
                    ServicePackageId = ServicePackageImage.ServicePackageId
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listServicePackageImages;
        }

        public static ServicePackageImage findServicePackageImageById(int id)
        {
            ServicePackageImage d = new ServicePackageImage();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    d = context.ServicePackageImages
                .Select(ServicePackageImage => new ServicePackageImage
                {
                    Id = ServicePackageImage.Id,
                    ImgUrl = ServicePackageImage.ImgUrl,
                    ServicePackageId = ServicePackageImage.ServicePackageId
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
        public static void SaveServicePackageImage(ServicePackageImage pi)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.ServicePackageImages.Add(pi);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteServicePackageImage(ServicePackageImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.ServicePackageImages.SingleOrDefault(x => x.Id == li.Id);
                    context.ServicePackageImages.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateServicePackageImage(ServicePackageImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<ServicePackageImage>(li).State =
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
