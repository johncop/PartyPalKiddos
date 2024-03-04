﻿using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository repository = new OrderRepository();

        [HttpGet("Orders")]
        public ActionResult<IEnumerable<Order>> getOrder()
            => repository.GetOrder();

        [HttpGet("Orders/{OrderId}")]
        public ActionResult<Order> getOrderById(int OrderId) =>
            repository.GetOrderByOrderId(OrderId);

        [HttpGet("Orders/by-userId")]
        public ActionResult<List<Order>> GetOrderByUserId(int userId) =>
            repository.GetOrderByUserId(userId);

        [HttpPost("Orders")]
        public ActionResult<Order> createOrder(decimal totalAmount, int? userId, int? paymentId, int? couponId, int? packageId)
        {
            Order l = new Order()
            {
                OrderDate = DateTime.Now,
                TotalAmount = totalAmount,
                UserId = userId,
                PaymentId = paymentId,
                CouponId = couponId,
                PackageId = packageId
            };
            repository.addOrder(l);
            return NoContent();
        }

        [HttpDelete("Orders/{id}")]
        public IActionResult Delete(int id)
        {
            var f = repository.GetOrderByOrderId(id);
            if (f == null)
            {
                return NotFound();
            }
            repository.removeOrder(f);
            return NoContent();
        }

        [HttpPut("Orders/{id}")]
        public IActionResult UpdateProduct(int id, decimal totalAmount, int? userId, int? paymentId, int? couponId, int? packageId)
        {
            Order Order = repository.GetOrderByOrderId(id);
            if (Order == null)
            {
                return NotFound();
            }
            Order = new Order(id, DateTime.Now, totalAmount, userId, paymentId, couponId, packageId);
            repository.UpdateOrder(Order);
            return NoContent();
        }
    }
}