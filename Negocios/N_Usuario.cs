using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Entidades;

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
        //el parametro nombre debe venir concatenado con el apellido
        public bool RegistrarUsuario(string nombre, string direccion, string telefono, string email, string password)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(direccion))
                throw new ArgumentException("Todos los campos son requeridos");

            return usuario.NuevoRegistroUsuario(nombre, direccion, telefono, email, password);
        }

        public List<E_Usuario> RetornarId(string email)
        {
            try
            {
                return usuario.RetornarId(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario", ex);
            }
        }

    }
}
