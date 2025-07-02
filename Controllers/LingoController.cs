using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.RegularExpressions;
using ArmoblaProject.Models;

namespace ArmoblaProject.Controllers
{
    public class LingoController : Controller
    {
        private readonly ExcelWriterService _excel;

        public LingoController(ExcelWriterService excel)
        {
            _excel = excel;
        }

        public IActionResult Run()
        {
            string pathResultado = @"C:\Ruta\resultado.txt";
            string resultado = "No se encontró el resultado.";

            if (System.IO.File.Exists(pathResultado))
            {
                resultado = System.IO.File.ReadAllText(pathResultado);

                // Extraer valores X(m,t)
                var valoresX = ExtraerValoresX(resultado);

                // Actualizar en Excel
                _excel.ActualizarResultadoLingo(valoresX);
                ViewBag.Mensaje = "Solución cargada y enviada a Excel.";
            }
            else
            {
                ViewBag.Mensaje = "Archivo de resultado no encontrado.";
            }

            ViewBag.Resultado = resultado;
            return View();
        }

        private Dictionary<(int, int), double> ExtraerValoresX(string texto)
        {
            var dic = new Dictionary<(int, int), double>();
            var regex = new Regex(@"X\(\s*(\d+),\s*(\d+)\)\s+([\d\.]+)");

            var matches = regex.Matches(texto);
            foreach (Match m in matches)
            {
                int i = int.Parse(m.Groups[1].Value);
                int j = int.Parse(m.Groups[2].Value);
                double valor = double.Parse(m.Groups[3].Value);
                dic[(i, j)] = valor;
            }

            return dic;
        }
    }
}
