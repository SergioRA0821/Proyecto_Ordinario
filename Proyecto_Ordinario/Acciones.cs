using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace Proyecto_Ordinario
{
    internal class Acciones : IAcciones
    {
        List<Auto> ListaAuto = new List<Auto>();
        Correo correo = new Correo();
        Auto a = new Auto();

        public int ContarDisponibles()
        {
            int contador = 0;
            foreach (var d in ListaAuto)
            {
                if (d.Estado == "Disponible")
                {
                    contador = contador + 1;
                }
            }
            return contador;
        }
        public bool ActualizarAuto(int NuevoId, string NuevaMarca, string NuevoModelo, int NuevoAnio, string NuevoColor, double NuevoPrecio, string NuevoEstado)
        {
            try
            {
                var ObjetoActualizar = ListaAuto.Find(x => x.Id == NuevoId);

                ObjetoActualizar.Id = NuevoId;
                ObjetoActualizar.Marca = NuevaMarca;
                ObjetoActualizar.Modelo = NuevoModelo;
                ObjetoActualizar.Anio = NuevoAnio;
                ObjetoActualizar.Color = NuevoColor;
                ObjetoActualizar.Precio = NuevoPrecio;
                ObjetoActualizar.Estado = NuevoEstado;
                return true;
            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                return false;
            }
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
            try
            {
                var ObjetoEliminar = ListaAuto.Find(x => x.Id == Id);
                if (ObjetoEliminar != null)
                {
                    ListaAuto.Remove(ObjetoEliminar);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExportarExcel()
        {
            try
            {
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Autos_Exportacion.xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var hoja = workbook.Worksheets.Add("Autos");

                    // Encabezados
                    hoja.Cell(1, 1).Value = "Id";
                    hoja.Cell(1, 2).Value = "Marca";
                    hoja.Cell(1, 3).Value = "Modelo";
                    hoja.Cell(1, 4).Value = "Anio";
                    hoja.Cell(1, 5).Value = "Color";
                    hoja.Cell(1, 6).Value = "Precio";
                    hoja.Cell(1, 7).Value = "Estado";

                    int fila = 2;

                    foreach (var auto in ListaAuto)
                    {
                        hoja.Cell(fila, 1).Value = auto.Id;
                        hoja.Cell(fila, 2).Value = auto.Marca;
                        hoja.Cell(fila, 3).Value = auto.Modelo;
                        hoja.Cell(fila, 4).Value = auto.Anio;
                        hoja.Cell(fila, 5).Value = auto.Color;
                        hoja.Cell(fila, 6).Value = auto.Precio;
                        hoja.Cell(fila, 7).Value = auto.Estado;

                        fila++;
                    }

                    workbook.SaveAs(rutaArchivo);
                }

                return true;
            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                return false;
            }
        }

        public bool ImportardeExcel()
        {
            try
            {
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Autos_Importacion.xlsx");

                if (!File.Exists(rutaArchivo))
                    return false;

                using (var workbook = new XLWorkbook(rutaArchivo))
                {
                    var hoja = workbook.Worksheets.First();
                    var filas = hoja.RowsUsed().Skip(1);

                    foreach (var fila in filas)
                    {
                        Auto auto = new Auto()
                        {
                            Id = int.Parse(fila.Cell(1).GetValue<string>()),
                            Marca = fila.Cell(2).GetValue<string>(),
                            Modelo = fila.Cell(3).GetValue<string>(),
                            Anio = int.Parse(fila.Cell(4).GetValue<string>()),
                            Color = fila.Cell(5).GetValue<string>(),
                            Precio = double.Parse(fila.Cell(6).GetValue<string>()),
                            Estado = fila.Cell(7).GetValue<string>()
                        };

                        ListaAuto.Add(auto);
                    }
                }

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
            try
            {
                ListaAuto.Add(new Auto(a.Id = Id, a.Marca = Marca, a.Modelo = Modelo, a.Anio = Anio, a.Color = Color, a.Precio = Precio, a.Estado = Estado));
                return true;
            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                return false;
            }
        }
    }
}
