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

        [HttpGet("Foods/by-mame")]
        public ActionResult<List<Food>> GetFoodByName(string FoodName) =>
            repository.GetFoodByName(FoodName);

        [HttpPost("Foods")]
        public ActionResult<Food> CreateFood(string? foodName, string? description, string? imageUrl, byte[]? image, int? foodCategoryId, decimal? price)
        {
            Food food = new Food(foodName, description, imageUrl,image, foodCategoryId, price);
            repository.addFood(food);
            return Ok(new { success = true, message = "Food updated successfully." });
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
