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
    public partial class Comida : UserControl
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
        public Comida()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        public int Id { get; set; }
        public bool Comprado { get; set; }
        public string Titulo { get { return PackNombre.Text; } set { PackNombre.Text = value; } }
        public string Precio { get{ return PrecioLabel.Text; } set { PrecioLabel.Text = value; } }

        public void CargarImagenes(string imagen)
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception)
            {
                pictureBox1.Load("https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg?w=2000");
            }

        }

        DialogResult Dialogo;
        public event EventHandler ButtonClick;
        private void BuyButton_Click(object sender, EventArgs e)
        {
            Dialogo = MessageBox.Show("¿Desea Comprar Este Pack De Comida?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Dialogo == DialogResult.Yes)
            {
                ButtonClick?.Invoke(this, EventArgs.Empty);
            }
        }

        public void SoldOut()
        {
            Sold.Visible = true;
            Sold.Location = new Point(0, 0);
            BuyButton.Visible = false;
            PrecioLabel.Text = "Sin Stock";
            PrecioLabel.ForeColor = Color.IndianRed;
            Comprado = true;
        }

        public void OcultarSold()
        {
            Sold.Visible = false;
            BuyButton.Visible = true;
            PrecioLabel.ForeColor = Color.LimeGreen;
        }
    }
}
