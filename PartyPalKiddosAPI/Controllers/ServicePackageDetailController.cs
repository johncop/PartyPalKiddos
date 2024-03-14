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
        public ActionResult<IEnumerable<ServicePackageDetail>> getServicePackageDetailById(int servicePackageId) =>
            repository.GetServicePackageDetailByServicePackageId(servicePackageId);

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

        [HttpDelete("package-detail/{id}")]
        public IActionResult DeleteServicePackageDetail(int servicePackageId, int serviceId)
        {
            var ServicePackageDetail = repository.GetServicePackageDetails(servicePackageId, serviceId);
            if (ServicePackageDetail == null)
            {
                return NotFound();
            }
            repository.removeServicePackageDetail(ServicePackageDetail);
            return Ok(new { success = true, message = "ServicePackageDetail deleted successfully." });
        }
    }
}
