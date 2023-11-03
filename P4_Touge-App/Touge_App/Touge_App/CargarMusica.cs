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
    public partial class CargarMusica : Form
    {
        public CargarMusica()
        {
            InitializeComponent();
            CargarImagenTapa.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
        }

        readonly OpenFileDialog CargarImagenTapa = new OpenFileDialog();
        private void CargarImagen_Click(object sender, EventArgs e)
        {
            if (CargarImagenTapa.ShowDialog() == DialogResult.OK)
            {
                string filePath = CargarImagenTapa.FileName;
                ImagenBox.Text = filePath;
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        readonly OpenFileDialog CargarAudio = new OpenFileDialog();
        private void CargarMp3_Click(object sender, EventArgs e)
        {
            CargarAudio.Filter = "Archivos de audio|*.mp3;*.wav";
            if (CargarAudio.ShowDialog() == DialogResult.OK)
            {
                string filePath = CargarAudio.FileName;
                Mp3Box.Text = filePath;
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (NombreBox.Text!="" && ImagenBox.Text!="" && Mp3Box.Text!="")
            {
                Musica aux = new Musica
                {
                    NombreCancion = NombreBox.Text,
                    TapaMusica = ImagenBox.Text,
                    CancionURL = Mp3Box.Text
                };
                NegocioBaseDatos negociobd = new NegocioBaseDatos();
                negociobd.AgregarCancion(aux);
                MessageBox.Show("Agregado Con exito");
                Close();
            }
        }

        private void CargarMusica_Load(object sender, EventArgs e)
        {
            Size = new Size(400, 303);
            ImagenLabel.BackColor = Color.FromArgb(128, 0, 0, 0);
            MusicaLabel.BackColor = Color.FromArgb(128, 0, 0, 0);
            NombreProductoLabel.BackColor = Color.FromArgb(128, 0, 0, 0);
        }
        Point mouseLoc;
        private void PictureBoxBack_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLoc = e.Location;
        }
        private void PictureBoxBack_MouseMove(object sender, MouseEventArgs e)
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
    }
}
