using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderFoodController : ControllerBase
    {
        /*private IOrderFoodRepository repository = new OrderFoodRepository();

        [HttpPost("order-foods")]
        public IActionResult PostOrderFood(int packageId, int? foodId, int? quantity)
        {
            OrderFood oFood = new OrderFood(packageId, foodId, quantity);
            repository.addOrderFood(oFood);
            return NoContent();
        }
        [HttpPut("order-foods")]
        public IActionResult UpdateOrderFood(int packageId, int? foodId, int? quantity)
        {
            var orderFood = repository.GetOrderFoodByPackageId(packageId);
            if (orderFood == null)
            {
                return NotFound();
            }
            OrderFood oFood = new OrderFood(packageId, foodId, quantity);
            repository.UpdateOrderFood(oFood);
            return NoContent();
        }
        [HttpDelete("order-foods")]
        public IActionResult DeleteOrderFood(int id)
        {
            var orderFood = repository.GetOrderFoodByPackageId(id);
            if (orderFood == null)
            {
                return NotFound();
            }
            repository.removeOrderFood(orderFood);
            return NoContent();
        }
        [HttpGet("order-foods")]
        public ActionResult<IEnumerable<OrderFood>> getOrderFood()
            => repository.GetOrderFood();

        [HttpGet("order-foods/{packageId}")]
        public ActionResult<OrderFood> getOrderFoodByPackageId(int packageId) =>
            repository.GetOrderFoodByPackageId(packageId);*/
    }
}
