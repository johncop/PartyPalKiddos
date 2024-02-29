using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImageDAO
{
    public class PackageImageDAO
    {
        #region query
        public static List<PackageImage> GetPackageImages()
        {
            var listPackageImages = new List<PackageImage>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listPackageImages = context.PackageImages
                .Select(PackageImage => new PackageImage
                {
                    Id = PackageImage.Id,
                    ImgUrl = PackageImage.ImgUrl,
                    PackageId = PackageImage.PackageId
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listPackageImages;
        }

        public static PackageImage findPackageImageById(int id)
        {
            PackageImage d = new PackageImage();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.PackageImages
                .Select(PackageImage => new PackageImage
                {
                    Id = PackageImage.Id,
                    ImgUrl = PackageImage.ImgUrl,
                    PackageId = PackageImage.PackageId
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
        public static void SavePackageImage(PackageImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.PackageImages.Add(li);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeletePackageImage(PackageImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.PackageImages.SingleOrDefault(x => x.Id == li.Id);
                    context.PackageImages.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdatePackageImage(PackageImage li)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<PackageImage>(li).State =
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
