using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ServiceTypeDAO
    {
        #region query
        public static List<ServiceType> GetServiceTypes()
        {
            var listOrder = new List<ServiceType>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listOrder = context.ServiceTypes
                        .Include(st => st.ServiceCategories)
                .Select(st => new ServiceType
                {
                    Id = st.Id,
                    TypeName = st.TypeName,
                    Description = st.Description,
                    ServiceCategories = st.ServiceCategories
                }).ToList();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrder;
        }

        public static ServiceType findServiceTypeById(int id)
        {
            ServiceType p = new ServiceType();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.ServiceTypes
                .Select(st => new ServiceType
                {
                    Id = st.Id,
                    TypeName = st.TypeName,
                    Description = st.Description,
                    ServiceCategories = st.ServiceCategories
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static List<ServiceType> findServiceTypeByName(string serviceTypeName)
        {
            List<ServiceType> pt = new List<ServiceType>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    pt = context.ServiceTypes
                .Where(ServiceType => ServiceType.TypeName == serviceTypeName)
                .Select(st => new ServiceType
                {
                    Id = st.Id,
                    TypeName = st.TypeName,
                    Description = st.Description,
                    ServiceCategories = st.ServiceCategories
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
        public static void SaveServiceType(ServiceType st)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.ServiceTypes.Add(st);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteServiceType(ServiceType st)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.ServiceTypes.SingleOrDefault(x => x.Id == st.Id);
                    context.ServiceTypes.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateServiceType(ServiceType st)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<ServiceType>(st).State =
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
