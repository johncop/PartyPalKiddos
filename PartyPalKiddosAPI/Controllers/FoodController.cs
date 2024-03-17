using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private IFoodRepository repository = new FoodRepository();

        [HttpGet("Foods")]
        public ActionResult<IEnumerable<Food>> getFood()
            => repository.GetAllFoods();

        [HttpGet("Foods/{foodId}")]
        public ActionResult<Food> getPackageById(int foodId) =>
            repository.GetFoodById(foodId);

        [HttpGet("Foods/by-name")]
        public ActionResult<List<Food>> GetFoodByName(string FoodName) =>
            repository.GetFoodByName(FoodName);

        [HttpGet("Foods/by-category")]
        public ActionResult<List<Food>> GetFoodByCategory(int id) =>
            repository.GetFoodByCategory(id);
        [HttpPost("Foods")]
        public async Task<ActionResult<Food>> CreateFood(string? foodName, string? description, string? imageUrl, IFormFile? file, int? foodCategoryId, decimal? price)
        {
            byte[] imageBytes = null;
            if (file != null)
            {
                // This reads the uploaded file into a byte array.
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }
            }

            Food food = new Food
            {
                FoodName = foodName,
                Description = description,
                Image = imageBytes, // Now correctly assigning byte[] to byte[]
                ImageUrl = imageUrl, // Assuming you're not using this field now
                FoodCategoryId = foodCategoryId,
                Price = price,
            };
            repository.addFood(food);
            return Ok(new { success = true, message = "Food created successfully." });
        }


        [HttpDelete("Foods/{id}")]
        public IActionResult DeleteFood(int id)
        {
            var f = repository.GetFoodById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeFood(f);
            return Ok(new { success = true, message = "Food deleted successfully." });
        }

        [HttpPut("Foods/{id}")]
        public IActionResult UpdateFood(int id, string? foodName, string? description, string? imageUrl, byte[]? image, int? foodCategoryId, decimal? price)
        {
            Food Food = repository.GetFoodById(id);
            if (Food == null)
            {
                return NotFound();
            }
            Food = new Food(id, foodName, description, imageUrl,image,foodCategoryId, price);
            repository.UpdateFood(Food);
            return Ok(new { success = true, message = "Food Updated successfully." });
        }
    }
}
