using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;

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
                    //throw new Exception("Error al validar el usuario");
                    return false;
                }
            }
        }

        public bool NuevoRegistroUsuario(string nombre, string direccion, string telefono, string email, string password, int idRol = 2)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand("RegistrarUsuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@Nombre", nombre);
                        comando.Parameters.AddWithValue("@Email", email);
                        comando.Parameters.AddWithValue("@Password", password);
                        comando.Parameters.AddWithValue("@Direccion", direccion);
                        comando.Parameters.AddWithValue("@Telefono", telefono);
                        comando.Parameters.AddWithValue("@IdRol", idRol);

                        int count = comando.ExecuteNonQuery();

                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar el usuario", ex);
                }
            }
        }


    }
}

