using Microsoft.AspNetCore.Mvc;

namespace Singularis_Test_Task.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
