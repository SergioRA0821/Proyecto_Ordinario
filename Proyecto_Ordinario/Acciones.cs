using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ordinario
{
    internal class Acciones : IAcciones
    {
        List<Auto> ListaAuto = new List<Auto>();
        public bool ActualizarAuto(int IdActual, int NuevoId, string NuevaMarca, string NuevoModelo, int NuevoAnio, string NuevoColor, double NuevoPrecio, string NuevoEstado)
        {
            throw new NotImplementedException();
        }

        public List<Auto> Consultar()
        {
            throw new NotImplementedException();
        }

        public bool EliminarAuto(int Id)
        {
            throw new NotImplementedException();
        }

        public bool ExportarExcel()
        {
            throw new NotImplementedException();
        }

        public bool ImportardeExcel()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "ListaAlumnos.xlsx");

                if (!File.Exists(filePath))
                    return false;

                var newList = new List<Auto>();

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("Alumnos");
                    var rows = worksheet.RowsUsed().Skip(1); // Omitir encabezados

                    foreach (var row in rows)
                    {
                        string nombre = row.Cell(1).GetString();
                        int edad = int.Parse(row.Cell(2).GetValue<string>());
                        string carrera = row.Cell(3).GetString();
                        int matricula = int.Parse(row.Cell(4).GetValue<string>());
                        DateTime fechaIngreso = DateTime.Parse(row.Cell(5).GetString());

                        newList.Add(new Auto(id, marca, modelo, anio, color, precio, estado));
                    }
                }

                ListaAuto = newList;
                return true;
            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                return false;
            }
        }

        public bool InsertarAuto(int Id, string Marca, string Modelo, int Anio, string Color, double Precio, string Estado)
        {
            throw new NotImplementedException();
        }
    }
}
