using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.Contexts;
using RegistrationForm.Interfaces;
using RegistrationForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly RegistrationDbContext _registrationDbContext;

        public UserController(IUser user, RegistrationDbContext registrationDbContext)
        {
            _user = user;
            _registrationDbContext = registrationDbContext;
        }

        [HttpGet("getUsers")]

        public ActionResult GetUsers()
        {
            var users = _user.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var UserById = await _user.GetUserById(id);

            if(UserById != null)
            {
                return Ok(UserById);
            }
            return NotFound($"User with id:{id} was not found");
        }

        [HttpPost("register")]
        public ActionResult AddUser(Registration registration)
        {
            return Ok(_user.AddUser(registration));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            Registration DeleteUser = await _user.GetUserById(id);

            if(DeleteUser != null)
            {
                _user.DeleteUser(DeleteUser);
                return Ok();
            }
            return NotFound($"User with id: {DeleteUser.UserId} was not found");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateUser(int id, Registration registration)
        {
            await _user.UpdateUserAsync(id, registration);
            return Ok();
        }

        [HttpGet("countries")]
        public ActionResult GetCountries()
        {
            var countries = _registrationDbContext.country.ToList();
            return Ok(countries);
        }


       
    }
}
