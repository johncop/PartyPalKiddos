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
    public class VenueComboDetailController : ControllerBase
    {
        private readonly VenueComboDetailDAO _VenueComboDetailDAO;
        public VenueComboDetailController(VenueComboDetailDAO VenueComboDetailDAO)
        {
            _VenueComboDetailDAO= VenueComboDetailDAO;
        }

        /*[HttpGet("Venue-combo-detail")]
        public IActionResult getAllVenueComboDetails()
        {
            var hcd = _VenueComboDetailDAO.GetVenueComboDetails();
            return Ok(hcd);
        }

        [HttpGet("Venue-combo-detail/{VenueId}")]
        public IActionResult getVenueComboDetailByVenueId(int VenueId) 
        {
            var hcd = _VenueComboDetailDAO.FindVenueComboDetailById(VenueId);
            return Ok(hcd);
        }
        [HttpPost]
        public IActionResult Post([FromBody]VenueComboDetail VenueComboDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _VenueComboDetailDAO.SaveVenueComboDetail(VenueComboDetail);
                return CreatedAtAction(nameof(addVenueComboDetail), new { id = VenueComboDetail.VenueId }, VenueComboDetail);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, ex.Message);
            }
        }*/


        private IVenueComboDetailRepository repository = new VenueComboDetailRepository();

        [HttpGet("VenueComboDetails")]
        public ActionResult<IEnumerable<VenueComboDetail>> getVenueComboDetail()
            => repository.GetAllVenueComboDetails();

        [HttpGet("VenueComboDetails/{VenueId}")]
        public ActionResult<IEnumerable<VenueComboDetail>> getPackageById(int VenueId) =>
            repository.GetVenueComboDetailById(VenueId);

        [HttpPost("VenueComboDetails")]
        public ActionResult<VenueComboDetail> CreateCombo([FromBody] List<addVenueComboDetail> VenueComboDetail)
        {
            foreach (var detail in VenueComboDetail)
            {
                VenueComboDetail hcd = new VenueComboDetail(detail.VenueId, detail.ComboId);
                repository.addVenueComboDetail(hcd);
            }
            return Ok(new { success = true, message = "Combo added successfully." });
        }

        [HttpDelete("VenueComboDetails")]
        public IActionResult DeleteCombo(int VenueId, int comboId)
        {
            var f = repository.GetVenueComboDetailByIds(VenueId, comboId);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeVenueComboDetail(f);
            return Ok(new { success = true, message = "Combo deleted successfully." });
        }

        [HttpPut("VenueComboDetails")]
        public IActionResult UpdateCombo(addVenueComboDetail VenueComboDetail, int VenueId, int comboId)
        {
            var Combo = repository.GetVenueComboDetailByIds(VenueId, comboId);
            if (Combo == null)
            {
                return NotFound();
            }
            VenueComboDetail hcd = new VenueComboDetail
            {
                VenueId = VenueId,
                ComboId = VenueComboDetail.ComboId,
            };
            repository.UpdateVenueComboDetail(hcd);
            return Ok(new { success = true, message = "Combo Updated successfully." });
        }
    }
}
