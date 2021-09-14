using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DAL;

namespace BLL
{
    public class SuscriptorBLL
    {
        SuscriptorDAL suscriptorDAL = new SuscriptorDAL();

        public bool insertarSuscriptor(Suscriptor suscriptor)
        {
            return suscriptorDAL.Insertar(suscriptor);
        }
        public bool modificarSuscriptor(Suscriptor suscriptor)
        {
            return suscriptorDAL.modificarSuscriptor(suscriptor);
        }
        public Suscriptor buscarSuscriptor(string tipoDoc, string numeroDoc)
        {
            return suscriptorDAL.buscarSuscriptor(tipoDoc,numeroDoc);
        }
    }
}
