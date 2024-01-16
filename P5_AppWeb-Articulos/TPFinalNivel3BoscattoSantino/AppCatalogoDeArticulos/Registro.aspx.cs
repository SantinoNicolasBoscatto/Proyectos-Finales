using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClasesStatic;
using ModeloDeDominio;
using NegocioConDB;

namespace AppCatalogoDeArticulos
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.Registrarse.UniqueID;
        }

        protected void Registrarse_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuariosNegocio negocio = new UsuariosNegocio();
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                user.Email = EmailBox.Text;
                user.Pass = PassBox.Text;
                user.Id = negocio.RegistroUsuario(user);
                Session.Add("Usuario", user);
                Response.Redirect("Catalogo.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}