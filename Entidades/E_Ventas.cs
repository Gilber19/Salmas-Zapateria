﻿using System;
using System.Collections.Generic;

namespace Entidades
{
    public class E_Venta
    {
        #region Atributos
        private int idArticulo;
        private string codigoArticulo;
        private string nombreArticulo;
        private double precioVenta;
        private double descuento;
        private int cantidad;
        private double importe;
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public string TipoVenta { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha{ get; set; }
        public string IdTipoVenta { get; set; }
        public string TipoComprobante { get; set; }
        public string SerieComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public DateTime FechaHora { get; set; }
        public double Impuesto{ get; set; }
        public bool Estado { get; set; }

        #endregion

        #region Constructores
        public E_Venta()
        {
            idArticulo = 0;
            codigoArticulo = string.Empty;
            nombreArticulo = string.Empty;
            precioVenta = 0;
            cantidad = 0;
            importe = 0;
            descuento = 0;
            IdVenta = 0;
            IdUsuario = 0;
            TipoVenta = string.Empty;
            Total = 0;
            Fecha = DateTime.Today;
            IdTipoVenta = string.Empty;
            TipoComprobante = string.Empty;
            SerieComprobante = string.Empty;
            NumeroComprobante = string.Empty;
            FechaHora = DateTime.Today;
            Impuesto = 0;
            Estado = true;

        }

        public E_Venta(
            int idArticulo,
            string codigoArticulo,
            string nombreArticulo,
            double precioVenta,
            int cantidad,
            double importe,
            double descuento,
            int idVenta,
            int idUsuario,
            string tipoVenta,
            decimal total,
            DateTime fecha,
            string idTipoVenta,
            string tipoComprobante,
            string serieComprobante,
            string numeroComprobante,
            DateTime fechaHora,
            double impuesto,
            bool estado
        )
        {
            this.idArticulo = idArticulo;
            this.codigoArticulo = codigoArticulo;
            this.nombreArticulo = nombreArticulo;
            this.precioVenta = precioVenta;
            this.cantidad = cantidad;
            this.importe = importe;
            this.descuento = descuento;
            this.IdVenta = idVenta;
            this.IdUsuario = idUsuario;
            this.TipoVenta = tipoVenta;
            this.Total = total;
            this.Fecha = fecha;
            this.IdTipoVenta = idTipoVenta;
            this.TipoComprobante = tipoComprobante;
            this.SerieComprobante = serieComprobante;
            this.NumeroComprobante = numeroComprobante;
            this.FechaHora = fechaHora;
            this.Impuesto = impuesto;
            this.Estado = estado;
        }

        #endregion

        #region Encapsulamiento
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string CodigoArticulo { get => codigoArticulo; set => codigoArticulo = value; }
        public string NombreArticulo { get => nombreArticulo; set => nombreArticulo = value; }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Importe { get => importe; set => importe = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        #endregion
    }

    public class E_FacturaVentas
    {
        #region Atributos
        private int idVenta;
        private int idPersona;
        private int idUsuario;
        private string tipoComprobante;
        private string serieComprobante;
        private string numeroComprobante;
        private DateTime fechaHora;
        private double impuestoVenta;
        private double total;
        private int totalArticulos;
        private List<E_Venta> listaArticulos;
        private int idArticulo;
        private string imagenes;
        #endregion

        #region Constructores
    public E_FacturaVentas(int idVenta, int idPersona, int idUsuario, string tipoComprobante, string serieComprobante, string numeroComprobante, DateTime fechaHora, double impuestoVenta, double total, int totalArticulos, List<E_Venta> listaArticulos, int idArticulo, string imagenes)
        {
            this.idVenta = idVenta;
            this.idPersona = idPersona;
            this.idUsuario = idUsuario;
            this.tipoComprobante = tipoComprobante;
            this.serieComprobante = serieComprobante;
            this.numeroComprobante = numeroComprobante;
            this.fechaHora = fechaHora;
            this.impuestoVenta = impuestoVenta;
            this.total = total;
            this.totalArticulos = totalArticulos;
            this.listaArticulos = listaArticulos;
            this.idArticulo = idArticulo;
            this.imagenes = imagenes;
        }
        public E_FacturaVentas()
        {
            idVenta = 0;
            idPersona = 0;
            idUsuario = 0;
            tipoComprobante = string.Empty;
            serieComprobante = string.Empty;
            numeroComprobante = string.Empty;
            fechaHora = DateTime.Today;
            impuestoVenta = 0;
            total = 0;
            totalArticulos = 0;
            listaArticulos = new List<E_Venta>();
            idArticulo = 0;
            imagenes = string.Empty;
        }
        #endregion

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public int IdPersona { get => idPersona; set => idPersona = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string TipoComprobante { get => tipoComprobante; set => tipoComprobante = value; }
        public string SerieComprobante { get => serieComprobante; set => serieComprobante = value; }
        public string NumeroComprobante { get => numeroComprobante; set => numeroComprobante = value; }
        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
        public double ImpuestoVenta { get => impuestoVenta; set => impuestoVenta = value; }
        public double Total { get => total; set => total = value; }
        public int TotalArticulos { get => totalArticulos; set => totalArticulos = value; }
        public List<E_Venta> ListaArticulos { get => listaArticulos; set => listaArticulos = value; }
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string Imagenes { get => imagenes; set => imagenes = value; }
    }

    public class E_Factura
    {
        public int IdVenta { get; set; }
        public string Cliente { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string TipoComprobante { get; set; }
        public string SerieComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public double TotalVenta { get; set; }
        public double ImpuestoVenta { get; set; }
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public int Cantidad { get; set; }
        public double PrecioVenta { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }

    }
}
