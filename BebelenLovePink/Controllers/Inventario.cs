using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BebelenLovePink.Controllers
{
    public class Inventario : Controller
    {
        // GET: Inventario
        public ActionResult Inventory()
        {
            return View();
        }
    }
}
