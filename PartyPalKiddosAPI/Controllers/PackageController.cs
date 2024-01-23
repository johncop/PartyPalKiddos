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

        [HttpGet("GetPackage")]
        public ActionResult<IEnumerable<Package>> getPackage()
            => repository.GetAllPackage();

        [HttpGet("Package/{packageId}")]
        public ActionResult<Package> getPackageById(int packageId) =>
            repository.GetPackageById(packageId);
    }
}
