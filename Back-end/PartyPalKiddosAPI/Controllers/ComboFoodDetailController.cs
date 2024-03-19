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
        public ActionResult<IEnumerable<ComboFoodDetail>> getComboFoodPackageByComboID(int comboId) =>
            repository.GetListComboFoodDetailByComboId(comboId);

        [HttpPost("combo-food-detail")]
        public ActionResult<ComboFoodDetail> CreateCombo(int? comboId, int? foodId, int? quantity)
        {
            ComboFoodDetail comboFoodDetail = new ComboFoodDetail(comboId, foodId, quantity);
            repository.addComboFoodDetail(comboFoodDetail);
            return Ok(new { success = true, message = "Combo food detail updated successfully." });
        }

        [HttpDelete("combo-food-detail")]
        public IActionResult DeleteCombo(int comboId, int foodId)
        {
            var f = repository.GetComboFoodDetail(comboId, foodId);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeComboFoodDetail(f);
            return Ok(new { success = true, message = "Combo deleted successfully." });
        }

        [HttpPut("combo-food-detail/{id}")]
        public IActionResult UpdateCombo(int comboId, int foodId, int? quantity)
        {
            ComboFoodDetail Combo = repository.GetComboFoodDetail(comboId, foodId);
            if (Combo == null)
            {
                return NotFound();
            }
            Combo = new ComboFoodDetail(foodId, quantity);
            repository.UpdateComboFoodDetail(Combo);
            return Ok(new { success = true, message = "Combo Updated successfully." });
        }
    }
}
