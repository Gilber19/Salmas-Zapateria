using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class E_ddlClientes
  {
   private int idPersona;
   private string nombrePersona;

   public int IdPersona { get => idPersona; set => idPersona = value; }
   public string NombrePersona { get => nombrePersona; set => nombrePersona = value; }
  }
}
