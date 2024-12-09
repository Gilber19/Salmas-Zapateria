using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Entidades;
using System.ComponentModel;
using System.Configuration;


namespace Datos
{
    public class D_SubCategoria : D_ConexionBD
    {

        public List<E_SubCategoria> ListarSubCategorias(int idCategoria) // IdCategoria = 3 (Ropa) IdCategoria = 2 (Calzado) IdCategoria = 1 (Accesorios)
        {
            List<E_SubCategoria> LstSubCategorias = new List<E_SubCategoria>();

            try
            {
                SqlCommand cmd = new SqlCommand("LstSubCategorias", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria); 

                AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_SubCategoria subCategoria = new E_SubCategoria
                        {
                            IdSubCategoria = Convert.ToInt32(reader["IdSubCategoria"]),
                            IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                            SubCategoria = reader["SubCategoria"].ToString(),
                            Descripcion = reader["Descripcion"].ToString()
                        };
                        LstSubCategorias.Add(subCategoria);
                    }
                    System.Diagnostics.Debug.WriteLine("Subcategorias listadas correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al listar las subcategorias (Datos): " + ex.Message);
                return new List<E_SubCategoria>();
            }
            finally
            {
                CerrarConexion();
            }

            return LstSubCategorias;
        }

    }
}





