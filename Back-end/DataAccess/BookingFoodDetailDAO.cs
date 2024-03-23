using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookingFoodDetailDAO
    {
        public static List<BookingFoodDetail> GetAllBookingFoodDetails()
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming BookingFoodDetail is a class that represents a single row in your database
                    var list = new List<BookingFoodDetail>();
                    list = context.BookingFoodDetails
                        .Select(detail => new BookingFoodDetail
                        {
                            BookingId = detail.BookingId,
                            FoodId = detail.FoodId,
                            ComboId = detail.ComboId,
                            FoodQuantity = detail.FoodQuantity,
                            ComboQuantity = detail.ComboQuantity,
                        }).ToList();

                    return list; // This now correctly matches the method signature
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message); // Consider specific exception handling or logging
            }
        }
        public static List<BookingFoodDetail> GetAllBookingFood(int bookingId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming BookingFoodDetail is a class that represents a single row in your database
                    var list = new List<BookingFoodDetail>();
                    list = context.BookingFoodDetails
                        .Where(detail => detail.BookingId == bookingId)
                        .Select(detail => new BookingFoodDetail
                        {
                            BookingId = detail.BookingId,
                            FoodId = detail.FoodId,
                            ComboId = detail.ComboId,
                            FoodQuantity = detail.FoodQuantity,
                            ComboQuantity = detail.ComboQuantity
                        }).ToList(); 

                    return list; // This now correctly matches the method signature
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message); // Consider specific exception handling or logging
            }
        }
        public static BookingFoodDetail GetBookingComboDetails(int bookingId, int comboId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming BookingFoodDetail is a class that represents a single row in your database
                    var bookingFoodDetail = context.BookingFoodDetails
                        .Where(detail => detail.BookingId == bookingId && detail.FoodId == comboId)
                        .Select(detail => new BookingFoodDetail
                        {
                            BookingId = detail.BookingId,
                            FoodId = detail.FoodId,
                            ComboId = detail.ComboId,
                            FoodQuantity = detail.FoodQuantity,
                            ComboQuantity = detail.ComboQuantity
                        }).FirstOrDefault(); // Change this line

                    return bookingFoodDetail; // This now correctly matches the method signature
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message); // Consider specific exception handling or logging
            }
        }

        public static BookingFoodDetail GetBookingFoodDetails(int bookingId, int foodId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming BookingFoodDetail is a class that represents a single row in your database
                    var bookingFoodDetail = context.BookingFoodDetails
                        .Where(detail => detail.BookingId == bookingId && detail.FoodId == foodId)
                        .Select(detail => new BookingFoodDetail
                        {
                            BookingId = detail.BookingId,
                            FoodId = detail.FoodId,
                            ComboId = detail.ComboId,
                            FoodQuantity = detail.FoodQuantity,
                            ComboQuantity = detail.ComboQuantity
                        }).FirstOrDefault(); // Change this line

                    return bookingFoodDetail; // This now correctly matches the method signature
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message); // Consider specific exception handling or logging
            }
        }
        public static void SaveBookingFoodDetail(BookingFoodDetail bookingFD)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming bookingFD.BookingId and bookingFD.FoodId uniquely identify a BookingFoodDetail
                    var existingBookingFD = context.BookingFoodDetails
                        .FirstOrDefault(bfd => bfd.BookingId == bookingFD.BookingId && bfd.FoodId == bookingFD.FoodId);

                    if (existingBookingFD != null)
                    {
                        // Update properties
                        existingBookingFD.BookingId = bookingFD.BookingId;
                        existingBookingFD.FoodId = bookingFD.BookingId;
                        existingBookingFD.FoodQuantity = bookingFD.FoodQuantity;

                        // As the entity is being tracked by EF context, we just need to save changes
                        context.SaveChanges();
                    }
                    else
                    {
                        // Handle the case where no matching record is found
                        // For instance, add a new record if that's the intended behavior
                        context.BookingFoodDetails.Add(bookingFD);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public static void SaveBookingComboDetail(BookingFoodDetail bookingFD)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming bookingFD.BookingId and bookingFD.FoodId uniquely identify a BookingFoodDetail
                    var existingBookingFD = context.BookingFoodDetails
                        .FirstOrDefault(bfd => bfd.BookingId == bookingFD.BookingId && bfd.ComboId == bookingFD.ComboId);

                    if (existingBookingFD != null)
                    {
                        // Update properties
                        existingBookingFD.BookingId = bookingFD.BookingId;
                        existingBookingFD.ComboId = bookingFD.ComboId;
                        existingBookingFD.ComboQuantity = bookingFD.ComboQuantity;
                        // As the entity is being tracked by EF context, we just need to save changes
                        context.SaveChanges();
                    }
                    else
                    {
                        // Handle the case where no matching record is found
                        // For instance, add a new record if that's the intended behavior
                        context.BookingFoodDetails.Add(bookingFD);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public static void DeleteBookingFoodDetail(int bookingId, int foodId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.BookingFoodDetails.SingleOrDefault(x => x.BookingId == bookingId && x.FoodId == foodId);
                    if (p1 != null)
                    {
                        context.BookingFoodDetails.Remove(p1);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
        }
        public static void DeleteBookingComboDetail(int bookingId, int comboId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.BookingFoodDetails.SingleOrDefault(x => x.BookingId == bookingId && x.ComboId == comboId);
                    if (p1 != null)
                    {
                        context.BookingFoodDetails.Remove(p1);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
        }
        public static void UpdateBookingFoodDetail(BookingFoodDetail bookingFD)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Find the existing record
                    var existingBookingFD = context.BookingFoodDetails
                        .FirstOrDefault(bfd => bfd.BookingId == bookingFD.BookingId && bfd.FoodId == bookingFD.FoodId);

                    if (existingBookingFD != null)
                    {
                        // Update properties
                        existingBookingFD.FoodId = bookingFD.BookingId;
                        existingBookingFD.FoodQuantity = bookingFD.FoodQuantity;
                        // Add any other fields that need to be updated

                        // Mark the entity as modified
                        context.Entry(existingBookingFD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                        // Save changes
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception($"No BookingFoodDetail found with BookingId {bookingFD.BookingId} and FoodId {bookingFD.FoodId}.");
                    }
                }
            }
            catch (Exception error)
            {
                // Consider logging the error as well
                throw new Exception(error.Message);
            }
        }

        public static void UpdateBookingComboDetail(BookingFoodDetail bookingFD)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Find the existing record
                    var existingBookingFD = context.BookingFoodDetails
                        .FirstOrDefault(bfd => bfd.BookingId == bookingFD.BookingId && bfd.ComboId == bookingFD.ComboId);

                    if (existingBookingFD != null)
                    {
                        // Update properties
                        existingBookingFD.ComboId = bookingFD.ComboId;
                        existingBookingFD.ComboQuantity = bookingFD.ComboQuantity;
                        // Add any other fields that need to be updated

                        // Mark the entity as modified
                        context.Entry(existingBookingFD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                        // Save changes
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception($"No BookingFoodDetail found with BookingId {bookingFD.BookingId} and FoodId {bookingFD.FoodId}.");
                    }
                }
            }
            catch (Exception error)
            {
                // Consider logging the error as well
                throw new Exception(error.Message);
            }
        }
    }
}
