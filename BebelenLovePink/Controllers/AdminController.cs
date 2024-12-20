using System.IO;
using BebelenLovePink.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BebelenLovePink.Controllers
{
    public class AdminController : Controller
    {
        public readonly IMongoCollection<Inventario> _inventario;
        private readonly IMongoCollection<Admin> _user;
        private readonly string _rutaDestino = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos");


        public AdminController(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("admin");
            _inventario = database.GetCollection<Inventario>("Inventario");
            _user = database.GetCollection<Admin>("AdminLogin");

            if (!Directory.Exists(_rutaDestino))
            {
                Directory.CreateDirectory(_rutaDestino);
            }
        }

        //[Authorize]
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
        public async Task<IActionResult> Create([Bind("Id", "Nombre", "Marca", "Precio", "Cantidad", "Estado", "Descripcion", "PhotoUrl" , "PrecioOferta")] Inventario inventario )
        {
            inventario.Id = ObjectId.GenerateNewId().ToString();
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var photo = Request.Form.Files[0];
                    var nombreArchivo = Path.GetFileName(photo.FileName);
                    var rutaArchivo = Path.Combine(_rutaDestino, nombreArchivo);

                    using (var stream = new FileStream(rutaArchivo, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }

                    inventario.PhotoUrl = Path.Combine("photos", nombreArchivo);
                    await _inventario.InsertOneAsync(inventario);
                }

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
        public async Task<IActionResult> Edit(string id, [Bind("Id", "Nombre", "Marca", "Precio", "Cantidad", "Estado", "Descripcion", "PrecioOferta")] Inventario inventario)
        {
            
            if (id != inventario.Id)
            {
                return NotFound();
            }

            if (id == inventario.Id)
            {
                await _inventario.ReplaceOneAsync(p => p.Id == id, inventario);
                return RedirectToAction(nameof(Index));
            }
            else
            {

            return View(inventario);
            }
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
        public async Task<IActionResult> Delete(string id, [Bind("Id", "Nombre", "Marca", "Precio", "Cantidad", "Estado", "Descripcion", "PrecioOferta")] Inventario inventario)
        {
            await _inventario.DeleteOneAsync(p => p.Id == id);
            return RedirectToAction(nameof(Index));
        }

    }
}
