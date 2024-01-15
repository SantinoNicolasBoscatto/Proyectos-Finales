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
                CargarProductos(negocio.ListaFiltrada(CampoBox.SelectedValue, CriterioBox.SelectedValue, FiltroBox.Text));
                Clean.Visible = true;
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
                    MostrarOcultar.Text = "Ocultar Filtros";
                    ViewState.Add("MostrarOcultar", false);
                    FiltroAvanzado.Visible = true;
                }
                else
                {
                    MostrarOcultar.Text = "Mostrar Filtros";
                    ViewState.Add("MostrarOcultar", true);
                    FiltroAvanzado.Visible = false;
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
            }
            else
            {
                CriterioBox.Items.Add("Empieza Por");
                CriterioBox.Items.Add("Termina Por");
                CriterioBox.Items.Add("Contiene");
                FiltroBox.TextMode = TextBoxMode.SingleLine;
            }
        }

        protected void Clean_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioProductos negocio = new NegocioProductos();
                List<Articulo> ListaArticulos = negocio.ListarArticulos();
                CargarProductos(ListaArticulos);
                Clean.Visible = false;
                FiltroBox.Text = "";
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
                if (Clean.Visible)
                    ListaArticulos = negocio.ListaFiltrada(CampoBox.SelectedValue, CriterioBox.SelectedValue, FiltroBox.Text);
                else
                    ListaArticulos = negocio.ListarArticulos();

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
