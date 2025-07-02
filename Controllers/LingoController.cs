using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArmoblaProject.Controllers
{
    public class LingoController : Controller
    {
        [HttpPost]
        public IActionResult Run()
        {
            string rutaLingoExe = @"C:\LINGO64_21\Lingo64_21.exe"; // Cambia por la ruta real de LINGO
            string rutaModelo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lingo", "modelo.lng");
            string rutaResultado = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lingo", "resultado.txt");

            // Asegúrate de eliminar resultado anterior
            if (System.IO.File.Exists(rutaResultado))
                System.IO.File.Delete(rutaResultado);

            var proceso = new ProcessStartInfo
            {
                FileName = rutaLingoExe,
                Arguments = $"\"{rutaModelo}\"",
                RedirectStandardOutput = false,
                UseShellExecute = true,
                CreateNoWindow = true
            };

            Process.Start(proceso)?.WaitForExit();

            string resultado = "No se encontró resultado.";
            if (System.IO.File.Exists(rutaResultado))
            {
                var lineas = System.IO.File.ReadAllLines(rutaResultado);
                resultado = string.Join(Environment.NewLine, lineas
                    .Where(l => l.Contains("YA") || l.Contains("YT") || l.Contains("YTR") || l.Contains("X(")));
            }

            ViewBag.Resultado = resultado;
            return View();
        }
    }
}
