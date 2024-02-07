using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private IDrinkRepository repository = new DrinkRepository();

        [HttpGet("GetDrink")]
        public ActionResult<IEnumerable<Drink>> getDrink()
            => repository.GetAllDrinks();

        [HttpGet("getDrinkById/{drinkId}")]
        public ActionResult<Drink> getPackageById(int drinkId) =>
            repository.GetDrinkById(drinkId);

        [HttpGet("GetDrinkByName/{foodName}")]
        public ActionResult<List<Drink>> GetDrinkByName(string drinkName) =>
            repository.GetDrinkByName(drinkName);

        [HttpPost("CreateFood")]
        public ActionResult<Drink> CreateDrink(string drinkName, string? description, int? drinkCategoryId, decimal price)
        {
            Drink f = new Drink(drinkName, description, drinkCategoryId, price);
            repository.addDrink(f);
            return NoContent();
        }

        [HttpDelete("DeleteDrink/id")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetDrinkById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeDrink(f);
            return NoContent();
        }

        [HttpPut("UpdateDrink")]
        public IActionResult UpdateProduct(int id, string drinkName, string? description, int? drinkCategoryId, decimal price)
        {
            Drink drink = repository.GetDrinkById(id);
            if (drink == null)
            {
                return NotFound();
            }
            drink = new Drink(id, drinkName, description, drinkCategoryId, price);
            repository.UpdateDrink(drink);
            return NoContent();
        }
    }
}
