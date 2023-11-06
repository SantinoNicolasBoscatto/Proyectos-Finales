using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo_Clases;
using Negocio_Base_Datos;

namespace Touge_App
{
    public partial class CargaMarca : Form
    {
        public CargaMarca()
        {
            InitializeComponent();
            CargarImagen.Filter = "Archivos PNG|*.png";
            Size = new Size(263, 197);
        }
        readonly OpenFileDialog CargarImagen = new OpenFileDialog();
        Form2 msg = new Form2();
        private void ImagenPista_Click(object sender, EventArgs e)
        {
            if (CargarImagen.ShowDialog() == DialogResult.OK)
            {
                string filePath = CargarImagen.FileName;
                ImagenBox.Text = filePath;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            NegocioBaseDatos negociobd = new NegocioBaseDatos();
            negociobd.InsertarMarcas(NombreBox.Text, ImagenBox.Text);
            msg.Mostrar("Agregado Con Exito");
            Close();
        }
    }
}
