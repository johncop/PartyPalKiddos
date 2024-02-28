using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private ICouponRepository repository = new CouponRepository();

        [HttpPost("coupons")]
        public IActionResult PostCoupon(string? couponName, decimal? discountAmount, decimal? conditionAmount, string? description, int? typeId, int? quantity, DateTime? createdDate, DateTime? expiredDate, string? status)
        {
            Coupon p = new Coupon(couponName, discountAmount, conditionAmount, description, typeId, quantity, createdDate, expiredDate, status);
            repository.addCoupon(p);
            return NoContent();
        }
        [HttpPut("coupons")]
        public IActionResult UpdateCoupon(int id, string? couponName, decimal? discountAmount, decimal? conditionAmount, string? description, int? typeId, int? quantity, DateTime? createdDate, DateTime? expiredDate, string? status)
        {
            var user = repository.GetCouponById(id);
            if(user == null)
            {
                return NotFound();
            }
            Coupon p = new Coupon(id, couponName, discountAmount, conditionAmount, description, typeId, quantity, createdDate, expiredDate, status);
            repository.UpdateCoupon(p);
            return NoContent();
        }
        [HttpDelete("coupons")]
        public IActionResult DeleteCoupon(int id)
        {
            var user = repository.GetCouponById(id);
            if (user == null)
            {
                return NotFound();
            }
            repository.removeCoupon(user);
            return NoContent();
        }
        [HttpGet("coupons")]
        public ActionResult<IEnumerable<Coupon>> getAllCoupons()
            => repository.GetAllCoupons();

        [HttpGet("coupons/{id}")]
        public ActionResult<Coupon> getCouponById(int id) =>
            repository.GetCouponById(id);

    }
}
