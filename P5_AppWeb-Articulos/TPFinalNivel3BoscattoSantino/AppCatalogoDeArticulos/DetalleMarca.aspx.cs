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
    public partial class DetalleMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Seguridad.VerificarAdmin((Usuario)Session["Usuario"]))
                    Response.Redirect("Catalogo.aspx", false);
                else
                {
                    if (Request.QueryString["MarcaID"] != null)
                    {
                        IdMarca.Text = (string)Request.QueryString["MarcaID"];
                        NombreMarca.Text = (string)Request.QueryString["NombreMarca"];
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
            NegocioProductos negocio = new NegocioProductos();
            if (Request.QueryString["MarcaID"] == null)
                negocio.AgregarMarca(NombreMarca.Text);
            else
                negocio.UpMarca(NombreMarca.Text, int.Parse(Request.QueryString["MarcaID"]));
            Response.Redirect("GrillaMC.aspx", false);
        }
    }
}