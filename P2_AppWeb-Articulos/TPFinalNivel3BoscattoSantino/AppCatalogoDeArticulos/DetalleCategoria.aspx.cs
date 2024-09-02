using ClasesStatic;
using ModeloDeDominio;
using System;
using NegocioConDB;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppCatalogoDeArticulos
{
    public partial class DetalleCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Seguridad.VerificarAdmin((Usuario)Session["Usuario"]))
                    Response.Redirect("Catalogo.aspx", false);
                else
                {
                    if (Request.QueryString["CatID"] != null)
                    {
                        IdCat.Text = (string)Request.QueryString["CatID"];
                        NombreCategoria.Text = (string)Request.QueryString["Nombre"];
                    }
                    else
                    {
                        ModificarBoton.Text = "Agregar";
                    }
                }
            }

        }

        protected void ModificarBoton_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            NegocioProductos negocio = new NegocioProductos();
            if (Request.QueryString["CatID"] == null)
                negocio.AgregarCategoria(NombreCategoria.Text);
            else
                negocio.UpCategoria(NombreCategoria.Text, int.Parse(Request.QueryString["CatID"]));
            Response.Redirect("GrillaMC.aspx", false);
        }
    }
}