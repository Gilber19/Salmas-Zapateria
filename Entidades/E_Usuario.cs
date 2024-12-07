using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Usuario
    {
        #region Atributos
        private int _IdUsuario;
        private int _IdRol;
        private string _Nombre;
        private string _Email;
        private string _PassWordHash;
        private string _Direccion;
        private string _Telefono;
        private bool _Estado;
        #endregion

        #region Constructor

        public E_Usuario()
        {
            _IdUsuario = 0;
            _IdRol = 0;
            _Nombre = string.Empty;
            _Email = string.Empty;
            _PassWordHash = string.Empty;
            _Direccion = string.Empty;
            _Telefono = string.Empty;
            _Estado = false;
        }

        public E_Usuario(int idUsuario, int idRol, string nombreUsuario, string email, string passWordHash, string direccion, string telefono, bool estado)
        {
            _IdUsuario = idUsuario;
            _IdRol = idRol;
            _Nombre = nombreUsuario;
            _Email = email;
            _PassWordHash = passWordHash;
            _Direccion = direccion;
            _Telefono = telefono;
            _Estado = estado;
        }


        #endregion

        #region Encapsulamiento
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public int IdRol { get => _IdRol; set => _IdRol = value; }
        public string NombreUsuario { get => _Nombre; set => _Nombre = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string PassWordHash
        {
            get => _PassWordHash; set => _PassWordHash = value;
        }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public bool Estado { get => _Estado; set => _Estado = value; }
        #endregion
    }

    public class E_SesionUsuario
    {
        #region Atributos    
        private int _IdUsuario;
        private int _IdRolLogueado;
        private string _NombreUsuario;
        private string _NombreRolLogueado;
        private string _EmailUsuario;
        #endregion

        #region Constructor
        public E_SesionUsuario()
        {
            _IdUsuario = 0;
            _IdRolLogueado = 0;
            _NombreUsuario = string.Empty;
            _NombreRolLogueado = string.Empty;
            _EmailUsuario = string.Empty;
        }
        public E_SesionUsuario(int pIdUsuario, int pIdRolLogueado, string pNombreUsuario, string pNombreRolLogueado, string pEmailusuario)
        {
            _IdUsuario = pIdUsuario;
            _IdRolLogueado = pIdRolLogueado;
            _NombreUsuario = pNombreUsuario;
            _NombreRolLogueado = pNombreRolLogueado;
            _EmailUsuario = pEmailusuario;
        }

        #endregion
        #region Encapsulamiento
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public int IdRolLogueado { get => _IdRolLogueado; set => _IdRolLogueado = value; }
        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string NombreRolLogueado { get => _NombreRolLogueado; set => _NombreRolLogueado = value; }
        public string EmailUsuario { get => _EmailUsuario; set => _EmailUsuario = value; }


        #endregion
    }
}
