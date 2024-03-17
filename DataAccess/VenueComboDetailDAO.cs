using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class VenueComboDetailDAO
    {
        private readonly PartyPalKiddosDBContext _context;
        public VenueComboDetailDAO(PartyPalKiddosDBContext context)
        {
            _context = context;
        }
        #region QUERY
        /*public List<VenueComboDetail> GetVenueComboDetails()
        {
            //var listVenueComboDetails = new List<VenueComboDetail>();
            try
            {
                return _context.VenueComboDetails
                    .Select(hcd => new VenueComboDetail
                    {
                        VenueId= hcd.VenueId,
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

        public List<VenueComboDetail> FindVenueComboDetailById(int VenueId)
        {
            //List<VenueComboDetail> f = new List<VenueComboDetail>();
            try
            {
                return _context.VenueComboDetails
                    .Where(hcd => hcd.VenueId == VenueId)
                    .Select(hcd => new VenueComboDetail
                    {
                        VenueId = hcd.VenueId,
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

        public static List<VenueComboDetail> GetVenueComboDetails()
        {
            var listVenueComboDetails = new List<VenueComboDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenueComboDetails = context.VenueComboDetails
                    .Select(hcd => new VenueComboDetail
                    {
                        VenueId = hcd.VenueId,
                        ComboId = hcd.ComboId,
                    })
                    .ToList();
                    return listVenueComboDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<VenueComboDetail> FindVenueComboDetailById(int VenueId)
        {
            var listVenueComboDetails = new List<VenueComboDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenueComboDetails = context.VenueComboDetails
                        .Where(hcd => hcd.VenueId == VenueId)
                    .Select(hcd => new VenueComboDetail
                    {
                        VenueId = hcd.VenueId,
                        ComboId = hcd.ComboId,
                    })
                    .ToList();
                    return listVenueComboDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*public static VenueComboDetail GetVenueComboDetailByIds(int VenueId, int comboId, int foodId)
        {
            try
            {
                return _context.VenueComboDetails
                        .Where(detail => detail.VenueId == VenueId && detail.ComboId == comboId && detail.FoodId == foodId)
                        .Select(detail => new VenueComboDetail
                        {
                            VenueId = detail.VenueId,
                            ComboId = detail.ComboId,
                            FoodId = detail.FoodId,
                        }).FirstOrDefault();               
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }*/

        public static VenueComboDetail GetVenueComboDetailByIds(int VenueId, int comboId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var hcd = context.VenueComboDetails
                         .Where(hcd => hcd.VenueId == VenueId && hcd.ComboId == comboId)
                     .Select(hcd => new VenueComboDetail
                     {
                         VenueId = hcd.VenueId,
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
        /*public void SaveVenueComboDetail(VenueComboDetail f)
        {
            try
            {             
                    _context.VenueComboDetails.Add(f);
                    _context.SaveChanges();              
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteVenueComboDetail(VenueComboDetail VenueComboDetail)
        {
            try
            {
                    var p1 = _context.VenueComboDetails.SingleOrDefault(x => x.ComboId == VenueComboDetail.ComboId && x.FoodId == VenueComboDetail.FoodId);
                    _context.VenueComboDetails.Remove(p1);
                    _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void UpdateVenueComboDetail(VenueComboDetail VenueComboDetail)
        {
            try
            {
                    _context.Entry<VenueComboDetail>(VenueComboDetail).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/

        public static void SaveVenueComboDetail(VenueComboDetail VenueComboDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.VenueComboDetails.Add(VenueComboDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteVenueComboDetail(VenueComboDetail VenueComboDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.VenueComboDetails.SingleOrDefault(x => x.VenueId == VenueComboDetail.VenueId && x.ComboId == VenueComboDetail.ComboId);
                    context.VenueComboDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateVenueComboDetail(VenueComboDetail VenueComboDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<VenueComboDetail>(VenueComboDetail).State =
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
