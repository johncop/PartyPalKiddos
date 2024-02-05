using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderServiceController : ControllerBase
    {
        private IOrderServiceRepository repository = new OrderServiceRepository();

        [HttpPost("AddOrderService")]
        public IActionResult PostOrderService(int packageId, int? serviceId, int? serviceOptionId, int? quantity)
        {
            OrderService oFood = new OrderService(packageId, serviceId, serviceOptionId, quantity);
            repository.addOrderService(oFood);
            return NoContent();
        }
        [HttpPut("UpdateOrderService")]
        public IActionResult UpdateOrderService(int packageId, int? serviceId, int? serviceOptionId, int? quantity)
        {
            var orderService = repository.GetOrderServiceByPackageId(packageId);
            if (orderService == null)
            {
                return NotFound();
            }
            OrderService oService = new OrderService(packageId, serviceId, serviceOptionId, quantity);
            repository.UpdateOrderService(oService);
            return NoContent();
        }
        [HttpDelete("DeleteOrderService")]
        public IActionResult DeleteOrderService(int id)
        {
            var orderService = repository.GetOrderServiceByPackageId(id);
            if (orderService == null)
            {
                return NotFound();
            }
            repository.removeOrderService(orderService);
            return NoContent();
        }
        [HttpGet("GetAllOrderService")]
        public ActionResult<IEnumerable<OrderService>> getOrderService()
            => repository.GetOrderService();

        [HttpGet("GetOrderFoodByPackageId")]
        public ActionResult<OrderService> getOrderServiceByPackageId(int packageId) =>
            repository.GetOrderServiceByPackageId(packageId);
    }
}
