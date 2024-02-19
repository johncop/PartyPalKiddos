using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.ICategoryRepository;
using Repository.Repository.CategoryRepository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCategoryController : ControllerBase
    {
        private IFoodCategoryRepository repository = new FoodCategoryRepository();

        [HttpGet("food-categories")]
        public ActionResult<IEnumerable<FoodCategory>> getFoodCategory()
            => repository.GetAllFoodCategories();

        [HttpGet("food-categories/{id}")]
        public ActionResult<FoodCategory> getPackageById(int id) =>
            repository.GetFoodCategoryById(id);

        [HttpGet("food-categories/by-name")]
        public ActionResult<List<FoodCategory>> GetFoodCateByName(string foodCateName) =>
            repository.GetFoodByName(foodCateName);

        [HttpPost("food-categories")]
        public ActionResult<FoodCategory> CreateFoodCate(string categoryName, string? description)
        {
            FoodCategory f = new FoodCategory(categoryName, description);
            repository.addFood(f);
            return NoContent();
        }

        [HttpDelete("food-categories/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetFoodCategoryById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeFoodCategory(f);
            return NoContent();
        }

        [HttpPut("food-categories/{id}")]
        public IActionResult UpdateProduct(int id, string categoryName, string? description)
        {
            FoodCategory food = repository.GetFoodCategoryById(id);
            if (food == null)
            {
                return NotFound();
            }
            food = new FoodCategory(id, categoryName, description);
            repository.UpdateFoodCategory(food);
            return NoContent();
        }
    }
}
