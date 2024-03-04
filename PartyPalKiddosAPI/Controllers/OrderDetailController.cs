using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IOrderDetailRepository repository = new OrderDetailRepository();

        [HttpGet("order-details")]
        public ActionResult<IEnumerable<OrderDetail>> getOrderDetail()
            => repository.GetOrderDetail();

        [HttpGet("order-details/{id}")]
        public ActionResult<OrderDetail> getOrderDetailById(int id)
            => repository.GetOrderDetailById(id);


        [HttpPost("order-details")]
        public ActionResult<OrderDetail> createOrderDetail(int? orderId, int? packageId)
        {
            OrderDetail od = new OrderDetail(orderId, packageId);
            repository.addOrderDetail(od);
            return Ok(new { success = true, message = "OrderDetail Added successfully." });
        }

        [HttpDelete("order-details/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetOrderDetailById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeOrderDetail(f);
            return Ok(new { success = true, message = "OrderDetail deleted successfully." });
        }

        [HttpPut("order-details/{orderId}")]
        public IActionResult UpdateProduct(int orderId, int? packageId)
        {
            OrderDetail OrderDetail = repository.GetOrderDetailById(orderId);
            if (OrderDetail == null)
            {
                return NotFound();
            }
            OrderDetail = new OrderDetail(orderId, packageId);
            repository.UpdateOrderDetail(OrderDetail);
            return Ok(new { success = true, message = "OrderDetail updated successfully." });
        }
    }
}
