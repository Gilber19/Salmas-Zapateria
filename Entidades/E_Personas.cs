using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Personas
    {
        #region Atributos
        private int idPersona;
        private string nombre;
        private string direccion;
        private string telefono;
        private bool estado;
        private int limiteCredito;
        private int limiteDisponible;
        #endregion

        #region Constructores
        public E_Personas()
        {
            IdPersona = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Estado = true;
            LimiteCredito = 0;
            limiteDisponible = 0;
        }

        public E_Personas(int idPersona, string nombre, string direccion, string telefono, bool estado, int limiteCredito, int limiteDisponible)
        {
            IdPersona = idPersona;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Estado = estado;
            LimiteCredito = limiteCredito;
            LimiteDisponible = limiteDisponible;

        }
        #endregion

        #region Encapsulamientos
        public int IdPersona { get => idPersona; set => idPersona = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public bool Estado { get => estado; set => estado = value; }
        public int LimiteCredito { get => limiteCredito; set => limiteCredito = value; }
        public int LimiteDisponible { get => limiteDisponible; set => limiteDisponible = value; }
        #endregion
    }
}
