using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_DetalleApartado
    {
        #region Atributos
        private int idDetalleApartado;
        private int idApartado;
        private int idArticulo;
        private int cantidad;
        private decimal precio;
        private decimal descuento;
        #endregion

        #region Constructores
        public E_DetalleApartado()
        {
            IdDetalleApartado = idDetalleApartado;
            IdApartado = idApartado;
            IdArticulo = idArticulo;
            Cantidad = cantidad;
            Precio = precio;
            Descuento = descuento;
        }

        public E_DetalleApartado(int idDetalleApartado, int idApartado, int idArticulo, int cantidad, decimal precio, decimal descuento)
        {
            IdDetalleApartado = idDetalleApartado;
            IdApartado = idApartado;
            IdArticulo = idArticulo;
            Cantidad = cantidad;
            Precio = precio;
            Descuento = descuento;
        }
        #endregion

        #region Encapsulamientos
        public int IdDetalleApartado { get => idDetalleApartado; set => idDetalleApartado = value; }
        public int IdApartado { get => idApartado; set => idApartado = value; }
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        #endregion



    }
}
