using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using System.Diagnostics;

namespace Negocios
{
    public class N_Tallas
    {

        D_Tallas DT = new D_Tallas();

        private readonly D_Tallas datosTallas = new D_Tallas();

        public E_Tallas ObtenerIdTalla(string Talla)
        {
            try
            {
                return DT.ObtenerIdTalla(Talla);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en N_Tallas.ObtenerIdTalla: ");

                throw new Exception("Error al insertar el artículo: " + ex.Message, ex);
            }

        }


    }
}
