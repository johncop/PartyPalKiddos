using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingTimeSlotController : ControllerBase
    {
        private readonly IBookingTimeSlotRepository repository = new BookingTimeSlotRepository();

        [HttpPost("BookingTimeSlots")]
        public IActionResult PostBookingTimeSlot(int? bookingId, int? availableTimeslotId)
        {
            BookingTimeSlot bookingTimeSlot = new BookingTimeSlot
            {
                BookingId = bookingId,
                AvailableTimeslotId = availableTimeslotId
            };
            repository.AddBookingTimeSlot(bookingTimeSlot);
            return Ok(new { success = true, message = "Booking time slot added successfully." });
        }

        [HttpPut("BookingTimeSlots")]
        public IActionResult UpdateBookingTimeSlot(int bookingId, int? availableTimeslotId) // Assuming these are the identifiers
        {
            var checkBookingTimeSlot = repository.GetBookingTimeSlotById(bookingId);
            if (checkBookingTimeSlot == null)
            {
                return NotFound();
            }

            BookingTimeSlot bookingTimeSlot = new BookingTimeSlot
            {
                BookingId = bookingId,
                AvailableTimeslotId = availableTimeslotId
            };
            repository.UpdateBookingTimeSlot(bookingTimeSlot);
            return Ok(new { success = true, message = "Booking time slot updated successfully." });
        }

        [HttpDelete("BookingTimeSlots/{bookingId}/{availableTimeslotId}")]
        public IActionResult DeleteBookingTimeSlot(int bookingId)
        {
            var bookingTimeSlot = repository.GetBookingTimeSlotById(bookingId);
            if (bookingTimeSlot == null)
            {
                return NotFound();
            }
            repository.RemoveBookingTimeSlot(bookingTimeSlot);
            return Ok(new { success = true, message = "Booking time slot deleted successfully." });
        }

        [HttpGet("BookingTimeSlots")]
        public ActionResult<IEnumerable<BookingTimeSlot>> GetAllBookingTimeSlots() => repository.GetAllBookingTimeSlots();

        [HttpGet("BookingTimeSlots/{bookingId}/{availableTimeslotId}")]
        public ActionResult<BookingTimeSlot> GetBookingTimeSlotById(int bookingId) => repository.GetBookingTimeSlotById(bookingId);
    }
}
