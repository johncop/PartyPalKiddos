using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PackageDAO
    {
        #region query
        public static List<Package> GetPackages()
        {
            var listPackage = new List<Package>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listPackage = context.Packages
                .Select(package => new Package
                {
                    Id = package.Id,
                    PackageName = package.PackageName,
                    UserId = package.UserId,
                    PackageCategoryId = package.PackageCategoryId,
                    Status = package.Status               
                }).ToList();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listPackage;
        }
    

        public static Package findPackageById(int id)
        {
            Package p = new Package();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.Packages
                .Include(p => p.OrderFood)
                .Include(p => p.OrderDrink)
                .Include(p => p.OrderService)
                .Select(package => new Package
                {
                    Id = package.Id,
                    PackageName = package.PackageName,
                    UserId = package.UserId,
                    PackageCategoryId = package.PackageCategoryId,
                    Status = package.Status
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static List<Package> findPackageByName(string packgaeName)
        {
            List<Package> p = new List<Package>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.Packages
                .Include(p => p.OrderFood)
                .Include(p => p.OrderDrink)
                .Include(p => p.OrderService)
                .Where(p => p.PackageName.Contains(packgaeName))
                .Select(package => new Package
                {
                    Id = package.Id,
                    PackageName = package.PackageName,
                    UserId = package.UserId,
                    PackageCategoryId = package.PackageCategoryId,
                    Status = package.Status
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }
        #endregion

        #region command
        public static void SavePackage(Package p)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Packages.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeletePackage(Package p)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.Packages.SingleOrDefault(x => x.Id == p.Id);
                    context.Packages.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdatePackage(Package p)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<Package>(p).State =
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
