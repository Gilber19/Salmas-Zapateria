using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Entidades;
using System.Configuration;
using System.Linq;

namespace Datos
{
    public class D_Usuarios : D_ConexionBD
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
                    System.Diagnostics.Debug.WriteLine("ERROR ValidarUsuario (DATOS) " + ex.Message);
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

                        comando.ExecuteNonQuery();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR NuevoRegistroUsuario (DATOS)");
                    throw new Exception("Error al registrar el usuario", ex);
                }
            }
        }

        public List<E_Usuario> RetornarId(string email)
        {
            List<E_Usuario> LstId = new List<E_Usuario>();

            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerRolYNombrePorEmail", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Email", email);

                AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Usuario Id = new E_Usuario
                        {
                            IdRol = Convert.ToInt32(reader["IdRol"].ToString()),
                            NombreUsuario = reader["Nombre"].ToString()
                        };

                        //System.Diagnostics.Debug.WriteLine("{Articulo.Stock}" + Articulo.NombreArticulo + " ::::: " + Articulo.Imagenes);

                        LstId.Add(Id);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR RetornarId (DATOS)");

                throw new Exception("Error al listar artículos: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return LstId;
        }
    }
}

