using Microsoft.AspNetCore.Mvc;

namespace BebelenLovePink.Controllers
{
    public class LoginController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> ValidarUsuario()
        {
            var confirmado = "confirmado";
            return View(confirmado);
        }
    }
}
