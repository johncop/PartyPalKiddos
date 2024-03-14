using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ComboFoodDetailDAO
    {
        #region query
        public static List<ComboFoodDetail> GetComboFoodDetails()
        {
            var listComboFoodDetails = new List<ComboFoodDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listComboFoodDetails = context.ComboFoodDetails
                .Select(ComboFoodDetail => new ComboFoodDetail
                {
                    ComboId= ComboFoodDetail.ComboId,
                    Combo = ComboFoodDetail.Combo,
                    FoodId= ComboFoodDetail.FoodId,
                    Food = ComboFoodDetail.Food,
                    Quantity = ComboFoodDetail.Quantity,
                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listComboFoodDetails;
        }

        public static ComboFoodDetail findComboFoodDetailByComboId(int comboId)
        {
            ComboFoodDetail f = new ComboFoodDetail();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    f = context.ComboFoodDetails
                     
                .Select(ComboFoodDetail => new ComboFoodDetail
                {
                    ComboId = ComboFoodDetail.ComboId,
                    Combo = ComboFoodDetail.Combo,
                    FoodId = ComboFoodDetail.FoodId,
                    Food = ComboFoodDetail.Food,
                    Quantity = ComboFoodDetail.Quantity,
                }).SingleOrDefault(x => x.ComboId == comboId);
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
        public static void SaveComboFoodDetail(ComboFoodDetail f)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.ComboFoodDetails.Add(f);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteComboFoodDetail(ComboFoodDetail comboFoodDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.ComboFoodDetails.SingleOrDefault(x => x.ComboId == comboFoodDetail.ComboId);
                    context.ComboFoodDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static void UpdateComboFoodDetail(ComboFoodDetail comboFoodDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<ComboFoodDetail>(comboFoodDetail).State =
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
