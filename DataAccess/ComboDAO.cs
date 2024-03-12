using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ComboDAO
    {
        #region query
        public static List<Combo> GetCombos()
        {
            var listCombos = new List<Combo>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listCombos = context.Combos
                        .Include(c=>c.Host)
                .Select(Combo => new Combo
                {
                    Id = Combo.Id,
                    ComboName = Combo.ComboName,
                    ComboPrice = Combo.ComboPrice,
                    HostId = Combo.HostId,
                    ImgUrl = Combo.ImgUrl,
                    Status = Combo.Status,
                    Host = Combo.Host,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listCombos;
        }

        public static Combo findComboById(int id)
        {
            Combo l = new Combo();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    l = context.Combos
                .Select(Combo => new Combo
                {
                    Id = Combo.Id,
                    ComboName = Combo.ComboName,
                    ComboPrice = Combo.ComboPrice,
                    HostId = Combo.HostId,
                    ImgUrl = Combo.ImgUrl,
                    Status = Combo.Status,
                    Host = Combo.Host,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return l;
        }

        public static List<Combo> findComboByName(string ComboName)
        {
            List<Combo> f = new List<Combo>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    f = context.Combos
                     .Where(Combo => Combo.ComboName.Contains(ComboName))
                .Select(Combo => new Combo
                {
                    Id = Combo.Id,
                    ComboName = Combo.ComboName,
                    ComboPrice = Combo.ComboPrice,
                    HostId = Combo.HostId,
                    ImgUrl = Combo.ImgUrl,
                    Status = Combo.Status,
                    Host = Combo.Host,
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return f;
        }

        public static List<Combo> findComboByHostId(int hostId)
        {
            List<Combo> f = new List<Combo>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    f = context.Combos
                     .Where(Combo => Combo.HostId == hostId)
                .Select(Combo => new Combo
                {
                    Id = Combo.Id,
                    ComboName = Combo.ComboName,
                    ComboPrice = Combo.ComboPrice,
                    HostId = Combo.HostId,
                    ImgUrl = Combo.ImgUrl,
                    Status = Combo.Status,
                    Host = Combo.Host,
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
        public static void SaveCombo(Combo f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Combos.Add(f);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteCombo(Combo f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.Combos.SingleOrDefault(x => x.Id == f.Id);
                    context.Combos.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateCombo(Combo p)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<Combo>(p).State =
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
