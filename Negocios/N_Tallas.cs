using Entidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_Tallas
    {
        D_Tallas DA = new D_Tallas();

        public string ObtenerIdTalla(string Talla)
        {
            E_Tallas talla = DA.ObtenerIdTalla(Talla);
            return talla.IdTalla.ToString();
        }
    }
}
