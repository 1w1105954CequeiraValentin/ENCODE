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
    public class SuscriptorDAL
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-02KC2T3\SQLEXPRESS;Initial Catalog=Suscripciones;User ID=valen; Password=12345; Integrated Security = false");
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr = null;

        //INSERTAR SUSCRIPTOR
        public bool Insertar(Suscriptor suscriptor)
        {
            //Conexion conexion = new Conexion();
            try
            {
                string nombreSP = "sp_insertarSuscriptor";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSP;
                comando.Parameters.AddWithValue("@nombre", suscriptor.NombreSuscriptor);
                comando.Parameters.AddWithValue("@apellido", suscriptor.ApellidoSuscriptor);
                comando.Parameters.AddWithValue("@nroDocumento", suscriptor.NumeroDocumento);
                comando.Parameters.AddWithValue("@tipoDocumento", suscriptor.TipoDocumento);
                comando.Parameters.AddWithValue("@direccion", suscriptor.Direccion);
                comando.Parameters.AddWithValue("@telefono", suscriptor.NroTelefono);
                comando.Parameters.AddWithValue("@email", suscriptor.Email);
                comando.Parameters.AddWithValue("@nomUsuario", suscriptor.NombreUsuario);
                comando.Parameters.AddWithValue("@pass", suscriptor.Contrasena);
                //Conexion.transaction = Conexion.conexion.BeginTransaction();
                //Conexion.Comando.Transaction = Conexion.transaction;
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                //Conexion.CommitTransaction();
                return true;
            }
            catch (Exception)
            {
                con.Close();
                //Conexion.BeginTransaction();
                return false;
            }
        }
        //MODIFICAR SUSCRIPTOR
        public bool modificarSuscriptor(Suscriptor suscriptor1)
        {
                try
                {
                    string spModificarSuscriptor = "sp_modificarSuscriptor";
                    con.Open();
                    comando.Connection = con;
                    comando.CommandText = spModificarSuscriptor;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nombre", suscriptor1.NombreSuscriptor);
                    comando.Parameters.AddWithValue("@apellido", suscriptor1.ApellidoSuscriptor);
                    comando.Parameters.AddWithValue("@direccion", suscriptor1.Direccion);
                    comando.Parameters.AddWithValue("@telefono", suscriptor1.NroTelefono);
                    comando.Parameters.AddWithValue("@email", suscriptor1.Email);
                    comando.Parameters.AddWithValue("@pass", suscriptor1.Contrasena);
                    comando.Parameters.AddWithValue("@nroDocumento", suscriptor1.NumeroDocumento);
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                    return true;
                }
                catch (Exception)
                {

                    con.Close();
                    return false;
                }
        }
        
        //BUSCAR SUSCRIPTOR
        public Suscriptor buscarSuscriptor(string tipoDoc, string numeroDoc)
        {
            try
            {
                Suscriptor susc = new Suscriptor();
                con.Open();
                comando.Connection = con;
                comando.CommandText = "select * " +
                                      "from Suscriptor" +
                                      " where TipoDocumento = '"+ tipoDoc +"' and NumeroDocumento = '" + numeroDoc + "'";
                dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        susc.IdSuscriptor = dr.GetInt32(0);
                    }
                    if (!dr.IsDBNull(1))
                    {
                        susc.NombreSuscriptor = dr.GetString(1);
                    }
                    if (!dr.IsDBNull(2))
                    {
                        susc.ApellidoSuscriptor = dr.GetString(2);
                    }
                    if (!dr.IsDBNull(3))
                    {
                        susc.NumeroDocumento = dr.GetString(3);
                    }
                    if (!dr.IsDBNull(4))
                    {
                        susc.TipoDocumento = dr.GetString(4);
                    }
                    if (!dr.IsDBNull(5))
                    {
                        susc.Direccion = dr.GetString(5);
                    }
                    if (!dr.IsDBNull(6))
                    {
                        susc.NroTelefono = dr.GetString(6);
                    }
                    if (!dr.IsDBNull(7))
                    {
                        susc.Email = dr.GetString(7);
                    }
                    if (!dr.IsDBNull(8))
                    {
                        susc.NombreUsuario = dr.GetString(8);
                    }
                    if (!dr.IsDBNull(9))
                    {
                        susc.Contrasena = dr.GetString(9);
                    }
                    return susc;
                }
                return susc = null;
            }
            catch (Exception e)
            {

                return null;
                
            }
            finally
            {
                con.Close();
            }
        }
    }
}

