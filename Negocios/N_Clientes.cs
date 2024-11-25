using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;

namespace Negocios
{

  public class N_Clientes
  {
    D_Clientes DC = new D_Clientes();

   public List<E_ddlClientes> ListadoCliente() => DC.ListarClientes();
  }
}
