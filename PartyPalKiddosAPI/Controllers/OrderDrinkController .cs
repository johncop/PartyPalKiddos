using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDrinkController : ControllerBase
    {
        private IOrderDrinkRepository repository = new OrderDrinkRepository();

        [HttpPost("AddOrderDrink")]
        public IActionResult PostOrderDrink(int packageId, int? drinkId, int? quantity)
        {
            OrderDrink oDrink = new OrderDrink(packageId, drinkId, quantity);
            repository.addOrderDrink(oDrink);
            return NoContent();
        }
        [HttpPut("UpdateOrderDrink")]
        public IActionResult UpdateOrderDrink(int packageId, int? drinkId, int? quantity)
        {
            var orderDrink = repository.GetOrderDrinkByPackageId(packageId);
            if (orderDrink == null)
            {
                return NotFound();
            }
            OrderDrink oDrink = new OrderDrink(packageId, drinkId, quantity);
            repository.UpdateOrderDrink(oDrink);
            return NoContent();
        }
        [HttpDelete("DeleteOrderDrink")]
        public IActionResult DeleteOrderDrink(int id)
        {
            var orderDrink = repository.GetOrderDrinkByPackageId(id);
            if (orderDrink == null)
            {
                return NotFound();
            }
            repository.removeOrderDrink(orderDrink);
            return NoContent();
        }
        [HttpGet("GetAllOrderDrink")]
        public ActionResult<IEnumerable<OrderDrink>> getOrderDrink()
            => repository.GetOrderDrink();

        [HttpGet("GetOrderDrinkByPackageId")]
        public ActionResult<OrderDrink> getOrderDrinkByPackageId(int packageId) =>
            repository.GetOrderDrinkByPackageId(packageId);
    }
}
