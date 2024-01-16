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
        public string Search { get { return FiltroRapido.Text; } }
        public void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                    Response.Redirect("Login.aspx", false);
                else
                {
                    ImagenPerfilMini.ImageUrl = ((Usuario)Session["Usuario"]).ImagenPerfil != null ? ((Usuario)Session["Usuario"]).ImagenPerfil : "https://i0.wp.com/digitalhealthskills.com/wp-content/uploads/2022/11/3da39-no-user-image-icon-27.png?fit=500%2C500&ssl=1";
                    Session.Add("SeFiltro", false);
                }
            }
            if (Page is Catalogo)
            {
                if (Request.Form["__EVENTTARGET"] == "MF")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "LimpiarEventTarget", "__doPostBack('', '');", true);
                }
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
                if (Page is Catalogo)
                {
                    LimpiarFiltroBasico_Click(sender, e);
                    Session.Add("SeFiltro", false);
                    (((Catalogo)Page)).RestaurarMostrarOcultar(true, "Mostrar Filtros", false);
                    Session.Add("FiltroSimple", true);
                    if (Session["FiltroDoble"] != null)
                        Session.Remove("FiltroDoble");
                    //(((Catalogo)Page).FindControl("FiltroAvanzado")).Visible = false;
                }
                FiltroFast();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }
        public List<Articulo> FiltroFast()
        {
            NegocioProductos negocio = new NegocioProductos();
            List<Articulo> ListaArticulos = new List<Articulo>();
            if (Page is MisFavoritos)
            {
                ListaArticulos = negocio.ListaFav(((Usuario)Session["Usuario"]).Id).FindAll(aux => aux.NombreDeArticulo.ToLower().Contains(FiltroRapido.Text.ToLower()));
                ((MisFavoritos)Page).CargarProductos(ListaArticulos);
                LimpiarFiltroBasico.Visible = true;
            }

            else
            {
                ListaArticulos = negocio.ListarArticulos().FindAll(aux => aux.NombreDeArticulo.ToLower().Contains(FiltroRapido.Text.ToLower()));
                ((Catalogo)Page).CargarProductos(ListaArticulos);
            }

            Session["SeFiltro"] = true;
            return ListaArticulos;

        }

        public void LimpiarFiltroBasico_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarFiltroBasico.Visible = false;
                NegocioProductos negocio = new NegocioProductos();
                if (Page is MisFavoritos)
                    ((MisFavoritos)Page).CargarProductos(negocio.ListaFav(((Usuario)Session["Usuario"]).Id));
                else
                    ((Catalogo)Page).CargarProductos(negocio.ListarArticulos());
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        public bool CallSeguridad()
        {
            return Seguridad.VerificarAdmin((Usuario)Session["Usuario"]);
        }

        protected void ImagenPerfilMini_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MiPerfil.aspx");
        }


    }
}