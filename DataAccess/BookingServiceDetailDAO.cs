using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookingServiceDetailDAO
    {
        public static List<BookingServiceDetail> GetAllBookingServiceDetails()
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming BookingFoodDetail is a class that represents a single row in your database
                    var list = new List<BookingServiceDetail>();
                    list = context.BookingServiceDetails
                        .Select(detail => new BookingServiceDetail
                        {
                            BookingId = detail.BookingId,
                            ServiceId = detail.ServiceId,
                            ServicePackageId = detail.ServicePackageId,
                            ServiceQuantity = detail.ServiceQuantity,
                            ServicePackageQuantity = detail.ServicePackageQuantity,
                        }).ToList();

                    return list; // This now correctly matches the method signature
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message); // Consider specific exception handling or logging
            }
        }
        public static List<BookingServiceDetail> GetAllBookingService(int bookingId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming BookingFoodDetail is a class that represents a single row in your database
                    var list = new List<BookingServiceDetail>();
                    list = context.BookingServiceDetails
                        .Where(detail => detail.BookingId == bookingId)
                        .Select(detail => new BookingServiceDetail
                        {
                            BookingId = detail.BookingId,
                            ServiceId = detail.ServiceId,
                            ServicePackageId = detail.ServicePackageId,
                            ServiceQuantity = detail.ServiceQuantity,
                            ServicePackageQuantity = detail.ServicePackageQuantity,
                        }).ToList();

                    return list; // This now correctly matches the method signature
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message); // Consider specific exception handling or logging
            }
        }
        public static BookingServiceDetail GetBookingServiceDetails(int bookingId, int serviceId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming BookingFoodDetail is a class that represents a single row in your database
                    var bookingDetail = context.BookingServiceDetails
                        .Where(detail => detail.BookingId == bookingId && detail.ServiceId == serviceId)
                        .Select(detail => new BookingServiceDetail
                        {
                            BookingId = detail.BookingId,
                            ServiceId = detail.ServiceId,
                            ServicePackageId = detail.ServicePackageId,
                            ServiceQuantity = detail.ServiceQuantity,
                            ServicePackageQuantity = detail.ServicePackageQuantity,
                        }).FirstOrDefault(); // Change this line

                    return bookingDetail; // This now correctly matches the method signature
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message); // Consider specific exception handling or logging
            }
        }

        public static BookingServiceDetail GetBookingPackageDetails(int bookingId, int packageId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Assuming BookingFoodDetail is a class that represents a single row in your database
                    var bookingDetail = context.BookingServiceDetails
                        .Where(detail => detail.BookingId == bookingId && detail.ServicePackageId == packageId)
                        .Select(detail => new BookingServiceDetail
                        {
                            BookingId = detail.BookingId,
                            ServiceId = detail.ServiceId,
                            ServicePackageId = detail.ServicePackageId,
                            ServiceQuantity = detail.ServiceQuantity,
                            ServicePackageQuantity = detail.ServicePackageQuantity,
                        }).FirstOrDefault(); // Change this line

                    return bookingDetail; // This now correctly matches the method signature
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message); // Consider specific exception handling or logging
            }
        }
        public static void SaveBookingServiceDetail(BookingServiceDetail bookingSD)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var existingBooking = context.BookingServiceDetails
                        .FirstOrDefault(bookingdetail => bookingdetail.BookingId == bookingSD.BookingId && bookingdetail.ServiceId == bookingSD.ServiceId);

                    if (existingBooking != null)
                    {
                        existingBooking.BookingId = bookingSD.BookingId;
                        existingBooking.ServiceId = bookingSD.ServiceId;
                        existingBooking.ServiceQuantity = bookingSD.ServiceQuantity;
                        context.SaveChanges();
                    }
                    else
                    {
                        context.BookingServiceDetails.Add(bookingSD);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public static void SaveBookingPackageDetail(BookingServiceDetail bookingSD)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var existingBooking = context.BookingServiceDetails
                        .FirstOrDefault(bookingdetail => bookingdetail.BookingId == bookingSD.BookingId && bookingdetail.ServicePackageId == bookingSD.ServicePackageId);

                    if (existingBooking != null)
                    {
                        existingBooking.BookingId = bookingSD.BookingId;
                        existingBooking.ServicePackageId = bookingSD.ServicePackageId;
                        existingBooking.ServicePackageQuantity = bookingSD.ServicePackageQuantity;
                        context.SaveChanges();
                    }
                    else
                    {
                        context.BookingServiceDetails.Add(bookingSD);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public static void DeleteBookingServiceDetail(int bookingId, int serviceId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.BookingServiceDetails.SingleOrDefault(x => x.BookingId == bookingId && x.ServiceId == serviceId);
                    if (p1 != null)
                    {
                        context.BookingServiceDetails.Remove(p1);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
        }
        public static void DeleteBookingPackageDetail(int bookingId, int packageId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.BookingServiceDetails.SingleOrDefault(x => x.BookingId == bookingId && x.ServicePackageId == packageId);
                    if (p1 != null)
                    {
                        context.BookingServiceDetails.Remove(p1);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
        }
        public static void UpdateBookingServiceDetail(BookingServiceDetail bookingSD)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Find the existing record
                    var existingBooking = context.BookingServiceDetails
                                            .FirstOrDefault(bookingdetail => bookingdetail.BookingId == bookingSD.BookingId && bookingdetail.ServiceId == bookingSD.ServiceId);

                    if (existingBooking != null)
                    {
                        // Update properties
                        existingBooking.BookingId = bookingSD.BookingId;
                        existingBooking.ServiceId = bookingSD.ServiceId;
                        existingBooking.ServiceQuantity = bookingSD.ServiceQuantity;
                        // Add any other fields that need to be updated

                        // Mark the entity as modified
                        context.Entry(existingBooking).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                        // Save changes
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception($"No BookingFoodDetail found with BookingId {bookingSD.BookingId} and ServiceId {bookingSD.ServiceId}.");
                    }
                }
            }
            catch (Exception error)
            {
                // Consider logging the error as well
                throw new Exception(error.Message);
            }
        }

        public static void UpdateBookingPackageDetail(BookingServiceDetail bookingSD)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Find the existing record
                    var existingBooking = context.BookingServiceDetails
                                            .FirstOrDefault(bookingdetail => bookingdetail.BookingId == bookingSD.BookingId && bookingdetail.ServiceId == bookingSD.ServiceId);

                    if (existingBooking != null)
                    {
                        // Update properties
                        existingBooking.BookingId = bookingSD.BookingId;
                        existingBooking.ServicePackageId = bookingSD.ServicePackageId;
                        existingBooking.ServicePackageQuantity = bookingSD.ServicePackageQuantity;
                        // Add any other fields that need to be updated

                        // Mark the entity as modified
                        context.Entry(existingBooking).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                        // Save changes
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception($"No BookingFoodDetail found with BookingId {bookingSD.BookingId} and PackageId {bookingSD.ServicePackageQuantity}.");
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
