using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArmoblaProject.Controllers
{
    public class LingoController : Controller
    {
        [HttpGet]
        [ActionName("Run")]
        public IActionResult RunGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Run()
        {
            string rutaLg4 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lingo", "ArmoblaModel_IO.lg4");

            try
            {
                if (!System.IO.File.Exists(rutaLg4))
                {
                    ViewBag.Mensaje = "No se encontró el archivo del modelo (.lg4).";
                    return View();
                }

                var proceso = new ProcessStartInfo
                {
                    FileName = rutaLg4,
                    UseShellExecute = true, // usa programa asociado (LINGO)
                    CreateNoWindow = false
                };

                Process.Start(proceso);

                ViewBag.Mensaje = "LINGO se ha abierto correctamente. Ejecuta el modelo manualmente y luego presiona 'Leer Resultado'.";
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = $"Error al intentar abrir el archivo: {ex.Message}";
            }

            return View();
        }

        // Acción para leer resultado.txt manualmente
        [HttpPost]
        public IActionResult LeerResultado()
        {
            string rutaResultado = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lingo", "resultado.txt");

            if (System.IO.File.Exists(rutaResultado))
            {
                var lineas = System.IO.File.ReadAllLines(rutaResultado);
                var resultadoFiltrado = lineas
                    .Where(l => l.Contains("YA(") || l.Contains("YT(") || l.Contains("YTR(") || l.Contains("X("))
                    .ToList();

                ViewBag.Resultado = string.Join(Environment.NewLine, resultadoFiltrado);
                ViewBag.Mensaje = "Resultados cargados desde LINGO.";
            }
            else
            {
                ViewBag.Mensaje = "No se encontró el archivo de resultados.";
                ViewBag.Resultado = null;
            }

            return View("Run");
        }
    }
}
