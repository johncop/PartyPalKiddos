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
    public class HostServicePackageDetailController : ControllerBase
    {
        private IHostServicePackageDetailRepository repository = new HostServicePackageDetailRepository();

        [HttpGet("HostServicePackageDetails")]
        public ActionResult<IEnumerable<HostServicePackageDetail>> getHostServicePackageDetail()
            => repository.GetAllHostServicePackageDetails();

        [HttpGet("HostServicePackageDetails/{hostId}")]
        public ActionResult<IEnumerable<HostServicePackageDetail>> getPackageById(int hostId) =>
            repository.GetHostServicePackageDetailById(hostId);

        [HttpPost("HostServicePackageDetails")]
        public ActionResult<HostServicePackageDetail> CreateCombo([FromBody] List<addHostServicePackageDetail> HostServicePackageDetail)
        {
            foreach (var detail in HostServicePackageDetail)
            {
                HostServicePackageDetail hsd = new HostServicePackageDetail(detail.HostId, detail.ServicePackageId);
                repository.addHostServicePackageDetail(hsd);
            }
            return Ok(new { success = true, message = "service package detail in host added successfully." });
        }

        [HttpDelete("HostServicePackageDetails")]
        public IActionResult DeleteCombo(int hostId, int comboId)
        {
            var f = repository.GetHostServicePackageDetailByIds(hostId, comboId);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeHostServicePackageDetail(f);
            return Ok(new { success = true, message = "Deleted successfully." });
        }

        [HttpPut("HostServicePackageDetails")]
        public IActionResult UpdateCombo(addHostServicePackageDetail HostServicePackageDetail, int hostId, int comboId)
        {
            var Combo = repository.GetHostServicePackageDetailByIds(hostId, comboId);
            if (Combo == null)
            {
                return NotFound();
            }
            HostServicePackageDetail hcd = new HostServicePackageDetail
            {
                HostId = hostId,
                ServicePackageId = HostServicePackageDetail.ServicePackageId
            };
            repository.UpdateHostServicePackageDetail(hcd);
            return Ok(new { success = true, message = "Combo Updated successfully." });
        }
    }
}
