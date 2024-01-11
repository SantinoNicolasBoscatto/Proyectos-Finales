using ModeloDeDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppCatalogoDeArticulos
{
    public partial class DetalleCatalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["ArticuloDetalle"] != null)
                    {
                        Articulo aux = (Articulo)Session["ArticuloDetalle"];
                        TituloLabel.Text = aux.NombreDeArticulo;
                        DescripcionLabel.Text = aux.DescripcionDeArticulo;
                        LabelCategoria.Text = "<strong>Categoria:</strong> " + aux.CategoriaDelProducto.NombreCategoria;
                        LabelMarca.Text = "<strong>Marca:</strong> " + aux.MarcaDelProducto.NombreMarca;
                        aux.PrecioDelProducto = (Math.Truncate(aux.PrecioDelProducto * 100) / 100);
                        PrecioLabel.Text = "$ " + aux.PrecioDelProducto.ToString();
                        ImagenProducto.ImageUrl = aux.ImagenDelProducto;
                    }
                    else
                        Response.Redirect("Catalogo.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }

            }

        }

        protected void MasDetalles_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx", false);
            Session.Remove("ArticuloDetalle");
        }
    }
}