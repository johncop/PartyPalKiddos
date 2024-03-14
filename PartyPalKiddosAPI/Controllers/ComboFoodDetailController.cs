using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboFoodDetailController : ControllerBase
    {
        private IComboFoodDetailRepository repository = new ComboFoodDetailRepository();

        [HttpGet("combo-food-detail")]
        public ActionResult<IEnumerable<ComboFoodDetail>> getComboFoodDetail()
            => repository.GetAllComboFoodDetail();

        [HttpGet("combo-food-detail/{comboId}")]
        public ActionResult<ComboFoodDetail> getComboFoodPackageByComboID(int comboId) =>
            repository.GetComboFoodDetailByComboId(comboId);

        [HttpPost("combo-food-detail")]
        public ActionResult<ComboFoodDetail> CreateCombo(int? comboId, int? foodId, int? quantity)
        {
            ComboFoodDetail comboFoodDetail = new ComboFoodDetail(comboId, foodId, quantity);
            repository.addComboFoodDetail(comboFoodDetail);
            return Ok(new { success = true, message = "Combo food detail updated successfully." });
        }

        [HttpDelete("combo-food-detail/{id}")]
        public IActionResult DeleteCombo(int id)
        {
            var f = repository.GetComboFoodDetailByComboId(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeComboFoodDetail(f);
            return Ok(new { success = true, message = "Combo deleted successfully." });
        }

        [HttpPut("combo-food-detail/{id}")]
        public IActionResult UpdateCombo(int id, int? comboId, int? foodId, int? quantity)
        {
            ComboFoodDetail Combo = repository.GetComboFoodDetailByComboId(id);
            if (Combo == null)
            {
                return NotFound();
            }
            Combo = new ComboFoodDetail(comboId, foodId, quantity);
            repository.UpdateComboFoodDetail(Combo);
            return Ok(new { success = true, message = "Combo Updated successfully." });
        }
    }
}
