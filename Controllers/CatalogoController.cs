using Microsoft.AspNetCore.Mvc;
using ArmoblaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ArmoblaProject.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Cargamos todos los MuebleTipo si existe esa tabla
            var muebles = _context.MuebleTipos
                .Include(mt => mt.Mueble)
                .Include(mt => mt.Tipo)
                .ToList();

            return View(muebles);
        }
    }
}
