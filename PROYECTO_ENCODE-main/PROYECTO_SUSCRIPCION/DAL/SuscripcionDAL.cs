using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DAL
{
    public class SuscripcionDAL
    {
        SqlConnection cone = new SqlConnection(@"Data Source=DESKTOP-02KC2T3\SQLEXPRESS;Initial Catalog=Suscripciones;User ID=valen; Password=12345; Integrated Security = false");
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr = null;

        //INSERTAR SUSCRIPCION
        public bool insertarSuscripcion(Suscripcion suscripcion)
        {
            try
            {
                string spInsertar = "sp_insertarSuscripcion";
                cone.Open();
                comando.Connection = cone;
                comando.CommandText = spInsertar;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idSuscriptor", suscripcion.IdSuscriptor);
                comando.Parameters.AddWithValue("@fechaAlta", DateTime.Now);
                comando.Parameters.AddWithValue("@fechaFin", suscripcion.FechaFin);
                comando.Parameters.AddWithValue("@motivoFin", suscripcion.MotivoFin);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                return true;

            }
            catch (Exception e)
            {
                cone.Close();
                return false;
            }
        }


        //COMENTADO POR QUE VAMOS A PROBAR LA LISTA DE ABAJO
        public bool validarSuscripcion(string tipoDoc, string nroDoc)
        {
            try
            {
                string spValidar = "sp_validarSuscripcion";
                cone.Open();
                comando.Connection = cone;
                comando.CommandText = spValidar;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoDoc", tipoDoc);
                comando.Parameters.AddWithValue("@nroDoc", nroDoc);
                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                cone.Close();
                throw new Exception(e.Message);

            }

        }

        public List<Suscripcion> lstSuscripcion()
        {
            List<Suscripcion> lista = new List<Suscripcion>();
            Suscripcion s = null;
            try
            {
                cone.Open();
                comando.Connection = cone;
                comando.CommandText = "select * from Suscripcion";
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    s = new Suscripcion();
                    if (!dr.IsDBNull(0))
                    {
                        s.IdAsociacion = dr.GetInt32(0);
                    }
                    if (!dr.IsDBNull(1))
                    {
                        s.IdSuscriptor = dr.GetInt32(1);
                    }
                    if (!dr.IsDBNull(2))
                    {
                        s.FechaAlta = dr.GetDateTime(2);
                    }
                    if (!dr.IsDBNull(3))
                    {
                        s.FechaFin = dr.GetDateTime(3);
                    }
                    if (!dr.IsDBNull(4))
                    {
                        s.MotivoFin = dr.GetString(4);
                    }
                    lista.Add(s);
                }
                return lista;
            }
            catch (Exception e)
            {
                cone.Close();
                throw new Exception(e.Message);

            }

        }
    }
}
