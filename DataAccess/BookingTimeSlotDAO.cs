using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookingTimeSlotDAO
    {
        public static List<BookingTimeSlot> GetBookingTimeSlots()
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var listBookingTimeSlot = new List<BookingTimeSlot>();
                    listBookingTimeSlot = context.BookingTimeSlots
                .Select(timeslot => new BookingTimeSlot
                {
                    BookingId = timeslot.BookingId,
                    AvailableTimeslotId = timeslot.AvailableTimeslotId,

                }).ToList();
                    return listBookingTimeSlot;
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public static BookingTimeSlot FindBookingTimeSlotByBookingId(int bookingId)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    BookingTimeSlot bookingTimeSlot = new BookingTimeSlot();
                    bookingTimeSlot = context.BookingTimeSlots
                .Select(timeslot => new BookingTimeSlot
                {
                    BookingId = timeslot.BookingId,
                    AvailableTimeslotId = timeslot.AvailableTimeslotId,
                }).SingleOrDefault(x => x.BookingId == bookingId);
                    return bookingTimeSlot;
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public static void SaveBookingTimeSlot(BookingTimeSlot bookingTimeSlot)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.BookingTimeSlots.Add(bookingTimeSlot);
                    context.SaveChanges();
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public static void DeleteBookingTimeSlot(BookingTimeSlot bookingTimeSlot)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var p1 = context.BookingTimeSlots.SingleOrDefault(x => x.BookingId == bookingTimeSlot.BookingId);
                    if (p1 != null)
                    {
                        context.BookingTimeSlots.Remove(p1);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
        }
        public static void UpdateBookingTimeSlot(BookingTimeSlot bookingTimeSlot)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<BookingTimeSlot>(bookingTimeSlot).State =
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
