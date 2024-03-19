using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboController : ControllerBase
    {
        private IComboRepository repository = new ComboRepository();

        [HttpGet("combos")]
        public ActionResult<IEnumerable<Combo>> getCombo()
            => repository.GetAllCombo();

        [HttpGet("combos/{serivceId}")]
        public ActionResult<Combo> getPackageById(int serivceId) =>
            repository.GetComboById(serivceId);

        [HttpGet("combos/by-mame")]
        public ActionResult<List<Combo>> GetComboByName(string ComboName) =>
            repository.GetComboByName(ComboName);

        [HttpPost("combos")]
        public ActionResult<Combo> CreateCombo(string? comboName, decimal? comboPrice, int? hostId, string? imgUrl, byte[]? image, int? status)
        {
            Combo combo = new Combo(comboName, comboPrice, hostId, imgUrl, image,status);
            repository.addCombo(combo);
            return Ok(new { success = true, message = "Combo updated successfully." });
        }

        [HttpDelete("combos/{id}")]
        public IActionResult DeleteCombo(int id)
        {
            var f = repository.GetComboById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeCombo(f);
            return Ok(new { success = true, message = "Combo deleted successfully." });
        }

        [HttpPut("combos/{id}")]
        public IActionResult UpdateCombo(int id, string? comboName, decimal? comboPrice, int? hostId, string? imgUrl, byte[]? image, int? status)
        {
            Combo Combo = repository.GetComboById(id);
            if (Combo == null)
            {
                return NotFound();
            }
            Combo = new Combo(id, comboName, comboPrice, hostId, imgUrl, image, status);
            repository.UpdateCombo(Combo);
            return Ok(new { success = true, message = "Combo Updated successfully." });
        }
    }
}
