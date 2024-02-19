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
        private IRoleRepository repository = new RoleRepository();

        [HttpPost("roles")]
        public IActionResult PostCoupon(string roleName, int status)
        {
            Role p = new Role(roleName, status);
            repository.addRole(p);
            return NoContent();
        }
        [HttpPut("roles")]
        public IActionResult UpdateCoupon(int id, string roleName, int status)
        {
            var user = repository.GetRoleById(id);
            if(user == null)
            {
                return NotFound();
            }
            Role p = new Role(id, roleName, status);
            repository.UpdateRole(p);
            return NoContent();
        }
        [HttpDelete("roles")]
        public IActionResult DeleteCoupon(int id)
        {
            var roles = repository.GetRoleById(id);
            if (roles == null)
            {
                return NotFound();
            }
            repository.removeRole(roles);
            return NoContent();
        }
        [HttpGet("roles")]
        public ActionResult<IEnumerable<Role>> getAllCoupons()
            => repository.GetAllRoles();

        [HttpGet("roles/{id}")]
        public ActionResult<Role> getCouponById(int id) =>
            repository.GetRoleById(id);

    }
}
