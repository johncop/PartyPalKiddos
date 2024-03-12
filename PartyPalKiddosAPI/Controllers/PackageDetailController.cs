/*using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageDetailController : ControllerBase
    {
        private IPackageDetailRepository repository = new PackageDetailRepository();

        [HttpPost("package-detail")]
        public IActionResult PostPackageDetail([FromBody] List<PackageDetail> packageDetails)
        {
            *//*PackageDetail pt = new PackageDetail(packageId, serviceId, quantity);
            repository.addPackageDetail(pt);
            return NoContent();*//*
            foreach (var detail in packageDetails)
            {
                PackageDetail pt = new PackageDetail(detail.PackageId, detail.ServiceId, detail.Quantity);
                repository.addPackageDetail(pt);
            }

            return Ok(new { success = true, message = "PackageDetail Added successfully." });
        }
        [HttpGet("package-detail")]
        public ActionResult<IEnumerable<PackageDetail>> getPackageDetail()
            => repository.GetAllPackageDetail();

        [HttpGet("package-detail/{packageId}")]
        public ActionResult<PackageDetail> getPackageDetailById(int packageId) =>
            repository.GetPackageDetailByPackageId(packageId);

        [HttpGet("package-detail/by-package/{packageId}")]
        public ActionResult<IEnumerable<PackageDetail>> getServiceByPackageId(int packageId)
            => repository.GetServiceByPackageId(packageId);


        [HttpPut("package-detail/{id}")]
        public IActionResult UpdatePackageDetail(int packageId, int? serviceId, int? quantity)
        {
            var PackageDetail = repository.GetPackageDetailByPackageId(packageId);
            if (PackageDetail == null)
            {
                return NotFound();
            }
            PackageDetail pt = new PackageDetail(packageId, serviceId, quantity);
            repository.UpdatePackageDetail(pt);
            return Ok(new { success = true, message = "PackageDetail updated successfully." });
        }

        *//*[HttpPut("package-detail/{id}")]
        public IActionResult UpdatePackageDetail(int id, int? serviceId, int? quantity)
        {
            var packageDetail = repository.GetPackageDetailByPackageId(id); // Method to get the package detail by its ID
            if (packageDetail == null)
            {
                return NotFound();
            }

            // Now that we have the packageDetail, let's update its properties
            if (serviceId.HasValue)
            {
                packageDetail.ServiceId = serviceId.Value;
            }
            if (quantity.HasValue)
            {
                packageDetail.Quantity = quantity.Value;
            }

            // The repository should have a method to update the packageDetail
            repository.UpdatePackageDetail(packageDetail);

            return NoContent();
        }*//*

        [HttpDelete("package-detail/{id}")]
        public IActionResult DeletePackageDetail(int id)
        {
            var PackageDetail = repository.GetPackageDetailByPackageId(id);
            if (PackageDetail == null)
            {
                return NotFound();
            }
            repository.removePackageDetail(PackageDetail);
            return Ok(new { success = true, message = "PackageDetail deleted successfully." });
        }
    }
}
*/