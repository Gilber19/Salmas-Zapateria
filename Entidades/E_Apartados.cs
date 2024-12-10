using System;


namespace Entidades
{
    public class E_Apartados
    {
        #region Atributos
        private int idApartado;
        private int idUsuario;
        private int idVenta;
        private decimal montoAbonado;
        private DateTime fechaApartado;
        private DateTime fechaVencimiento;
        private string estado;
        private string imagenesArticulo;
        #endregion

        #region Constructores
        public E_Apartados()
        {
            IdApartado = idApartado;
            IdUsuario = idUsuario;
            MontoAbonado = montoAbonado;
            FechaApartado = fechaApartado;
            FechaVencimiento = fechaVencimiento;
            Estado = estado;
            ImagenesArticulo = imagenesArticulo;
            IdVenta = idVenta;
        }

        public E_Apartados(int idApartado, int idUsuario, decimal montoAbonado, DateTime fechaApartado, DateTime fechaVencimiento, string estado, string imagenesArticulo, int idVenta)
        {
            IdApartado = idApartado;
            IdUsuario = idUsuario;
            MontoAbonado = montoAbonado;
            FechaApartado = fechaApartado;
            FechaVencimiento = fechaVencimiento;
            Estado = estado;
            ImagenesArticulo = imagenesArticulo;
            IdVenta = idVenta;
        }
        #endregion

        #region Encapsulamientos
        public int IdApartado { get => idApartado; set => idApartado = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public decimal MontoAbonado { get => montoAbonado; set => montoAbonado = value; }
        public DateTime FechaApartado { get => fechaApartado; set => fechaApartado = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public string Estado { get => estado; set => estado = value; }
        public string ImagenesArticulo { get => imagenesArticulo; set => imagenesArticulo = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }
        #endregion



    }
}
