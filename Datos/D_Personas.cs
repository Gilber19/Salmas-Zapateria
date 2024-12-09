using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Entidades;
using System.Configuration;

namespace Datos
{
    public class D_Personas : D_ConexionBD
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        public List<E_Personas> ListarClientes()
        {
            List<E_Personas> LstClientes = new List<E_Personas>();

            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerClientes", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Personas cliente = new E_Personas
                        {
                            Nombre = reader["Nombre"].ToString(),
                        };


                        LstClientes.Add(cliente);
                        //System.Diagnostics.Debug.WriteLine("CARGAR: " + cliente.Nombre);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR LISTAR CLIENTES (DATOS)");

                throw new Exception("Error al obtener los clientes: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }
            return LstClientes;
        }

    }
}
