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
    public class VenueServiceDetailController : ControllerBase
    {
        private IVenueServiceDetailRepository repository = new VenueServiceDetailRepository();

        [HttpGet("VenueServiceDetails")]
        public ActionResult<IEnumerable<VenueServiceDetail>> getVenueServiceDetail()
            => repository.GetAllVenueServiceDetails();

        [HttpGet("VenueServiceDetails/{VenueId}")]
        public ActionResult<IEnumerable<VenueServiceDetail>> getPackageById(int VenueId) =>
            repository.GetVenueServiceDetailById(VenueId);

        [HttpPost("VenueServiceDetails")]
        public ActionResult<VenueServiceDetail> CreateCombo([FromBody] List<addVenueServiceDetail> VenueServiceDetail)
        {
            foreach (var detail in VenueServiceDetail)
            {
                VenueServiceDetail hsd = new VenueServiceDetail(detail.VenueId, detail.ServiceId);
                repository.addVenueServiceDetail(hsd);
            }
            return Ok(new { success = true, message = "service in Venue added successfully." });
        }

        [HttpDelete("VenueServiceDetails")]
        public IActionResult DeleteCombo(int VenueId, int comboId)
        {
            var f = repository.GetVenueServiceDetailByIds(VenueId, comboId);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeVenueServiceDetail(f);
            return Ok(new { success = true, message = "Deleted successfully." });
        }

        [HttpPut("VenueServiceDetails")]
        public IActionResult UpdateCombo(addVenueServiceDetail VenueServiceDetail, int VenueId, int comboId)
        {
            var Combo = repository.GetVenueServiceDetailByIds(VenueId, comboId);
            if (Combo == null)
            {
                return NotFound();
            }
            VenueServiceDetail hcd = new VenueServiceDetail
            {
                VenueId = VenueId,
                ServiceId = VenueServiceDetail.ServiceId
            };
            repository.UpdateVenueServiceDetail(hcd);
            return Ok(new { success = true, message = "Combo Updated successfully." });
        }
    }
}
