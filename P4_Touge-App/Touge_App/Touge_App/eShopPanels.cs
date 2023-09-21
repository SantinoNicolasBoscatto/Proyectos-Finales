using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touge_App
{
    public partial class eShopPanels : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public eShopPanels()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 85, 85));
            Sold.BackColor = Color.FromArgb(128, 60, 60, 60);
            Sold.Parent = ProductoImagen;
        }

        public void CargarImagenes(string imagen)
        {
            try
            {
                ProductoImagen.Load(imagen);
            }
            catch (Exception)
            {
                ProductoImagen.Load("https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg?w=2000");
            }

        }

        DialogResult Dialogo;
        public event EventHandler ButtonClick;
        private void BotonComprar_Click(object sender, EventArgs e)
        {
            Dialogo = MessageBox.Show("¿Desea Comprar Este Articulo?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Dialogo == DialogResult.Yes)
            {
                ButtonClick?.Invoke(this, EventArgs.Empty);
            }
        }

        public string Precio 
        {
            get { return PrecioLabel.Text; } 
          set { PrecioLabel.Text = value; }
        }

        public string NombreProducto
        {
            get { return NombreDelProducto.Text; }
            set { NombreDelProducto.Text = value; }
        }
        public int Id { get; set; }

        public bool Comprado { get; set; }

        public void SoldOut()
        {
            Sold.Visible = true;
            Sold.Location = new Point(0, 0);
            BotonComprar.Visible = false;
            PrecioLabel.Text = "Sin Stock";
            PrecioLabel.ForeColor = Color.IndianRed;
            Comprado = true;
        }

        public void OcultarSold()
        {
            Sold.Visible = false;
            BotonComprar.Visible = true;
            PrecioLabel.ForeColor = Color.LimeGreen;      
        }

        public void Letras(Color Fore)
        {
            NombreDelProducto.ForeColor = Fore;
        }

    }
}
