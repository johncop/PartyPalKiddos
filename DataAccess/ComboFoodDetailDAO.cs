using BusinessObject.Models;
using Microsoft.Data.SqlClient;
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
        #region QUERY
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

        public static List<ComboFoodDetail> findComboFoodDetailByComboId(int comboId)
        {
            List<ComboFoodDetail> f = new List<ComboFoodDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    f = context.ComboFoodDetails
                        .Where(x => x.ComboId == comboId)
                .Select(ComboFoodDetail => new ComboFoodDetail
                {
                    ComboId = ComboFoodDetail.ComboId,
                    Combo = ComboFoodDetail.Combo,
                    FoodId = ComboFoodDetail.FoodId,
                    Food = ComboFoodDetail.Food,
                    Quantity = ComboFoodDetail.Quantity,
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return f;
        }

        public static ComboFoodDetail GetComboFoodDetails(int comboId, int foodId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming BookingFoodDetail is a class that represents a single row in your database
                    var bookingFoodDetail = context.ComboFoodDetails
                        .Where(detail => detail.ComboId == comboId && detail.FoodId == foodId)
                        .Select(detail => new ComboFoodDetail
                        {
                            ComboId = detail.ComboId,
                            FoodId = detail.FoodId,
                            Quantity = detail.Quantity,
                        }).FirstOrDefault(); // Change this line

                    return bookingFoodDetail; // This now correctly matches the method signature
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message); // Consider specific exception handling or logging
            }
        }
        #endregion



        #region COMMAND
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
                    var sql = "DELETE FROM dbo.ComboFoodDetail WHERE combo_id = @comboId AND food_id = @foodId";

                    // Execute the raw SQL query
                    context.Database.ExecuteSqlRaw(sql,
                        new SqlParameter("@comboId", comboFoodDetail.ComboId),
                        new SqlParameter("@foodId", comboFoodDetail.FoodId));
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void DeleteComboDetail(int comboId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var sql = "DELETE FROM dbo.ComboFoodDetail WHERE combo_id = @comboId";

                    // Execute the raw SQL query
                    context.Database.ExecuteSqlRaw(sql, new SqlParameter("@comboId", comboId));
                }
            }
            catch (Exception e)
            {
                // It's generally a bad practice to throw a new exception like this because it can obscure the original stack trace.
                // Consider logging the error and/or rethrowing the original exception if needed.
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
