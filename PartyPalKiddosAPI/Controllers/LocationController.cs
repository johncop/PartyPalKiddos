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

        [HttpGet("GetLocation")]
        public ActionResult<IEnumerable<Location>> getLocation()
            => repository.GetAllLocation();

        [HttpGet("getFoodById/{foodId}")]
        public ActionResult<Location> getLocationById(int foodId) =>
            repository.GetLocationById(foodId);

        [HttpGet("GetLocationByAddress/{address}")]
        public ActionResult<List<Location>> GetFoodtByName(string address) =>
            repository.GetLocationByName(address);

        [HttpPost("createLocation")]
        public ActionResult<Food> CreateFood(string? address, int? districtId, string? description, decimal? price)
        {
            Location l = new Location(address, districtId, description, price);
            repository.addLocation(l);
            return NoContent();
        }

        [HttpDelete("DeleteFood/id")]
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

        [HttpPut("UpdateFood")]
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
