using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class E_Imagenes
    {
        #region Atributos
        private int idImagen;
        private int idArticulo;
        private string imagen;
        private string descripcion;
        #endregion

        #region Constructores
        public E_Imagenes()
        {
            IdImagen = idImagen;
            IdArticulo = idArticulo;
            Imagen = imagen;
            Descripcion = descripcion;
        }

        public E_Imagenes(int idImagen, int idArticulo, string imagen, string descripcion)
        {
            IdImagen = idImagen;
            IdArticulo = idArticulo;
            Imagen = imagen;
            Descripcion = descripcion;
        }
        #endregion

        #region Encapsulamientos
        public int IdImagen { get => idImagen; set => idImagen = value; }
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        #endregion

    }
}
