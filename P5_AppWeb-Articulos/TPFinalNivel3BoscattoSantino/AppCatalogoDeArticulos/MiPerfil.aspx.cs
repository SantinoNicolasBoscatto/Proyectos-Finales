using ModeloDeDominio;
using NegocioConDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppCatalogoDeArticulos
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["Usuario"] != null)
                    {
                        Usuario aux = (Usuario)Session["Usuario"];
                        EmailBox.Text = aux.Email;
                        PassBox.Text = aux.Pass;
                        NombreBox.Text = aux.Nombre;
                        ApellidoBox.Text = aux.Apellido;
                        if (aux.ImagenPerfil != null)
                        {
                            if (aux.ImagenPerfil.ToLower().Contains("http"))
                            {
                                URLBox.Text = aux.ImagenPerfil;
                                CargarImagen();
                                ImagenWeb.Checked = true;
                            }
                            else if (aux.ImagenPerfil.ToLower().Contains("/"))
                            {
                                ImagenPorLocal.ImageUrl = aux.ImagenPerfil;
                                ImagenServer.Checked = true;
                                Session.Add("auxFoto", aux.ImagenPerfil);
                                ImagenPorLocal.CssClass = "MyImg";
                                ImagenPorUrl.CssClass = "d-none";
                            }
                        }
                        else
                        {
                            ImagenPorUrl.CssClass = "d-none";
                            ImagenPorLocal.CssClass = "d-none";
                            ImagenWeb.Checked = true;
                        }
                    }
                    else
                        Response.Redirect("Login.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }

            }

        }

        protected void ImagenServer_CheckedChanged(object sender, EventArgs e)
        {
            try
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
                string ruta = Server.MapPath("./Images/Perfiles/");
                SeleccionarImagen.PostedFile.SaveAs(ruta + "Usuario-" + ((Usuario)Session["Usuario"]).Id + ".png");
                ImagenPorLocal.ImageUrl = "./Images/Perfiles/" + "Usuario-" + ((Usuario)Session["Usuario"]).Id + ".png";
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



        protected void UpImagen_Click(object sender, EventArgs e)
        {
            ConfigurarImagen();
        }

        protected void GuardarCambios_Click(object sender, EventArgs e)
        {
            Usuario aux = new Usuario();
            UsuariosNegocio negocio = new UsuariosNegocio();
            try
            {
                aux.Pass = PassBox.Text;
                aux.Nombre = NombreBox.Text;
                aux.Apellido = ApellidoBox.Text;
                aux.Id = ((Usuario)Session["Usuario"]).Id;
                if (ImagenWeb.Checked && URLBox.Text != "")
                {
                    aux.ImagenPerfil = ImagenPorUrl.ImageUrl;
                    File.Delete(Server.MapPath("./Images/Perfiles/Usuario-" + ((Usuario)Session["Usuario"]).Id + ".png"));
                }
                else if (ImagenServer.Checked && Session["IMG"] != null)
                    aux.ImagenPerfil = (string)Session["IMG"];
                else
                    aux.ImagenPerfil = Session["auxFoto"] != null ? (string)Session["auxFoto"] : "https://i0.wp.com/digitalhealthskills.com/wp-content/uploads/2022/11/3da39-no-user-image-icon-27.png?fit=500%2C500&ssl=1";
                negocio.UpdateUsuario(aux);
                aux.Email = EmailBox.Text;
                Session.Add("Usuario", aux);
                Response.Redirect("Catalogo.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            File.Delete(Server.MapPath("./Images/Perfiles/Usuario-" + ((Usuario)Session["Usuario"]).Id + ".png"));
            Response.Redirect("Catalogo.aspx", false);
        }
    }


}