using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioConDB;
using ModeloDeDominio;
using ClasesStatic;

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
                    if (!Seguridad.VerificarAdmin((Usuario)Session["Usuario"]))
                        Response.Redirect("Catalogo.aspx", false);
                    else
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
                            AgregarBoton.Text = "Modificar";
                            AgregarBoton.CssClass = "btn btn-secondary";
                            EliminarBoton.Visible = true;
                            IdBox.Text = Request.QueryString["Id"];
                            Articulo aux = negocio.ListaPorID(int.Parse(IdBox.Text));
                            CodigoBox.Text = aux.CodigoDeArticulo;
                            NombreBox.Text = aux.NombreDeArticulo;
                            DescripcionBox.Text = aux.DescripcionDeArticulo;
                            URLBox.Text = aux.ImagenDelProducto;
                            PrecioBox.Text = Math.Round(aux.PrecioDelProducto).ToString();
                            MarcaBox.SelectedValue = aux.MarcaDelProducto.IdMarca.ToString();
                            CategoriaBox.SelectedValue = aux.CategoriaDelProducto.IdCategoria.ToString();
                            if (aux.ImagenDelProducto.ToLower().Contains("http"))
                            {
                                URLBox.Text = aux.ImagenDelProducto;
                                CargarImagen();
                                ImagenWeb.Checked = true;
                            }
                            else
                            {
                                ImagenPorLocal.ImageUrl = URLBox.Text;
                                ImagenServer.Checked = true;
                                Session.Add("auxFoto", URLBox.Text);
                                URLBox.Text = "";
                                ImagenPorLocal.CssClass = "MyImg";
                                ImagenPorUrl.CssClass = "d-none";
                            }

                        }
                        else
                        {
                            ImagenWeb.Checked = true;
                            ImagenPorLocal.CssClass = "d-none";
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        public void CargarImagen()
        {
            try
            {
                ImagenPorUrl.CssClass = "MyImg";
                ImagenPorLocal.CssClass = "d-none";
                ImagenPorUrl.ImageUrl = URLBox.Text;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        public void ConfigurarImagen()
        {
            try
            {
                if (URLBox.Text == "")
                    ImagenPorUrl.CssClass = "d-none";
                ImagenPorLocal.CssClass = "MyImg";
                string ruta = Server.MapPath("./Images/Articulos/");
                SeleccionarImagen.PostedFile.SaveAs(ruta + "Articulo-" + IdBox.Text + ".png");
                ImagenPorLocal.ImageUrl = "./Images/Articulos/" + "Articulo-" + IdBox.Text + ".png";
                Session.Add("IMG", ImagenPorLocal.ImageUrl);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }


        protected void URLBox_TextChanged(object sender, EventArgs e)
        {
            CargarImagen();
            if (Session["IMG"] != null)
                Session.Remove("IMG");
        }

        protected void ImagenServer_CheckedChanged(object sender, EventArgs e)
        {
            if (ImagenWeb.Checked && URLBox.Text != "")
            {
                CargarImagen();
            }
            else if (ImagenServer.Checked && Session["auxFoto"] != null)
            {
                if (ImagenPorLocal.CssClass != "MyImg")
                    ImagenPorLocal.CssClass = "MyImg";
                ImagenPorLocal.ImageUrl = (string)Session["auxFoto"];
            }
        }

        protected void ModificarBoton_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo aux = new Articulo();
                NegocioProductos negocio = new NegocioProductos();
                aux.CodigoDeArticulo = CodigoBox.Text;
                aux.NombreDeArticulo = NombreBox.Text;
                if (ImagenWeb.Checked && URLBox.Text != "")
                {
                    aux.ImagenDelProducto = ImagenPorUrl.ImageUrl;
                    File.Delete(Server.MapPath("./Images/Articulos/Articulo-" + IdBox.Text + ".png"));
                }
                else if (ImagenServer.Checked && Session["IMG"] != null)
                    aux.ImagenDelProducto = (string)Session["IMG"];
                else
                    aux.ImagenDelProducto = Session["auxFoto"] != null ? (string)Session["auxFoto"] : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTUefeN8m3w2jrqlb2CaPONb1XVKRTDXpyALbIlnpI-7A&s";
                aux.DescripcionDeArticulo = DescripcionBox.Text;
                aux.MarcaDelProducto.IdMarca = int.Parse(MarcaBox.SelectedValue);
                aux.CategoriaDelProducto.IdCategoria = int.Parse(CategoriaBox.SelectedValue);
                aux.PrecioDelProducto = int.Parse(PrecioBox.Text);
                if (Request.QueryString["Id"] != null)
                {
                    aux.Id = int.Parse(IdBox.Text);
                    negocio.Modificar(aux);
                }
                else
                    negocio.AgregarArticulo(aux);
                Response.Redirect("GrillaArticulos.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void UpImagen_Click(object sender, EventArgs e)
        {
            ConfigurarImagen();
        }

        protected void EliminarBoton_Click(object sender, EventArgs e)
        {
            if (CheckDelete.Visible != false)
            {
                if (CheckDelete.Checked && Request.QueryString["Id"] != null)
                {
                    NegocioProductos negocio = new NegocioProductos();
                    negocio.EliminarArticulo(int.Parse(Request.QueryString["Id"]));
                    Response.Redirect("GrillaArticulos.aspx", false);
                }
            }
            else
            {
                EliminarLabel.Visible = true;
                CheckDelete.Visible = true;
            }

        }
    }
}