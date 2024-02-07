using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private ILocationRepository repository = new LocationRepository();

        [HttpGet("locations")]
        public ActionResult<IEnumerable<Location>> getLocation()
            => repository.GetAllLocation();

        [HttpGet("locations/{locationId}")]
        public ActionResult<Location> getLocationById(int locationId) =>
            repository.GetLocationById(locationId);

        [HttpGet("locations/by-name")]
        public ActionResult<List<Location>> GetLocationByName(string address) =>
            repository.GetLocationByName(address);

        [HttpPost("locations")]
        public ActionResult<Location> createLocation(string? address, int? districtId, string? description, decimal? price)
        {
            Location l = new Location(address, districtId, description, price);
            repository.addLocation(l);
            return NoContent();
        }

        [HttpDelete("locations/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetLocationById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeLocation(f);
            return NoContent();
        }

        [HttpPut("locations/{id}")]
        public IActionResult UpdateProduct(int id, string? address, int? districtId, string? description, decimal? price)
        {
            Location location = repository.GetLocationById(id);
            if (location == null)
            {
                return NotFound();
            }
            location = new Location(id, address, districtId, description, price);
            repository.UpdateLocation(location);
            return NoContent();
        }
    }
}
