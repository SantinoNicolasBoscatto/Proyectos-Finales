using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NegocioConDB
{
    public class AccesoCentralBD
    {
        //Creo Las variables para conectarme a la BD
        SqlCommand comandoSQL;
        SqlConnection conexionBD;
        SqlDataReader guardadorDeDatos;
        //Esta propiedad tendra los valores del objeto guardadorDeDatos pero sera de publico acceso.
        public SqlDataReader Guardador
        {
            get { return guardadorDeDatos; }
        }

        //Cuando Llame a esta clase automaticamente se crea el comando y la conexion a la base.
        public AccesoCentralBD()
        {
            comandoSQL = new SqlCommand();
            conexionBD = new SqlConnection("server=.\\SQLEXPRESS01; database= CATALOGO_DB; integrated security= true");
        }

        //Con esta funcion seteamos el comando a Texto y la pasamos la linea de comando a ejecutar por parametro.
        public void SQLquery(string inyeccion)
        {
            try
            {
                comandoSQL.CommandType = System.Data.CommandType.Text;
                comandoSQL.CommandText = inyeccion;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Conectamos el comando a la base, abrimos conexion y guardamos los datos de la ejecucion de la inyeccion en el
        //SqlDataReader
        public void EjecutarLecturaBD()
        {
            try
            {
                comandoSQL.Connection = conexionBD;
                conexionBD.Open();
                guardadorDeDatos = comandoSQL.ExecuteReader();
            }
            catch (Exception ex)
            { throw ex; }
        }

        //Similar al anterior con la diferencia de que no ejecutamos una accion de lectura, sino de modificacion contra la BD
        public void EjecutarAccionContraBD()
        {
            try
            {
                comandoSQL.Connection = conexionBD;
                conexionBD.Open();
                comandoSQL.ExecuteNonQuery();
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
        //Cierra COnexion con la BD
        public void CerrarConexion()
        {
            try
            {
                conexionBD.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        //Permitira setear los parametros de distintas variables.
        public void SetearParametros(string Parametro, object Objeto)
        {
            comandoSQL.Parameters.AddWithValue(Parametro, Objeto);
        }
    }
}
