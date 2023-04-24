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
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            
        }

        [HttpGet]
        public IEnumerable<UserBrief> Get() => _userService.getBriefInformation();

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var user = _userService.getUserById(id);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _userService.deleteUserById(id);
                return Ok();
            }
            catch(Exception ex) {return BadRequest(ex.Message); }
           
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, User user) 
        {
            try
            {
                _userService.updateUserById(id, user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(String email, [Required] String firstName,
           [Required] String lastName, String dateBirthday, String phoneNumber, String address)
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
            try
            {
                byte[] bytes = _userService.GetUsersExportJson().ReadAsByteArrayAsync().Result;
                return File(bytes, "application/json", "AllUsers.json");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            
        }

        [HttpPost("import")]
        public IActionResult GetAction(IFormFile file)
        {

            try
            {
                _userService.GetUsersImportJson(file);

                return Ok();
            }
            catch(Exceprion ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
