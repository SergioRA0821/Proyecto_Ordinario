using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ordinario
{
    internal class Usuario
    {
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario{NombreUsuario = "Sergio", Contrasenia = "0000"},
            new Usuario{NombreUsuario = "Sofi", Contrasenia = "1111"}
        };

        public Usuario() { }

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
