using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private IServiceTypeRepository repository = new ServiceTypeRepository();
        [HttpGet("service-type")]
        public ActionResult<IEnumerable<ServiceType>> getAllServiceType() => repository.GetAllServiceType();
        [HttpGet("service-type/{id}")]
        public ActionResult<ServiceType> getServiceTypeById(int id) =>
            repository.GetServiceTypeById(id);

        [HttpGet("service-type/by-name")]
        public ActionResult<List<ServiceType>> GetServiceTypeByName(string typeName) =>
            repository.GetAllServiceTypeByName(typeName);

        [HttpPost("service-type")]
        public ActionResult<ServiceType> CreateServiceType(string? typeName, string? description)
        {
            ServiceType f = new ServiceType(typeName, description);
            repository.addServiceType(f);
            return Ok(new { success = true, message = "Serivce type Added successfully." });
        }

        [HttpDelete("service-type/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetServiceTypeById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeServiceType(f);
            return Ok(new { success = true, message = "Service type Added successfully." });
        }

        [HttpPut("service-type/{id}")]
        public IActionResult Update(int id, string? typeName, string? description)
        {
            ServiceType st = repository.GetServiceTypeById(id);
            if (st == null)
            {
                return NotFound();
            }
            st = new ServiceType(id, typeName, description);
            repository.updateServiceType(st);
            return Ok(new { success = true, message = "Service Type Added successfully." });
        }
    }
}
