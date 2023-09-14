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
using Negocio_Base_Datos;

namespace Touge_App
{
    public partial class Alquileres : UserControl
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

        public Alquileres()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
        }

        //public Image ImagenAlqu 
           //{ get{ return ImagenAlquiler.Image; } set { ImagenAlquiler.Image = value; }  }

        public void CargarImagenes(string imagen)
        {
            try
            {
                ImagenAlquiler.Load(imagen);
            }
            catch (Exception)
            {
                ImagenAlquiler.Load("https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg?w=2000");
            }
            
        }

        public string TituloDepa
        {
            get { return TituloAlquiler.Text; }
            set { TituloAlquiler.Text = value; }
        }

        public string Precio
        {
            get { return Preciolabel.Text; }
            set { Preciolabel.Text = "$" + value; }
        }

        public string Pieza
        {
            get { return DormitorioLabel.Text; }
            set { DormitorioLabel.Text = "● " + value; }
        }

        public string Sala
        {
            get { return SalaLabel.Text; }
            set { SalaLabel.Text = "● " + value; }
        }

        public string Ducha
        {
            get { return Duchalabel.Text; }
            set { Duchalabel.Text = "● " + value; }
        }

        public string Garaje
        {
            get { return GarajeLabel.Text; }
            set { GarajeLabel.Text = "● " + value; }
        }
        public int Id { get; set; }

        DialogResult Dialogo;
        public event EventHandler ButtonClick;
        private void BotonAlquilar_Click(object sender, EventArgs e)
        {
            Dialogo = MessageBox.Show("Desea Alquilar aca? Cada Mes se pedira renovar el Alquiler", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Dialogo == DialogResult.Yes)
            {
                ButtonClick?.Invoke(this, EventArgs.Empty);
            }
        }

        public DialogResult DevolverSi()
        {
            return DialogResult.Yes;
        }

        private void Alquileres_Click(object sender, EventArgs e)
        {
            
        }
    }
}
