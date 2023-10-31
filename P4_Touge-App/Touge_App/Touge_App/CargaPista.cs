using Modelo_Clases;
using System;
using Negocio_Base_Datos;
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
    public partial class CargaPista : Form
    {
        public CargaPista()
        {
            InitializeComponent();
            PanelFondo.BackColor = Color.FromArgb(180, 0, 0, 0);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SetPlaceholderText()
        {
            Record.ForeColor = SystemColors.ControlLight;
        }
        private void TiempoTextBox_Leave(object sender, EventArgs e)
        {
            if (Record.Text == "")
            {
                SetPlaceholderText();
            }
        }
        private void TiempoTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                string text = Record.Text;
                if (text.Length == 2)
                {
                    text += ":";
                }
                else if (text.Length == 5)
                {
                    text += ":";
                }
                Record.Text = text;
                Record.SelectionStart = Record.Text.Length;
            }
            else if (e.KeyChar == '\b') // Verificar si se presionó la tecla Retroceso (BackSpace)
            {
                string text = Record.Text;

                // Eliminar el último carácter si es un dos puntos o un dígito
                if (!string.IsNullOrEmpty(text))
                {
                    text = text.Substring(0, text.Length - 1);
                }
                Record.Text = text;

                // Establecer el cursor al final del texto
                Record.SelectionStart = Record.Text.Length;
                e.Handled = true;
            }
            else
            {
                // Evitar que se ingresen caracteres que no sean dígitos ni Retroceso
                e.Handled = true;
            }
        }

        private void CargaPista_Load(object sender, EventArgs e)
        {
            SetPlaceholderText();
            ModalidadBox.Items.Add("Side By Side");
            ModalidadBox.Items.Add("El Gato Y El Raton");
            ModalidadBox.Items.Add("Muerte Subita");
            ModalidadBox.Items.Add("Batalla Aleatoria");
            CargarImagen.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagen2.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagen3.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
        }

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

        readonly OpenFileDialog CargarImagen = new OpenFileDialog();
        readonly OpenFileDialog CargarImagen2 = new OpenFileDialog();
        readonly OpenFileDialog CargarImagen3 = new OpenFileDialog();
        private void Agregar_Click(object sender, EventArgs e)
        {
            if (NombrePista.Text != "" && Distancia.Text != "" && PP.Text != "" && ModalidadBox.Text != "" && Record.Text != "" && Img1.Text != "" && Img2.Text != "" && Lay.Text != "" && Bio.Text != "")
            {
                Pistas aux = new Pistas
                {
                    NombrePista = NombrePista.Text,
                    Distancia = Distancia.Text,
                    Pais = PP.Text,
                    ModalidadPreferida = ModalidadBox.Text,
                    Record = Record.Text,
                    Imagenes = Img1.Text,
                    Imagenes2 = Img2.Text,
                    BiografiaPista = Bio.Text,
                    Lay = Lay.Text
                };
                NegocioBaseDatos negocioAgregar = new NegocioBaseDatos();
                negocioAgregar.AgregarPistas(aux);
                MessageBox.Show("Pista Agregada Con Exito");
                Close();
            }
            else
            {
                MessageBox.Show("Faltan Datos");
            }
                
        }

        private void Imagen1Boton_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagen, Img1);
        }
        private void Imagen2Boton_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagen2, Img2);
        }
        private void Imagen3Boton_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagen3, Lay);
        }

        private void CargarOpen(OpenFileDialog aux, TextBox auxT)
        {
            if (aux.ShowDialog() == DialogResult.OK)
            {
                string filePath = aux.FileName;
                auxT.Text = filePath;
            }
        }
    }
}
