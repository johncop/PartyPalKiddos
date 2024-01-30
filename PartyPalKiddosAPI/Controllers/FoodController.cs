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
        private IFoodReposiroty repository = new FoodRepository();

        [HttpGet("GetFood")]
        public ActionResult<IEnumerable<Food>> getFood()
            => repository.GetAllFoods();

        [HttpGet("getFoodById/{foodId}")]
        public ActionResult<Food> getPackageById(int foodId) =>
            repository.GetFoodById(foodId);

        [HttpGet("GetFoodByName/{foodName}")]
        public ActionResult<List<Food>> GetFoodtByName(string foodName) =>
            repository.GetFoodByName(foodName);

        [HttpPost("CreateFood")]
        public ActionResult<Food> CreateFood(string foodName, string? description, int? foodCategoryId, decimal price)
        {
            Food f = new Food(foodName, description, foodCategoryId, price);
            repository.addFood(f);
            return NoContent();
        }

        [HttpDelete("DeleteFood/id")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetFoodById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeFood(f);
            return NoContent();
        }

        [HttpPut("UpdateFood")]
        public IActionResult UpdateProduct(int id, string foodName, string? description, int? foodCategoryId, decimal price)
        {
            Food food = repository.GetFoodById(id);
            if (food == null)
            {
                return NotFound();
            }
            food = new Food(id, foodName, description, foodCategoryId, price);
            repository.UpdateFood(food);
            return NoContent();
        }
    }
}
