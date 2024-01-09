using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModeloDeDominio;
using NegocioConDB;
using ClasesStatic;

namespace AppCatalogoDeArticulos
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void Desloguear_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioProductos negocio = new NegocioProductos();
                List<Articulo>  ListaArticulos = negocio.ListarArticulos();
                ListaArticulos = ListaArticulos.FindAll(aux => aux.NombreDeArticulo.ToLower().Contains(FiltroRapido.Text.ToLower()));
                ((Catalogo)Page).CargarProductos(ListaArticulos);
                LimpiarFiltroBasico.Visible = true;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            
        }

        protected void LimpiarFiltroBasico_Click(object sender, EventArgs e)
        {
            if (LimpiarFiltroBasico.Visible == true)
            {
                LimpiarFiltroBasico.Visible = false;
                NegocioProductos negocio = new NegocioProductos();
                ((Catalogo)Page).CargarProductos(negocio.ListarArticulos());
                FiltroRapido.Text = "";
            } 
        }

        public bool CallSeguridad()
        {
           return Seguridad.VerificarAdmin((Usuario)Session["Usuario"]);
        }

    }
}