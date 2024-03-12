using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBookingRepository
    {
        void addBooking(Booking booking);
        void removeBooking(Booking booking);
        void UpdateBooking(Booking booking);
        List<Booking> GetAllBookings();
        Booking GetBookingById(int id);
    }
}
