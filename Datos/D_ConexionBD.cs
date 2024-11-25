using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
  public class D_ConexionBD
  {
    // Objeto para manejar la conexión con la base de datos
    public SqlConnection conexion;

    // Constructor para inicializar la cadena de conexión desde Web.config
    public D_ConexionBD()
    {
      // Obtener la cadena de conexión desde Web.config usando ConfigurationManager
      conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString);
    }

    // Método para abrir la conexión a la base de datos
    public void AbrirConexion()
    {
      try
      {
        if (conexion.State == ConnectionState.Closed || conexion.State == ConnectionState.Broken)
        {
          conexion.Open();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error al abrir la conexión: " + ex.Message);
      }
    }

    // Método para cerrar la conexión a la base de datos
    public void CerrarConexion()
    {
      try
      {
        if (conexion.State == ConnectionState.Open)
        {
          conexion.Close();          
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
      }
    }

    // Método para obtener la conexión (en caso de ser necesario)
    public SqlConnection ObtenConexion()
    {
      return conexion;
    }
  }
}
