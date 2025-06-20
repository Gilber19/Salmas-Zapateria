﻿using Entidades;
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
            bool id = false;
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
                        id = true;
                    }
                }

                if (!id)
                {
                    SqlCommand cmd2 = new SqlCommand("IBMO_Tallas", conexion);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@Accion", "INSERTAR");
                    cmd2.Parameters.AddWithValue("@Talla", Talla);

                    // Usar ExecuteScalar para obtener el ID devuelto por el procedimiento almacenado
                    var idTallaResult = cmd2.ExecuteScalar();
                    if (idTallaResult != null)
                    {
                        talla = new E_Tallas
                        {
                            IdTalla = Convert.ToInt32(idTallaResult),
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener o insertar la talla: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return talla;
        }

    }
}