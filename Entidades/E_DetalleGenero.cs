using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class E_DetalleGenero
    {
        #region Atributos
        private int idDetalleGenero;
        private int idGenero;
        private int idArticulo;
        #endregion

        #region Constructores
        public E_DetalleGenero(int idDetalleGenero, int idGenero, int idArticulo)
        {
            IdDetalleGenero = idDetalleGenero;
            IdGenero = idGenero;
            IdArticulo = idArticulo;
        }

        public E_DetalleGenero()
        {
            IdDetalleGenero = idDetalleGenero;
            IdGenero = idGenero;
            IdArticulo = idArticulo;
        }
        #endregion

        #region Encapsulamientos
        public int IdDetalleGenero { get => idDetalleGenero; set => idDetalleGenero = value; }
        public int IdGenero { get => idGenero; set => idGenero = value; }
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }

        #endregion
    }
}
