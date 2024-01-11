using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDominio;

namespace NegocioConDB
{
    public class UsuariosNegocio
    {
        public bool ValidadorLogin(Usuario user)
        {
            AccesoCentralBD negocio = new AccesoCentralBD();
            try
            {
                negocio.SQLqueryStoreProcedure("ValidarLogin");
                negocio.SetearParametros("@email", user.Email);
                negocio.SetearParametros("@pass", user.Pass);
                negocio.EjecutarLecturaBD();
                if (negocio.Guardador.Read())
                {
                    if (negocio.Guardador["nombre"] != DBNull.Value)
                        user.Nombre = (string)negocio.Guardador["nombre"];
                    if (negocio.Guardador["apellido"] != DBNull.Value)
                        user.Apellido = (string)negocio.Guardador["apellido"];
                    user.Id = (int)negocio.Guardador["Id"];
                    if (negocio.Guardador["urlImagenPerfil"] != DBNull.Value)
                        user.ImagenPerfil = (string)negocio.Guardador["urlImagenPerfil"];
                    user.Permiso = (bool)negocio.Guardador["admin"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                negocio.CerrarConexion();
            }
        }

        public int RegistroUsuario(Usuario user)
        {
            AccesoCentralBD negocio = new AccesoCentralBD();
            try
            {
                negocio.SQLqueryStoreProcedure("RegistrarUsuario");
                negocio.SetearParametros("@email", user.Email);
                negocio.SetearParametros("@pass", user.Pass);
                return negocio.EjecutarAccionContraBdOutPut();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                negocio.CerrarConexion();
            }
        }

        public void UpdateUsuario(Usuario user)
        {
            object imagen;
            AccesoCentralBD accesoCentral = new AccesoCentralBD();
            try
            {
                accesoCentral.SQLqueryStoreProcedure("UpUsuario");
                accesoCentral.SetearParametros("@pass", user.Pass);
                accesoCentral.SetearParametros("@MyId", user.Id);
                accesoCentral.SetearParametros("@nombre", user.Nombre);
                accesoCentral.SetearParametros("@apellido", user.Apellido);
                accesoCentral.SetearParametros("@urlImagenPerfil", imagen = user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);
                accesoCentral.EjecutarAccionContraBD();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoCentral.CerrarConexion();
            }
        }
    }
}
