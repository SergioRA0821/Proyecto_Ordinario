using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ordinario
{
    internal interface IAcciones
    {
        bool ImportardeExcel();
        List<Auto> Consultar();
        bool InsertarAuto(int Id, string Marca, string Modelo, int Anio, string Color, double Precio, string Estado);
        bool EliminarAuto(int Id);
        bool ActualizarAuto(int IdActual, int NuevoId, string NuevaMarca, string NuevoModelo, int NuevoAnio, string NuevoColor, double NuevoPrecio, string NuevoEstado);
        bool ExportarExcel();
    }
}
