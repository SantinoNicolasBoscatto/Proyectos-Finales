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
    public partial class CargaPilotos : Form
    {
        readonly OpenFileDialog CargarImagenPiloto = new OpenFileDialog();
        readonly OpenFileDialog CargarImagenBandera = new OpenFileDialog();
        readonly OpenFileDialog CargarImagenAuto = new OpenFileDialog();
        readonly OpenFileDialog CargarImagenAuto2 = new OpenFileDialog();
        readonly OpenFileDialog CargarImagenAuto3 = new OpenFileDialog();
        readonly OpenFileDialog CargarImagenAuto4 = new OpenFileDialog();
        
        public CargaPilotos()
        {
            InitializeComponent();
            RankingBox.Items.Add("Rookie");
            RankingBox.Items.Add("Junior");
            RankingBox.Items.Add("Amateur");
            RankingBox.Items.Add("Semi-Pro");
            RankingBox.Items.Add("Profesional");
            RankingBox.Items.Add("Estrella");
            RankingBox.Items.Add("Leyenda");
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void VictoriaBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Esto evitará que se escriban caracteres no numéricos.
            }
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
        bool botonMasBandera = true;
        private void MasBoton_Click(object sender, EventArgs e)
        {
            if (botonMasBandera)
            {
                MostrarOcultar(false);
                botonMasBandera = false;
                Agregar.Visible = true;
            }
            else
            {
                MostrarOcultar(true);
                botonMasBandera = true;
            }
            
        }

        private void MostrarOcultar(bool tf)
        {
            NombreLabel.Visible = tf;
            NombreBox.Visible = tf;
            ApodoBox.Visible = tf;
            ApodoLabel.Visible = tf;
            AlturaBox.Visible = tf;
            AlturaLabel.Visible = tf;
            PesoBox.Visible = tf;
            PesoLabel.Visible = tf;
            EquipoBox.Visible = tf;
            EquipoLabel.Visible = tf;
            VictoriaBox.Visible = tf;
            VictoriasLabel.Visible = tf;
            DerrotasBox.Visible = tf;
            DerrotasLabel.Visible = tf;
            WinRateBox.Visible = tf;
            WinRateLabel.Visible = tf;
            RankingBox.Visible = tf;
            RankingLabel.Visible = tf;
            RivalBox.Visible = tf;
            RivalLabel.Visible = tf;
            BioBox.Visible = tf;
            BioLabel.Visible = tf;
            FotoPilotoBox.Visible = tf;
            FotoPilotoLabel.Visible = tf;
            FotoBandera.Visible = tf;
            FotoBanderaLabel.Visible = tf;
            FotoAuto1.Visible = tf;
            FotoAutoLabel1.Visible = tf;
            FotoAuto2.Visible = tf;
            FotoAutoLabel2.Visible = tf;
            FotoAuto3.Visible = tf;
            FotoAutoLabel3.Visible = tf;
            CargarAuto1.Visible = tf;
            CargarAuto2.Visible = tf;
            CargarAuto3.Visible = tf;
            CargarPiloto.Visible = tf;
            CargarBandera.Visible = tf;
            CorneringBox.Visible = !tf;
            CorneringLabel.Visible = !tf;
            BrakingBox.Visible = !tf;
            BrakingLabel.Visible = !tf;
            ReflexesBox.Visible = !tf;
            ReflexesLabel.Visible = !tf;
            TyresManagementBox.Visible = !tf;
            TyresManagementLabel.Visible = !tf;
            OvertakingBox.Visible = !tf;
            OvertakingLabel.Visible = !tf;
            DefendingBox.Visible = !tf;
            DefendingLabel.Visible = !tf;
            RainBox.Visible = !tf;
            RainLabel.Visible = !tf;
            ConcentrationBox.Visible = !tf;
            ConcentrationLabel.Visible = !tf;
            PressureBox.Visible = !tf;
            PressureLabel.Visible = !tf;
            ExperienceBox.Visible = !tf;
            ExperienceLabel.Visible = !tf;
            AgressiveBox.Visible = !tf;
            AgressiveLabel.Visible = !tf;
            PaceLabel.Visible = !tf;
            PaceBox.Visible = !tf;
            OverallBox.Visible = !tf;
            OverallLabel.Visible = !tf;
            FotoAuto4.Visible = !tf;
            FotoAutoLabel4.Visible = !tf;
            CargarAuto4.Visible = !tf;
            EdadBox.Visible = !tf;
            EdadLabel.Visible = !tf;

        }

        private void CargaPilotos_Load(object sender, EventArgs e)
        {
            MostrarOcultar(true);
            PanelFondo.Parent = this;
            this.Size = PanelFondo.Size;
            PanelFondo.BackColor = Color.FromArgb(150, 150, 150, 150);
            CargarImagenPiloto.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagenBandera.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagenAuto.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagenAuto2.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagenAuto3.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
            CargarImagenAuto4.Filter = "Archivos JPG|*.jpg|Archivos PNG|*.png";
        }
        private void CargarOpen(OpenFileDialog aux, TextBox auxT)
        {
            if (aux.ShowDialog() == DialogResult.OK)
            {
                string filePath = aux.FileName;
                auxT.Text = filePath;
            }
        }
        private void CargarPiloto_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagenPiloto, FotoPilotoBox);
        }
        private void CargarBandera_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagenBandera, FotoBandera);
        }
        private void CargarAuto4_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagenAuto4, FotoAuto4);
        }
        private void CargarAuto3_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagenAuto3, FotoAuto3);
        }
        private void CargarAuto2_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagenAuto2, FotoAuto2);
        }
        private void CargarAuto1_Click(object sender, EventArgs e)
        {
            CargarOpen(CargarImagenAuto, FotoAuto1);
        }
        private void VictoriaBox_Leave(object sender, EventArgs e)
        {
            if (VictoriaBox.Text != "" && DerrotasBox.Text != "")
            {
                double v = double.Parse(VictoriaBox.Text);
                double d = double.Parse(DerrotasBox.Text);
                double t = v + d;
                double wr = v/t*100;
                WinRateBox.Text = wr.ToString("0.00");
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (NombreBox.Text != "" && ApodoBox.Text != "" && AlturaBox.Text != "" && PesoBox.Text != "" && VictoriaBox.Text != "" && DerrotasBox.Text != "" && WinRateBox.Text != "" && RankingBox.Text != "" && RivalBox.Text != "" &&
                BioBox.Text != "" && FotoPilotoBox.Text != "" && FotoBandera.Text != "" && FotoAuto1.Text != "" && FotoAuto2.Text != "" && FotoAuto3.Text != "" && FotoAuto4.Text != "" && CorneringBox.Text != "" && BrakingBox.Text != "" &&
                ReflexesBox.Text != "" && TyresManagementBox.Text != "" && OvertakingBox.Text != "" && DefendingBox.Text != "" && RainBox.Text != "" && ConcentrationBox.Text != "" && PressureBox.Text != "" && ExperienceBox.Text != "" &&
                AgressiveBox.Text != "" && PaceBox.Text != "" && OverallBox.Text != "" && EdadBox.Text != "")
            {
                Pilotos aux = new Pilotos
                {
                    NombrePiloto = NombreBox.Text,
                    Apodo = ApodoBox.Text,
                    Equipo = EquipoBox.Text,
                    Altura = AlturaBox.Text,
                    Peso = PesoBox.Text,
                    Victorias = int.Parse(VictoriaBox.Text),
                    Derrotas = int.Parse(DerrotasBox.Text),
                    CantidadDeCarreras = int.Parse(VictoriaBox.Text) + int.Parse(DerrotasBox.Text),
                    PorcentajeCarrerasGanadas = double.Parse(WinRateBox.Text),
                    Ranking = RankingBox.Text,
                    Rival = RivalBox.Text,
                    Biografia = BioBox.Text,
                    Foto = FotoPilotoBox.Text,
                    Nacionalidad = FotoBandera.Text,
                    Auto = FotoAuto1.Text,
                    AutoAtras = FotoAuto2.Text,
                    AutoFrontal = FotoAuto3.Text,
                    AutoDriving = FotoAuto4.Text,
                    Cornering = int.Parse(CorneringBox.Text),
                    Braking = int.Parse(BrakingBox.Text),
                    Reflexes = int.Parse(ReflexesBox.Text),
                    TyresManagement = int.Parse(TyresManagementBox.Text),
                    Overtaking = int.Parse(OvertakingBox.Text),
                    Defending = int.Parse(DefendingBox.Text),
                    RainHability = int.Parse(RainBox.Text),
                    Concentracion = int.Parse(ConcentrationBox.Text),
                    ManejoPresion = int.Parse(PressureBox.Text),
                    Experiencia = int.Parse(ExperienceBox.Text),
                    Agresividad = int.Parse(AgressiveBox.Text),
                    Pace = int.Parse(PaceBox.Text),
                    Overall = int.Parse(OverallBox.Text),
                    Edad = int.Parse(EdadBox.Text),
                };
                NegocioBaseDatos negociobd = new NegocioBaseDatos();
                negociobd.AgregarPilotos(aux);
                MessageBox.Show("Piloto agregado Con Exito");
                Close();
            }

            else
            {
                MessageBox.Show("Faltan Cargar Datos");
            }
        }
    }
}
