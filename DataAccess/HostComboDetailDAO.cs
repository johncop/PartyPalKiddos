using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class HostComboDetailDAO
    {
        private readonly PartyPalKiddosDBContext _context;
        public HostComboDetailDAO(PartyPalKiddosDBContext context)
        {
            _context = context;
        }
        #region QUERY
        /*public List<HostComboDetail> GetHostComboDetails()
        {
            //var listHostComboDetails = new List<HostComboDetail>();
            try
            {
                return _context.HostComboDetails
                    .Select(hcd => new HostComboDetail
                    {
                        HostId= hcd.HostId,
                        ComboId=hcd.ComboId,
                        FoodId=hcd.FoodId,
                    })
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }           
        }

        public List<HostComboDetail> FindHostComboDetailById(int hostId)
        {
            //List<HostComboDetail> f = new List<HostComboDetail>();
            try
            {
                return _context.HostComboDetails
                    .Where(hcd => hcd.HostId == hostId)
                    .Select(hcd => new HostComboDetail
                    {
                        HostId = hcd.HostId,
                        ComboId = hcd.ComboId,
                        FoodId = hcd.FoodId,
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/

        public static List<HostComboDetail> GetHostComboDetails()
        {
            var listHostComboDetails = new List<HostComboDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listHostComboDetails = context.HostComboDetails
                    .Select(hcd => new HostComboDetail
                    {
                        HostId = hcd.HostId,
                        ComboId = hcd.ComboId,
                        FoodId = hcd.FoodId,
                    })
                    .ToList();
                    return listHostComboDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<HostComboDetail> FindHostComboDetailById(int hostId)
        {
            var listHostComboDetails = new List<HostComboDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listHostComboDetails = context.HostComboDetails
                        .Where(hcd => hcd.HostId == hostId)
                    .Select(hcd => new HostComboDetail
                    {
                        HostId = hcd.HostId,
                        ComboId = hcd.ComboId,
                        FoodId = hcd.FoodId,
                    })
                    .ToList();
                    return listHostComboDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*public static HostComboDetail GetHostComboDetailByIds(int hostId, int comboId, int foodId)
        {
            try
            {
                return _context.HostComboDetails
                        .Where(detail => detail.HostId == hostId && detail.ComboId == comboId && detail.FoodId == foodId)
                        .Select(detail => new HostComboDetail
                        {
                            HostId = detail.HostId,
                            ComboId = detail.ComboId,
                            FoodId = detail.FoodId,
                        }).FirstOrDefault();               
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }*/

        public static HostComboDetail GetHostComboDetailByIds(int hostId, int comboId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var hcd = context.HostComboDetails
                         .Where(hcd => hcd.HostId == hostId && hcd.ComboId == comboId)
                     .Select(hcd => new HostComboDetail
                     {
                         HostId = hcd.HostId,
                         ComboId = hcd.ComboId,
                     }).FirstOrDefault();
                    return hcd;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion



        #region COMMAND
        /*public void SaveHostComboDetail(HostComboDetail f)
        {
            try
            {             
                    _context.HostComboDetails.Add(f);
                    _context.SaveChanges();              
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteHostComboDetail(HostComboDetail HostComboDetail)
        {
            try
            {
                    var p1 = _context.HostComboDetails.SingleOrDefault(x => x.ComboId == HostComboDetail.ComboId && x.FoodId == HostComboDetail.FoodId);
                    _context.HostComboDetails.Remove(p1);
                    _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void UpdateHostComboDetail(HostComboDetail HostComboDetail)
        {
            try
            {
                    _context.Entry<HostComboDetail>(HostComboDetail).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/

        public static void SaveHostComboDetail(HostComboDetail HostComboDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.HostComboDetails.Add(HostComboDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteHostComboDetail(HostComboDetail HostComboDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.HostComboDetails.SingleOrDefault(x => x.HostId == HostComboDetail.HostId && x.ComboId == HostComboDetail.ComboId && x.FoodId == HostComboDetail.FoodId);
                    context.HostComboDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateHostComboDetail(HostComboDetail HostComboDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<HostComboDetail>(HostComboDetail).State =
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
