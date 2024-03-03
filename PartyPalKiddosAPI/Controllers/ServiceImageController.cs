using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.Image;
using Repository.Repository.ImageRepository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceImageController : ControllerBase
    {
        private IServiceImageRepository repository = new ServiceImageRepository();

        [HttpGet("service-image")]
        public ActionResult<IEnumerable<ServiceImage>> getServiceImage()
            => repository.GetAllServiceImages();

        [HttpGet("service-image/{id}")]
        public ActionResult<ServiceImage> getPackageById(int id) =>
            repository.GetServiceImageById(id);

        [HttpPost("service-image")]
        public IActionResult CreateServiceImage(string? imgUrl, int? serviceId)
        {
            ServiceImage si = new ServiceImage(imgUrl, serviceId);
            repository.addServiceImage(si);
            return NoContent();
        }

        [HttpDelete("service-image/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetServiceImageById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeServiceImage(f);
            return NoContent();
        }

        [HttpPut("service-image/{id}")]
        public IActionResult UpdateProduct(int id, string? imgUrl, int? serviceId)
        {
            ServiceImage ServiceImage = repository.GetServiceImageById(id);
            if (ServiceImage == null)
            {
                return NotFound();
            }
            ServiceImage = new ServiceImage(id, imgUrl, serviceId);
            repository.UpdateServiceImage(ServiceImage);
            return NoContent();
        }
    }
}
