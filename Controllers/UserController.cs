using Microsoft.AspNetCore.Mvc;
using Singularis_Test_Task.DAO.Implements;
using Singularis_Test_Task.Models;
using Singularis_Test_Task.Services;

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
        public IActionResult Get(int id)
        {
            User user = null;

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NotFound();
        }
    }
}
