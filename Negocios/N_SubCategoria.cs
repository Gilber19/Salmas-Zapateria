using System;
using System.Collections.Generic;
using Datos;
using Entidades;

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