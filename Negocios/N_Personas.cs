using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_Personas
    {
        D_Personas DP = new D_Personas();

        private readonly D_Personas datosPersonas = new D_Personas();

        public List<E_Personas> ListarClientes()
        {
            try
            {
                return DP.ListarClientes();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en N_Personas.ListarClientes: " + ex.Message);
                throw new Exception("Error al listar los clientes: " + ex.Message, ex);
            }
        }

        public List<E_Personas> ObtenerDetalleCliente(int idPersona)
        {
            try
            {
                return DP.ObtenerDetalleCliente(idPersona);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en N_Personas.ObtenerDetalleCliente: " + ex.Message);
                throw new Exception("Error al obtener el detalle del cliente: " + ex.Message, ex);
            }
        }

        public List<E_Personas> ListarClientesPorNombre(string Nombre)
        {
            try
            {
                return DP.ListarClientesPorNombre(Nombre);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en N_Personas.ListarClientesPorNombre: " + ex.Message);
                throw new Exception("Error al listar los clientes por nombre: " + ex.Message, ex);
            }
        }

    }
}
