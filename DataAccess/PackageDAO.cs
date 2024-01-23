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
                .Include(p => p.OrderFood)
                .ThenInclude(of => of.Food)
                .Include(p => p.OrderDrink)
                .ThenInclude(of => of.Drink)
                .Include(p => p.OrderService)
                .ThenInclude(of => of.Service)
                .Include(p => p.User)
                .Select(package => new Package
                {
                    Id = package.Id,
                    PackageName = package.PackageName,
                    OrderDrinkId = package.OrderDrinkId,
                    OrderFoodId = package.OrderFoodId,
                    OrderServiceId = package.OrderServiceId,
                    UserId = package.UserId,
                    PackageCategoryId = package.PackageCategoryId,
                    Status = package.Status,
                    // Assuming you have navigation properties in your Package entity
                    OrderFood = package.OrderFood != null ? new OrderFood
                    {
                        Id = package.OrderFood.Id,
                        FoodId = package.OrderFood.FoodId,
                        Quantity = package.OrderFood.Quantity,
                        Food = package.OrderFood.Food != null ? new Food
                        {
                            Id = package.OrderFood.Id,
                            FoodName = package.OrderFood.Food.FoodName,
                            Description = package.OrderFood.Food.Description,
                            Price = package.OrderFood.Food.Price,
                        } : null,
                    } : null,
                    OrderDrink = package.OrderDrink != null ? new OrderDrink
                    {
                        Id = package.OrderDrink.Id,
                        DrinkId = package.OrderDrink.DrinkId,
                        Quantity = package.OrderDrink.Quantity,
                        Drink = package.OrderDrink.Drink != null ? new Drink
                        {
                            Id = package.OrderDrink.Id,
                            DrinkName = package.OrderDrink.Drink.DrinkName,
                            Description = package.OrderDrink.Drink.Description,
                            Price = package.OrderDrink.Drink.Price,

                        } : null,
                    } : null,
                    OrderService = package.OrderService != null ? new OrderService
                    {
                        Id = package.OrderService.Id,
                        ServiceId = package.OrderService.ServiceId,
                        Quantity = package.OrderService.Quantity,
                        Service = package.OrderService.Service != null ? new Service
                        {
                            Id = package.OrderDrink.Id,
                            ServiceName = package.OrderService.Service.ServiceName,
                            Description = package.OrderService.Service.Description,
                            Price = package.OrderService.Service.Price,

                        } : null,
                    } : null
                    // If there are more fields, map them accordingly
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
                    OrderDrinkId = package.OrderDrinkId,
                    OrderFoodId = package.OrderFoodId,
                    OrderServiceId = package.OrderServiceId,
                    UserId = package.UserId,
                    PackageCategoryId = package.PackageCategoryId,
                    Status = package.Status,
                    // Assuming you have navigation properties in your Package entity
                    OrderFood = package.OrderFood != null ? new OrderFood
                    {
                        Id = package.OrderFood.Id,
                        FoodId = package.OrderFood.FoodId,
                        Quantity = package.OrderFood.Quantity
                    } : null,
                    OrderDrink = package.OrderDrink != null ? new OrderDrink
                    {
                        Id = package.OrderDrink.Id,
                        DrinkId = package.OrderDrink.DrinkId,
                        Quantity = package.OrderDrink.Quantity
                    } : null,
                    OrderService = package.OrderService != null ? new OrderService
                    {
                        Id = package.OrderService.Id,
                        ServiceId = package.OrderService.ServiceId,
                        Quantity = package.OrderService.Quantity
                    } : null
                    // If there are more fields, map them accordingly
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
                    OrderDrinkId = package.OrderDrinkId,
                    OrderFoodId = package.OrderFoodId,
                    OrderServiceId = package.OrderServiceId,
                    UserId = package.UserId,
                    PackageCategoryId = package.PackageCategoryId,
                    Status = package.Status,
                    // Assuming you have navigation properties in your Package entity
                    OrderFood = package.OrderFood != null ? new OrderFood
                    {
                        Id = package.OrderFood.Id,
                        FoodId = package.OrderFood.FoodId,
                        Quantity = package.OrderFood.Quantity
                    } : null,
                    OrderDrink = package.OrderDrink != null ? new OrderDrink
                    {
                        Id = package.OrderDrink.Id,
                        DrinkId = package.OrderDrink.DrinkId,
                        Quantity = package.OrderDrink.Quantity
                    } : null,
                    OrderService = package.OrderService != null ? new OrderService
                    {
                        Id = package.OrderService.Id,
                        ServiceId = package.OrderService.ServiceId,
                        Quantity = package.OrderService.Quantity
                    } : null
                    // If there are more fields, map them accordingly
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
