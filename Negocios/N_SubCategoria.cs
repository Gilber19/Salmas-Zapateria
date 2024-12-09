using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using Negocios;

namespace Negocios
{
    public class N_SubCategoria
    {
        D_SubCategoria DSC = new D_SubCategoria();


        public List<E_SubCategoria> ListarSubCategorias(int idCategoria)
        {
            try
            {
                return DSC.ListarSubCategorias(idCategoria);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al listar las subcategorias: (negocios)", ex.Message);
                return new List<E_SubCategoria>();

            }

        }
    }
}
