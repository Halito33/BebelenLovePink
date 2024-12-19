using Microsoft.AspNetCore.Mvc;

namespace BebelenLovePink.Controllers
{
    public class LoginController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
