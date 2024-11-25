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
    private int stock;
    private bool estado;
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
      Stock = stock;
      Estado = estado;
    }

    // Constructor con parámetros
    public E_Articulo(int idArticulo, int idCategoria, string codigoArticulo, string nombreArticulo, string descripcionArticulo, double precioVenta, int stock, bool estado)
    {
      IdArticulo = idArticulo;
      IdCategoria = idCategoria;
      CodigoArticulo = codigoArticulo;
      NombreArticulo = nombreArticulo;
      DescripcionArticulo = descripcionArticulo;
      PrecioVenta = precioVenta;
      Stock = stock;
      Estado = estado;
    }
    #endregion

    #region Encapsulamientos
    public int IdArticulo { get => idArticulo; set => idArticulo = value; }
    public int IdCategoria { get => idCategoria; set => idCategoria = value; }
    public string CodigoArticulo { get => codigoArticulo; set => codigoArticulo = value; }
    public string NombreArticulo { get => nombreArticulo; set => nombreArticulo = value; }
    public string DescripcionArticulo { get => descripcionArticulo; set => descripcionArticulo = value; }
    public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
    public int Stock { get => stock; set => stock = value; }
    public bool Estado { get => estado; set => estado = value; }
    #endregion
  }
}
