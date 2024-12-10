using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_DetalleVentas
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdArticulo { get; set; }
        public int IdTalla { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Descuento { get; set; }
    }
}
