using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio_Base_Datos
{
    public class FuncionesNegocio
    {
        readonly  SqlConnection ConexionBaseDatos;
        readonly SqlCommand ComandoDeBaseDatos;
        private SqlDataReader GuardadorDatos;
        public SqlDataReader Guardador { get { return GuardadorDatos; } }
        public FuncionesNegocio()
        {
            ConexionBaseDatos = new SqlConnection("server=.\\; database= Touge_DB; User Id=Touge;Password=TougeAdmin;");
            ComandoDeBaseDatos = new SqlCommand();
        }

        public void SQLQuery(string inyeccion)
        {
            try
            {
                ComandoDeBaseDatos.CommandType = System.Data.CommandType.Text;
                ComandoDeBaseDatos.CommandText = inyeccion;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int? EjecutarAccionContraBdOutPut()
        {
            try
            {
                ComandoDeBaseDatos.Connection = ConexionBaseDatos;
                ConexionBaseDatos.Open();
                int? hola = (int?)ComandoDeBaseDatos.ExecuteScalar();
                return hola;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public void SQLQuerySP(string inyeccion)
        {
            try
            {
                ComandoDeBaseDatos.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoDeBaseDatos.CommandText = inyeccion;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void EjecutarAccion()
        {
            try
            {
                ComandoDeBaseDatos.Connection = ConexionBaseDatos;
                if (ConexionBaseDatos.State == System.Data.ConnectionState.Closed)
                {
                    ConexionBaseDatos.Open();
                }
                ComandoDeBaseDatos.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ConexionBaseDatos.Close();
            }
        }
        public void SetearParametros(string Nombre, object valor)
        {
            ComandoDeBaseDatos.Parameters.AddWithValue(Nombre, valor);
        }
        public void LecturaBase()
        {
            try
            {
                ComandoDeBaseDatos.Connection = ConexionBaseDatos;
                if (ConexionBaseDatos.State == System.Data.ConnectionState.Closed)
                {
                    ConexionBaseDatos.Open();
                }
                GuardadorDatos = ComandoDeBaseDatos.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            } 
        }
        public void CerrarConexion()
        {
            try
            {
                ConexionBaseDatos.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
