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
    public class HostFoodDetailController : ControllerBase
    {
        private IHostFoodDetailRepository repository = new HostFoodDetailRepository();

        [HttpGet("HostFoodDetails")]
        public ActionResult<IEnumerable<HostFoodDetail>> getHostFoodDetail()
            => repository.GetAllHostFoodDetails();

        [HttpGet("HostFoodDetails/{hostId}")]
        public ActionResult<IEnumerable<HostFoodDetail>> getPackageById(int hostId) =>
            repository.GetHostFoodDetailById(hostId);

        [HttpPost("HostFoodDetails")]
        public ActionResult<HostFoodDetail> CreateCombo([FromBody] List<addHostFoodDetail> HostFoodDetail)
        {
            foreach (var detail in HostFoodDetail)
            {
                HostFoodDetail hcd = new HostFoodDetail(detail.HostId, detail.FoodId);
                repository.addHostFoodDetail(hcd);
            }
            return Ok(new { success = true, message = "Combo added successfully." });           
        }

        [HttpDelete("HostFoodDetails")]
        public IActionResult DeleteCombo(int hostId, int comboId)
        {
            var f = repository.GetHostFoodDetailByIds(hostId, comboId);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeHostFoodDetail(f);
            return Ok(new { success = true, message = "Deleted successfully." });
        }

        [HttpPut("HostFoodDetails")]
        public IActionResult UpdateCombo(addHostFoodDetail HostFoodDetail, int hostId, int comboId)
        {
            var Combo = repository.GetHostFoodDetailByIds(hostId, comboId);
            if (Combo == null)
            {
                return NotFound();
            }
            HostFoodDetail hcd = new HostFoodDetail
            {
                HostId = hostId,
                FoodId = HostFoodDetail.FoodId
            };
            repository.UpdateHostFoodDetail(hcd);
            return Ok(new { success = true, message = "Combo Updated successfully." });
        }
    }
}
