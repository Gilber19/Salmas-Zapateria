using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class D_LimitesCredito
    {
        #region Atributos
        private int idLimiteCredito;
        private int idPersona;
        private decimal limiteCredito;
        private DateTime fechaAsignacion;
        private string comentarios;
        #endregion

        #region Constructores
        public D_LimitesCredito()
        {
            IdLimiteCredito = idLimiteCredito;
            IdPersona = idPersona;
            LimiteCredito = limiteCredito;
            FechaAsignacion = fechaAsignacion;
            Comentarios = comentarios;
        }

        public D_LimitesCredito(int idLimiteCredito, int idPersona, decimal limiteCredito, DateTime fechaAsignacion, string comentarios)
        {
            IdLimiteCredito = idLimiteCredito;
            IdPersona = idPersona;
            LimiteCredito = limiteCredito;
            FechaAsignacion = fechaAsignacion;
            Comentarios = comentarios;
        }
        #endregion

        #region Encapsulamientos
        public int IdLimiteCredito { get => idLimiteCredito; set => idLimiteCredito = value; }
        public int IdPersona { get => idPersona; set => idPersona = value; }
        public decimal LimiteCredito { get => limiteCredito; set => limiteCredito = value; }
        public DateTime FechaAsignacion { get => fechaAsignacion; set => fechaAsignacion = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        #endregion

    }
}
