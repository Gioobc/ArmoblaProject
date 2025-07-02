using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArmoblaProject.Controllers
{
    public class LingoController : Controller
    {
        // GET: /Lingo/Run
        [HttpGet]
        [ActionName("Run")]
        public IActionResult RunGet()
        {
            return View();
        }

        // POST: /Lingo/Run
        [HttpPost]
        public IActionResult Run()
        {
            // Ruta al ejecutable de LINGO
            string rutaLingoExe = @"C:\LINGO64_21\Lingo64_21.exe";

            // Ruta al archivo del modelo .lng
            string rutaModelo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lingo", "ArmoblaModel_IO.lng");

            // Ruta donde LINGO escribirá los resultados
            string rutaResultado = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lingo", "resultado.txt");

            try
            {
                // Verificar existencia del ejecutable
                if (!System.IO.File.Exists(rutaLingoExe))
                {
                    ViewBag.Mensaje = "No se encontró el ejecutable de LINGO.";
                    return View();
                }

                // Verificar existencia del archivo del modelo
                if (!System.IO.File.Exists(rutaModelo))
                {
                    ViewBag.Mensaje = "No se encontró el archivo del modelo (.lng).";
                    return View();
                }

                // Eliminar resultado anterior si existe
                if (System.IO.File.Exists(rutaResultado))
                    System.IO.File.Delete(rutaResultado);

                // Ejecutar LINGO con el archivo .lng
                var proceso = new ProcessStartInfo
                {
                    FileName = rutaLingoExe,
                    Arguments = $"\"{rutaModelo}\"", // Importante: usar comillas para rutas con espacios
                    UseShellExecute = true,
                    CreateNoWindow = true
                };

                var proc = Process.Start(proceso);
                proc?.WaitForExit();

                // Leer el resultado generado
                if (System.IO.File.Exists(rutaResultado))
                {
                    var lineas = System.IO.File.ReadAllLines(rutaResultado);
                    var resultadoFiltrado = lineas
                        .Where(l => l.Contains("YA(") || l.Contains("YT(") || l.Contains("YTR(") || l.Contains("X("))
                        .ToList();

                    ViewBag.Resultado = string.Join(Environment.NewLine, resultadoFiltrado);
                    ViewBag.Mensaje = "Evaluación ejecutada correctamente.";
                }
                else
                {
                    ViewBag.Mensaje = "La ejecución se completó, pero no se generó el archivo de resultados.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = $"Ocurrió un error al ejecutar el modelo: {ex.Message}";
            }

            return View();
        }
    }
}
