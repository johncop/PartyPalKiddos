using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookingDAO
    {
        public static List<Booking> GetBookings()
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var listBooking = new List<Booking>();
                    listBooking = context.Bookings
                        .Include(booking => booking.BookingTimeSlots) // Include BookingTimeSlots
                        .Include(booking => booking.BookingFoodDetails)
                        .Include(booking => booking.BookingServiceDetails)
                .Select(booking => new Booking
                {
                    Id = booking.Id,
                    BookingDate = booking.BookingDate,
                    UserId = booking.UserId,
                    PaymentId = booking.PaymentId,
                    CouponId = booking.CouponId,
                    NumberOfAdults = booking.NumberOfAdults,
                    NumberOfKids = booking.NumberOfKids,
                    BookingStatus = booking.BookingStatus,
                    BookingTimeSlots = booking.BookingTimeSlots,
                    BookingFoodDetails = booking.BookingFoodDetails,
                    BookingServiceDetails= booking.BookingServiceDetails,
                }).ToList();
                    return listBooking;
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public static Booking findBookingById(int id)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    Booking booking = new Booking();
                    booking = context.Bookings
                .Select(booking => new Booking
                {
                    Id = booking.Id,
                    BookingDate = booking.BookingDate,
                    UserId = booking.UserId,
                    PaymentId = booking.PaymentId,
                    CouponId = booking.CouponId,
                    NumberOfAdults = booking.NumberOfAdults,
                    NumberOfKids = booking.NumberOfKids,
                    BookingStatus = booking.BookingStatus,
                }).SingleOrDefault(x => x.Id == id);
                    return booking;
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public static void SaveBooking(Booking booking)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Bookings.Add(booking);
                    context.SaveChanges();
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public static void SaveBookingFirst(Booking booking, int availableTimeSlotId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    // Check if the AvailableTimeSlot is actually available
                    var availableTimeSlot = context.AvailableTimeSlots
                        .SingleOrDefault(ts => ts.Id == availableTimeSlotId);

                    if (availableTimeSlot != null && availableTimeSlot.Status == "Available")
                    {
                        // Change the status of the AvailableTimeSlot to "Booked"
                        availableTimeSlot.Status = "Not Available";
                        booking.BookingStatus = "Booking";
                        // Add the new booking
                        context.Bookings.Add(booking);

                        // Save changes to get the new booking id
                        context.SaveChanges();

                        // booking.Id will now have the auto-incremented ID from the database after SaveChanges() is called.

                        // Create a new BookingTimeSlot with the new booking id and the availableTimeSlotId
                        var bookingTimeSlot = new BookingTimeSlot
                        {
                            BookingId = booking.Id, // EF populates this after SaveChanges
                            AvailableTimeslotId = availableTimeSlotId
                        };

                        // Add the new BookingTimeSlot
                        context.BookingTimeSlots.Add(bookingTimeSlot);

                        // Save all changes to the database
                        context.SaveChanges();
                    }
                    if (availableTimeSlot != null && availableTimeSlot.Status == "Not Available")
                    {
                        throw new Exception("The timeslot is booked");
                    }
                    else
                    {
                        throw new Exception("The timeslot is not available or does not exist.");
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error saving booking: " + error.Message);
            }
        }

        public static void DeleteBooking(Booking booking)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.Bookings.SingleOrDefault(x => x.Id == booking.Id);
                    context.Bookings.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
        }
        public static void UpdateBooking(Booking booking)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<Booking>(booking).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
        }
    }
}
