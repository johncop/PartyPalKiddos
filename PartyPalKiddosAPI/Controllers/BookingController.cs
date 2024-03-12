using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingRepository repository = new BookingRepository();
        [HttpPost("Bookings")]
        public IActionResult PostBooking(DateTime bookingDate, int userId, decimal bookingDetailId, int? paymentId, int? couponId, int? numberOfKids, int? numberOfAdults, string? bookingStatus)
        {
            Booking booking = new Booking(bookingDate, userId, bookingDetailId, paymentId, couponId, numberOfKids, numberOfAdults, bookingStatus);
            repository.addBooking(booking);
            return Ok(new { success = true, message = "Booking Added successfully." });
        }
        [HttpPut("Bookings")]
        public IActionResult UpdateBooking(int id, DateTime bookingDate, int userId, decimal bookingDetailId, int? paymentId, int? couponId, int? numberOfKids, int? numberOfAdults, string? bookingStatus)
        {
            var checkbooking = repository.GetBookingById(id);
            if (checkbooking == null)
            {
                return NotFound();
            }
            Booking booking = new Booking(id, bookingDate, userId, bookingDetailId, paymentId, couponId, numberOfKids, numberOfAdults, bookingStatus);
            repository.UpdateBooking(booking);
            return Ok(new { success = true, message = "Booking updated successfully." });
        }
        [HttpDelete("Bookings")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = repository.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            repository.removeBooking(booking);
            return Ok(new { success = true, message = "Booking deleted successfully." });
        }
        [HttpGet("Bookings")]
        public ActionResult<IEnumerable<Booking>> getAllBookings()
            => repository.GetAllBookings();

        [HttpGet("Bookings/{id}")]
        public ActionResult<Booking> getBookingById(int id) =>
            repository.GetBookingById(id);
    }
}
