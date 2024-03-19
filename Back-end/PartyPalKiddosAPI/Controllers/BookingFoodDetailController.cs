using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingFoodDetailController : ControllerBase
    {
        private readonly IBookingFoodDetailRepository repository = new BookingFoodDetailRepository();
        [HttpGet("AllBookingFoodDetail")]
        public ActionResult<IEnumerable<BookingFoodDetail>> GetAllBookingFoodDetails() => repository.GetAllBookingFoodDetails();
        [HttpGet("BookingFoodDetail/{BookingId}")]
        public ActionResult<IEnumerable<BookingFoodDetail>> GetAllBookingFood(int bookingId) => repository.GetAllBookingFood(bookingId);
        [HttpGet("BookingFoodDetail/{BookingId}/{FoodId}")]
        public BookingFoodDetail GetBookingFoodDetail(int bookingId, int foodId) => repository.GetBookingFoodDetails(bookingId, foodId);
        [HttpGet("BookingFoodDetail/{BookingId}/{ComboId}")]
        public BookingFoodDetail GetBookingComboDetail(int bookingId, int comboId) => repository.GetBookingComboDetails(bookingId, comboId);
        [HttpPost("BookingFoodDetail1")]
        public IActionResult PostBookingFoodDetail(int? bookingId, int? foodId, int? foodQuantity)
        {
            BookingFoodDetail foodDetail = new BookingFoodDetail
            {
                BookingId = bookingId,
                FoodId = foodId,
                FoodQuantity = foodQuantity,
            };
            repository.SaveBookingFoodDetail(foodDetail);
            return Ok(new { success = true, message = "FoodDetail added successfully." });
        }
        [HttpPost("BookingComboDetail2")]
        public IActionResult PostBookingComboDetail(int? bookingId, int? comboId, int? comboQuantity)
        {
            BookingFoodDetail comboDetail = new BookingFoodDetail
            {
                BookingId = bookingId,
                ComboId = comboId,
                ComboQuantity = comboQuantity,
            };
            repository.SaveBookingFoodDetail(comboDetail);
            return Ok(new { success = true, message = "ComboDetail added successfully." });
        }
        [HttpPut("BookingFoodDetail1")]
        public IActionResult UpdateBookingFoodDetail(int? bookingId, int? foodId, int? foodQuantity)
        {
            var checkbooking = repository.GetBookingFoodDetails((int)bookingId, (int)foodId);
            if (checkbooking == null)
            {
                return NotFound();
            }
            BookingFoodDetail foodDetail = new BookingFoodDetail
            {
                BookingId = bookingId,
                FoodId = foodId,
                FoodQuantity = foodQuantity,
            };
            repository.UpdateBookingFoodDetail(foodDetail);
            return Ok(new { success = true, message = "FoodDetail updated successfully." });
        }
        [HttpPut("BookingComboDetail2")]
        public IActionResult UpdateBookingComboDetail(int? bookingId, int? comboId, int? comboQuantity)
        {
            var checkbooking = repository.GetBookingComboDetails((int)bookingId, (int)comboId);
            if (checkbooking == null)
            {
                return NotFound();
            }
            BookingFoodDetail comboDetail = new BookingFoodDetail
            {
                BookingId = bookingId,
                ComboId = comboId,
                ComboQuantity = comboQuantity,
            };
            repository.UpdateBookingComboDetail(comboDetail);
            return Ok(new { success = true, message = "FoodDetail updated successfully." });
        }
        [HttpDelete("BookingFoodDetail1")]
        public IActionResult DeleteBookingFoodDetail(int? bookingId, int? foodId)
        {
            var checkbooking = repository.GetBookingFoodDetails((int)bookingId, (int)foodId);
            if (checkbooking == null)
            {
                return NotFound();
            }
            repository.DeleteBookingFoodDetail((int)checkbooking.BookingId, (int)checkbooking.FoodId);
            return Ok(new { success = true, message = "Food Detail deleted successfully." });
        }
        [HttpDelete("BookingComboDetail2")]
        public IActionResult DeleteBookingComboDetail(int? bookingId, int? comboId)
        {
            var checkbooking = repository.GetBookingComboDetails((int)bookingId, (int)comboId);
            if (checkbooking == null)
            {
                return NotFound();
            }
            repository.DeleteBookingFoodDetail((int)checkbooking.BookingId, (int)checkbooking.ComboId);
            return Ok(new { success = true, message = "Combo Detail deleted successfully." });
        }
    }
}
