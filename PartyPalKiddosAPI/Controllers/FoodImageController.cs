using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.Image;
using Repository.Repository.ImageRepository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodImageController : ControllerBase
    {
        private IFoodImageRepository repository = new FoodImageRepository();

        [HttpGet("food-image")]
        public ActionResult<IEnumerable<FoodImage>> getFoodImage()
            => repository.GetAllFoodImages();

        [HttpGet("food-image/{id}")]
        public ActionResult<FoodImage> getPackageById(int id) =>
            repository.GetFoodImageById(id);

        [HttpPost("food-image")]
        public ActionResult<FoodImage> CreateFoodImage(string? imgUrl, int? drinkId)
        {
            FoodImage f = new FoodImage(imgUrl, drinkId);
            repository.addFoodImage(f);
            return NoContent();
        }

        [HttpDelete("food-image/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetFoodImageById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeFoodImage(f);
            return NoContent();
        }

        [HttpPut("food-image/{id}")]
        public IActionResult UpdateProduct(int id, string? imgUrl, int? drinkId)
        {
            FoodImage FoodImage = repository.GetFoodImageById(id);
            if (FoodImage == null)
            {
                return NotFound();
            }
            FoodImage = new FoodImage(id, imgUrl, drinkId);
            repository.UpdateFoodImage(FoodImage);
            return NoContent();
        }
    }
}
