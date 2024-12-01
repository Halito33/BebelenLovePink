using BebelenLovePink.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BebelenLovePink.Controllers
{
    public class Admin : Controller
    {
        public readonly IMongoCollection<Inventario> _inventario;
        public Admin(IMongoClient monogClient)
        {
            var database = monogClient.GetDatabase("admin");
            _inventario = database.GetCollection<Inventario>("Inventario");
        }

        public async Task<IActionResult> Index()
        {
            var inventario = await _inventario.Find(_ => true).ToListAsync();
            return View(inventario);
        }

        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id", "Nombre", "Marca", "Precio", "Cantidad")] Inventario inventario)
        {
            inventario.Id = ObjectId.GenerateNewId().ToString();
            try
            {
                await _inventario.InsertOneAsync(inventario);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error insertando el producto: {ex.Message}");
                ModelState.AddModelError("", "Error insertando el producto");
                return View(inventario);
            }

        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _inventario.Find(p => p.Id == id).FirstOrDefaultAsync();

            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id", "Nombre", "Marca", "Precio","Cantidad")] Inventario inventario)
        {
            if (id != inventario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _inventario.ReplaceOneAsync(p => p.Id == id, inventario);
                return RedirectToAction($"{nameof(Index)}");
            }

            return View(inventario);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _inventario.Find(p => p.Id == id).FirstOrDefaultAsync();

            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, [Bind("Id", "Nombre", "Marca", "Precio", "Cantidad")] Inventario inventario)
        {
            await _inventario.DeleteOneAsync(p => p.Id == id);
            return RedirectToAction(nameof(Index));
        }
    }
}
