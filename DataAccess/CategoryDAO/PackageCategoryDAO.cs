using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CategoryDAO
{
    public class PackageCategoryDAO
    {
        #region query
        public static List<PackageCategory> GetPackageCategory()
        {
            var listPackageCategorys = new List<PackageCategory>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listPackageCategorys = context.PackageCategories
                        //.Include(d => d.Drinks)
                .Select(PackageCategory => new PackageCategory
                {
                    Id = PackageCategory.Id,
                    CategoryName = PackageCategory.CategoryName,
                    Description = PackageCategory.Description,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listPackageCategorys;
        }

        public static PackageCategory findPackageCategoryById(int id)
        {
            PackageCategory d = new PackageCategory();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.PackageCategories
                .Select(PackageCategory => new PackageCategory
                {
                    Id = PackageCategory.Id,
                    CategoryName = PackageCategory.CategoryName,
                    Description = PackageCategory.Description,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return d;
        }

        public static List<PackageCategory> findPackageCategoryByName(string PackageCategoryName)
        {
            List<PackageCategory> d = new List<PackageCategory>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.PackageCategories
                     .Where(PackageCategory => PackageCategory.CategoryName.Contains(PackageCategoryName))
                .Select(PackageCategory => new PackageCategory
                {
                    Id = PackageCategory.Id,
                    CategoryName = PackageCategory.CategoryName,
                    Description = PackageCategory.Description,
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
        public static void SavePackageCategory(PackageCategory d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.PackageCategories.Add(d);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeletePackageCategory(PackageCategory d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.PackageCategories.SingleOrDefault(x => x.Id == d.Id);
                    context.PackageCategories.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdatePackageCategory(PackageCategory d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<PackageCategory>(d).State =
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
