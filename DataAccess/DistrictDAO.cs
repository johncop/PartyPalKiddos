using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DistrictDAO
    {
        #region query
        public static List<District> GetDistricts()
        {
            var listDistricts = new List<District>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listDistricts = context.Districts
                .Select(District => new District
                {
                    Id = District.Id,
                    Description = District.Description
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listDistricts;
        }

        public static District findDistrictById(int id)
        {
            District d = new District();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    d = context.Districts
                .Select(District => new District
                {
                    Id = District.Id,
                    Description = District.Description
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return d;
        }

        public static List<District> findDistrictByName(string description)
        {
            List<District> d = new List<District>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    d = context.Districts
                     .Where(District => District.Description.Contains(description))
                .Select(District => new District
                {
                    Id = District.Id,
                    Description = District.Description
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
        public static void SaveDistrict(District d)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Districts.Add(d);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteDistrict(District d)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.Districts.SingleOrDefault(x => x.Id == d.Id);
                    context.Districts.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateDistrict(District d)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<District>(d).State =
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
