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
        /*private IOrderDrinkRepository repository = new OrderDrinkRepository();

        [HttpPost("order-drinks")]
        public IActionResult PostOrderDrink(int packageId, int? drinkId, int? quantity)
        {
            OrderDrink oDrink = new OrderDrink(packageId, drinkId, quantity);
            repository.addOrderDrink(oDrink);
            return NoContent();
        }
        [HttpPut("order-drinks")]
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
        [HttpDelete("order-drinks")]
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
        [HttpGet("order-drinks")]
        public ActionResult<IEnumerable<OrderDrink>> getOrderDrink()
            => repository.GetOrderDrink();

        [HttpGet("order-drinks/{packageId}")]
        public ActionResult<OrderDrink> getOrderDrinkByPackageId(int packageId) =>
            repository.GetOrderDrinkByPackageId(packageId);*/
    }
}
