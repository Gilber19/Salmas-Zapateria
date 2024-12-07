namespace Entidades
{
    public class E_Articulo
    {
        #region Atributos
        // Atributos privados
        private int idArticulo;
        private int idCategoria;
        private string codigoArticulo;
        private string nombreArticulo;
        private string descripcionArticulo;
        private double precioVenta;
        private bool estado;
        private int idImagen;
        private string talla;
        private string subCategoria;
        private int stock;
        private int idTalla;

        #endregion

        #region Constructores
        // Constructor por defecto
        public E_Articulo()
        {
            IdArticulo = idArticulo;
            IdCategoria = idCategoria;
            CodigoArticulo = codigoArticulo;
            NombreArticulo = nombreArticulo;
            DescripcionArticulo = descripcionArticulo;
            PrecioVenta = precioVenta;
            Estado = estado;
            IdImagen = idImagen;
            Stock = stock;
            Talla = talla;
            SubCategoria = subCategoria;
            idTalla = idTalla;
        }

        // Constructor con parámetros
        public E_Articulo(int idArticulo, int idCategoria, string codigoArticulo, string nombreArticulo, string descripcionArticulo, double precioVenta, int stock, bool estado, int idImagen, int pstock = 0, string talla = "0", string subcategoria = "a", int idTalla = 1)
        {
            IdArticulo = idArticulo;
            IdCategoria = idCategoria;
            CodigoArticulo = codigoArticulo;
            NombreArticulo = nombreArticulo;
            DescripcionArticulo = descripcionArticulo;
            PrecioVenta = precioVenta;
            Estado = estado;
            IdImagen = idImagen;
            Stock = pstock;
            Talla = talla;
            SubCategoria = subcategoria;
            IdTalla = idTalla;

        }
        #endregion

        #region Encapsulamientos
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string CodigoArticulo { get => codigoArticulo; set => codigoArticulo = value; }
        public string NombreArticulo { get => nombreArticulo; set => nombreArticulo = value; }
        public string DescripcionArticulo { get => descripcionArticulo; set => descripcionArticulo = value; }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public bool Estado { get => estado; set => estado = value; }
        public int IdImagen { get => idImagen; set => idImagen = value; }
        public string Talla { get => talla; set => talla = value; }
        public string SubCategoria { get => subCategoria; set => subCategoria = value; }
        public int Stock { get => stock; set => stock = value; }
        public int IdTalla { get => idTalla; set => idTalla = value; }
        #endregion
    }
}
