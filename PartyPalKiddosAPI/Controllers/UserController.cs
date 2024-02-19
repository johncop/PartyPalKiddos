﻿using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository repository = new UserRepository();

        [HttpPost("users")]
        public IActionResult PostUser(string firstName, string lastName, string email, string password, string address, string phoneNumber, int? roleId, int? status)
        {
            User p = new User(firstName, lastName, email, password, address, phoneNumber, roleId, status);
            repository.addUser(p);
            return NoContent();
        }
        [HttpPut("users")]
        public IActionResult UpdateUser(int id,string firstName, string lastName, string email, string password, string address, string phoneNumber, int? roleId, int? status)
        {
            var user = repository.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            User p = new User(id, firstName, lastName, email, password, address, phoneNumber, roleId, status);
            repository.UpdateUser(p);
            return NoContent();
        }
        [HttpDelete("users")]
        public IActionResult DeleteUser(int id)
        {
            var user = repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            repository.removeUser(user);
            return NoContent();
        }
        [HttpGet("users")]
        public ActionResult<IEnumerable<User>> getAllUsers()
            => repository.GetAllUsers();

        [HttpGet("users/{id}")]
        public ActionResult<User> getUserById(int id) =>
            repository.GetUserById(id);

    }
}
