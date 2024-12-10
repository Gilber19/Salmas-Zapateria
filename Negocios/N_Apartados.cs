using System;
using System.Collections.Generic;
using System.Diagnostics;
using Datos;
using Entidades;

namespace Negocios
{
    public class N_Apartados
    {
        D_Apartados DA = new D_Apartados();

        private readonly D_Apartados datosApartados = new D_Apartados();

        public List<E_Apartados> ListarApartadosPorUsuario(int idUsuario)
        {
            try
            {
                return DA.ListarApartadosPorUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR ListarApartadosPorUsuario (NEGOCIOS)");

                Console.WriteLine("Error al buscar por criterio: ", ex.Message);
                return null;
            }
        }

        public List<E_Apartados> ListarDetalleApartado(int idUsuario)
        {
            try
            {
                return DA.ListarDetalleApartado(idUsuario);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR ListarDetalleApartado (NEGOCIOS)");

                Console.WriteLine("Error al buscar por criterio: ", ex.Message);
                return null;
            }
        }

        public bool AbonarApartado(int idApartado, int abono)
        {
            try
            {
                return DA.AbonarApartado(idApartado, abono);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR AbonarApartado (NEGOCIOS)");

                Console.WriteLine("Error al buscar por criterio: ", ex.Message);
                return false;
            }
        }
    }
}
