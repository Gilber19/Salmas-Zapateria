namespace Entidades
{
  public class E_Categoria
  {
    #region Atributos    
    private int idCategoria;
    private string nombreCategoria;
    private string descripcionCategoria;
    private bool estado;
    #endregion

    #region Constructores
    // Constructor que inicializa una instancia de la clase
    public E_Categoria()
    {
      IdCategoria = 0;
      NombreCategoria = string.Empty;
      DescripcionCategoria = string.Empty;
      Estado = true;
    }

    // Constructor con parámetros
    public E_Categoria(int idCategoria, string nombreCategoria, string descripcionCategoria, bool estado)
    {
      IdCategoria = idCategoria;
      NombreCategoria = nombreCategoria;
      DescripcionCategoria = descripcionCategoria;
      Estado = estado;
    }
    #endregion

    #region Encapsulamientos
    public int IdCategoria { get => idCategoria; set => idCategoria = value; }    
    public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
    public string DescripcionCategoria { get => descripcionCategoria; set => descripcionCategoria = value; }
    public bool Estado { get => estado; set => estado = value; }
    #endregion
  }
}
