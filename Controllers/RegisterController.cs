using Microsoft.AspNetCore.Mvc;

namespace foodrecipe.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
