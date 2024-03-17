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
    public class VenueServicePackageDetailController : ControllerBase
    {
        private IVenueServicePackageDetailRepository repository = new VenueServicePackageDetailRepository();

        [HttpGet("VenueServicePackageDetails")]
        public ActionResult<IEnumerable<VenueServicePackageDetail>> getVenueServicePackageDetail()
            => repository.GetAllVenueServicePackageDetails();

        [HttpGet("VenueServicePackageDetails/{VenueId}")]
        public ActionResult<IEnumerable<VenueServicePackageDetail>> getPackageById(int VenueId) =>
            repository.GetVenueServicePackageDetailById(VenueId);

        [HttpPost("VenueServicePackageDetails")]
        public ActionResult<VenueServicePackageDetail> CreateCombo([FromBody] List<addVenueServicePackageDetail> VenueServicePackageDetail)
        {
            foreach (var detail in VenueServicePackageDetail)
            {
                VenueServicePackageDetail hsd = new VenueServicePackageDetail(detail.VenueId, detail.ServicePackageId);
                repository.addVenueServicePackageDetail(hsd);
            }
            return Ok(new { success = true, message = "service package detail in Venue added successfully." });
        }

        [HttpDelete("VenueServicePackageDetails")]
        public IActionResult DeleteCombo(int VenueId, int comboId)
        {
            var f = repository.GetVenueServicePackageDetailByIds(VenueId, comboId);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeVenueServicePackageDetail(f);
            return Ok(new { success = true, message = "Deleted successfully." });
        }

        [HttpPut("VenueServicePackageDetails")]
        public IActionResult UpdateCombo(addVenueServicePackageDetail VenueServicePackageDetail, int VenueId, int comboId)
        {
            var Combo = repository.GetVenueServicePackageDetailByIds(VenueId, comboId);
            if (Combo == null)
            {
                return NotFound();
            }
            VenueServicePackageDetail hcd = new VenueServicePackageDetail
            {
                VenueId = VenueId,
                ServicePackageId = VenueServicePackageDetail.ServicePackageId
            };
            repository.UpdateVenueServicePackageDetail(hcd);
            return Ok(new { success = true, message = "Combo Updated successfully." });
        }
    }
}
