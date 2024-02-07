using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.ICategoryRepository;
using Repository.Repository.CategoryRepository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoryController : ControllerBase
    {
        private IServiceCategoryRepository repository = new ServiceCategoryRepository();

        [HttpGet("service-categories")]
        public ActionResult<IEnumerable<ServiceCategory>> getServiceCategory()
            => repository.GetAllServiceCategory();

        [HttpGet("service-categories/{id}")]
        public ActionResult<ServiceCategory> getServiceCategoryById(int id) =>
            repository.GetServiceCategoryById(id);

        [HttpGet("service-categories/by-name")]
        public ActionResult<List<ServiceCategory>> GetServiceCategoryByName(string foodCateName) =>
            repository.GetServiceCategoryByName(foodCateName);

        [HttpPost("service-categories")]
        public ActionResult<ServiceCategory> CreateServiceCategory(string categoryName, string? description)
        {
            ServiceCategory f = new ServiceCategory(categoryName, description);
            repository.addServiceCategory(f);
            return NoContent();
        }

        [HttpDelete("service-categories/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetServiceCategoryById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeServiceCategory(f);
            return NoContent();
        }

        [HttpPut("service-categories/{id}")]
        public IActionResult UpdateProduct(int id, string categoryName, string? description)
        {
            ServiceCategory food = repository.GetServiceCategoryById(id);
            if (food == null)
            {
                return NotFound();
            }
            food = new ServiceCategory(id, categoryName, description);
            repository.UpdateServiceCategory(food);
            return NoContent();
        }
    }
}
