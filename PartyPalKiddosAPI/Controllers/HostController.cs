using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;
using Host = BusinessObject.Models.Host;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostController : ControllerBase
    {
        private IHostRepository repository = new HostRepository();

        [HttpGet("Hosts")]
        public ActionResult<IEnumerable<Host>> getHost()
            => repository.GetAllHost();

        [HttpGet("Hosts/{HostId}")]
        public ActionResult<Host> getHostById(int HostId) =>
            repository.GetHostById(HostId);

        [HttpGet("Hosts/by-name")]
        public ActionResult<List<Host>> GetHostByName(string address) =>
            repository.GetHostByName(address);

        [HttpPost("Hosts")]
        public ActionResult<Host> createHost(string? hostName,string? address, int? capacity, int? districtId, string? description, decimal? price, string? status)
        {
            Host host = new Host(hostName, address, capacity, districtId, description, price, status);
            repository.addHost(host);
            return Ok(new { success = true, message = "Host Added successfully." });
        }

        [HttpDelete("Hosts/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetHostById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeHost(f);
            return Ok(new { success = true, message = "Host deleted successfully." });
        }

        [HttpPut("Hosts/{id}")]
        public IActionResult UpdateHost(int id, string? hostName, string? address,int? capacity, int? districtId,string? description, decimal? price, string? status)
        {
            Host host = repository.GetHostById(id);
            if (host == null)
            {
                return NotFound();
            }
            host = new Host(id,hostName, address, capacity,districtId, description, price, status);
            repository.UpdateHost(host);
            return Ok(new { success = true, message = "Host updated successfully." });
        }
    }
}
