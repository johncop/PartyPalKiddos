using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.IImageRepository;
using Repository.Interface.Image;
using Repository.Repository.ImageRepository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageImageController : ControllerBase
    {
        private IPackageImageRepository repository = new PackageImageRepository();

        [HttpGet("package-image")]
        public ActionResult<IEnumerable<PackageImage>> getPackageImage()
            => repository.GetAllPackageImages();

        [HttpGet("package-image/{id}")]
        public ActionResult<PackageImage> getPackageById(int id) =>
            repository.GetPackageImageById(id);

        [HttpPost("package-image")]
        public IActionResult Post(string? imgUrl, int? packageId)
        {
            PackageImage pi = new PackageImage(imgUrl, packageId);
            repository.addPackageImage(pi);
            return Ok(new { success = true, message = "Package image Added successfully." });
        }

        [HttpDelete("package-image/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetPackageImageById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removePackageImage(f);
            return Ok(new { success = true, message = "Package Image Deleted successfully." });
        }

        [HttpPut("package-image/{id}")]
        public IActionResult UpdateProduct(int id, string? imgUrl, int? packageId)
        {
            PackageImage PackageImage = repository.GetPackageImageById(id);
            if (PackageImage == null)
            {
                return NotFound();
            }
            PackageImage = new PackageImage(id, imgUrl, packageId);
            repository.UpdatePackageImage(PackageImage);
            return Ok(new { success = true, message = "Package Image Updated successfully." });
        }
    }
}
