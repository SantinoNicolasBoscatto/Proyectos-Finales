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
        SqlConnection ConexionBaseDatos;
        SqlCommand ComandoDeBaseDatos;
        private SqlDataReader GuardadorDatos;
        public SqlDataReader Guardador { get { return GuardadorDatos; } }
        public FuncionesNegocio()
        {
            ConexionBaseDatos = new SqlConnection("server=.\\SQLEXPRESS01; database= TougeBD; integrated security= true");
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

        public void LecturaBase()
        {
            try
            {
                ComandoDeBaseDatos.Connection = ConexionBaseDatos;
                ConexionBaseDatos.Open();
                GuardadorDatos = ComandoDeBaseDatos.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }  
        }

        
    }
}
