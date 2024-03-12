using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBookingTimeSlotRepository
    {
        void AddBookingTimeSlot(BookingTimeSlot bookingTimeSlot);
        void RemoveBookingTimeSlot(BookingTimeSlot bookingTimeSlot);
        void UpdateBookingTimeSlot(BookingTimeSlot bookingTimeSlot);
        List<BookingTimeSlot> GetAllBookingTimeSlots();
        BookingTimeSlot GetBookingTimeSlotById(int bookingId);
    }

}
