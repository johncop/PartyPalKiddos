using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private ICouponRepository repository = new RoleRepository();

        [HttpPost("AddCoupon")]
        public IActionResult PostCoupon(string couponName, decimal discountAmount, string? description)
        {
            Coupon p = new Coupon(couponName, discountAmount, description);
            repository.addRole(p);
            return NoContent();
        }
        [HttpPut("UpdateCoupon")]
        public IActionResult UpdateCoupon(int id, string couponName, decimal discountAmount, string? description)
        {
            var user = repository.GetCouponById(id);
            if(user == null)
            {
                return NotFound();
            }
            Coupon p = new Coupon(id, couponName, discountAmount, description);
            repository.UpdateCoupon(p);
            return NoContent();
        }
        [HttpDelete("DeleteCoupon")]
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
        [HttpGet("GetAllCoupons")]
        public ActionResult<IEnumerable<Coupon>> getAllCoupons()
            => repository.GetAllCoupons();

        [HttpGet("GetCouponById")]
        public ActionResult<Coupon> getCouponById(int id) =>
            repository.GetCouponById(id);

    }
}
