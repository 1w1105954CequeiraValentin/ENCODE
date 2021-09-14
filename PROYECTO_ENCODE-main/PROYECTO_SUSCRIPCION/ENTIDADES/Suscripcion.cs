using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Suscripcion
    {
        private int idAsociacion;
        private int idSuscriptor;
        private DateTime fechaAlta;
        private DateTime? fechaFin;
        private string motivoFin;

        public Suscripcion()
        {

        }

        public Suscripcion(int idAsociacion, int idSuscriptor, DateTime fechaAlta, DateTime fechaFin, string motivoFin)
        {
            this.IdAsociacion = idAsociacion;
            this.IdSuscriptor = idSuscriptor;
            this.FechaAlta = fechaAlta;
            this.FechaFin = fechaFin;
            this.MotivoFin = motivoFin;
        }

        public int IdAsociacion { get => idAsociacion; set => idAsociacion = value; }
        public int IdSuscriptor { get => idSuscriptor; set => idSuscriptor = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public DateTime? FechaFin { get => fechaFin; set => fechaFin = value; }
        public string MotivoFin { get => motivoFin; set => motivoFin = value; }
    }
}
