using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.Image;
using Repository.Repository.ImageRepository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationImageController : ControllerBase
    {
        private ILocationImageRepository repository = new LocationImageRepository();

        [HttpGet("location-image")]
        public ActionResult<IEnumerable<LocationImage>> getLocationImage()
            => repository.GetAllLocationImages();

        [HttpGet("location-image/{id}")]
        public ActionResult<LocationImage> getPackageById(int id) =>
            repository.GetLocationImageById(id);

        [HttpPost("location-image")]
        public ActionResult<LocationImage> CreateLocationImage(string? imgUrl, int? drinkId)
        {
            LocationImage f = new LocationImage(imgUrl, drinkId);
            repository.addLocationImage(f);
            return NoContent();
        }

        [HttpDelete("location-image/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetLocationImageById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeLocationImage(f);
            return NoContent();
        }

        [HttpPut("location-image/{id}")]
        public IActionResult UpdateProduct(int id, string? imgUrl, int? drinkId)
        {
            LocationImage LocationImage = repository.GetLocationImageById(id);
            if (LocationImage == null)
            {
                return NotFound();
            }
            LocationImage = new LocationImage(id, imgUrl, drinkId);
            repository.UpdateLocationImage(LocationImage);
            return NoContent();
        }
    }
}
