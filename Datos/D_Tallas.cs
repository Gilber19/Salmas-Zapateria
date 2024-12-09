using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Tallas : D_ConexionBD
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        public E_Tallas ObtenerIdTalla(string Talla)
        {
            E_Tallas talla = null;
            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerIdTalla", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Talla", Talla);

                AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        talla = new E_Tallas
                        {
                            IdTalla = Convert.ToInt32(reader["IdTalla"]),
                        };

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el artículo: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return talla;
        }
    }
}
