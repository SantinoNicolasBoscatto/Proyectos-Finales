using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Touge_App
{
    public partial class GastosDiarios : UserControl
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
                pictureBox1.Load(imagen);
            }
            catch (Exception)
            {
                pictureBox1.Load("https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg?w=2000");
            }

        }
        public void CargarImagenesBoton(string imagen)
        {
            try
            {
                using (Image imagenDeFondo = Image.FromFile(imagen))
                {
                    // Clona la imagen para evitar problemas de memoria
                    button1.BackgroundImage = new Bitmap(imagenDeFondo);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public GastosDiarios()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
        }
        public string Precio
        {
            get { return PrecioLabel.Text; }
            set { PrecioLabel.Text = value; }
        }
        DialogResult Dialogo;
        public event EventHandler ButtonClick;
        private void Button1_Click(object sender, EventArgs e)
        {
            Dialogo = MessageBox.Show("¿Quiere Pagar este servicio?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Dialogo == DialogResult.Yes)
            {
                ButtonClick?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
