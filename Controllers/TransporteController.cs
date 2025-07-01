using Microsoft.AspNetCore.Mvc;
using ArmoblaProject.Models;
using System.Linq;

namespace ArmoblaProject.Controllers
{
    public class TransporteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ExcelWriterService _excel;

        public TransporteController(ApplicationDbContext context, ExcelWriterService excel)
        {
            _context = context;
            _excel = excel;
        }

        public IActionResult Index()
        {
            var transportes = _context.Transportes.ToList(); // solo lectura
            return View(transportes);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Transporte transporte)
        {
            if (!ModelState.IsValid || (transporte.YTR != true && transporte.YTR != false))
            {
                ModelState.AddModelError("YTR", "Debes indicar si el transporte está activo.");
                return View(transporte);
            }

            _excel.ActualizarYTR(transporte.Id, transporte.YTR);
            TempData["Mensaje"] = "Campo YTR actualizado correctamente en Excel.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var transporte = _context.Transportes.Find(id);
            return View(transporte);
        }

        [HttpPost]
        public IActionResult Edit(Transporte transporte)
        {
            if (!ModelState.IsValid || (transporte.YTR != true && transporte.YTR != false))
            {
                ModelState.AddModelError("YTR", "Debes indicar si el transporte está activo.");
                return View(transporte);
            }

            _excel.ActualizarYTR(transporte.Id, transporte.YTR);
            TempData["Mensaje"] = "Campo YTR actualizado correctamente en Excel.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            TempData["Mensaje"] = "Solo puedes desactivar el campo desde el formulario.";
            return RedirectToAction(nameof(Index));
        }
    }
}
