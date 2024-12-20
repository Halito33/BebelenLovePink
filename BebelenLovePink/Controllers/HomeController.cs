using BebelenLovePink.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Diagnostics;

namespace BebelenLovePink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IMongoCollection<Inventario> _inventario;
        public HomeController(IMongoClient monogClient)
        {
            var database = monogClient.GetDatabase("admin");
            _inventario = database.GetCollection<Inventario>("Inventario");
        }

        public async Task<IActionResult> Index()
        {
            var inventario = await _inventario.Find(_ => true).ToListAsync();
            return View(inventario);
        }
       

        public async Task<IActionResult> Details(string id)
        {
            var inventario = await _inventario.Find(p => p.Id == id).FirstOrDefaultAsync();
            return View(inventario);
        }

        public async Task<IActionResult> CarroDeCompra()
        {
            var inventario = await _inventario.Find(_ => true).ToListAsync();
            return View(inventario);
        }

        public async Task<IActionResult> Productos()
        {
            var inventario = await _inventario.Find(_ => true).ToListAsync();
            return View(inventario);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}