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
                            IdPersona = Convert.ToInt32(reader["IdPersona"]),
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

        public List<E_Personas> ObtenerDetalleCliente(int idPersona)
        {
            List<E_Personas> LstClientes = new List<E_Personas>();

            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerDetalleCliente", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdPersona", idPersona);

                AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Personas cliente = new E_Personas
                        {
                            Nombre = reader["Nombre"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            LimiteCredito = Convert.ToInt32(reader["LimiteCredito"]),
                            LimiteDisponible = Convert.ToInt32(reader["LimiteDisponible"]),
                        };

                        LstClientes.Add(cliente);
                        //System.Diagnostics.Debug.WriteLine("CARGAR: " + cliente.Nombre + " " + cliente.LimiteDisponible);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR OBTENER DETALLE CLIENTE (DATOS)");

                throw new Exception("Error al obtener los clientes: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }
            return LstClientes;
        }

        public List<E_Personas> ListarClientesPorNombre(string Nombre)
        {
            List<E_Personas> LstClientes = new List<E_Personas>();

            try
            {
                SqlCommand cmd = new SqlCommand("BuscarClientePorNombre", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Nombre", Nombre);

                AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Personas clientes = new E_Personas
                        {
                            Nombre = reader["Nombre"].ToString(),
                            IdPersona = Convert.ToInt32(reader["IdPersona"]),
                        };
                        LstClientes.Add(clientes);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                System.Diagnostics.Debug.WriteLine("ERROR ListarClientesPorNombre (DATOS)");

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
