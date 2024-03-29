﻿using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private IServiceRepository repository = new ServiceRepository();

        [HttpGet("services")]
        public ActionResult<IEnumerable<Service>> getService()
            => repository.GetAllService();

        [HttpGet("services/{serivceId}")]
        public ActionResult<Service> getPackageById(int serivceId) =>
            repository.GetServiceById(serivceId);

        [HttpGet("services/by-mame")]
        public ActionResult<List<Service>> GetServiceByName(string serviceName) =>
            repository.GetServiceByName(serviceName);

        [HttpPost("services")]
        public ActionResult<Service> CreateService(string? serviceName, string? description, int? serviceCategoryId, string? imageUrl, byte[]? image, decimal? price)
        {
            Service s = new Service(serviceName, description, serviceCategoryId,imageUrl,image, price);
            repository.addService(s);
            return Ok(new { success = true, message = "Service updated successfully." });
        }

        [HttpDelete("services/{id}")]
        public IActionResult DeleteService(int id)
        {
            var f = repository.GetServiceById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeService(f);
            return Ok(new { success = true, message = "Service deleted successfully." });
        }

        [HttpPut("services/{id}")]
        public IActionResult UpdateService(int id, string? serviceName, string? description, int? serviceCategoryId, string? imageUrl, byte[]? image, decimal? price)
        {
            Service service = repository.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            service = new Service(id, serviceName, description, serviceCategoryId, imageUrl, image, price);
            repository.UpdateService(service);
            return Ok(new { success = true, message = "Service Updated successfully." });
        }
    }
}
