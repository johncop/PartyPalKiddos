using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageTagController : ControllerBase
    {
        private IPackageTagRepository repository = new PackageTagRepository();

        [HttpPost("package-tag")]
        public IActionResult PostPackageTag(int? packageId, int? categoryId, string? description)
        {
            PackageTag pt = new PackageTag(packageId, categoryId, description);
            repository.addPackageTag(pt);
            return NoContent();
        }
        [HttpGet("package-tag")]
        public ActionResult<IEnumerable<PackageTag>> getPackageTag()
            => repository.GetPackageTag();

        [HttpGet("package-tag/by-category/{cateId}")]
        public ActionResult<IEnumerable<PackageTag>> getPackageByCategoryId(int cateId)
    => repository.GetPackageByCategoryId(cateId);

        [HttpGet("package-tag/by-package/{packageId}")]
        public ActionResult<IEnumerable<PackageTag>> getCategoryByPackageId(int packageId)
            => repository.GetCategoryByPackageId(packageId);


        [HttpPut("package-tag/{id}")]
        public IActionResult UpdatePackageTag(int packageId, int? categoryId, string? description)
        {
            var PackageTag = repository.GetPackageTagByPackageId(packageId);
            if (PackageTag == null)
            {
                return NotFound();
            }
            PackageTag pt = new PackageTag(packageId, categoryId, description);
            repository.UpdatePackageTag(pt);
            return NoContent();
        }

        [HttpDelete("package-tag/{id}")]
        public IActionResult DeletePackageTag(int id)
        {
            var PackageTag = repository.GetPackageTagByPackageId(id);
            if (PackageTag == null)
            {
                return NotFound();
            }
            repository.removePackageTag(PackageTag);
            return NoContent();
        } 
    }
}
