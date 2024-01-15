using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClasesStatic;
using ModeloDeDominio;
using NegocioConDB;

namespace AppCatalogoDeArticulos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request.Form["__EVENTTARGET"] == "Log")
                {
                    Login_Click(sender, e);
                    ScriptManager.RegisterStartupScript(this, GetType(), "LimpiarEventTarget", "__doPostBack('', '');", true);
                }
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuariosNegocio negocio = new UsuariosNegocio();
            try
            {
                user.Email = EmailBox.Text;
                user.Pass = PassBox.Text;
                if (negocio.ValidadorLogin(user))
                    Session.Add("Usuario", user);
                else
                    LabelError.Visible = true;
                    
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}