using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DAL;

namespace BLL
{
    public class SuscripcionBLL
    {
        SuscripcionDAL suscripcionDAL = new SuscripcionDAL();
        public bool insertarSuscripcion(Suscripcion suscripcion)
        { 
           return suscripcionDAL.insertarSuscripcion(suscripcion);
        }

        public bool validarSuscripcion(string tipoDoc, string nroDoc)
        {
            return suscripcionDAL.validarSuscripcion(tipoDoc, nroDoc);
        }

        public List<Suscripcion> lstSuscripcion()
        {
            return suscripcionDAL.lstSuscripcion();
        }
    }
}
