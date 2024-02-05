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

        [HttpPost("AddPackage")]
        public IActionResult PostPackage(string? packageName, int? packageCategoryId, int? userId, int? locationId, decimal? price, int? status)
        {
            Package p = new Package(packageName, packageCategoryId, userId, locationId, price, status);
            repository.addPackage(p);
            return NoContent();
        }
        [HttpPut("UpdatePackage")]
        public IActionResult UpdatePackage(int id,string? packageName, int? packageCategoryId, int? userId, int? locationId, decimal? price, int? status)
        {
            var package = repository.GetPackageById(id);
            if(package == null)
            {
                return NotFound();
            }
            Package p = new Package(id, packageName, packageCategoryId, userId, locationId, price, status);
            repository.UpdatePackage(p);
            return NoContent();
        }
        [HttpDelete("DeletePackage")]
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
        [HttpGet("GetAllPackage")]
        public ActionResult<IEnumerable<Package>> getPackage()
            => repository.GetAllPackage();

        [HttpGet("GetPackageById")]
        public ActionResult<Package> getPackageById(int packageId) =>
            repository.GetPackageById(packageId);

        [HttpGet("GetPackageByPackageName")]
        public ActionResult<IEnumerable<Package>> getPackageByName(string packageName) =>
            repository.GetPackagetByName(packageName);

        [HttpGet("GetPackageByUserId")]
        public ActionResult<IEnumerable<Package>> getPackageByUserId(int userId) =>
            repository.GetPackagetByUserId(userId);
    }
}
