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
        private IOrderFoodRepository repository = new OrderFoodRepository();

        [HttpPost("AddOrderFood")]
        public IActionResult PostOrderFood(int packageId, int? foodId, int? quantity)
        {
            OrderFood oFood = new OrderFood(packageId, foodId, quantity);
            repository.addOrderFood(oFood);
            return NoContent();
        }
        [HttpPut("UpdateOrderFood")]
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
        [HttpDelete("DeleteOrderFood")]
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
        [HttpGet("GetAllOrderFood")]
        public ActionResult<IEnumerable<OrderFood>> getOrderFood()
            => repository.GetOrderFood();

        [HttpGet("GetOrderFoodByPackageId")]
        public ActionResult<OrderFood> getOrderFoodByPackageId(int packageId) =>
            repository.GetOrderFoodByPackageId(packageId);
    }
}
