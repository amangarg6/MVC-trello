using Microsoft.AspNetCore.Mvc;

namespace ProjectTask.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
