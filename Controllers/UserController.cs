using Microsoft.AspNetCore.Mvc;
using Singularis_Test_Task.Models;

namespace Singularis_Test_Task.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private static List<User> users = new List<User>(new[]
        {
            new User() {Id = 0L ,firstName = "Игорь", lastName = "Иванов",
                address = "Москва, Ленинский проспект", dateBirthday = "20 августа 1900",
            email = "qwerty1@yandex.ru", phoneNumber = "123456789"},

            new User() {Id = 1L ,firstName = "Евгений", lastName = "Иванка",
                address = "Москва, Ленинский проспектик", dateBirthday = "21 августа 1900",
            email = "qwerty2@yandex.ru", phoneNumber = "123456789"},

            new User() {Id = 2L ,firstName = "Анатолий", lastName = "Ивановичкин",
                address = "Москва, Ленинский проспектун", dateBirthday = "22 августа 1900",
            email = "qwerty3@yandex.ru", phoneNumber = "123456789"}
        });

        [HttpGet]
        public IEnumerable<User> Get() => users;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = users.SingleOrDefault(user => user.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


/*        public IActionResult Index()
        {
            return View();
        }*/
    }
}
