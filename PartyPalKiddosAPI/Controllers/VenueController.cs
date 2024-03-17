using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private IVenueRepository repository = new VenueRepository();

        [HttpGet("Venues")]
        public ActionResult<IEnumerable<Venue>> getVenue()
            => repository.GetAllVenue();

        [HttpGet("Venues/{VenueId}")]
        public ActionResult<Venue> getVenueById(int VenueId) =>
            repository.GetVenueById(VenueId);

        [HttpGet("Venues/by-name")]
        public ActionResult<List<Venue>> GetVenueByName(string venueName) =>
            repository.GetVenueByName(venueName);

        [HttpPost("Venues")]
        public ActionResult<Venue> createVenue(string? venueName, string? address, int? capacity, int? districtId, string? description, decimal? price, TimeSpan? openHour, TimeSpan? closeHour, string? status)
        {
            Venue Venue = new Venue(venueName, address, capacity, districtId, description,price, openHour,closeHour, status);
            repository.addVenue(Venue);
            return Ok(new { success = true, message = "Venue Added successfully." });
        }

        [HttpDelete("Venues/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetVenueById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeVenue(f);
            return Ok(new { success = true, message = "Venue deleted successfully." });
        }

        [HttpPut("Venues/{id}")]
        public IActionResult UpdateVenue(int id, string? venueName, string? address, int? capacity, int? districtId, string? description, decimal? price, TimeSpan? openHour, TimeSpan? closeHour, string? status)
        {
            Venue Venue = repository.GetVenueById(id);
            if (Venue == null)
            {
                return NotFound();
            }
            Venue = new Venue(id, venueName, address, capacity, districtId, description,price, openHour, closeHour, status);
            repository.UpdateVenue(Venue);
            return Ok(new { success = true, message = "Venue updated successfully." });
        }
    }
}
