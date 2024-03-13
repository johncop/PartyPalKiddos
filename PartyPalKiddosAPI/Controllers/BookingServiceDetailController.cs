using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingServiceDetailController : ControllerBase
    {
        private readonly IBookingServiceDetailRepository repository = new BookingServiceDetailRepository();
        [HttpGet("AllBookingServiceDetail")]
        public ActionResult<IEnumerable<BookingServiceDetail>> GetAllBookingServiceDetails() => repository.GetAllBookingServiceDetails();
        [HttpGet("AllBookingServiceDetail/{BookingId}")]
        public ActionResult<IEnumerable<BookingServiceDetail>> GetAllBookingService(int bookingId) => repository.GetAllBookingService(bookingId);
        [HttpGet("BookingServiceDetail/{BookingId}/{ServiceId}")]
        public BookingServiceDetail GetBookingServiceDetail(int bookingId, int serviceId) => repository.GetBookingServiceDetail(bookingId, serviceId);
        [HttpGet("BookingPackageDetail/{BookingId}/{PackageId}")]
        public BookingServiceDetail GetBookingPackageDetail(int bookingId, int packageId) => repository.GetBookingPackageDetail(bookingId, packageId);
        [HttpPost("BookingServiceDetail")]
        public IActionResult PostBookingFoodDetail(int? bookingId, int? serviceId, int? serviceQuantity)
        {
            BookingServiceDetail service = new BookingServiceDetail
            {
                BookingId = bookingId,
                ServiceId = serviceId,
                ServiceQuantity = serviceQuantity,
            };
            repository.SaveBookingServiceDetail(service);
            return Ok(new { success = true, message = "ServiceDetail added successfully." });
        }
        [HttpPost("BookingPackageDetail")]
        public IActionResult PostBookingPackageDetail(int? bookingId, int? packageId, int? packageQuantity)
        {
            BookingServiceDetail service = new BookingServiceDetail
            {
                BookingId = bookingId,
                ServicePackageId = packageId,
                ServicePackageQuantity = packageQuantity,
            };
            repository.SaveBookingServiceDetail(service);
            return Ok(new { success = true, message = "PackageDetail added successfully." });
        }
        [HttpPut("BookingServiceDetail")]
        public IActionResult UpdateBookingSerivceDetail(int? bookingId, int? serviceId, int? serviceQuantity)
        {
            var checkbooking = repository.GetBookingServiceDetail((int)bookingId, (int)serviceId);
            if (checkbooking == null)
            {
                return NotFound();
            }
            BookingServiceDetail service = new BookingServiceDetail
            {
                BookingId = bookingId,
                ServiceId = serviceId,
                ServiceQuantity = serviceQuantity,
            };
            repository.UpdateBookingServiceDetail(service);
            return Ok(new { success = true, message = "ServiceDetail updated successfully." });
        }
        [HttpPut("BookingPackageDetail")]
        public IActionResult UpdateBookingPackageDetail(int? bookingId, int? packageId, int? packageQuantity)
        {
            var checkbooking = repository.GetBookingPackageDetail((int)bookingId, (int)packageId);
            if (checkbooking == null)
            {
                return NotFound();
            }
            BookingServiceDetail service = new BookingServiceDetail
            {
                BookingId = bookingId,
                ServicePackageId = packageId,
                ServicePackageQuantity = packageQuantity,
            };
            repository.UpdateBookingPackageDetail(service);
            return Ok(new { success = true, message = "PackageDetail updated successfully." });
        }
        [HttpDelete("BookingFoodDetail")]
        public IActionResult DeleteBookingServiceDetail(int? bookingId, int? serviceId)
        {
            var checkbooking = repository.GetBookingServiceDetail((int)bookingId, (int)serviceId);
            if (checkbooking == null)
            {
                return NotFound();
            }
            repository.DeleteBookingServiceDetail((int)checkbooking.BookingId, (int)checkbooking.ServiceId);
            return Ok(new { success = true, message = "ServiceDetail deleted successfully." });
        }
        [HttpDelete("BookingFoodDetail")]
        public IActionResult DeleteBookingPackageDetail(int? bookingId, int? packageId)
        {
            var checkbooking = repository.GetBookingServiceDetail((int)bookingId, (int)packageId);
            if (checkbooking == null)
            {
                return NotFound();
            }
            repository.DeleteBookingServiceDetail((int)checkbooking.BookingId, (int)checkbooking.PackageId);
            return Ok(new { success = true, message = "PackageDetail deleted successfully." });
        }
    }
}
