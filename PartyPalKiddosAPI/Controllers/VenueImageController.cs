using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.Image;
using Repository.Repository.ImageRepository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueImageController : ControllerBase
    {
        private IVenueImageRepository repository = new VenueImageRepository();

        [HttpGet("location-image")]
        public ActionResult<IEnumerable<VenueImage>> getVenueImage()
            => repository.GetAllVenueImages();

        [HttpGet("location-image/{id}")]
        public ActionResult<VenueImage> getPackageById(int id) =>
            repository.GetVenueImageById(id);

        [HttpPost("location-image")]
        public ActionResult<VenueImage> CreateVenueImage(string? imgUrl, int? venueId, byte[]? image)
        {
            VenueImage f = new VenueImage(imgUrl, venueId, image);
            repository.addVenueImage(f);
            return Ok(new { success = true, message = "Location image Added successfully." });
        }

        [HttpDelete("location-image/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetVenueImageById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeVenueImage(f);
            return Ok(new { success = true, message = "Location image deleted successfully." });
        }

        [HttpPut("location-image/{id}")]
        public IActionResult UpdateProduct(int id, string? imgUrl, int? venueId, byte[]? image)
        {
            VenueImage VenueImage = repository.GetVenueImageById(id);
            if (VenueImage == null)
            {
                return NotFound();
            }
            VenueImage = new VenueImage(id, imgUrl, venueId, image);
            repository.UpdateVenueImage(VenueImage);
            return Ok(new { success = true, message = "Location image updated successfully." });
        }
    }
}
