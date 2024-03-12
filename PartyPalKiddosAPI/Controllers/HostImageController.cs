using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.Image;
using Repository.Repository.ImageRepository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostImageController : ControllerBase
    {
        private IHostImageRepository repository = new HostImageRepository();

        [HttpGet("location-image")]
        public ActionResult<IEnumerable<HostImage>> getHostImage()
            => repository.GetAllHostImages();

        [HttpGet("location-image/{id}")]
        public ActionResult<HostImage> getPackageById(int id) =>
            repository.GetHostImageById(id);

        [HttpPost("location-image")]
        public ActionResult<HostImage> CreateHostImage(string? imgUrl, int? drinkId)
        {
            HostImage f = new HostImage(imgUrl, drinkId);
            repository.addHostImage(f);
            return Ok(new { success = true, message = "Location image Added successfully." });
        }

        [HttpDelete("location-image/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetHostImageById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeHostImage(f);
            return Ok(new { success = true, message = "Location image deleted successfully." });
        }

        [HttpPut("location-image/{id}")]
        public IActionResult UpdateProduct(int id, string? imgUrl, int? drinkId)
        {
            HostImage HostImage = repository.GetHostImageById(id);
            if (HostImage == null)
            {
                return NotFound();
            }
            HostImage = new HostImage(id, imgUrl, drinkId);
            repository.UpdateHostImage(HostImage);
            return Ok(new { success = true, message = "Location image updated successfully." });
        }
    }
}
