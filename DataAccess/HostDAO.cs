using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HostDAO
    {
        #region query
        public static List<Host> GetHosts()
        {
            var listHosts = new List<Host>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listHosts = context.Hosts
                .Include(Host => Host.HostImages)
                .Select(Host => new Host
                {
                    Id = Host.Id,
                    Address = Host.Address,
                    Capacity = Host.Capacity,
                    DistrictId = Host.DistrictId,
                    Description = Host.Description,                
                    Price = Host.Price,
                    HostImages = Host.HostImages,
                    District = Host.District,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listHosts;
        }

        public static Host findHostById(int id)
        {
            Host l = new Host();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    l = context.Hosts
                .Include(Host => Host.HostImages)
                .Select(Host => new Host
                {
                    Id = Host.Id,
                    Address = Host.Address,
                    Capacity = Host.Capacity,
                    DistrictId = Host.DistrictId,
                    Description = Host.Description,
                    Price = Host.Price,
                    HostImages = Host.HostImages,
                    District = Host.District,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return l;
        }

        public static List<Host> findHostByName(string address)
        {
            List<Host> f = new List<Host>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    f = context.Hosts
                     .Include(Host => Host.HostImages)
                     .Where(Host => Host.Address.Contains(address))
                .Select(Host => new Host
                {
                    Id = Host.Id,
                    Address = Host.Address,
                    Capacity = Host.Capacity,
                    DistrictId = Host.DistrictId,
                    Description = Host.Description,
                    Price = Host.Price,
                    HostImages = Host.HostImages,
                    District = Host.District,
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
        public static void SaveHost(Host f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Hosts.Add(f);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteHost(Host f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.Hosts.SingleOrDefault(x => x.Id == f.Id);
                    context.Hosts.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateHost(Host p)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<Host>(p).State =
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
