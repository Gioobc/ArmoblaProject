using OfficeOpenXml;
using System.IO;

namespace ArmoblaProject.Models
{
    public class ExcelWriterService
    {
        private readonly string _rutaExcel;

        public ExcelWriterService()
        {
            // Asegúrate de ajustar esta ruta si tu archivo está en otro lado
            _rutaExcel = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "TablasIO_Excel.xlsx");

            // Configurar la licencia de EPPlus para uso no comercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void ActualizarYA(int id, bool valor)
        {
            int fila = 25 + id; // YA en C26, C27, C28
            ActualizarCelda("Hoja1", $"C{fila}", valor);
        }

        public void ActualizarYT(int id, bool valor)
        {
            int fila = 30 + id; // YT en C31, C32, C33
            ActualizarCelda("Hoja1", $"C{fila}", valor);
        }

        public void ActualizarYTR(int id, bool valor)
        {
            int fila = 35 + id; // YTR en C36, C37
            ActualizarCelda("Hoja1", $"C{fila}", valor);
        }

        private void ActualizarCelda(string hojaNombre, string celda, bool valor)
        {
            if (!File.Exists(_rutaExcel))
                throw new FileNotFoundException("El archivo Excel no fue encontrado.", _rutaExcel);

            using (var paquete = new ExcelPackage(new FileInfo(_rutaExcel)))
            {
                var hoja = paquete.Workbook.Worksheets[hojaNombre];
                if (hoja == null)
                    throw new InvalidDataException($"La hoja '{hojaNombre}' no existe en el archivo Excel.");

                hoja.Cells[celda].Value = valor;
                paquete.Save();
            }

        }

        public void ActualizarResultadoLingo(Dictionary<(int m, int t), double> valoresX)
        {
            if (!File.Exists(_rutaExcel))
                throw new FileNotFoundException("El archivo Excel no fue encontrado.", _rutaExcel);

            using (var paquete = new ExcelPackage(new FileInfo(_rutaExcel)))
            {
                var hoja = paquete.Workbook.Worksheets["Hoja1"];
                if (hoja == null)
                    throw new InvalidDataException("La hoja 'Hoja1' no existe.");

                // Mapeo de X(M,T) en G10:G13 (en orden M=1,2; T=1,2)
                // Asumiendo 2 muebles y 2 tipos
                int baseRow = 10;
                foreach (var ((m, t), valor) in valoresX)
                {
                    int fila = baseRow + ((m - 1) * 2) + (t - 1); // orden fila por M y T
                    hoja.Cells[$"G{fila}"].Value = valor;
                }

                paquete.Save();
            }
        }

    }
}
