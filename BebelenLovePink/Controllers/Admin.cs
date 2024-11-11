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
		public ActionResult Options()
		{
			return View();
		}
        public ActionResult Inventory()
        {
            return View();
        }
        public ActionResult Estadistics()
        {
            return View();
        }
    }
}
