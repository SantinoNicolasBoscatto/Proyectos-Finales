using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio_Base_Datos
{
    public class UsuarioNegocio
    {
        public bool ValidadorLogin(Usuario user)
        {
            FuncionesNegocio negocio = new FuncionesNegocio();
            try
            {
                negocio.SQLQuerySP("ValidarLogin");
                negocio.SetearParametros("@email", user.Email);
                negocio.SetearParametros("@pass", user.Pass);
                negocio.LecturaBase();
                if (negocio.Guardador.Read())
                {
                    if (negocio.Guardador["Nombre"] != DBNull.Value)
                        user.Nombre = (string)negocio.Guardador["Nombre"];
                    if (negocio.Guardador["ImagenUrl"] != DBNull.Value)
                        user.ImagenPerfil = (string)negocio.Guardador["ImagenUrl"];
                    user.Id = (int)negocio.Guardador["Id"];
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
            FuncionesNegocio negocio = new FuncionesNegocio();
            try
            {
                negocio.SQLQuerySP("RegistrarUsuario");
                negocio.SetearParametros("@email", user.Email);
                negocio.SetearParametros("@pass", user.Pass);
                int? idret = negocio.EjecutarAccionContraBdOutPut();
                if (idret != null)
                return (int)idret;
                else return 0;
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
            FuncionesNegocio accesoCentral = new FuncionesNegocio();
            try
            {
                accesoCentral.SQLQuerySP("UpUsuario");
                accesoCentral.SetearParametros("@pass", user.Pass);
                accesoCentral.SetearParametros("@MyId", user.Id);
                accesoCentral.SetearParametros("@nombre", user.Nombre);
                accesoCentral.SetearParametros("@Email", user.Email);
                accesoCentral.SetearParametros("@urlImagenPerfil", imagen = user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);
                accesoCentral.EjecutarAccion();
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

        public Usuario DevolverUsuario(int id)
        {
            FuncionesNegocio negocio = new FuncionesNegocio();
            negocio.SQLQuery("select Email, Pass, ImagenUrl, Nombre from Usuario where Id = @Id");
            negocio.SetearParametros("@Id", id);
            negocio.LecturaBase();
            Usuario usuario = new Usuario();
            if (negocio.Guardador.Read())
            {
                if(negocio.Guardador["Nombre"] != DBNull.Value)
                    usuario.Nombre = (string)negocio.Guardador["Nombre"];
                usuario.Email = (string)negocio.Guardador["Email"];
                usuario.Pass = (string)negocio.Guardador["Pass"];
                if (negocio.Guardador["ImagenUrl"] != DBNull.Value)
                    usuario.ImagenPerfil = (string)negocio.Guardador["ImagenUrl"];
            }
            return usuario;
        }
    }
}

