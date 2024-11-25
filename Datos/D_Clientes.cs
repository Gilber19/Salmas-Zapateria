using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Datos
{
  public class D_Clientes: D_ConexionBD
  {
    public List<E_ddlClientes> ListarClientes()
    {
      List<E_ddlClientes> LstClientes = new List<E_ddlClientes>();

      try
      {
        SqlCommand cmd = new SqlCommand("LstClientes", conexion)
        {
          CommandType = CommandType.StoredProcedure
        };

        AbrirConexion();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            E_ddlClientes clientes = new E_ddlClientes
            {
              IdPersona = Convert.ToInt32(reader["IdPersona"]),
              NombrePersona = reader["NombrePersona"].ToString()
            };
            LstClientes.Add(clientes);
          }
        }
      }
      catch (Exception ex)
      {
        // Manejo de excepciones
        Console.WriteLine(ex.Message);
      }
      finally
      {
        CerrarConexion();
      }

      return LstClientes;
    }
  }
}
