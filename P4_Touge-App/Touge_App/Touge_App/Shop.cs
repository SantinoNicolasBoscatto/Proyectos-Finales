using System.Drawing;
using System.Windows.Forms;

namespace Touge_App
{
    public partial class Shop : Bunifu.UI.WinForms.BunifuUserControl
    {
        public Shop()
        {
            InitializeComponent();
        }

        public Image Producto
        {
            get { return ImagenProducto.Image; }

            set { ImagenProducto.Image = value; }

        } 
        public string NombreProducto
        {
            get { return NombreProductoLabel.Text; }

            set { NombreProductoLabel.Text = value; }

        }

        public string Precio
        {
            get { return PrecioLabel.Text; }

            set { PrecioLabel.Text = value; }

        }
    }
}
