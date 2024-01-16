using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioConDB;
using ModeloDeDominio;

namespace AppCatalogoDeArticulos
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    NegocioProductos negocio = new NegocioProductos();
                    List<Articulo> ListaArticulos = negocio.ListarArticulos();
                    CargarProductos(ListaArticulos);
                    ViewState.Add("MostrarOcultar", true);
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
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

        protected void FiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioProductos negocio = new NegocioProductos();
                CargarProductos(negocio.ListaFiltradaDoble(CampoBox.SelectedValue, CriterioBox.SelectedValue, FiltroBox.Text, ((SiteMaster)Master).Search));
                Session.Add("FiltroDoble", true);
                if (Session["FiltroSimple"] != null)
                    Session.Remove("FiltroSimple");
                //Clean.Visible = true;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void MostrarOcultar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bool)ViewState["MostrarOcultar"])
                {
                    RestaurarMostrarOcultar(false, "Ocultar Filtros", true);
                }
                else
                {
                    RestaurarMostrarOcultar(true, "Mostrar Filtros", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void CampoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CriterioBox.Items.Clear();
            if (CampoBox.SelectedValue == "5")
            {
                CriterioBox.Items.Add("Es Mayor a");
                CriterioBox.Items.Add("Es Menor a");
                CriterioBox.Items.Add("Es Igual a");
                FiltroBox.TextMode = TextBoxMode.Number;
                CriterioBox.Items[0].Value = "1";
                CriterioBox.Items[1].Value = "2";
                CriterioBox.Items[2].Value = "3";
            }
            else
            {
                CriterioBox.Items.Add("Empieza Por");
                CriterioBox.Items.Add("Termina Por");
                CriterioBox.Items.Add("Contiene");
                FiltroBox.TextMode = TextBoxMode.SingleLine;
                CriterioBox.Items[0].Value = "1";
                CriterioBox.Items[1].Value = "2";
                CriterioBox.Items[2].Value = "3";
            }
        }

        public void RestaurarMostrarOcultar(bool MO, string text, bool visi)
        {
            ViewState.Add("MostrarOcultar", MO);
            MostrarOcultar.Text = text;
            FiltroAvanzado.Visible = visi;
        }

        public void Clean_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioProductos negocio = new NegocioProductos();
                List<Articulo> ListaArticulos = negocio.ListarArticulos();
                CargarProductos(ListaArticulos);
                //Clean.Visible = false;
                ((SiteMaster)Master).LimpiarFiltroBasico_Click(sender, e);
                Session.Add("SeFiltro", false);
                RestaurarMostrarOcultar(true, "Mostrar Filtros", false);
                if (Session["FiltroSimple"] != null)
                    Session.Remove("FiltroSimple");
                if (Session["FiltroDoble"] != null)
                    Session.Remove("FiltroDoble");
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
                List<Articulo> ListaArticulos = null;
                if (Session["FiltroSimple"] != null)
                {
                    ListaArticulos = ((SiteMaster)Master).FiltroFast();
                    Session.Remove("FiltroSimple");
                }
                                   
                else if (Session["FiltroDoble"] != null)
                {
                    ListaArticulos = negocio.ListaFiltradaDoble(CampoBox.SelectedValue, CriterioBox.SelectedValue, FiltroBox.Text, ((SiteMaster)Master).Search);
                    Session.Remove("FiltroDoble");
                }               
                else
                ListaArticulos = negocio.ListarArticulos();
                    
                    //ListaArticulos = negocio.ListaFiltrada(CampoBox.SelectedValue, CriterioBox.SelectedValue, FiltroBox.Text);
                CargarProductos(ListaArticulos);
                Session.Add("ArticuloDetalle", ListaArticulos[index]);
                Response.Redirect("DetalleCatalogo.aspx?Back=1", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}
