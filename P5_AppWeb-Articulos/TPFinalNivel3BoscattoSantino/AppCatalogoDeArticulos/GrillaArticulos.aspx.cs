using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClasesStatic;
using ModeloDeDominio;
using NegocioConDB;

namespace AppCatalogoDeArticulos
{
    public partial class GrillaArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Seguridad.VerificarAdmin((Usuario)Session["Usuario"]))
                    Response.Redirect("Catalogo.aspx", false);
                else
                {
                    NegocioProductos negocio = new NegocioProductos();
                    CargarProductos(negocio.ListarArticulos());
                }
                ViewState.Add("MostrarOcultar", true);
            }
        }

        protected void DGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ModificarArticulo.aspx?Id=" + DGV.SelectedDataKey.Value.ToString());
        }

        protected void DGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                NegocioProductos negocio = new NegocioProductos();
                DGV.PageIndex = e.NewPageIndex;
                CargarProductos(negocio.ListarArticulos());
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        private void CargarProductos(List<Articulo> ListaArticulos)
        {
            try
            {
                foreach (Articulo Precio in ListaArticulos)
                {
                    Precio.PrecioDelProducto = (Math.Truncate(Precio.PrecioDelProducto * 100) / 100);
                }
                DGV.DataSource = ListaArticulos;
                DGV.DataBind();
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

        protected void FiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioProductos negocio = new NegocioProductos();
                if (FiltroBox.Text != "")
                {
                    FiltroBox.BackColor = System.Drawing.Color.White;
                    CargarProductos(negocio.ListaFiltrada(CampoBox.SelectedValue, CriterioBox.SelectedValue, FiltroBox.Text));
                    Clean.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void Clean_Click(object sender, EventArgs e)
        {
            NegocioProductos negocio = new NegocioProductos();
            List<Articulo> ListaArticulos = negocio.ListarArticulos();
            CargarProductos(ListaArticulos);
            Clean.Visible = false;
            FiltroBox.Text = "";
        }

        protected void AgregarBoton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarArticulo.aspx");
        }
    }

}