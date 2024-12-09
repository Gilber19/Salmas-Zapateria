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
        private string idTalla;
        private string stock; // Stock de cada talla XL (10), L (20), M (30), S (40), XS (50)
        private string imagenes; // Imágenes separadas por coma   
        private int genero;

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
            IdTalla = idTalla;
            Imagenes = imagenes;
            Genero = genero;
        }

        // Constructor con parámetros
        public E_Articulo(int idArticulo, int idCategoria, string codigoArticulo, string nombreArticulo, string descripcionArticulo, double precioVenta, string pstock, bool estado, int idImagen, int genero, string talla = "0", string subcategoria = "a", string idTalla = "idtalla1, idtalla2", string imagenes = "imagen1.png, imagen2.png")
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
            Imagenes = imagenes;
            Genero = genero;

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
        public string Stock { get => stock; set => stock = value; }
        public string IdTalla { get => idTalla; set => idTalla = value; }
        public string Imagenes { get => imagenes; set => imagenes = value; }
        public int Genero { get => genero; set => genero = value; }
        #endregion
    }
}
