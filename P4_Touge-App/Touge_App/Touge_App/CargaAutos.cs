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
    public partial class CargaAutos : Form
    {
        readonly OpenFileDialog CargarBandera = new OpenFileDialog();
        readonly OpenFileDialog CargarImagen = new OpenFileDialog();
        readonly OpenFileDialog CargarImagen2 = new OpenFileDialog();
        readonly OpenFileDialog CargarImagen3 = new OpenFileDialog();
        readonly OpenFileDialog CargarImagen4 = new OpenFileDialog();
        readonly OpenFileDialog CargarImagen5 = new OpenFileDialog();
        readonly OpenFileDialog CargarImagen6 = new OpenFileDialog();
        public CargaAutos()
        {
            InitializeComponent();
        }

        Autos aux = null;
        public CargaAutos(Autos traslado)
        {
            InitializeComponent();           
            aux = traslado;
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
        private void CargaAutos_Load(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Length >= 2)
            {
                // Obtener la segunda pantalla
                Screen segundaPantalla = Screen.AllScreens[1];

                // Obtener el formulario actual
                Form formulario = this;

                // Centrar el formulario en la segunda pantalla
                formulario.Location = new Point(2430, 50);
            }
            PanelFondo.BackColor = Color.FromArgb(128, 0, 0, 0);
            PanelFondo.Parent = this;
            this.Size = PanelFondo.Size;
            CargarBandera.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagen.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagen2.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagen3.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagen4.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagen5.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargaCombos();
           
            if (aux != null)
            {
                Agregar.Text = "Mod";
                NombreAuto.Text = aux.NombreModelo;
                PilotoAuto.Text = aux.Piloto;              
                AnioAuto.Text = aux.Anio.ToString();
                PaisImagen.Text = aux.PaisFabricacion;
                HpAuto.Text = aux.HP.ToString();
                PesoAuto.Text = aux.Peso.ToString();
                PPAuto.Text = aux.RelacionPesoPotencia.ToString();
                TopSpeedAuto.Text = aux.TopSpeed.ToString();
                KilometrajeAuto.Text = aux.Kilometraje.ToString();
                TanqueAuto.Text = aux.Tanque.ToString();
                Price.Text = aux.Precio.ToString();
                TorqueAuto.Text = aux.Torque.ToString();
                Img1.Text = aux.ImagenAuto;
                Img2.Text = aux.ImagenAutoSecundaria;
                Img3.Text = aux.ImagenAutoTres;
                Img4.Text = aux.ImagenAutoCuatro;
                Img5.Text = aux.ImagenAutoCinco;
                Img6.Text = aux.ImagenAutoCinco;

                for (int i = 0; i < CategoriaAuto.Items.Count; i++)
                {
                    if (CategoriaAuto.Items[i].ToString() == aux.Categoria)
                    {
                        CategoriaAuto.SelectedIndex = i;
                        i = CategoriaAuto.Items.Count;
                    }
                }
                for (int i = 0; i < TraccionAuto.Items.Count; i++)
                {
                    if (TraccionAuto.Items[i].ToString() == aux.Traccion)
                    {
                        TraccionAuto.SelectedIndex = i;
                        i = TraccionAuto.Items.Count;
                    }
                }
                for (int i = 0; i < Aspiracion.Items.Count; i++)
                {
                    if (Aspiracion.Items[i].ToString() == aux.Aspiracion)
                    {
                        Aspiracion.SelectedIndex = i;
                        i = Aspiracion.Items.Count;
                    }
                }
                Marca.SelectedIndex = -1;
                for (int i = 0; i < Marca.Items.Count; i++)
                {
                    if ((int)Marca.Items[i].GetType().GetProperty(Marca.ValueMember).GetValue(Marca.Items[i]) == aux.MarcaAuto.IdMarca)
                    {
                        Marca.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        private void CargarOpen(OpenFileDialog aux, TextBox auxT)
        {
            if (aux.ShowDialog() == DialogResult.OK)
            {
                string filePath = aux.FileName;
                auxT.Text = filePath;
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CargaCombos()
        {
            CategoriaAuto.Items.Add("F");
            CategoriaAuto.Items.Add("E");
            CategoriaAuto.Items.Add("D");
            CategoriaAuto.Items.Add("C");
            CategoriaAuto.Items.Add("B");
            CategoriaAuto.Items.Add("A");
            CategoriaAuto.Items.Add("S");
            CategoriaAuto.Items.Add("S++");
            TraccionAuto.Items.Add("RWD");
            TraccionAuto.Items.Add("FWD");
            TraccionAuto.Items.Add("AWD");
            TraccionAuto.Items.Add("4WD");
            Aspiracion.Items.Add("NA");
            Aspiracion.Items.Add("T");
            Aspiracion.Items.Add("SC");
            NegocioBaseDatos negociobaseMarca = new NegocioBaseDatos();
            List<Marca> listaMarca;
            listaMarca =  negociobaseMarca.DevolverMarca();
            Marca.DataSource = listaMarca;
            Marca.ValueMember = "IdMarca";
            Marca.DisplayMember = "NombreMarca";
            Marca.SelectedItem = Marca.ValueMember;
        }
        private void HpAuto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Esto evitará que se escriban caracteres no numéricos.
            }
        }
        private void PPAuto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Esto evitará que se escriban caracteres no numéricos ni puntos.
            }
            // Asegurarse de que solo haya un punto decimal en el TextBox.
            if (e.KeyChar == '.' && PPAuto.Text.Contains("."))
            {
                e.Handled = true; // Bloquear la entrada de un segundo punto.
            }
        }
        private void TopSpeedAuto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Esto evitará que se escriban caracteres no numéricos ni puntos.
            }

            // Asegurarse de que solo haya un punto decimal en el TextBox.
            if (e.KeyChar == '.' && TopSpeedAuto.Text.Contains("."))
            {
                e.Handled = true; // Bloquear la entrada de un segundo punto.
            }
        }

        int contador = 1;
        private void MasBoton_Click(object sender, EventArgs e)
        {
            contador++;
            if (contador>3)
            {
                contador = 1;
            }
            switch (contador)
            {
                case 1:
                    NombreAuto.Visible = true;
                    AnioAuto.Visible = true;
                    PaisAuto.Visible = true;
                    TraccionAuto.Visible = true;
                    CategoriaAuto.Visible = true;
                    HpAuto.Visible = true;
                    PPAuto.Visible = true;
                    PesoAuto.Visible = true;
                    TopSpeedAuto.Visible = true;
                    NombreLabel.Visible = true;
                    Anio.Visible = true;
                    Pais.Visible = true;
                    TraccionLabel.Visible = true;
                    CatLabel.Visible = true;
                    HpLabel.Visible = true;
                    PesoLabel.Visible = true;
                    PPlabel.Visible = true;
                    TopLabel.Visible = true;
                    Img3.Visible = false;
                    Img4.Visible = false;
                    Img5.Visible = false;
                    Img6.Visible = false;
                    Imagen3Boton.Visible = false;
                    Imagen4Boton.Visible = false;
                    Imagen5Boton.Visible = false;
                    Imagen6Boton.Visible = false;
                    Imagen3Label.Visible = false;
                    Imagen4Label.Visible = false;
                    Imagen5Label.Visible = false;
                    Imagen6Label.Visible = false;
                    TorqueAuto.Visible = false;
                    TorqueLabel.Visible = false;
                    break;
                case 2:
                    NombreAuto.Visible = false;
                    Anio.Visible = false;
                    AnioAuto.Visible = false;
                    PaisAuto.Visible = false;
                    TraccionAuto.Visible = false;
                    CategoriaAuto.Visible = false;
                    HpAuto.Visible = false;
                    PPAuto.Visible = false;
                    PesoAuto.Visible = false;
                    TopSpeedAuto.Visible = false;
                    NombreLabel.Visible = false;
                    Anio.Visible = false;
                    Pais.Visible = false;
                    TraccionLabel.Visible = false;
                    CatLabel.Visible = false;
                    HpLabel.Visible = false;
                    PesoLabel.Visible = false;
                    PPlabel.Visible = false;
                    TopLabel.Visible = false;

                    KilometrajeAuto.Visible = true;
                    PilotoAuto.Visible = true;
                    TanqueAuto.Visible = true;
                    Aspiracion.Visible = true;
                    Marca.Visible = true;
                    PaisImagen.Visible = true;
                    Img1.Visible = true;
                    Img2.Visible = true;
                    Price.Visible = true;
                    PaisBoton.Visible = true;
                    Imagen1Boton.Visible = true;
                    Imagen2Boton.Visible = true;
                    KilometrajeLabel.Visible = true;
                    PilotoLabel.Visible = true;
                    TanqueLabel.Visible = true;
                    AspLabel.Visible = true;
                    MarcaLabel.Visible = true;
                    BanderaLabel.Visible = true;
                    Imagen1Label.Visible = true;
                    Imagen2Label.Visible = true;
                    PrecioLabel.Visible = true;

                    break;
                case 3:
                    KilometrajeAuto.Visible = false;
                    PilotoAuto.Visible = false;
                    TanqueAuto.Visible = false;
                    Aspiracion.Visible = false;
                    Marca.Visible = false;
                    PaisImagen.Visible = false;
                    Img1.Visible = false;
                    Img2.Visible = false;
                    Price.Visible = false;
                    PaisBoton.Visible = false;
                    Imagen1Boton.Visible = false;
                    Imagen2Boton.Visible = false;
                    KilometrajeLabel.Visible = false;
                    PilotoLabel.Visible = false;
                    TanqueLabel.Visible = false;
                    AspLabel.Visible = false;
                    MarcaLabel.Visible = false;
                    BanderaLabel.Visible = false;
                    Imagen1Label.Visible = false;
                    Imagen2Label.Visible = false;
                    PrecioLabel.Visible = false;

                    Img3.Visible = true;
                    Img4.Visible = true;
                    Img5.Visible = true;
                    Img6.Visible = true;
                    Imagen3Boton.Visible = true;
                    Imagen4Boton.Visible = true;
                    Imagen5Boton.Visible = true;
                    Imagen6Boton.Visible = true;
                    Imagen3Label.Visible = true;
                    Imagen4Label.Visible = true;
                    Imagen5Label.Visible = true;
                    Imagen6Label.Visible = true;
                    TorqueAuto.Visible = true;
                    TorqueLabel.Visible = true;
                    Agregar.Visible = true;
                    break;
                default:
                    contador = 1;
                    break;
            }
        }
        

        

        private void PaisBoton_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarBandera, PaisImagen);
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
            CargarOpen(CargarImagen3, Img3);
        }
        private void Imagen4Boton_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagen4, Img4);
        }
        private void Imagen5Boton_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagen5, Img5);
        }
        private void Imagen6Boton_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagen6, Img6);
        }

        private void PesoAuto_Leave(object sender, EventArgs e)
        {
            if (PesoAuto.Text!="" && HpAuto.Text!="")
            {
                double Kg = double.Parse(PesoAuto.Text);
                double Hp = double.Parse(HpAuto.Text);
                double pp = Kg / Hp;
                PPAuto.Text = pp.ToString("0.00");
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (NombreAuto.Text!=""&&AnioAuto.Text!=""&& PaisAuto.Text!=""&&TraccionAuto.Text != "" && CategoriaAuto.Text != "" && PPAuto.Text != "" && HpAuto.Text != "" && PesoAuto.Text != "" && TopSpeedAuto.Text != "" 
                && KilometrajeAuto.Text != "" && TanqueAuto.Text != "" && PilotoAuto.Text != "" && Aspiracion.Text != "" && Marca.Text != "" && PaisImagen.Text != "" && Img1.Text != "" && Img2.Text != "" && Img3.Text != "" 
                && Img4.Text != "" && Img5.Text != "" && Img6.Text != "" && Price.Text!="" && TorqueAuto.Text!="")
            {
                if (aux == null)
                {
                    Autos aux2 = new Autos();
                    int marcaId = (int)Marca.SelectedValue;
                    aux2.NombreModelo = NombreAuto.Text;
                    aux2.Anio = int.Parse(AnioAuto.Text);
                    aux2.PaisFabricacion = PaisImagen.Text;
                    aux2.Traccion = TraccionAuto.Text;
                    aux2.Categoria = CategoriaAuto.Text;
                    aux2.RelacionPesoPotencia = double.Parse(PPAuto.Text);
                    aux2.HP = int.Parse(HpAuto.Text);
                    aux2.Torque = int.Parse(TorqueAuto.Text);
                    aux2.Peso = int.Parse(PesoAuto.Text);
                    aux2.TopSpeed = double.Parse(TopSpeedAuto.Text);
                    aux2.Kilometraje = int.Parse(KilometrajeAuto.Text);
                    aux2.Tanque = int.Parse(TanqueAuto.Text);
                    aux2.Piloto = PilotoAuto.Text;
                    aux2.Aspiracion = Aspiracion.Text;
                    aux2.MarcaAuto.IdMarca = marcaId;
                    aux2.ImagenAuto = Img1.Text;
                    aux2.ImagenAutoSecundaria = Img2.Text;
                    aux2.ImagenAutoTres = Img3.Text;
                    aux2.ImagenAutoCuatro = Img4.Text;
                    aux2.ImagenAutoCinco = Img5.Text;
                    aux2.ImagenVenta = Img6.Text;
                    aux2.Precio = int.Parse(Price.Text);
                    NegocioBaseDatos negociobd = new NegocioBaseDatos();
                    negociobd.AgregarAutos(aux2);
                    MessageBox.Show("Agregado Con Exito");
                }

                else
                {
                    int marcaId = (int)Marca.SelectedValue;
                    aux.NombreModelo = NombreAuto.Text;
                    aux.Anio = int.Parse(AnioAuto.Text);
                    aux.PaisFabricacion = PaisImagen.Text;
                    aux.Traccion = TraccionAuto.Text;
                    aux.Categoria = CategoriaAuto.Text;
                    aux.RelacionPesoPotencia = double.Parse(PPAuto.Text);
                    aux.HP = int.Parse(HpAuto.Text);
                    aux.Torque = int.Parse(TorqueAuto.Text);
                    aux.Peso = int.Parse(PesoAuto.Text);
                    aux.TopSpeed = double.Parse(TopSpeedAuto.Text);
                    aux.Kilometraje = int.Parse(KilometrajeAuto.Text);
                    aux.Tanque = int.Parse(TanqueAuto.Text);
                    aux.Piloto = PilotoAuto.Text;
                    aux.Aspiracion = Aspiracion.Text;
                    aux.MarcaAuto.IdMarca = marcaId;
                    aux.ImagenAuto = Img1.Text;
                    aux.ImagenAutoSecundaria = Img2.Text;
                    aux.ImagenAutoTres = Img3.Text;
                    aux.ImagenAutoCuatro = Img4.Text;
                    aux.ImagenAutoCinco = Img5.Text;
                    aux.ImagenVenta = Img6.Text;
                    aux.Precio = int.Parse(Price.Text);
                    NegocioBaseDatos negociobd = new NegocioBaseDatos();
                    negociobd.ModAutos(aux);
                    MessageBox.Show("Modificado Con Exito");
                }

                Close();
            }

            else
            {
                MessageBox.Show("Quedan Campos por cargar!");
            }
        }

    }
}
