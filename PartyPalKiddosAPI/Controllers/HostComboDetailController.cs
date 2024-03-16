using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostComboDetailController : ControllerBase
    {
        private readonly HostComboDetailDAO _hostComboDetailDAO;
        public HostComboDetailController(HostComboDetailDAO hostComboDetailDAO)
        {
            _hostComboDetailDAO= hostComboDetailDAO;
        }

        /*[HttpGet("host-combo-detail")]
        public IActionResult getAllHostComboDetails()
        {
            var hcd = _hostComboDetailDAO.GetHostComboDetails();
            return Ok(hcd);
        }

        [HttpGet("host-combo-detail/{hostId}")]
        public IActionResult getHostComboDetailByHostId(int hostId) 
        {
            var hcd = _hostComboDetailDAO.FindHostComboDetailById(hostId);
            return Ok(hcd);
        }
        [HttpPost]
        public IActionResult Post([FromBody]HostComboDetail hostComboDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _hostComboDetailDAO.SaveHostComboDetail(hostComboDetail);
                return CreatedAtAction(nameof(addHostComboDetail), new { id = hostComboDetail.HostId }, hostComboDetail);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, ex.Message);
            }
        }*/


        private IHostComboDetailRepository repository = new HostComboDetailRepository();

        [HttpGet("HostComboDetails")]
        public ActionResult<IEnumerable<HostComboDetail>> getHostComboDetail()
            => repository.GetAllHostComboDetails();

        [HttpGet("HostComboDetails/{hostId}")]
        public ActionResult<IEnumerable<HostComboDetail>> getPackageById(int hostId) =>
            repository.GetHostComboDetailById(hostId);

        [HttpPost("HostComboDetails")]
        public ActionResult<HostComboDetail> CreateCombo([FromBody]addHostComboDetail hostComboDetail)
        {
            HostComboDetail hcd = new HostComboDetail
            {
                HostId = hostComboDetail.HostId,
                ComboId = hostComboDetail.ComboId,
                FoodId = hostComboDetail.FoodId
            };
            repository.addHostComboDetail(hcd);
            return Ok(new { success = true, message = "Combo added successfully." });
        }

        [HttpDelete("HostComboDetails")]
        public IActionResult DeleteCombo(int hostId, int comboId, int foodId)
        {
            var f = repository.GetHostComboDetailByIds(hostId, comboId, foodId);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeHostComboDetail(f);
            return Ok(new { success = true, message = "Combo deleted successfully." });
        }

        [HttpPut("HostComboDetails")]
        public IActionResult UpdateCombo(addHostComboDetail hostComboDetail, int hostId, int comboId, int foodId)
        {
            var Combo = repository.GetHostComboDetailByIds(hostId, comboId, foodId);
            if (Combo == null)
            {
                return NotFound();
            }
            HostComboDetail hcd = new HostComboDetail
            {
                HostId = hostId,
                ComboId = hostComboDetail.ComboId,
                FoodId = hostComboDetail.FoodId
            };
            repository.UpdateHostComboDetail(hcd);
            return Ok(new { success = true, message = "Combo Updated successfully." });
        }
    }
}
