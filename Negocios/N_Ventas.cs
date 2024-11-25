using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;

namespace Negocios
{
  public class N_Ventas
  {
    readonly D_Ventas DV = new D_Ventas();

    public List<E_Factura> BuscarFactura(string criterio)
    {
      return DV.BuscarFactura(criterio);
    }
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
