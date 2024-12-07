using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Datos
{
    public class D_Usuarios
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        public bool ValidarUsuario(string email, string password)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand("sp_IniciarSesion", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@Email", email);
                        comando.Parameters.AddWithValue("@Password", password);

                        int count = (int)comando.ExecuteScalar();

                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al validar el usuario");
                }
            }
        }

    }
}

