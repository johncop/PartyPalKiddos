using BusinessObject.Models;
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
        public IActionResult PostPackageDetail(int? packageId, int? serviceId, int? quantity)
        {
            PackageDetail pt = new PackageDetail(packageId, serviceId, quantity);
            repository.addPackageDetail(pt);
            return NoContent();
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
            return NoContent();
        }

        [HttpDelete("package-detail/{id}")]
        public IActionResult DeletePackageDetail(int id)
        {
            var PackageDetail = repository.GetPackageDetailByPackageId(id);
            if (PackageDetail == null)
            {
                return NotFound();
            }
            repository.removePackageDetail(PackageDetail);
            return NoContent();
        }
    }
}
