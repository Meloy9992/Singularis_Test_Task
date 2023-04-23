using Microsoft.AspNetCore.Mvc;
using Singularis_Test_Task.DAO.Implements;
using Singularis_Test_Task.Models;
using Singularis_Test_Task.Services;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace Singularis_Test_Task.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get() => _userService.getBriefInformation();

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            User user = _userService.getUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _userService.deleteUserById(id); 
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, User user) 
        {
            _userService.updateUserById(id, user);

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([Required] String email, [Required] String firstName,
           [Required] String lastName, [Required] String dateBirthday, [Required] String phoneNumber, [Required] String address)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.createUser(new User(email, firstName, lastName, dateBirthday, phoneNumber, address));

            return Ok(_userService.GetLastUsersIndex());
        }

        [HttpGet("export")]
        public IActionResult GetAction()
        {
            byte[] bytes = _userService.GetUsersExportJson().ReadAsByteArrayAsync().Result;

            return File(bytes, "application/json", "AllUsers.json");
        }
    }
}
