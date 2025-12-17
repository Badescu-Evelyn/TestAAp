using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace foodrecipe.Controllers
{
    public class AboutController : Controller
    {
        [Authorize(Roles = "User, Administrator")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
