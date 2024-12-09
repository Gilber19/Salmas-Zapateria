using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class E_Genero
    {
        #region Atributos
        private int idGenero;
        private string genero;
        #endregion

        #region Constructores
        public E_Genero(int idGenero, string genero)
        {
            IdGenero = idGenero;
            Genero = genero;
        }

        public E_Genero()
        {
           IdGenero = idGenero;
           Genero = genero;
        }
        #endregion

        #region Encapsulamientos
        public int IdGenero { get => idGenero; set => idGenero = value; }
        public string Genero { get => genero; set => genero = value; }
        #endregion






    }
}
