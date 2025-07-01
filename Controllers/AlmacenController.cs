using Microsoft.AspNetCore.Mvc;
using ArmoblaProject.Models;
using System.Linq;

namespace ArmoblaProject.Controllers
{
    public class AlmacenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ExcelWriterService _excel;

        public AlmacenController(ApplicationDbContext context, ExcelWriterService excel)
        {
            _context = context;
            _excel = excel;
        }

        public IActionResult Index()
        {
            var almacenes = _context.Almacenes.ToList(); // Solo lectura
            return View(almacenes);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Almacen almacen)
        {
            if (!ModelState.IsValid || (almacen.YA != true && almacen.YA != false))
            {
                ModelState.AddModelError("YA", "Debes indicar si el almacén está activo o no.");
                return View(almacen);
            }

            _excel.ActualizarYA(almacen.Id, almacen.YA);
            TempData["Mensaje"] = "Campo YA actualizado correctamente en el Excel.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var almacen = _context.Almacenes.Find(id);
            return View(almacen);
        }

        [HttpPost]
        public IActionResult Edit(Almacen almacen)
        {
            if (!ModelState.IsValid || (almacen.YA != true && almacen.YA != false))
            {
                ModelState.AddModelError("YA", "Debes indicar si el almacén está activo o no.");
                return View(almacen);
            }

            _excel.ActualizarYA(almacen.Id, almacen.YA);
            TempData["Mensaje"] = "Campo YA actualizado correctamente en el Excel.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            TempData["Mensaje"] = "Solo puedes desactivar el campo desde el formulario.";
            return RedirectToAction(nameof(Index));
        }
    }
}
