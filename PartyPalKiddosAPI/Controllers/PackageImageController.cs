﻿using BusinessObject.Models;
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
        public ActionResult<PackageImage> CreatePackageImage(string? imgUrl, int? packageId)
        {
            PackageImage f = new PackageImage(imgUrl, packageId);
            repository.addPackageImage(f);
            return NoContent();
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
            return NoContent();
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
            return NoContent();
        }
    }
}
