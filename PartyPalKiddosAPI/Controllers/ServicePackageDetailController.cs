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
    public class ServicePackageDetailController : ControllerBase
    {
        private IServicePackageDetailRepository repository = new ServicePackageDetailRepository();

        [HttpPost("package-detail")]
        public IActionResult PostServicePackageDetail([FromBody] List<ServicePackageDetail> ServicePackageDetails)
        {            
            foreach (var detail in ServicePackageDetails)
            {
                ServicePackageDetail pt = new ServicePackageDetail(detail.ServicePackageId, detail.ServiceId, detail.Quantity);
                repository.addServicePackageDetail(pt);
            }

            return Ok(new { success = true, message = "ServicePackageDetail Added successfully." });
        }
        [HttpGet("package-detail")]
        public ActionResult<IEnumerable<ServicePackageDetail>> getServicePackageDetail()
            => repository.GetAllServicePackageDetail();

        [HttpGet("package-detail/{packageId}")]
        public ActionResult<IEnumerable<ServicePackageDetail>> getServicePackageDetailById(int packageId) =>
            repository.GetServicePackageDetailByServicePackageId(packageId);

        [HttpPut("package-detail/{id}")]
        public IActionResult UpdateServicePackageDetail(int packageId, int? serviceId, int? quantity)
        {
            var ServicePackageDetail = repository.GetServicePackageDetailByServicePackageId(packageId);
            if (ServicePackageDetail == null)
            {
                return NotFound();
            }
            ServicePackageDetail pt = new ServicePackageDetail(packageId, serviceId, quantity);
            repository.UpdateServicePackageDetail(pt);
            return Ok(new { success = true, message = "ServicePackageDetail updated successfully." });
        }

        [HttpPut("package-detail/{id}")]
        public IActionResult UpdateServicePackageDetail(int id, int? serviceId, int? quantity)
        {
            var ServicePackageDetail = repository.GetServicePackageDetailByPackageId(id); // Method to get the package detail by its ID
            if (ServicePackageDetail == null)
            {
                return NotFound();
            }

            // Now that we have the ServicePackageDetail, let's update its properties
            if (serviceId.HasValue)
            {
                ServicePackageDetail.ServiceId = serviceId.Value;
            }
            if (quantity.HasValue)
            {
                ServicePackageDetail.Quantity = quantity.Value;
            }

            // The repository should have a method to update the ServicePackageDetail
            repository.UpdateServicePackageDetail(ServicePackageDetail);

            return NoContent();
        }

        [HttpDelete("package-detail/{id}")]
        public IActionResult DeleteServicePackageDetail(int id)
        {
            var ServicePackageDetail = repository.GetServicePackageDetailByPackageId(id);
            if (ServicePackageDetail == null)
            {
                return NotFound();
            }
            repository.removeServicePackageDetail(ServicePackageDetail);
            return Ok(new { success = true, message = "ServicePackageDetail deleted successfully." });
        }
    }
}
