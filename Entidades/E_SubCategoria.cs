using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_SubCategoria
    {
        #region Atributos
        private int idSubCategoria;
        private int idCategoria;
        private string subCategoria;
        private string descripcion;
        #endregion

        #region Constructores
        public E_SubCategoria()
        {
            IdSubCategoria = 0;
            IdCategoria = 0;
            SubCategoria = string.Empty;
            Descripcion = string.Empty;
        }

        public E_SubCategoria(int idCategoria,int idSubCategoria, string subCategoria, string descripcion)
        {
            IdSubCategoria = idSubCategoria;
            IdCategoria = idCategoria;
            SubCategoria = subCategoria;
            Descripcion = descripcion;
        }

        public E_SubCategoria(int idCategoria)
        {
            IdSubCategoria = 0;
            IdCategoria = idCategoria;
            SubCategoria = string.Empty;
            Descripcion = string.Empty;
        }
        #endregion

        #region Encapsulamientos
        public int IdSubCategoria { get => idSubCategoria; set => idSubCategoria = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string SubCategoria { get => subCategoria; set => subCategoria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        #endregion

    }
}
