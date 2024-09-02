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
                        NegocioProductos negocio = new NegocioProductos();                  
                        Articulo aux = (Articulo)Session["ArticuloDetalle"];
                        Session.Add("IsFav", negocio.DevolverFav(((Usuario)Session["Usuario"]).Id, aux.Id));
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

        protected void Fav_Click(object sender, EventArgs e)
        {
            NegocioProductos negocio = new NegocioProductos();
            if (Session["IsFav"] != null && (bool)Session["IsFav"])
            {
                Session.Add("IsFav", false);
                negocio.BorrarFavoritos(((Usuario)Session["Usuario"]).Id, ((Articulo)Session["ArticuloDetalle"]).Id);
                
            }
            else
            {
                Session.Add("IsFav", true);
                negocio.AgregarFavoritos(((Usuario)Session["Usuario"]).Id, ((Articulo)Session["ArticuloDetalle"]).Id);
            }
        }

        protected void VolverBoton_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Back"] != null && Request.QueryString["Back"] == "1")
            {
                Response.Redirect("Catalogo.aspx", false);
                Session.Remove("ArticuloDetalle");
            }
            else
            {
                Response.Redirect("MisFavoritos.aspx", false);
                Session.Remove("ArticuloDetalle");
            }
            
        }
    }
}