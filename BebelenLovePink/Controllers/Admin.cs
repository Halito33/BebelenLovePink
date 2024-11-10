using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BebelenLovePink.Controllers
{
    public class Admin : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

    }
}
