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
        public IActionResult PostRole(string roleName, int status)
        {
            Role p = new Role(roleName, status);
            repository.addRole(p);
            return Ok(new { success = true, message = "Role Added successfully." });
        }
        [HttpPut("roles")]
        public IActionResult UpdateRole(int id, string roleName, int status)
        {
            var user = repository.GetRoleById(id);
            if(user == null)
            {
                return NotFound();
            }
            Role p = new Role(id, roleName, status);
            repository.UpdateRole(p);
            return Ok(new { success = true, message = "Role Updated successfully." });
        }
        [HttpDelete("roles")]
        public IActionResult DeleteRole(int id)
        {
            var roles = repository.GetRoleById(id);
            if (roles == null)
            {
                return NotFound();
            }
            repository.removeRole(roles);
            return Ok(new { success = true, message = "Role deleted successfully." });
        }
        [HttpGet("roles")]
        public ActionResult<IEnumerable<Role>> getAllRole()
            => repository.GetAllRoles();

        [HttpGet("roles/{id}")]
        public ActionResult<Role> getRoleById(int id) =>
            repository.GetRoleById(id);

    }
}
