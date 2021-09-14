using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class Conexion
    {

        
            /*public static SqlConnection conexion;
            public static SqlTransaction transaction;
          private static SqlCommand comando;
            private SqlDataReader dr = null;

            public SqlDataReader Dr { get => dr; set => dr = value; }
            public static SqlCommand Comando { get => comando; set => comando = value; }

            public Conexion()
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["connDb"].ConnectionString);
                Comando = new SqlCommand();

            }



            //TRANSACCIONES
            public static void BeginTransaction()
            {
                int TimeOut = 36;
                while (conexion != null)
                {
                    Thread.Sleep(250);
                    TimeOut--;

                    if (TimeOut == 0)
                    {
                        RollbackTransaction();
                    }
                }

            }

            //COMMIT

            public static void CommitTransaction()
            {
                transaction.Commit();
                transaction.Dispose();
                conexion.Dispose();
                conexion = null;
            }

            //ROLLBACK
            public static void RollbackTransaction()
            {
                transaction.Rollback();
                transaction.Dispose();
                conexion.Dispose();
                conexion = null;
            }

            public void Leer(string tabla)
            {
                AbrirConexion();
                Comando.CommandText = "select * from " + tabla;
                Dr = Comando.ExecuteReader();
            }


            public bool ValidarSuscripcion(string tipoDoc, int numDoc)
            {

                AbrirConexion();
                Comando.CommandText = "select * from Suscriptor s join Suscripcion su on s.IdSuscriptor = su.IdSuscriptor where s.TipoDocumento  = '" + tipoDoc + "' and s.NumeroDocumento = " + numDoc + "";
                Dr = Comando.ExecuteReader();

                if (Dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            public bool ValidarSuscriptor(string tipoDoc, int numDoc)
            {

                AbrirConexion();
                Comando.CommandText = "select * from Suscriptor where TipoDocumento  = '" + tipoDoc + "' and NumeroDocumento = " + numDoc + "";
                Dr = Comando.ExecuteReader();

                if (Dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            public static void AbrirConexion()
            {
                conexion.Open();
                comando.Connection = conexion;
            }


            public static void CerrarConexion()
            {
                conexion.Close();
            }*/
        }
    }

    /*public static SqlConnection conexion;

    private static SqlCommand comando;

    private SqlDataReader dr = null;

    public SqlDataReader Dr { get => dr; set => dr = value; }
    public static SqlCommand Comando { get => comando; set => comando = value; }

    //private static SqlTransaction transaccion;


    public Conexion()
    {
        conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
        Comando = new SqlCommand();
    }
    public static void conectar()
    {

        conexion.Open();
        comando.Connection = conexion;

    }
    public static void desconectar()
    {
        conexion.Close();
        //conexion.Dispose();
    }
    public void leerTabla(string nombreTabla)
    {
        conectar();
        comando.CommandText = $"select * from {nombreTabla}";
        dr = comando.ExecuteReader();
    }

    public DataTable recuperarTabla(string nombreTabla) // recupera los datos de la consulta
    {
        conectar();

        comando.CommandText = $"select * from {nombreTabla}";
        DataTable tabla = new DataTable();
        tabla.Load(comando.ExecuteReader());

        desconectar();
        return tabla;
    }
    public void actualizar(string consulta)// consultas que modifica registros
    {
        conectar();
        comando.CommandText = consulta;
        comando.ExecuteNonQuery();
        desconectar();
    }*/

