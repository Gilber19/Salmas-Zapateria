using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using Datos;

namespace Negocios
{
    public class N_Ventas
    {
        readonly D_Ventas DV = new D_Ventas();

        public List<E_FacturaVentas> ListarVentas()
        {
            return DV.ListarVentas();
        }

        public List<E_Factura> BuscarFactura(string criterio)
        {
            return DV.BuscarFactura(criterio);
        }

        public int ProcesarVenta(E_Venta venta, List<E_DetalleVentas> detalles)
        {
            try
            {
                decimal total = 0;
                foreach (var detalle in detalles)
                {
                    // Obtener el precio del artículo desde la capa de datos
                    decimal precio = DV.ObtenerPrecioArticulo(detalle.IdArticulo);
                    detalle.PrecioVenta = precio;
                    total += precio * detalle.Cantidad;
                }

                venta.Total = total;

                int idVenta = DV.InsertarVenta(venta);

                // Iterar sobre los detalles para insertarlos con el ID de la venta
                foreach (var detalle in detalles)
                {
                    detalle.IdVenta = idVenta;
                    DV.InsertarDetalleVenta(detalle);
                }

                return idVenta; // Retornar el ID de la venta creada
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la venta: " + ex.Message);
            }
        }

        // Método para obtener el precio de un artículo (passthrough a la capa de datos)
        public decimal ObtenerPrecioArticulo(int idArticulo)
        {
            try
            {
                return DV.ObtenerPrecioArticulo(idArticulo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el precio del artículo: " + ex.Message);
            }
        }

        //Posible implementacion
        //public List<E_DetalleVenta> ListarDetallesVenta(int idVenta)
        //{
        //    try
        //    {
        //        return DV.ListarDetallesVenta(idVenta);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al listar los detalles de la venta: " + ex.Message);
        //    }
        //}
    }




    public class NumeroATexto
    {
        private static string[] unidades = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
        private static string[] decenas = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
        private static string[] especiales = { "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
        private static string[] centenas = { "", "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

        public static string Convertir(double numero)
        {
            if (numero == 0)
                return "cero";

            if (numero < 0)
                return "menos " + Convertir(Math.Abs(numero));

            int entero = (int)numero;
            int decimales = (int)((numero - entero) * 100);
            string resultado = ConvertirEntero(entero) + " pesos";

            if (decimales > 0)
            {
                resultado += ConvertirEntero(decimales) + "/100 ";
            }
            else
            {
                resultado += " 00/100";
            }

            return resultado;
        }

        private static string ConvertirEntero(int numero)
        {
            if (numero == 0)
                return "";

            if (numero < 10)
                return unidades[numero];

            if (numero < 20)
                return especiales[numero - 10];

            if (numero < 100)
                return decenas[numero / 10] + (numero % 10 > 0 ? " y " + unidades[numero % 10] : "");

            if (numero < 1000)
                return centenas[numero / 100] + (numero % 100 > 0 ? " " + ConvertirEntero(numero % 100) : "");

            if (numero < 1000000)
                return (numero / 1000 == 1 ? "mil" : ConvertirEntero(numero / 1000) + " mil") + (numero % 1000 > 0 ? " " + ConvertirEntero(numero % 1000) : "");

            if (numero < 1000000000)
                return ConvertirEntero(numero / 1000000) + " millones" + (numero % 1000000 > 0 ? " " + ConvertirEntero(numero % 1000000) : "");

            return ConvertirEntero(numero / 1000000000) + " mil millones" + (numero % 1000000000 > 0 ? " " + ConvertirEntero(numero % 1000000000) : "");
        }
    }
}
