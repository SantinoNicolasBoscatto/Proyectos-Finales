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
        public bool Limpiar
        {
            get { return LimpiarFiltroBasico.Visible; }
            set { Limpiar = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                    Response.Redirect("Login.aspx", false);
                else
                    ImagenPerfilMini.ImageUrl = ((Usuario)Session["Usuario"]).ImagenPerfil != null ? ((Usuario)Session["Usuario"]).ImagenPerfil : "https://i0.wp.com/digitalhealthskills.com/wp-content/uploads/2022/11/3da39-no-user-image-icon-27.png?fit=500%2C500&ssl=1";
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
            ListaArticulos = negocio.ListaFav(((Usuario)Session["Usuario"]).Id).FindAll(aux => aux.NombreDeArticulo.ToLower().Contains(FiltroRapido.Text.ToLower()));
            ((MisFavoritos)Page).CargarProductos(ListaArticulos);
            LimpiarFiltroBasico.Visible = true;
            return ListaArticulos;
            
        }

        protected void LimpiarFiltroBasico_Click(object sender, EventArgs e)
        {
            try
            {
                if (LimpiarFiltroBasico.Visible == true)
                {
                    LimpiarFiltroBasico.Visible = false;
                    NegocioProductos negocio = new NegocioProductos();
                    ((MisFavoritos)Page).CargarProductos(negocio.ListaFav(((Usuario)Session["Usuario"]).Id));
                    FiltroRapido.Text = "";
                }
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