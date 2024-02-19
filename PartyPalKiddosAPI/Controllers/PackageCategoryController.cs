using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.ICategoryRepository;
using Repository.Repository.CategoryRepository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageCategoryController : ControllerBase
    {
        private IPackageCategoryRepository repository = new PackageCategoryRepository();

        [HttpGet("package-categories")]
        public ActionResult<IEnumerable<PackageCategory>> getPackageCategory()
            => repository.GetAllPackageCategory();

        [HttpGet("package-categories/{id}")]
        public ActionResult<PackageCategory> getPackageById(int id) =>
            repository.GetPackageCategoryById(id);

        [HttpGet("package-categories/by-name")]
        public ActionResult<List<PackageCategory>> GetFoodCateByName(string packageCateName) =>
            repository.GetPackageCategoryByName(packageCateName);

        [HttpPost("package-categories")]
        public ActionResult<PackageCategory> CreateFoodCate(string categoryName, string? description)
        {
            PackageCategory f = new PackageCategory(categoryName, description);
            repository.addPackageCategory(f);
            return NoContent();
        }

        [HttpDelete("package-categories/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetPackageCategoryById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removePackageCategory(f);
            return NoContent();
        }

        [HttpPut("package-categories/{id}")]
        public IActionResult UpdateProduct(int id, string categoryName, string? description)
        {
            PackageCategory food = repository.GetPackageCategoryById(id);
            if (food == null)
            {
                return NotFound();
            }
            food = new PackageCategory(id, categoryName, description);
            repository.UpdatePackageCategory(food);
            return NoContent();
        }
    }
}
