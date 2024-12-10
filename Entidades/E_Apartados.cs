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
        private double totalCosto;
        private double totalAbonado;
        private double adeudo;
        #endregion

        #region Constructores
        public E_Apartados()
        {
            IdApartado = 0;
            IdUsuario = 0;
            MontoAbonado = 0;
            FechaApartado = DateTime.Now;
            FechaVencimiento = DateTime.Now;
            Estado = "";
            ImagenesArticulo = "";
            IdVenta = 0;
            TotalCosto = 0;
            TotalAbonado = 0;
            Adeudo = 0;

        }

        public E_Apartados(int idApartado, int idUsuario, decimal montoAbonado, DateTime fechaApartado, DateTime fechaVencimiento, string estado, string imagenesArticulo, int idVenta, double totalCosto, double totalAbonado, double adeudo)
        {
            IdApartado = idApartado;
            IdUsuario = idUsuario;
            MontoAbonado = montoAbonado;
            FechaApartado = fechaApartado;
            FechaVencimiento = fechaVencimiento;
            Estado = estado;
            ImagenesArticulo = imagenesArticulo;
            IdVenta = idVenta;
            TotalCosto = totalCosto;
            TotalAbonado = totalAbonado;
            Adeudo = adeudo;
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
        public double TotalCosto { get => totalCosto; set => totalCosto = value; }
        public double TotalAbonado { get => totalAbonado; set => totalAbonado = value; }
        public double Adeudo { get => adeudo; set => adeudo = value; }
        #endregion



    }
}
