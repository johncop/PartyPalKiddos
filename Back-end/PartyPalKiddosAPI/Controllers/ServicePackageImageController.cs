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
    public class ServicePackageImageController : ControllerBase
    {
        private IServicePackageImageRepository repository = new ServicePackageImageRepository();

        [HttpGet("package-image")]
        public ActionResult<IEnumerable<ServicePackageImage>> getServicePackageImage()
            => repository.GetAllServicePackageImages();

        [HttpGet("package-image/{id}")]
        public ActionResult<ServicePackageImage> getPackageById(int id) =>
            repository.GetServicePackageImageById(id);

        [HttpPost("package-image")]
        public IActionResult Post(string? imgUrl, byte[]? image, int? packageId)
        {
            ServicePackageImage pi = new ServicePackageImage(imgUrl,image, packageId);
            repository.addServicePackageImage(pi);
            return Ok(new { success = true, message = "Package image Added successfully." });
        }

        [HttpDelete("package-image/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetServicePackageImageById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeServicePackageImage(f);
            return Ok(new { success = true, message = "Package Image Deleted successfully." });
        }

        [HttpPut("package-image/{id}")]
        public IActionResult UpdateProduct(int id, string? imgUrl, byte[]? image, int? packageId)
        {
            ServicePackageImage ServicePackageImage = repository.GetServicePackageImageById(id);
            if (ServicePackageImage == null)
            {
                return NotFound();
            }
            ServicePackageImage = new ServicePackageImage(imgUrl, image, packageId);
            repository.UpdateServicePackageImage(ServicePackageImage);
            return Ok(new { success = true, message = "Package Image Updated successfully." });
        }
    }
}
