using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ordinario
{
    internal class Auto
    {
        public Auto() { }
        public Auto(int id, string marca, string modelo, int anio, string color, double precio, string estado)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            Color = color;
            Precio = precio;
            Estado = estado;
        }
       
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }
    }
}
