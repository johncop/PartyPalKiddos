using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VenueFoodDetailDAO
    {
        #region QUERY
        public static List<VenueFoodDetail> GetVenueFoodDetails()
        {
            var listVenueFoodDetails = new List<VenueFoodDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenueFoodDetails = context.VenueFoodDetails
                    .Select(hcd => new VenueFoodDetail
                    {
                        VenueId = hcd.VenueId,
                        FoodId = hcd.FoodId,
                    })
                    .ToList();
                    return listVenueFoodDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<VenueFoodDetail> FindVenueFoodDetailById(int VenueId)
        {
            var listVenueFoodDetails = new List<VenueFoodDetail>();
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    listVenueFoodDetails = context.VenueFoodDetails
                        .Where(hcd => hcd.VenueId == VenueId)
                    .Select(hcd => new VenueFoodDetail
                    {
                        VenueId = hcd.VenueId,
                        FoodId = hcd.FoodId,
                    })
                    .ToList();
                    return listVenueFoodDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static VenueFoodDetail GetVenueFoodDetailByIds(int VenueId, int foodId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var hcd = context.VenueFoodDetails
                         .Where(hcd => hcd.VenueId == VenueId && hcd.FoodId == foodId)
                     .Select(hcd => new VenueFoodDetail
                     {
                         VenueId = hcd.VenueId,
                         FoodId = hcd.FoodId
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

        public static void SaveVenueFoodDetail(VenueFoodDetail VenueFoodDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.VenueFoodDetails.Add(VenueFoodDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void SaveVenueFoodDetailByCategory(int foodCategoryId, int venueId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Find all Food items that have the given food category ID
                    var foodItems = context.Foods
                                           .Where(f => f.FoodCategoryId == foodCategoryId)
                                           .ToList();

                    // Create a list of VenueFoodDetail from the food items found
                    var venueFoodDetails = foodItems.Select(foodItem => new VenueFoodDetail
                    {
                        FoodId = foodItem.Id,
                        VenueId = venueId
                    }).ToList();

                    // Add all VenueFoodDetail items to the context
                    context.VenueFoodDetails.AddRange(venueFoodDetails);

                    // Save all changes in the context
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static string SaveVenueFoodDetailByCategoryAndVenueName(int foodCategoryId, string venueName)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Check if the food category exists
                    var categoryExists = context.FoodCategories.Any(fc => fc.Id == foodCategoryId);
                    if (!categoryExists)
                    {
                        return "Food category not found.";
                    }

                    // Find the venue by name
                    var venues = context.Venues.Where(v => v.VenueName == venueName).ToList();
                    if (!venues.Any())
                    {
                        return "Venue not found.";
                    }

                    // Find all Food items that have the given food category ID
                    var foodItems = context.Foods
                                           .Where(f => f.FoodCategoryId == foodCategoryId)
                                           .ToList();

                    // Loop through each venue and add all food items to its details
                    foreach (var venue in venues)
                    {
                        var venueFoodDetails = foodItems.Select(foodItem => new VenueFoodDetail
                        {
                            FoodId = foodItem.Id,
                            VenueId = venue.Id // Assuming venue.Id is the identifier for Venue
                        }).ToList();

                        // Add all VenueFoodDetail items to the context
                        context.VenueFoodDetails.AddRange(venueFoodDetails);
                    }

                    // Save all changes in the context
                    context.SaveChanges();
                    return "VenueFoodDetails saved successfully.";
                }
            }
            catch (Exception e)
            {
                return $"An error occurred: {e.Message}";
            }
        }


        public static void DeleteVenueFoodDetail(VenueFoodDetail VenueFoodDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.VenueFoodDetails.SingleOrDefault(x => x.VenueId == VenueFoodDetail.VenueId && x.FoodId == VenueFoodDetail.FoodId);
                    context.VenueFoodDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void DeleteVenueFoodDetailsByVenueId(int venueId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Find all VenueFoodDetail records that have the given venue ID
                    var venueFoodDetails = context.VenueFoodDetails
                                                  .Where(vfd => vfd.VenueId == venueId)
                                                  .ToList();

                    // Remove all found VenueFoodDetail records from the context
                    context.VenueFoodDetails.RemoveRange(venueFoodDetails);

                    // Save all changes in the context
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateVenueFoodDetail(VenueFoodDetail VenueFoodDetail)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<VenueFoodDetail>(VenueFoodDetail).State =
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
