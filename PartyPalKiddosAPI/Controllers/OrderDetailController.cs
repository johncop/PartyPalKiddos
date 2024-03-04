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

        [HttpGet("OrderDetails")]
        public ActionResult<IEnumerable<OrderDetail>> getOrderDetail()
            => repository.GetOrderDetail();


        [HttpPost("OrderDetails")]
        public ActionResult<OrderDetail> createOrderDetail(int? orderId, int? packageId)
        {
            OrderDetail od = new OrderDetail(orderId, packageId);
            repository.addOrderDetail(od);
            return NoContent();
        }

        [HttpDelete("OrderDetails/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetOrderDetailById(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeOrderDetail(f);
            return NoContent();
        }

        [HttpPut("OrderDetails/{id}")]
        public IActionResult UpdateProduct(int orderId, int? packageId)
        {
            OrderDetail OrderDetail = repository.GetOrderDetailById(orderId);
            if (OrderDetail == null)
            {
                return NotFound();
            }
            OrderDetail = new OrderDetail(orderId, packageId);
            repository.UpdateOrderDetail(OrderDetail);
            return NoContent();
        }
    }
}
