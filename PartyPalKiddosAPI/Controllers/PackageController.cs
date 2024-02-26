using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private IPackageRepository repository = new PackageRepository();

        [HttpPost("packages")]
        public IActionResult PostPackage(string? packageName, int? numberOfKid, int? userId, int? locationId, DateTime? startTime, DateTime? endTime, decimal? price, int? status)
        {
            if (!startTime.HasValue || !endTime.HasValue || !locationId.HasValue)
            {
                return BadRequest("Start time, end time, and location are required.");
            }
            if (!repository.isTimeSlotAvaiable(locationId.Value, startTime.Value, endTime.Value))
            {
                return Conflict("The selected time slot is not available for this location.");
            }
            Package p = new Package(packageName, numberOfKid, userId, locationId, startTime, endTime, price, status);
            repository.addPackage(p);
            return NoContent();
        }

        [HttpPut("packages")]
        public IActionResult UpdatePackage(int id,string? packageName, int? numberOfKid, int? userId, int? locationId, DateTime? startTime, DateTime? endTime, decimal? price, int? status)
        {
            var package = repository.GetPackageById(id);
            if(package == null)
            {
                return NotFound();
            }
            Package p = new Package(packageName, numberOfKid, userId, locationId, startTime, endTime, price, status);
            repository.UpdatePackage(p);
            return NoContent();
        }

        [HttpDelete("packages")]
        public IActionResult DeletePackage(int id)
        {
            var package = repository.GetPackageById(id);
            if (package == null)
            {
                return NotFound();
            }
            repository.removePackage(package);
            return NoContent();
        }

        [HttpGet("packages")]
        public ActionResult<IEnumerable<Package>> getPackage()
            => repository.GetAllPackage();

        [HttpGet("packages/{packageId}")]
        public ActionResult<Package> getPackageById(int packageId) =>
            repository.GetPackageById(packageId);

        [HttpGet("packages/by-name")]
        public ActionResult<IEnumerable<Package>> getPackageByName(string packageName) =>
            repository.GetPackagetByName(packageName);

        [HttpGet("packages/by-user/{userId}")]
        public ActionResult<IEnumerable<Package>> getPackageByUserId(int userId) =>
            repository.GetPackagetByUserId(userId);
    }
}
