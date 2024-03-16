using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostServiceDetailController : ControllerBase
    {
        private IHostServiceDetailRepository repository = new HostServiceDetailRepository();

        [HttpGet("HostServiceDetails")]
        public ActionResult<IEnumerable<HostServiceDetail>> getHostServiceDetail()
            => repository.GetAllHostServiceDetails();

        [HttpGet("HostServiceDetails/{hostId}")]
        public ActionResult<IEnumerable<HostServiceDetail>> getPackageById(int hostId) =>
            repository.GetHostServiceDetailById(hostId);

        [HttpPost("HostServiceDetails")]
        public ActionResult<HostServiceDetail> CreateCombo([FromBody] List<addHostServiceDetail> HostServiceDetail)
        {
            foreach (var detail in HostServiceDetail)
            {
                HostServiceDetail hsd = new HostServiceDetail(detail.HostId, detail.ServiceId);
                repository.addHostServiceDetail(hsd);
            }
            return Ok(new { success = true, message = "service in host added successfully." });
        }

        [HttpDelete("HostServiceDetails")]
        public IActionResult DeleteCombo(int hostId, int comboId)
        {
            var f = repository.GetHostServiceDetailByIds(hostId, comboId);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeHostServiceDetail(f);
            return Ok(new { success = true, message = "Deleted successfully." });
        }

        [HttpPut("HostServiceDetails")]
        public IActionResult UpdateCombo(addHostServiceDetail HostServiceDetail, int hostId, int comboId)
        {
            var Combo = repository.GetHostServiceDetailByIds(hostId, comboId);
            if (Combo == null)
            {
                return NotFound();
            }
            HostServiceDetail hcd = new HostServiceDetail
            {
                HostId = hostId,
                FoodId = HostServiceDetail.FoodId
            };
            repository.UpdateHostServiceDetail(hcd);
            return Ok(new { success = true, message = "Combo Updated successfully." });
        }
    }
}
