using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Apartados
    {
        #region Atributos
        private int idApartado;
        private int idPersona;
        private int idDetalleApartado;
        private decimal montoAbonado;
        private DateTime fechaApartado;
        private DateTime fechaVencimiento;
        private bool estado;
        #endregion

        #region Constructores
        public E_Apartados()
        {
            IdApartado = idApartado;
            IdPersona = idPersona;
            IdDetalleApartado = idDetalleApartado;
            MontoAbonado = montoAbonado;
            FechaApartado = fechaApartado;
            FechaVencimiento = fechaVencimiento;
            Estado = estado;
        }

        public E_Apartados(int idApartado, int idPersona, int idDetalleApartado, decimal montoAbonado, DateTime fechaApartado, DateTime fechaVencimiento, bool estado)
        {
            IdApartado = idApartado;
            IdPersona = idPersona;
            IdDetalleApartado = idDetalleApartado;
            MontoAbonado = montoAbonado;
            FechaApartado = fechaApartado;
            FechaVencimiento = fechaVencimiento;
            Estado = estado;
        }
        #endregion

        #region Encapsulamientos
        public int IdApartado { get => idApartado; set => idApartado = value; }
        public int IdPersona { get => idPersona; set => idPersona = value; }
        public int IdDetalleApartado { get => idDetalleApartado; set => idDetalleApartado = value; }
        public decimal MontoAbonado { get => montoAbonado; set => montoAbonado = value; }
        public DateTime FechaApartado { get => fechaApartado; set => fechaApartado = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public bool Estado { get => estado; set => estado = value; }
        #endregion



    }
}
