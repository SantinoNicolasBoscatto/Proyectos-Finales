using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClasesStatic;
using ModeloDeDominio;

namespace AppCatalogoDeArticulos
{
    public partial class LoginRegister : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                if (!Seguridad.VerificarAdmin((Usuario)Session["Usuario"]))
                    Response.Redirect("Catalogo.aspx", false);
                else
                    Response.Redirect("GrillaArticulos.aspx", false);
            }
        }

        protected void Registrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Registro.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void Loguearse_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}