using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private IDistrictRepository repository = new DistrictRepository();

        [HttpGet("Districts")]
        public ActionResult<IEnumerable<District>> getDistrict()
            => repository.GetAllDistricts();

        [HttpGet("Districts/{DistrictId}")]
        public ActionResult<District> getDistrictById(int DistrictId) =>
            repository.GetDistrictById(DistrictId);

        [HttpGet("Districts/by-name")]
        public ActionResult<List<District>> GetDistrictByName(string address) =>
            repository.GetDistrictByName(address);

        [HttpPost("Districts")]
        public ActionResult<District> createDistrict(string? description)
        {
            District District = new District(description);
            repository.addDistrict(District);
            return Ok(new { success = true, message = "District Added successfully." });
        }

        [HttpDelete("Districts/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetDistrictById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeDistrict(f);
            return Ok(new { success = true, message = "District deleted successfully." });
        }

        [HttpPut("Districts/{id}")]
        public IActionResult UpdateProduct(int id, string? description)
        {
            District District = repository.GetDistrictById(id);
            if (District == null)
            {
                return NotFound();
            }
            District = new District(id, description);
            repository.UpdateDistrict(District);
            return Ok(new { success = true, message = "District updated successfully." });
        }
    }
}
