using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Pagos
    {
        #region Atributos
        private int idPago;
        private int idPersona;
        private DateTime fechaPago;
        private decimal montoPago;
        private string metodoPago;
        private string estadoPago;
        #endregion

        #region Constructores
        public E_Pagos()
        {
            IdPago = idPago;
            IdPersona = idPersona;
            FechaPago = fechaPago;
            MontoPago = montoPago;
            MetodoPago = metodoPago;
            EstadoPago = estadoPago;
        }

        public E_Pagos(int idPago, int idPersona, DateTime fechaPago, decimal montoPago, string metodoPago, string estadoPago)
        {
            IdPago = idPago;
            IdPersona = idPersona;
            FechaPago = fechaPago;
            MontoPago = montoPago;
            MetodoPago = metodoPago;
            EstadoPago = estadoPago;
        }
        #endregion

        #region Encapsulamientos
        public int IdPago { get => idPago; set => idPago = value; }
        public int IdPersona { get => idPersona; set => idPersona = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public decimal MontoPago { get => montoPago; set => montoPago = value; }
        public string MetodoPago { get => metodoPago; set => metodoPago = value; }
        public string EstadoPago { get => estadoPago; set => estadoPago = value; }
        #endregion

    }
}
