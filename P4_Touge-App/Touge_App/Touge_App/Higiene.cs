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
    public partial class Higiene : UserControl
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
        public void CargarImagenes(string imagen)
        {
            try
            {
                HigienePictureBox.Load(imagen);
            }
            catch (Exception)
            {
                HigienePictureBox.Load("https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg?w=2000");
            }

        }
        public Higiene()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            Sold.BackColor = Color.FromArgb(128, 60, 60, 60);
            Sold.Parent = HigienePictureBox;
            Sold.Location = new Point(0, 0);
        }
        public string Precio
        {
            get { return PrecioLabel.Text; }
            set { PrecioLabel.Text = value; }
        }
        public string NombreProducto
        {
            get { return NombrePackHigiene.Text; }
            set { NombrePackHigiene.Text = value; }
        }
        public int Id { get; set; }
        public bool Comprado { get; set; }
        public void SoldOut()
        {
            Sold.Visible = true;
            
            ComprarBoton.Visible = false;
            PrecioLabel.Text = "Sin Stock";
            PrecioLabel.ForeColor = Color.IndianRed;
            Comprado = true;
        }
        public void OcultarSold()
        {
            Sold.Visible = false;
            ComprarBoton.Visible = true;
            PrecioLabel.ForeColor = Color.LimeGreen;
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
    }
}
