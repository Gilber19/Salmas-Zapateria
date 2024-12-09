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
    }
}
