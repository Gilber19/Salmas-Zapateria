using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Tallas
    {
        #region Atributos
        private int idTalla;
        private int idArticulo;
        private char talla;
        private int stock;
        #endregion


        #region Constructores
        public E_Tallas()
        {
            IdTalla = idTalla;
            IdArticulo = idArticulo;
            Talla = talla;
            Stock = stock;
        }

        public E_Tallas(int idTalla, int idArticulo, char talla, int stock)
        {
            IdTalla = idTalla;
            IdArticulo = idArticulo;
            Talla = talla;
            Stock = stock;
        }
        #endregion


        #region Encapsulamientos
        public int IdTalla { get => idTalla; set => idTalla = value; }
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public char Talla { get => talla; set => talla = value; }
        public int Stock { get => stock; set => stock = value; }
        #endregion


    }
}
