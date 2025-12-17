using Microsoft.AspNetCore.Mvc;

namespace foodrecipe.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
