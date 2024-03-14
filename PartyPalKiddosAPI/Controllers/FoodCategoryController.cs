using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Interface.ICategoryRepository;
using Repository.Repository;
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
            => repository.GetAllFoodCategory();

        [HttpGet("food-categories/{foodCateId}")]
        public ActionResult<FoodCategory> getPackageById(int foodCateId) =>
            repository.GetFoodCategoryById(foodCateId);

        [HttpGet("food-categories/by-mame")]
        public ActionResult<List<FoodCategory>> GetFoodCategoryByName(string FoodCategoryName) =>
            repository.GetFoodCategoryByName(FoodCategoryName);

        [HttpPost("food-categories")]
        public ActionResult<FoodCategory> CreateFoodCategory(string? FoodCategoryName, string? description, int? FoodCategoryCategoryId, decimal? price)
        {
            FoodCategory s = new FoodCategory(FoodCategoryName, description);
            repository.addFoodCategory(s);
            return Ok(new { success = true, message = "FoodCategory updated successfully." });
        }

        [HttpDelete("food-categories/{id}")]
        public IActionResult DeleteFoodCategory(int id)
        {
            var f = repository.GetFoodCategoryById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeFoodCategory(f);
            return Ok(new { success = true, message = "FoodCategory deleted successfully." });
        }

        [HttpPut("food-categories/{id}")]
        public IActionResult UpdateFoodCategory(int id, string FoodCategoryName, string? description, int? FoodCategoryCategoryId, decimal price)
        {
            FoodCategory FoodCategory = repository.GetFoodCategoryById(id);
            if (FoodCategory == null)
            {
                return NotFound();
            }
            FoodCategory = new FoodCategory(id, FoodCategoryName, description);
            repository.UpdateFoodCategory(FoodCategory);
            return Ok(new { success = true, message = "FoodCategory Updated successfully." });
        }
    }
}
