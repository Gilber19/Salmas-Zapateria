using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class Pruebas
    {
        static void Main()
        {
            D_Usuarios datos = new D_Usuarios();

            string email = "uwu@uwu.com";
            string password = "12345";

            bool esValido = datos.ValidarUsuario(email, password);

            if (esValido)
            {
                Console.WriteLine("Uusario valido");
            }
            else
            {
                Console.WriteLine("Usuari invalido");
            }
        }
    }
}
