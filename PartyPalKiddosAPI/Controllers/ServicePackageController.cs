using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePackageController : ControllerBase
    {
        private IServicePackageRepository repository = new ServicePackageRepository();

        [HttpPost("ServicePackages")]
        public IActionResult PostServicePackage(string? packageName, int? hostId, decimal? price, int? status)
        {           
            ServicePackage p = new ServicePackage(packageName, hostId, price, status);
            repository.addServicePackage(p);
            return Ok(new { success = true, message = "ServicePackage Added successfully." });
        }

        [HttpPut("ServicePackages")]
        public IActionResult UpdateServicePackage(int id, string? packageName, int? hostId, decimal? price, int? status)
        {
            var ServicePackage = repository.GetServicePackageById(id);
            if (ServicePackage == null)
            {
                return NotFound();
            }
            ServicePackage p = new ServicePackage(packageName, hostId, price, status);
            repository.UpdateServicePackage(p);
            return Ok(new { success = true, message = "ServicePackage updated successfully." });
        }

        /*[HttpPut("ServicePackages/clone-ServicePackage/{id}")]
        public IActionResult CloneServicePackage(int id, string? ServicePackageName, int? numberOfKid, int? numberOfAdults, int? userId, int? locationId, DateTime? startTime, DateTime? endTime, decimal? price)
        {
            var existingServicePackage = repository.GetServicePackageById(id);
            if (existingServicePackage == null)
            {
                return NotFound("The ServicePackage does not exist.");
            }

            // Check if the time slot is available for the new ServicePackage
            if (!repository.isTimeSlotAvaiable(locationId ?? existingServicePackage.LocationId, startTime ?? existingServicePackage.StartTime, endTime ?? existingServicePackage.EndTime))
            {
                return Conflict("The selected time slot is not available for this location.");
            }

            // Clone the ServicePackage with new customizations
            ServicePackage newServicePackage = ServicePackageDAO.CloneServicePackage(existingServicePackage, ServicePackageName, numberOfKid, numberOfAdults, userId, locationId, startTime, endTime, price);

            // Add the new ServicePackage as a new entity in the database
            repository.addServicePackage(newServicePackage);

            return NoContent();
        }
*/

        [HttpDelete("ServicePackages")]
        public IActionResult DeleteServicePackage(int id)
        {
            var ServicePackage = repository.GetServicePackageById(id);
            if (ServicePackage == null)
            {
                return NotFound();
            }
            repository.removeServicePackage(ServicePackage);
            return NoContent();
        }

        [HttpGet("ServicePackages")]
        public ActionResult<IEnumerable<ServicePackage>> getServicePackage()
            => repository.GetAllServicePackage();

        [HttpGet("ServicePackages/{ServicePackageId}")]
        public ActionResult<ServicePackage> getServicePackageById(int ServicePackageId) =>
            repository.GetServicePackageById(ServicePackageId);

        [HttpGet("ServicePackages/by-name")]
        public ActionResult<IEnumerable<ServicePackage>> getServicePackageByName(string ServicePackageName) =>
            repository.GetServicePackagetByName(ServicePackageName);

    }
}
