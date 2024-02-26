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
    public class DrinkCategoryController : ControllerBase
    {
        /*private IDrinkCategoryRepository repository = new DrinkCategoryRepository();

        [HttpGet("drink-categories")]
        public ActionResult<IEnumerable<DrinkCategory>> getDrink()
            => repository.GetAllDrinkCategory();

        [HttpGet("drink-categories/{drinkCateId}")]
        public ActionResult<DrinkCategory> getPackageById(int drinkCateId) =>
            repository.GetDrinkCategoryById(drinkCateId);

        [HttpGet("drink-categories/by-name")]
        public ActionResult<List<DrinkCategory>> GetDrinkByName(string drinkCateName) =>
            repository.GetDrinkCategoryByName(drinkCateName);

        [HttpPost("drink-categories")]
        public ActionResult<DrinkCategory> CreateDrink(string categoryName, string? description)
        {
            DrinkCategory f = new DrinkCategory(categoryName, description);
            repository.addDrinkCategory(f);
            return NoContent();
        }

        [HttpDelete("drink-categories/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetDrinkCategoryById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeDrinkCategory(f);
            return NoContent();
        }

        [HttpPut("drink-categories/{id}")]
        public IActionResult UpdateProduct(int id, string categoryName, string? description)
        {
            DrinkCategory drink = repository.GetDrinkCategoryById(id);
            if (drink == null)
            {
                return NotFound();
            }
            drink = new DrinkCategory(id, categoryName, description);
            repository.UpdateDrinkCategory(drink);
            return NoContent();
        }*/
    }
}
