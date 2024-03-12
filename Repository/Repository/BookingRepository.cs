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
    public class BookingRepository : IBookingRepository
    {
        public void addBooking(Booking booking) => BookingDAO.SaveBooking(booking);

        public List<Booking> GetAllBookings() => BookingDAO.GetBookings();

        public Booking GetBookingById(int id) => BookingDAO.findBookingById(id);

        public void removeBooking(Booking booking) => BookingDAO.DeleteBooking(booking);

        public void UpdateBooking(Booking booking) => BookingDAO.SaveBooking(booking);
    }
}
