using ClosedXML.Excel;
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
        Correo correo = new Correo();
        public bool ActualizarAuto(int IdActual, int NuevoId, string NuevaMarca, string NuevoModelo, int NuevoAnio, string NuevoColor, double NuevoPrecio, string NuevoEstado)
        {
            throw new NotImplementedException();
        }

        public List<Auto> Consultar()
        {
            try
            {
                return ListaAuto;

            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                throw;
            }
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
                string filePath = Path.Combine(desktopPath, "Autos_Importacion.xlsx");

                if (!File.Exists(filePath))
                    return false;

                var newList = new List<Auto>();

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("Autos");
                    var rows = worksheet.RowsUsed().Skip(1);

                    foreach (var row in rows)
                    {
                        int Id = int.Parse(row.Cell(1).GetValue<string>());
                        string Marca = row.Cell(2).GetString();
                        string Modelo = row.Cell(3).GetString();
                        int Anio = int.Parse(row.Cell(4).GetValue<string>());
                        string Color = row.Cell(5).GetString();
                        double Precio = double.Parse(row.Cell(6).GetValue<string>());
                        string Estado = row.Cell(7).GetString();

                        newList.Add(new Auto(Id, Marca, Modelo, Anio, Color, Precio, Estado));
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
