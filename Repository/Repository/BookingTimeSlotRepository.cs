using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class BookingTimeSlotRepository : IBookingTimeSlotRepository
    {
        public void AddBookingTimeSlot(BookingTimeSlot bookingTimeSlot) => BookingTimeSlotDAO.SaveBookingTimeSlot(bookingTimeSlot);

        public List<BookingTimeSlot> GetAllBookingTimeSlots() => BookingTimeSlotDAO.GetBookingTimeSlots();

        public BookingTimeSlot GetBookingTimeSlotById(int bookingId) => BookingTimeSlotDAO.FindBookingTimeSlotByBookingId(bookingId);

        public void RemoveBookingTimeSlot(BookingTimeSlot bookingTimeSlot) => BookingTimeSlotDAO.DeleteBookingTimeSlot(bookingTimeSlot);

        public void UpdateBookingTimeSlot(BookingTimeSlot bookingTimeSlot) => BookingTimeSlotDAO.UpdateBookingTimeSlot(bookingTimeSlot);
    }

}
