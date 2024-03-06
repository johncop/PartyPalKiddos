using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CategoryDAO
{
    public class ServiceCategoryDAO
    {
        #region query
        public static List<ServiceCategory> GetServiceCategorys()
        {
            var listServiceCategorys = new List<ServiceCategory>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listServiceCategorys = context.ServiceCategories
                        .Include(s=>s.Services)
                .Select(ServiceCategory => new ServiceCategory
                {
                    Id = ServiceCategory.Id,
                    CategoryName = ServiceCategory.CategoryName,
                    Description = ServiceCategory.Description,
                    TypeId = ServiceCategory.TypeId,
                    Services= ServiceCategory.Services,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listServiceCategorys;
        }

        public static ServiceCategory findServiceCategoryById(int id)
        {
            ServiceCategory d = new ServiceCategory();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.ServiceCategories
                        .Include(s=>s.Services)
                .Select(ServiceCategory => new ServiceCategory
                {
                    Id = ServiceCategory.Id,
                    CategoryName = ServiceCategory.CategoryName,
                    Description = ServiceCategory.Description,
                    TypeId = ServiceCategory.TypeId,
                    Services = ServiceCategory.Services,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return d;
        }


        public static List<ServiceCategory> findServiceCategoryByName(string ServiceCategoryName)
        {
            List<ServiceCategory> d = new List<ServiceCategory>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    d = context.ServiceCategories
                     .Where(ServiceCategory => ServiceCategory.CategoryName.Contains(ServiceCategoryName))
                     .Include(s=>s.Services)
                .Select(ServiceCategory => new ServiceCategory
                {
                    Id = ServiceCategory.Id,
                    CategoryName = ServiceCategory.CategoryName,
                    Description = ServiceCategory.Description,
                    TypeId = ServiceCategory.TypeId,
                    Services = ServiceCategory.Services,
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
        public static void SaveServiceCategory(ServiceCategory d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.ServiceCategories.Add(d);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteServiceCategory(ServiceCategory d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.ServiceCategories.SingleOrDefault(x => x.Id == d.Id);
                    context.ServiceCategories.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateServiceCategory(ServiceCategory d)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<ServiceCategory>(d).State =
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
