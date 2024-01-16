using ClasesStatic;
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
    public partial class GrillaMC : System.Web.UI.Page
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
                    CargarCatmarca(negocio.ListarCategorias(), negocio.ListarMarcas());
                }
            }
        }
        protected void DGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("DetalleCategoria.aspx?CatID=" + DGV.SelectedDataKey.Value+"&Nombre="+ 
                DGV.SelectedRow.Cells[0].Text, false);
        }
        protected void DGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            NegocioProductos negocio = new NegocioProductos();
            DGV.PageIndex = e.NewPageIndex;
            CargarCatmarca(negocio.ListarCategorias(), negocio.ListarMarcas());
        }
        private void CargarCatmarca(List<Categoria> ListCat, List<Marca> ListM)
        {
            try
            {
                DGV.DataSource = ListCat;
                DGV.DataBind();
                DGVMarca.DataSource = ListM;
                DGVMarca.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void AgregarBoton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleCategoria.aspx", false);
        }

        protected void AgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleMarca.aspx", false);
        }

        protected void DGVMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("DetalleMarca.aspx?MarcaID=" + DGVMarca.SelectedDataKey.Value + "&NombreMarca=" +
                DGVMarca.SelectedRow.Cells[0].Text, false);
        }

        protected void DGVMarca_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            NegocioProductos negocio = new NegocioProductos();
            DGVMarca.PageIndex = e.NewPageIndex;
            CargarCatmarca(negocio.ListarCategorias(), negocio.ListarMarcas());
        }
    }
}