using Microsoft.AspNetCore.Mvc;
using ArmoblaProject.Models;
using System.Linq;

namespace ArmoblaProject.Controllers
{
    public class TallerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ExcelWriterService _excel;

        public TallerController(ApplicationDbContext context, ExcelWriterService excel)
        {
            _context = context;
            _excel = excel;
        }

        public IActionResult Index()
        {
            var talleres = _context.Talleres.ToList(); // lectura permitida
            return View(talleres);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Taller taller)
        {
            if (!ModelState.IsValid || (taller.YT != true && taller.YT != false))
            {
                ModelState.AddModelError("YT", "Debes indicar si el taller está seleccionado.");
                return View(taller);
            }

            _excel.ActualizarYT(taller.Id, taller.YT);
            TempData["Mensaje"] = "Campo YT actualizado correctamente en Excel.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var taller = _context.Talleres.Find(id);
            return View(taller);
        }

        [HttpPost]
        public IActionResult Edit(Taller taller)
        {
            if (!ModelState.IsValid || (taller.YT != true && taller.YT != false))
            {
                ModelState.AddModelError("YT", "Debes indicar si el taller está seleccionado.");
                return View(taller);
            }

            _excel.ActualizarYT(taller.Id, taller.YT);
            TempData["Mensaje"] = "Campo YT actualizado correctamente en Excel.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            TempData["Mensaje"] = "Solo puedes cambiar el estado desde el formulario.";
            return RedirectToAction(nameof(Index));
        }
    }
}
