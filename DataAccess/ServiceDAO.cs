using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ServiceDAO
    {
        #region query
        public static List<Service> Getservices()
        {
            var listService = new List<Service>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listService = context.Services
                        .Include(service => service.ServiceImages)
                .Select(service => new Service
                {
                    Id = service.Id,
                    ServiceName = service.ServiceName,
                    Description = service.Description,
                    ServiceCategoryId = service.ServiceCategoryId,
                    Price = service.Price,
                    ServiceImages = service.ServiceImages,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listService;
        }

        public static Service findserviceById(int id)
        {
            Service f = new Service();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    f = context.Services
                .Include(service => service.ServiceImages)
                .Select(service => new Service
                {
                    Id = service.Id,
                    ServiceName = service.ServiceName,
                    Description = service.Description,
                    ServiceCategoryId = service.ServiceCategoryId,
                    Price = service.Price,
                    ServiceImages = service.ServiceImages,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return f;
        }

        public static List<Service> findserviceByName(string serviceName)
        {
            List<Service> f = new List<Service>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    f = context.Services
                     .Include(service => service.ServiceImages)
                     .Where(service => service.ServiceName.Contains(serviceName))
                .Select(service => new Service
                {
                    Id = service.Id,
                    ServiceName = service.ServiceName,
                    Description = service.Description,
                    ServiceCategoryId = service.ServiceCategoryId,
                    Price = service.Price,
                    ServiceImages = service.ServiceImages,
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return f;
        }
        #endregion



        #region command
        public static void Saveservice(Service s)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Services.Add(s);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void Deleteservice(Service s)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.Services.SingleOrDefault(x => x.Id == s.Id);
                    context.Services.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void Updateservice(Service s)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<Service>(s).State =
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
