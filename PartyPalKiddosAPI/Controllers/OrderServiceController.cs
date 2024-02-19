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

        [HttpPost("order-services")]
        public IActionResult PostOrderService(int packageId, int? serviceId, int? serviceOptionId, int? quantity)
        {
            OrderService oFood = new OrderService(packageId, serviceId, serviceOptionId, quantity);
            repository.addOrderService(oFood);
            return NoContent();
        }
        [HttpPut("order-services")]
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
        [HttpDelete("order-services")]
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
        [HttpGet("order-services")]
        public ActionResult<IEnumerable<OrderService>> getOrderService()
            => repository.GetOrderService();

        [HttpGet("order-services/{packageId}")]
        public ActionResult<OrderService> getOrderServiceByPackageId(int packageId) =>
            repository.GetOrderServiceByPackageId(packageId);
    }
}
