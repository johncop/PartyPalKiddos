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
    public class VenueFoodDetailController : ControllerBase
    {
        private IVenueFoodDetailRepository repository = new VenueFoodDetailRepository();

        [HttpGet("VenueFoodDetails")]
        public ActionResult<IEnumerable<VenueFoodDetail>> getVenueFoodDetail()
            => repository.GetAllVenueFoodDetails();

        [HttpGet("VenueFoodDetails/{VenueId}")]
        public ActionResult<IEnumerable<VenueFoodDetail>> getPackageById(int VenueId) =>
            repository.GetVenueFoodDetailById(VenueId);

        [HttpPost("VenueFoodDetails")]
        public ActionResult<VenueFoodDetail> CreateCombo([FromBody] List<addVenueFoodDetail> VenueFoodDetail)
        {
            foreach (var detail in VenueFoodDetail)
            {
                VenueFoodDetail hcd = new VenueFoodDetail(detail.VenueId, detail.FoodId);
                repository.addVenueFoodDetail(hcd);
            }
            return Ok(new { success = true, message = "Combo added successfully." });           
        }

        [HttpDelete("VenueFoodDetails")]
        public IActionResult DeleteCombo(int VenueId, int comboId)
        {
            var f = repository.GetVenueFoodDetailByIds(VenueId, comboId);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeVenueFoodDetail(f);
            return Ok(new { success = true, message = "Deleted successfully." });
        }

        [HttpPut("VenueFoodDetails")]
        public IActionResult UpdateCombo(addVenueFoodDetail VenueFoodDetail, int VenueId, int comboId)
        {
            var Combo = repository.GetVenueFoodDetailByIds(VenueId, comboId);
            if (Combo == null)
            {
                return NotFound();
            }
            VenueFoodDetail hcd = new VenueFoodDetail
            {
                VenueId = VenueId,
                FoodId = VenueFoodDetail.FoodId
            };
            repository.UpdateVenueFoodDetail(hcd);
            return Ok(new { success = true, message = "Combo Updated successfully." });
        }
    }
}
