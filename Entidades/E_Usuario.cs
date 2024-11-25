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
    private string _NombreUsuario;
    private string _TipoDocumento;
    private string _NumeroDocumento;
    private string _Direccion;
    private string _Telefono;
    private string _EmailUsuario;
    private string _PassWordHash;
    private string _PassWordSalt;    
    #endregion

    #region Constructor

    public E_Usuario()
    {
      _IdUsuario = 0;
      _IdRol = 0;
      _NombreUsuario = string.Empty;
      _TipoDocumento = string.Empty;
      _NumeroDocumento = string.Empty;
      _Direccion = string.Empty;
      _Telefono = string.Empty;
      _EmailUsuario = string.Empty;
      _PassWordHash = string.Empty;
      _PassWordSalt = string.Empty;
    }

    public E_Usuario(int idUsuario, int idRol, string nombreUsuario, string tipoDocumento, string numeroDocumento, string direccion, string telefono, string emailUsuario, string passWordHash, string passWordSalt)
    {
      _IdUsuario = idUsuario;
      _IdRol = idRol;
      _NombreUsuario = nombreUsuario;
      _TipoDocumento = tipoDocumento;
      _NumeroDocumento = numeroDocumento;
      _Direccion = direccion;
      _Telefono = telefono;
      _EmailUsuario = emailUsuario;
      _PassWordHash = passWordHash;
      _PassWordSalt = passWordSalt;
    }


    #endregion

    #region Encapsulamiento
    public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
    public int IdRol { get => _IdRol; set => _IdRol = value; }
    public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
    public string TipoDocumento { get => _TipoDocumento; set => _TipoDocumento = value; }
    public string NumeroDocumento { get => _NumeroDocumento; set => _NumeroDocumento = value; }
    public string Direccion { get => _Direccion; set => _Direccion = value; }
    public string Telefono { get => _Telefono; set => _Telefono = value; }
    public string EmailUsuario { get => _EmailUsuario; set => _EmailUsuario = value; }
    public string PassWordHash { get => _PassWordHash; set => _PassWordHash = value; }
    public string PassWordSalt { get => _PassWordSalt; set => _PassWordSalt = value; }
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
    public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
    public int IdRolLogueado { get => _IdRolLogueado; set => _IdRolLogueado = value; }
    public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
    public string NombreRolLogueado { get => _NombreRolLogueado; set => _NombreRolLogueado = value; }
    public string EmailUsuario { get => _EmailUsuario; set => _EmailUsuario = value; }    
    #region Encapsulamiento


    #endregion
  }
}
