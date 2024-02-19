using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PackageTagDAO
    {
        #region query
        public static List<PackageTag> GetPackageTags()
        {
            var listOrder = new List<PackageTag>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listOrder = context.PackageTags
                .Select(order => new PackageTag
                {
                    PackageId = order.PackageId,
                    CategoryId = order.CategoryId,
                    Description = order.Description,
                }).ToList();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrder;
        }

        public static PackageTag findPackageTagByPackageId(int id)
        {
            PackageTag p = new PackageTag();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.PackageTags
                .Select(pt => new PackageTag
                {
                    PackageId = pt.PackageId,
                    CategoryId = pt.CategoryId,
                    Description = pt.Description,
                }).SingleOrDefault(x => x.PackageId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static List<PackageTag> findPackageByCategoryId(int categoryId)
        {
            List<PackageTag> pt = new List<PackageTag>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    pt = context.PackageTags
                .Where(packageTag => packageTag.CategoryId == categoryId)
                .Select(pt => new PackageTag
                {
                    PackageId = pt.PackageId,
                    CategoryId = pt.CategoryId,
                    Description = pt.Description,
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return pt;
        }
        public static List<PackageTag> findCategoryByPackageId(int packageId)
        {
            List<PackageTag> pt = new List<PackageTag>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    pt = context.PackageTags
                .Where(packageTag => packageTag.PackageId == packageId)
                .Select(pt => new PackageTag
                {
                    PackageId = pt.PackageId,
                    CategoryId = pt.CategoryId,
                    Description = pt.Description,
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return pt;
        }
        #endregion

        #region command
        public static void SavePackageTag(PackageTag oDrink)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.PackageTags.Add(oDrink);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeletePackageTag(PackageTag oDrink)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.PackageTags.SingleOrDefault(x => x.PackageId == oDrink.PackageId);
                    context.PackageTags.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdatePackageTag(PackageTag oDrink)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<PackageTag>(oDrink).State =
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
