using Microsoft.AspNetCore.Mvc;
using Singularis_Test_Task.Models;

namespace Singularis_Test_Task.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private static List<User> users = new List<User>(new[]
        {
            new User() {firstName = "Игорь", lastName = "Иванов",
                address = "Москва, Ленинский проспект", dateBirthday = "20 августа 1900",
            email = "qwerty1@yandex.ru", phoneNumber = "123456789"},

            new User() {firstName = "Евгений", lastName = "Иванка",
                address = "Москва, Ленинский проспектик", dateBirthday = "21 августа 1900",
            email = "qwerty2@yandex.ru", phoneNumber = "123456789"},

            new User() {firstName = "Анатолий", lastName = "Ивановичкин",
                address = "Москва, Ленинский проспектун", dateBirthday = "22 августа 1900",
            email = "qwerty3@yandex.ru", phoneNumber = "123456789"}
        });



        [HttpGet]
        public IEnumerable<User> Get() => users;
        

        public IActionResult Index()
        {
            return View();
        }
    }
}
