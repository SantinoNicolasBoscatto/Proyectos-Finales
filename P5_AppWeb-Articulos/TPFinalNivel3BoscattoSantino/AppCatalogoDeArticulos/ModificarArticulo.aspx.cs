using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioConDB;
using ModeloDeDominio;

namespace AppCatalogoDeArticulos
{
    public partial class ModificarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    NegocioProductos negocio = new NegocioProductos();
                    CategoriaBox.DataSource = negocio.ListarCategorias();
                    CategoriaBox.DataValueField = "IdCategoria";
                    CategoriaBox.DataTextField = "NombreCategoria";
                    CategoriaBox.DataBind();
                    MarcaBox.DataSource = negocio.ListarMarcas();
                    MarcaBox.DataValueField = "IdMarca";
                    MarcaBox.DataTextField = "NombreMarca";
                    MarcaBox.DataBind();
                    if (Request.QueryString["Id"] != null)
                    {
                        IdBox.Text = Request.QueryString["Id"];
                        Articulo aux = negocio.ListaPorID(int.Parse(IdBox.Text));
                        CodigoBox.Text = aux.CodigoDeArticulo;
                        NombreBox.Text = aux.NombreDeArticulo;
                        DescripcionBox.Text = aux.DescripcionDeArticulo;
                        URLBox.Text = aux.ImagenDelProducto;
                        PrecioBox.Text = Math.Round(aux.PrecioDelProducto).ToString();
                        MarcaBox.SelectedValue = aux.MarcaDelProducto.IdMarca.ToString();
                        CategoriaBox.SelectedValue = aux.CategoriaDelProducto.IdCategoria.ToString();
                        CargarImagen();
                        if (URLBox.Text.ToLower().Contains("http"))
                            ImagenWeb.Checked = true;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        protected void URLBox_TextChanged(object sender, EventArgs e)
        {
            CargarImagen();
        }

        public void CargarImagen()
        {
            ImagenProducto.ImageUrl = URLBox.Text;
            if (ImagenProducto.CssClass == "")
                ImagenProducto.CssClass = "MyImg";
        }

        protected void ImagenServer_CheckedChanged(object sender, EventArgs e)
        {
            ImagenProducto.CssClass = "";
            ImagenProducto.ImageUrl = "";
            if (ImagenWeb.Checked)
                CargarImagen();
        }

        protected void SeleccionarImagen_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (ImagenProducto.CssClass == "")
                ImagenProducto.CssClass = "MyImg";
            string ruta = Server.MapPath("./Images/Articulos/");
            SeleccionarImagen.PostedFile.SaveAs(ruta + "Articulo-" + IdBox.Text + ".png");
            ImagenProducto.ImageUrl = "~/Images/Articulos/" + "Articulo-" + IdBox.Text + ".png";
        }

        protected void ModificarBoton_Click(object sender, EventArgs e)
        {
            if (IdBox.Text!="")
            {
                
            }
        }
    }
}