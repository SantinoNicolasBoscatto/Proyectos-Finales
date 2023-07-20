using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseNegocio
{
    class ConexionDBCentralizada
    {
        public ConexionDBCentralizada()
        {
            ConexionCentral = new SqlConnection("server= .\\SQLEXPRESS01; database=POKEDEX_DB; integrated security=true");
            ComandoCentralSQL = new SqlCommand();
        }
        private SqlConnection ConexionCentral;
        private SqlCommand ComandoCentralSQL;
        private SqlDataReader guardadorCentralDeDatosSQL;
        public SqlDataReader GuardadorCentralDeDatosSQLAcceso { get { return guardadorCentralDeDatosSQL; } }

        public void SQLQuery(string inyeccion)
        {
            ComandoCentralSQL.CommandType = System.Data.CommandType.Text;
            ComandoCentralSQL.CommandText = inyeccion;
        }
        public void EjecutarLecturaDeTabla()
        {
            try
            {
                ComandoCentralSQL.Connection = ConexionCentral;
                ConexionCentral.Open();
                guardadorCentralDeDatosSQL = ComandoCentralSQL.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public void EjecutarInsertar()
        {
            try
            {
                ComandoCentralSQL.Connection = ConexionCentral;
                ConexionCentral.Open();
                ComandoCentralSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void SetearParametrosSQL(string NombreParametro, object objeto)
        {
            ComandoCentralSQL.Parameters.AddWithValue(NombreParametro, objeto);
        }
        public void CerrarConexion()
        {
            ConexionCentral.Close();
        }



    }
}
