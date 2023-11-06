using Modelo_Clases;
using Negocio_Base_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touge_App
{
    public partial class CargarProductos : Form
    {
        public CargarProductos()
        {
            InitializeComponent();
        }
        readonly OpenFileDialog CargarImagen = new OpenFileDialog();
        Form2 mensajeBox = new Form2();
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - mouseLoc.X;
                int dy = e.Location.Y - mouseLoc.Y;
                dx += this.Location.X;
                dy += this.Location.Y;
                this.Location = new Point(dx, dy);
            }
        }
        Point mouseLoc;
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLoc = e.Location;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IdBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Esto evitará que se escriban caracteres no numéricos.
            }
        }

        private void CargarProducto_Click(object sender, EventArgs e)
        {
            if (CargarImagen.ShowDialog() == DialogResult.OK)
            {
                string filePath = CargarImagen.FileName;
                ImagenBox.Text = filePath;
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (IdBox.Text!="" && PrecioBox.Text != "" && NombreBox.Text != "" && ImagenBox.Text != "" && ClaseComboBox.Text != "")
            {
                try
                {
                    MisObjetos aux = new MisObjetos
                    {
                        Id = int.Parse(IdBox.Text),
                        NombreProducto = NombreBox.Text,
                        Imagen = ImagenBox.Text,
                        Precio = int.Parse(PrecioBox.Text)
                    };
                    NegocioBaseDatos negociobd = new NegocioBaseDatos();
                    negociobd.AgregarProductos(aux, ClaseComboBox.Text);
                    mensajeBox.Mostrar("Agregado Con exito");
                    Close();
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            else
            {
                mensajeBox.Mostrar("Faltan Datos de cargar");
            }
        }

        private void CargarProductos_Load(object sender, EventArgs e)
        {
            ClaseComboBox.Items.Add("Ropa");
            ClaseComboBox.Items.Add("Muebles");
            ClaseComboBox.Items.Add("Electronicos");
            CargarImagen.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            this.Size = new Size(340, 410);
        }
    }
}
