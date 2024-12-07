using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_Usuario
    {
        private D_Usuarios usuario = new D_Usuarios();

        public bool ValidarLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                throw new ArgumentException("El nombre de usuario y la contraseña son requeridos");

            return usuario.ValidarUsuario(email, password);

        }
    }
}
