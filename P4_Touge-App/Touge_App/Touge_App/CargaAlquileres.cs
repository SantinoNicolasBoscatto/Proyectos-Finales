using Modelo_Clases;
using Negocio_Base_Datos;
using System;
using System.Windows.Forms;

namespace Touge_App
{
    public partial class CargaAlquileres : Form
    {
        public CargaAlquileres()
        {
            InitializeComponent();
            cargarImagen.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
        }

        private void IdBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Esto evitará que se escriban caracteres no numéricos.
            }
        }

        readonly OpenFileDialog cargarImagen = new OpenFileDialog();
        private void CargarFoto_Click(object sender, EventArgs e)
        {
            if (cargarImagen.ShowDialog() == DialogResult.OK)
            {
                string filePath = cargarImagen.FileName;
                FotoBox.Text = filePath;
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (NombreBox.Text != "" && IdBox.Text != "" && BaniosBox.Text != "" && DormitoriosBox.Text != "" && SalaBox.Text != "" && GarajeBox.Text != "" && PrecioBox.Text != "" && FotoBox.Text != "")
            {
                Alquiler aux = new Alquiler
                {
                    NombreAlquiler = NombreBox.Text,
                    NumeroRegistro = int.Parse(IdBox.Text),
                    CantidadDuchas = int.Parse(BaniosBox.Text),
                    CantidadDormitorios = int.Parse(DormitoriosBox.Text),
                    CantidadSalasEstar = int.Parse(SalaBox.Text),
                    CantidadGarajes = int.Parse(GarajeBox.Text),
                    PrecioDepartamento = int.Parse(PrecioBox.Text),
                    ImagenAlquiler = FotoBox.Text
                };
                NegocioBaseDatos negociobd = new NegocioBaseDatos();
                negociobd.AgregarAlquiler(aux);
                MessageBox.Show("Agregado Con exito");
                Close();
            }
            else
                MessageBox.Show("Faltan Datos Por Cargar");
        }
    }
}
