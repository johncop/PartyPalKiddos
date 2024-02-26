using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Interface.Image;
using Repository.Repository.ImageRepository;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkImageController : ControllerBase
    {
        /*private IDrinkImageRepository repository = new DrinkImageRepository();

        [HttpGet("drink-image")]
        public ActionResult<IEnumerable<DrinkImage>> getDrinkImage()
            => repository.GetAllDrinkImages();

        [HttpGet("drink-image/{DrinkImageId}")]
        public ActionResult<DrinkImage> getPackageById(int DrinkImageId) =>
            repository.GetDrinkImageById(DrinkImageId);

        [HttpPost("drink-image")]
        public ActionResult<DrinkImage> CreateDrinkImage(string? imgUrl, int? drinkId)
        {
            DrinkImage f = new DrinkImage(imgUrl, drinkId);
            repository.addDrinkImage(f);
            return NoContent();
        }

        [HttpDelete("drink-image/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetDrinkImageById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeDrinkImage(f);
            return NoContent();
        }

        [HttpPut("drink-image/{id}")]
        public IActionResult UpdateProduct(int id, string? imgUrl, int? drinkId)
        {
            DrinkImage DrinkImage = repository.GetDrinkImageById(id);
            if (DrinkImage == null)
            {
                return NotFound();
            }
            DrinkImage = new DrinkImage(id, imgUrl, drinkId);
            repository.UpdateDrinkImage(DrinkImage);
            return NoContent();
        }*/
    }
}
