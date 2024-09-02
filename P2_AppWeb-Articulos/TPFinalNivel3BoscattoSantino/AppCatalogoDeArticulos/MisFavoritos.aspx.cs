using ModeloDeDominio;
using NegocioConDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppCatalogoDeArticulos
{
    public partial class MisFavoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioProductos negocio = new NegocioProductos();
                if (Session["Usuario"]!= null)
                {
                    List<Articulo> ListaArticulos = negocio.ListaFav(((Usuario)Session["Usuario"]).Id);
                    CargarProductos(ListaArticulos);
                }
                
            }
        }

        public void CargarProductos(List<Articulo> ListaArticulos)
        {
            try
            {
                foreach (Articulo Precio in ListaArticulos)
                {
                    Precio.PrecioDelProducto = (Math.Truncate(Precio.PrecioDelProducto * 100) / 100);
                }
                RepetidorCatalogo.DataSource = ListaArticulos;
                RepetidorCatalogo.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void MasDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                int index = ((RepeaterItem)((Button)sender).NamingContainer).ItemIndex;
                NegocioProductos negocio = new NegocioProductos();
                List<Articulo> listafav = negocio.ListaFav(((Usuario)Session["Usuario"]).Id);
                //string id = ListaArticulos[index].Id.ToString();
                Session.Add("ArticuloDetalle", listafav[index]);
                Response.Redirect("DetalleCatalogo.aspx?Back=2", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}