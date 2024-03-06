using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_Base_Datos
{
    public class NegocioPagina
    {
        public FuncionesNegocio Negocio { get;}
        public NegocioPagina(FuncionesNegocio negocio)
        {
            Negocio = negocio;
        }

        public bool ComprarAuto(int idAutoCompra)
        {
            try
            {
                int idAutoViejo = 0;
                Negocio.SQLQuery("select AutoID from Autos where Dueno = 1");
                Negocio.LecturaBase();
                Negocio.Guardador.Read();
                idAutoViejo = (int)Negocio.Guardador["AutoID"];
                Negocio.Guardador.Close();
                Negocio.SQLQuery("Select dbo.ValidacionCompra(@IdAutoCompra) as result");
                Negocio.SetearParametros("@IdAutoCompra", idAutoCompra);
                Negocio.LecturaBase();
                Negocio.Guardador.Read(); 
                if ((bool)Negocio.Guardador["result"])
                {
                    Negocio.SQLQuerySP("DescontarSaldo");
                    Negocio.EjecutarAccion();
                    Negocio.SQLQuerySP("CambioAuto");
                    Negocio.SetearParametros("@IdViejo", idAutoViejo);
                    Negocio.SetearParametros("@IdNuevo", idAutoCompra);
                    Negocio.EjecutarAccion();
                    Negocio.Guardador.Close();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
