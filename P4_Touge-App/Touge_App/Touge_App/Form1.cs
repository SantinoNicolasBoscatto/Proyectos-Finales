using System;
using NAudio.Wave;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Modelo_Clases;
using Negocio_Base_Datos;
using System.Globalization;

namespace Touge_App
{
    public partial class TougeForms : Form
    {
        private WaveOutEvent waveOutDevice = new WaveOutEvent();
        private AudioFileReader audioFile;
        NegocioBaseDatos negocioBD = new NegocioBaseDatos();
        List<Musica> listaCanciones;
        private Size initialSize;
        DateTime fechaManager;
        string Formato;
        Fecha fechaAux;
        DateTime CambioMes;
        bool Alquilando;
        int CasaAlquilada;
        NegocioBaseDatos negocioAlquiler = new NegocioBaseDatos();
        NegocioBaseDatos Dinero = new NegocioBaseDatos();
        Economia miDinero = new Economia(); 
        List<Alquiler> listaAlquiler = new List<Alquiler>();
        string Player = "Santino Boscatto";

        public TougeForms()
        {
            InitializeComponent();
            
            initialSize = this.ClientSize;
            this.Resize += TougeForms_Resize;
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.MidnightBlue;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            historialDGV.ColumnHeadersDefaultCellStyle = headerStyle;
            historialDGV.ColumnHeadersDefaultCellStyle = headerStyle;
            historialDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            historialDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn columna in historialDGV.Columns)
            {
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            historialDGV.RowHeadersWidth = 4;
        }
        bool banderaSize = false;
        private void TougeForms_Resize(object sender, EventArgs e)
        {
            // Obtener el tamaño actual del formulario
            Size currentSize = this.ClientSize;

            // Comparar el tamaño actual con el tamaño inicial
            if (currentSize.Width > initialSize.Width || currentSize.Height > initialSize.Height)
            {
                banderaSize = true;
                PilotoLabel.Location = new Point(145, 480);
                NombrePilotoLabel.Parent = FichaTecnicaPb;
                NombrePilotoLabel.Location = new Point(8, 535);
            }
            else
            {
                Cornering.Location = new Point(48, 42);
                Braking.Location = new Point(155, 42);
                Reflexes.Location = new Point(262, 42);
                Pressure.Location = new Point(43, 149);
                Experience.Location = new Point(155, 149);
                Pace.Location = new Point(262, 149);
                Tyres.Location = new Point(43, 255);
                Agressiveness.Location = new Point(155, 255);
                Overtaking.Location = new Point(262, 255);
                Concentration.Location = new Point(45, 354);
                Rain.Location = new Point(155, 354);
                Defending.Location = new Point(262, 354);
                Overall.Location = new Point(465, 308);
                banderaSize = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Cargo La base de datos de canciones
            listaCanciones = negocioBD.DevolverCanciones();
            //Pido Un numero Random para reproducir alguna Cancion
            indexMusica = RandomNumero();  
            //Me susvcribo al evento de parar la musica
            waveOutDevice.PlaybackStopped += WaveOutDevice_PlaybackStopped;
            //Creo el AudioFile para reproducir y reproduzco
            audioFile = new AudioFileReader(listaCanciones[indexMusica].CancionURL);
            IniciarMusica(ref audioFile);   
            //Suscribo al evento del cambio de valor del volumen
            VolumenControl.ValueChanged += VolumenControl_ValueChanged;
            //Trasparento Botones
            Trasparentado(CloseBoton, ConfiguracionBoton);
            //Pido un Fondo Random
            RandomFondo();
            //Inicio en Segunda pantalla si hay
            Screen secondScreen = Screen.AllScreens.Length > 1 ? Screen.AllScreens[1] : Screen.PrimaryScreen;
            Location = secondScreen.Bounds.Location;
            //DAY
            NegocioBaseDatos negocioFecha = new NegocioBaseDatos();
            fechaAux = negocioFecha.DevolverFecha();
            CambioMes = fechaAux.FechaManager;
            FormatearFecha(fechaAux);
            NegocioBaseDatos alquilerBDManager = new NegocioBaseDatos();
            Alquilando = alquilerBDManager.LeerBanderaAlquiler();
            CasaAlquilada = alquilerBDManager.LeerCasaAlquilada();
            estadoFacturas = alquilerBDManager.LeerBanderaFacturas();
            listaAlquiler = negocioAlquiler.DevolverAlquiler(true, CasaAlquilada);
            miDinero.MiDinero = Dinero.DevolverDinero();
            MessageBox.Show("Tu Dinero es: " + miDinero.MiDinero);
            alquileres1.ButtonClick += MiUserControl_ButtonClick;
            alquileres2.ButtonClick += MiUserControl2_ButtonClick;
            ShopPanel1.ButtonClick += ShopPanel1_ButtonClick; ShopPanel2.ButtonClick += ShopPanel2_ButtonClick; ShopPanel3.ButtonClick += ShopPanel3_ButtonClick; ShopPanel4.ButtonClick += ShopPanel4_ButtonClick; ShopPanel5.ButtonClick += ShopPanel5_ButtonClick; ShopPanel6.ButtonClick += ShopPanel6_ButtonClick; ShopPanel7.ButtonClick += ShopPanel7_ButtonClick;ShopPanel8.ButtonClick += ShopPanel8_ButtonClick;
            listaRopa = negocioRopa.DevolverRopa();
            listaMuebles = negocioMuebles.DevolverMuebles();
            listaElectro = negocioElectro.DevolverElectros();
            if (!Alquilando)
            {
                Ocultar();
                MessageBox.Show("Debe Pagar el Alquiler Moroso!");
                PaginaUnoAlquiler();
                VolverBoton.Visible = false;
            }
            if (!estadoFacturas)
            {
                Ocultar();
                MessageBox.Show("Debe Pagar Sus Facturas Moroso!");
                MostrarFacturas();
                VolverBoton.Visible = false;
            }
            PictureBox pb = new PictureBox();
           // pb.Size = PictureBoxBack.Size;
            //pb.Visible = true;
            //pb.Parent = PictureBoxBack;
            //pb.Location = new Point (0, 0);
        }

        private void FormatearFecha(Fecha aux)
        {
            fechaManager = DateTime.Parse(aux.FechaManager.ToString());
            Formato = fechaManager.ToString("dd/MM/yy", CultureInfo.InvariantCulture);
            dateTimePicker1.Value = fechaAux.FechaManager;

        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            Size newResolution = ClientSize;          
        }

        //Aca se Valida mediante un bool cuando el Mouse entra o sale de los botones y el evento de repintado

        bool HoverBotonBD = false;
        private void HoverBoton_MouseEnter(object sender, EventArgs e)
        { HoverBotonBD = true;
        }
        private void HoverBoton_MouseLeave(object sender, EventArgs e)
        { HoverBotonBD = false;
        }
        private void BotonPistas_Paint(object sender, PaintEventArgs e)
        { RepintadoBotones(HoverBotonBD, e, BotonPistas); }

        //Lo mismo pero con el Boton Autos

        bool HoverAutosBD = false;
        private void AutosBoton_MouseEnter(object sender, EventArgs e)
        {
            HoverAutosBD = true;
        }
        private void AutosBoton_MouseLeave(object sender, EventArgs e)
        {
            HoverAutosBD = false;
        }
        private void AutosBoton_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverAutosBD, e, AutosBoton);
        }

        //Lo mismo pero con el Boton Piloto

        bool HoverDriversBD = false;
        private void PilotosBoton_MouseEnter(object sender, EventArgs e)
        {
            HoverDriversBD = true;
        }
        private void PilotosBoton_MouseLeave(object sender, EventArgs e)
        {
            HoverDriversBD = false;
        }
        private void PilotosBoton_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverDriversBD, e, PilotosBoton);
        }

        //Lo mismo pero con el Boton Close

        bool HoverClose = false;
        private void CloseBoton_MouseEnter(object sender, EventArgs e)
        {
            HoverClose = true;
        }
        private void CloseBoton_MouseLeave(object sender, EventArgs e)
        {
            HoverClose = false;
        }
        private void CloseBoton_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverClose, e, CloseBoton);
        }

        // Lo mismo Con el boton Reglas

        bool HoverRulesBD = false;
        private void ReglasBoton_MouseEnter(object sender, EventArgs e)
        {
            HoverRulesBD = true;
        }
        private void ReglasBoton_MouseLeave(object sender, EventArgs e)
        {
            HoverRulesBD = false;
        }
        private void ReglasBoton_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverRulesBD, e, ReglasBoton);
        }

        // Idem

        bool HoverHistorialBD = false;
        private void HistorialBoton_MouseEnter(object sender, EventArgs e)
        {
            HoverHistorialBD = true;
            
        }
        private void HistorialBoton_MouseLeave(object sender, EventArgs e)
        {
            HoverHistorialBD = false;
        }
        private void HistorialBoton_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverHistorialBD, e, HistorialBoton);
        }

        // Idem

        bool HoverEconomiaBD = false;
        private void EconomiaBoton_MouseEnter(object sender, EventArgs e)
        {
            HoverEconomiaBD = true;
        }
        private void EconomiaBoton_MouseLeave(object sender, EventArgs e)
        {
            HoverEconomiaBD = false;
        }
        private void EconomiaBoton_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverEconomiaBD, e, EconomiaBoton);
        }

        // Idem

        bool HoverConfiguracion = false;     
        private void ConfiguracionBoton_MouseEnter(object sender, EventArgs e)
        {
            HoverConfiguracion = true;
        }
        private void ConfiguracionBoton_MouseLeave(object sender, EventArgs e)
        {
            HoverConfiguracion = false;
        }
        private void ConfiguracionBoton_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverConfiguracion, e, ConfiguracionBoton);
        }


        //Visibilidad de la barra de volumen
        bool BarraManager = true;
        private void ConfiguracionBoton_Click(object sender, EventArgs e)
        {
            if (BarraManager)
            {
                VolumenControl.Visible = true;
                NextBoton.Visible = true;
                BackBoton.Visible = true;
                BarraManager = false;
            }
            else
            {
                VolumenControl.Visible = false;
                NextBoton.Visible = false;
                BackBoton.Visible = false;
                BarraManager = true;
            }
        }

        //Cerrar Forms
        private void CloseBoton_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Mouse Mover
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

        //FUNCIONES
        private void RepintadoBotones(bool bandera, PaintEventArgs e, Button Boton)
        {
            if (bandera)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(128, Color.White)))
                {
                    e.Graphics.FillRectangle(brush, Boton.ClientRectangle);
                }
            }
        }

        // Trasparentar Los Botones
        private void Trasparentado(Button Boton, Button Boton2)
        {
            Boton.BackColor = Color.Transparent;
            Boton.Parent = PictureBoxBack;
            Boton.Visible = true;
            Boton2.BackColor = Color.Transparent;
            Boton2.Parent = PictureBoxBack;
            Boton2.Visible = true;
            NextDriver.BackColor = Color.Transparent;
            NextDriver.Parent = PictureBoxBack;
            BackDriver.BackColor = Color.Transparent;
            BackDriver.Parent = PictureBoxBack;
            BotonPistas.Parent = PictureBoxBack;
            AutosBoton.Parent = PictureBoxBack;
            EconomiaBoton.Parent = PictureBoxBack;
            HistorialBoton.Parent = PictureBoxBack;
            ReglasBoton.Parent = PictureBoxBack;
            PilotosBoton.Parent = PictureBoxBack;
            NextBoton.BackColor = Color.Transparent;
            NextBoton.Parent = PictureBoxBack;
            NextBoton.Visible = false;
            NextBoton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            NextBoton.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            BackBoton.BackColor = Color.Transparent;
            BackBoton.Parent = PictureBoxBack;
            BackBoton.Visible = false;
            BackBoton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            BackBoton.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            VolverBoton.BackColor = Color.Transparent;
            VolverBoton.Parent = PictureBoxBack;
            VolverBoton.Visible = true;
            PistaPictureBox.Parent = PictureBoxBack;
            PistasBiografia.Parent = PictureBoxBack; 
            NombreCircuito.Parent = PictureBoxBack;
            DistanciaTextbox.Parent = PictureBoxBack;
            PaisTextBox.Parent = PictureBoxBack;
            ModalidadTextBox.Parent = PictureBoxBack;
            SiguientePistaBoton.BackColor = Color.Transparent;
            SiguientePistaBoton.Parent = PictureBoxBack;
            AnteriorPistaBoton.BackColor = Color.Transparent;
            AnteriorPistaBoton.Parent = PictureBoxBack;
            SiguientePistaBoton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            SiguientePistaBoton.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            AnteriorPistaBoton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            AnteriorPistaBoton.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            PilotosPictureBox.Parent = PictureBoxBack;
            AutoPilotoPictureBox.Parent = PictureBoxBack;
            PaisPictureBox.Parent = PictureBoxBack;
            BiografiaPilotosTextBox.Parent = PictureBoxBack;
            VolumenControl.Parent = PictureBoxBack;
            Cornering.BackColor = Color.Transparent;
            Cornering.Parent = PilotosPictureBox;
            Cornering.Location = new Point(48, 42);
            Braking.BackColor = Color.Transparent;
            Braking.Parent = PilotosPictureBox;
            Braking.Location = new Point(155, 42);
            Reflexes.BackColor = Color.Transparent;
            Reflexes.Parent = PilotosPictureBox;
            Reflexes.Location = new Point(262, 42);
            Pressure.BackColor = Color.Transparent;
            Pressure.Parent = PilotosPictureBox;
            Pressure.Location = new Point(43, 149);
            Experience.BackColor = Color.Transparent;
            Experience.Parent = PilotosPictureBox;
            Experience.Location = new Point(155, 149);
            Pace.BackColor = Color.Transparent;
            Pace.Parent = PilotosPictureBox;
            Pace.Location = new Point(262, 149);
            Tyres.BackColor = Color.Transparent;
            Tyres.Parent = PilotosPictureBox;
            Tyres.Location = new Point(43, 255);
            Agressiveness.BackColor = Color.Transparent;
            Agressiveness.Parent = PilotosPictureBox;
            Agressiveness.Location = new Point(155, 255);
            Overtaking.BackColor = Color.Transparent;
            Overtaking.Parent = PilotosPictureBox;
            Overtaking.Location = new Point(262, 255);
            Concentration.BackColor = Color.Transparent;
            Concentration.Parent = PilotosPictureBox;
            Concentration.Location = new Point(45, 354);
            Rain.BackColor = Color.Transparent;
            Rain.Parent = PilotosPictureBox;
            Rain.Location = new Point(155, 354);
            Defending.BackColor = Color.Transparent;
            Defending.Parent = PilotosPictureBox;
            Defending.Location = new Point(262, 354);
            Overall.BackColor = Color.Transparent;
            Overall.Parent = PilotosPictureBox;
            Overall.Location = new Point(465, 308);
            NombrePilotoTextBox.Parent = PilotosPictureBox;
            NombrePilotoTextBox.Location = new Point(118, 490);
            ApodoTextBox.Parent = PilotosPictureBox;
            ApodoTextBox.Location = new Point(118, 525);
            EquipoTextBox.Parent = PilotosPictureBox;
            EquipoTextBox.Location = new Point(118, 560);
            RivalTextBox.Parent = PilotosPictureBox;
            RivalTextBox.Location = new Point(118, 590);
            EdadTextBox.Parent = PilotosPictureBox;
            EdadTextBox.Location = new Point(433, 488);
            AlturaTextBox.Parent = PilotosPictureBox;
            AlturaTextBox.Location = new Point(430, 527);
            PesoTextBox.Parent = PilotosPictureBox;
            PesoTextBox.Location = new Point(430, 562);
            VictoriaTextBox.Parent = PilotosPictureBox;
            VictoriaTextBox.Location = new Point(612, 492);
            DerrotaTextBox.Parent = PilotosPictureBox;
            DerrotaTextBox.Location = new Point(612, 525);
            WinRateTextBox.Parent = PilotosPictureBox;
            WinRateTextBox.Location = new Point(612, 558);
            TotalTextBox.Parent = PilotosPictureBox;
            TotalTextBox.Location = new Point(612, 590);
            BanderasPictureBox.Parent = PictureBoxBack;
            AutosPictureBox.Parent = PictureBoxBack;
            NombreAutoTextbox.Parent = PictureBoxBack;
            BackAuto.BackColor = Color.Transparent;
            BackAuto.Parent = PictureBoxBack;
            NextAuto.BackColor = Color.Transparent;
            NextAuto.Parent = PictureBoxBack;
            BackAuto.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            BackAuto.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            NextAuto.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            NextAuto.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            VolverBoton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            VolverBoton.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            MarcaPictureBox.BackColor = Color.Transparent;
            MarcaPictureBox.Parent = AutosPictureBox;
            MarcaPictureBox.Location = new Point(810, 20);
            TorqueLabel.Parent = FichaTecnicaPb;
            TorqueLabel.Location = new Point(240, 10);
            NmLabel.Parent = FichaTecnicaPb;
            NmLabel.Location = new Point(235, 60); 
            PesoLabel.Parent = FichaTecnicaPb;
            PesoLabel.Location = new Point(280, 140);
            KgLabel.Parent = FichaTecnicaPb;
            KgLabel.Location = new Point(250, 180);
            CategoriaLabel.Parent = FichaTecnicaPb;
            CategoriaLabel.Location = new Point(245, 260);
            CatLabel.Parent = FichaTecnicaPb;
            CatLabel.Location = new Point(285, 295);
            TopSpeedLabel.Parent = FichaTecnicaPb;
            TopSpeedLabel.Location = new Point(225, 360);
            TopLabel.Parent = FichaTecnicaPb;
            TopLabel.Location = new Point(225, 400);
            AnioLabel.Parent = FichaTecnicaPb;
            AnioLabel.Location = new Point(55, 10);
            YearLabel.Parent = FichaTecnicaPb;
            YearLabel.Location = new Point(33, 60);
            PotenciaLabel.Parent = FichaTecnicaPb;
            PotenciaLabel.Location = new Point(30, 140);
            HpLabel.Parent = FichaTecnicaPb;
            HpLabel.Location = new Point(40, 180);
            PesoPotenciaLabel.Parent = FichaTecnicaPb;
            PesoPotenciaLabel.Location = new Point(52, 260);
            KgHp.Parent = FichaTecnicaPb;
            KgHp.Location = new Point(0, 300);
            KilometrosLabel.Parent = FichaTecnicaPb;
            KilometrosLabel.Location = new Point(25, 365);
            KmLabel.Parent = FichaTecnicaPb;
            KmLabel.Location = new Point(20, 400);
            PilotoLabel.Parent = FichaTecnicaPb;
            PilotoLabel.Location = new Point(145, 448);
            NombrePilotoLabel.Parent = FichaTecnicaPb;
            NombrePilotoLabel.Location = new Point(8, 505);
            FLabel.Parent = PictureBoxBack;
            ELabel.Parent = PictureBoxBack;
            DLabel.Parent = PictureBoxBack;
            CLabel.Parent = PictureBoxBack;
            Blabel.Parent = PictureBoxBack;
            ALabel.Parent = PictureBoxBack;
            SLabel.Parent = PictureBoxBack;
            SPlusLabel.Parent = PictureBoxBack;
            FTextbox.Parent = PictureBoxBack;
            ETextbox.Parent = PictureBoxBack;
            DTextbox.Parent = PictureBoxBack;
            CTextbox.Parent = PictureBoxBack;
            BTextbox.Parent = PictureBoxBack;
            ATextbox.Parent = PictureBoxBack;
            STextbox.Parent = PictureBoxBack;
            SPlusTextbox.Parent = PictureBoxBack;
            CategoriaTitulo.Parent = PictureBoxBack;
            ModalidadesTitulo.Parent = PictureBoxBack;
            GatoTitulo.Parent = PictureBoxBack;
            GatoTextbox.Parent = PictureBoxBack;
            SideTextBox.Parent = PictureBoxBack;
            SideTitulo.Parent = PictureBoxBack;
            SubitaTextBox.Parent = PictureBoxBack;
            SubitaTitulo.Parent = PictureBoxBack;
            RandomTitulo.Parent = PictureBoxBack;
            AletorioTextBox.Parent = PictureBoxBack;
            NextModalidad.Parent = PictureBoxBack;
            BackModalidad.Parent = PictureBoxBack;
            RookieLabel.Parent = PictureBoxBack;
            RookieTextBox.Parent = PictureBoxBack;
            JuniorLabel.Parent = PictureBoxBack;
            JuniorTextBox.Parent = PictureBoxBack;
            AmateurLabel.Parent = PictureBoxBack;
            AmateurTextBox.Parent = PictureBoxBack;
            SemiProLabel.Parent = PictureBoxBack;
            SemiProTextBox.Parent = PictureBoxBack;
            ProfesionalLabel.Parent = PictureBoxBack;
            ProfesionalTextbox.Parent = PictureBoxBack;
            EstrellaLabel.Parent = PictureBoxBack;
            EstrellaTextBox.Parent = PictureBoxBack;
            LeyendaLabel.Parent = PictureBoxBack;
            LeyendaTextBox.Parent = PictureBoxBack;
            PromocionLabel.Parent = PictureBoxBack;
            PromocionTextBox.Parent = PictureBoxBack;
            RankingPilotosLabel.Parent = PictureBoxBack;
            BackRanking.Parent = PictureBoxBack;
            NextRanking.Parent = PictureBoxBack;
            BackModalidad.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            BackModalidad.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            NextModalidad.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            NextModalidad.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 50, 50, 50);
            BackRanking.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            BackRanking.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            NextRanking.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            NextRanking.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            BackEconomia.Parent = PictureBoxBack;
            NextEconomia.Parent = PictureBoxBack;
            BackEconomia.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            BackEconomia.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            NextEconomia.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            NextEconomia.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            ComidaPictureBox.Parent = PictureBoxBack;
            AlquilerPictureBox.Parent = PictureBoxBack;
            FacturasPictureBox.Parent = PictureBoxBack;
            RopaPictureBox.Parent = PictureBoxBack;
            MueblesPictureBox.Parent = PictureBoxBack;
            ElectroPictureBox.Parent = PictureBoxBack;
            MecanicoPictureBox.Parent = PictureBoxBack;
            GastosVariosPictureBox.Parent = PictureBoxBack;
            CarDealerPictureBox.Parent = PictureBoxBack;
            HigienePictureBox.Parent = PictureBoxBack;
            GarajePictureBox.Parent = PictureBoxBack;
            AhorrosPictureBox.Parent = PictureBoxBack;
            FiltrosLabel.Parent = PictureBoxBack;
            CampoLabel.Parent = PictureBoxBack;
            CriterioLabel.Parent = PictureBoxBack;
            FiltroBusquedaLabel.Parent = PictureBoxBack;
            VolverAlquiler.Parent = PictureBoxBack;
            SiguienteAlquiler.Parent = PictureBoxBack;
            NextRopaMuebleTecno.Parent = PictureBoxBack;
            BackRopaMuebleTecno.Parent = PictureBoxBack;
            BackRopaMuebleTecno.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            BackRopaMuebleTecno.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            NextRopaMuebleTecno.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            NextRopaMuebleTecno.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            Servicios1.Parent = PictureBoxBack;
            Servicios2.Parent = PictureBoxBack;
            Servicios3.Parent = PictureBoxBack;
            Servicios4.Parent = PictureBoxBack;
            Servicios5.Parent = PictureBoxBack;
            PagoLabel.Parent = PictureBoxBack;
            AbonarFacturas.Parent = PictureBoxBack;
            Servicios1.BackColor = Color.FromArgb(135, 30, 30, 30);
            Servicios2.BackColor = Color.FromArgb(135, 30, 30, 30);
            Servicios3.BackColor = Color.FromArgb(135, 30, 30, 30);
            Servicios4.BackColor = Color.FromArgb(135, 30, 30, 30);
            Servicios5.BackColor = Color.FromArgb(135, 30, 30, 30);
            PagoLabel.BackColor = Color.FromArgb(135, 30, 30, 30);
        }

        //Dispara la Primera pista de Musica

        float Volumen = 0.1f;
        int indexMusica = 0;
        bool primeraVuelta = true;
        private void IniciarMusica(ref AudioFileReader Musica, bool ValueBD = true)
        {
            try
            {
                waveOutDevice.Init(Musica);
                waveOutDevice.Play();
                if (primeraVuelta)
                {
                    VolumenControl.Minimum = 0;
                    VolumenControl.Maximum = 25;
                    VolumenControl.Value = 10;
                    Musica.Volume = Volumen;
                    primeraVuelta = false;
                }
                else
                    Musica.Volume = Volumen;
                
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        //Verifica Cuando se para una cancion y segun los datos elige cual reproducir
        private void WaveOutDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {

            if (CausaStop)
            {
                audioFile.Dispose();
                
                if (indexMusica < listaCanciones.Count() - 1)
                {
                    indexMusica++;
                    audioFile = new AudioFileReader(listaCanciones[indexMusica].CancionURL);
                    IniciarMusica(ref audioFile);
                    //audioFile = new AudioFileReader(listaCanciones[indexMusica].CancionURL);                    
                    //waveOutDevice.Init(audioFile); // Asignar el nuevo archivo al WaveOutDevice
                    //audioFile.Volume = Volumen;
                    // waveOutDevice.Play();
                }
                else
                {
                    indexMusica = 0;
                    audioFile = new AudioFileReader(listaCanciones[indexMusica].CancionURL);
                    waveOutDevice.Init(audioFile); // Asignar el nuevo archivo al WaveOutDevice
                    audioFile.Volume = Volumen;
                    waveOutDevice.Play();
                }
            }
            else
            {
                CausaStop = true;
            }
                
            
        }

        //Se ejecuta cuando se cambia de valor la TrackBar
        private void VolumenControl_ValueChanged(object sender, EventArgs e)
        {
            Volumen = VolumenControl.Value/100.00f;
            audioFile.Volume = Volumen;
        }

        Random randomCancion = new Random();
        private int RandomNumero()
        {
            int RandomNumero = randomCancion.Next(listaCanciones.Count());
            return RandomNumero;
        }

        Random randomFondo = new Random();
        private void RandomFondo()
        {
            int RandomNumero = randomFondo.Next(8);
            PictureBoxBack.BackgroundImageLayout = ImageLayout.Stretch;
            switch(RandomNumero)
            {
                case 0:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/1_Fondo.gif");
                    FiltrosLabel.ForeColor = Color.Red;
                    CampoLabel.ForeColor = Color.Red;
                    CriterioLabel.ForeColor = Color.Red;
                    FiltroBusquedaLabel.ForeColor = Color.Red;
                    PistasBiografia.BackAlpha = 20;
                    break;
                case 1:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/2_Fondo.gif");
                    PistasBiografia.BackAlpha = 20;
                    break;
                case 2:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/3_Fondo.gif");
                    PistasBiografia.BackAlpha = 45;
                    break;
                case 3:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/4_Fondo.gif");
                    PistasBiografia.BackAlpha = 55;
                    break;
                case 4:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/5_Fondo.gif");
                    PistasBiografia.BackAlpha = 45;
                    break;
                case 5:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/6_Fondo.gif");
                    PistasBiografia.BackAlpha = 40;
                    break;
                case 6:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/7_Fondo.gif");
                    PistasBiografia.BackAlpha = 40;
                    break;
                case 7:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/10_Fondo.gif");
                    PistasBiografia.BackAlpha = 60;
                    break;
            }
        }

        bool CausaStop = true;
        private void NextBoton_Click(object sender, EventArgs e)
        {
            CausaStop = false;
            waveOutDevice.Stop(); // Detener la reproducción actual
            audioFile.Dispose(); // Liberar recursos del archivo actual

            if (indexMusica < listaCanciones.Count - 1)
            {
                indexMusica++;
            }
            else
            {
                indexMusica = 0;
            }
            // Cargar la nueva pista de audio
            audioFile = new AudioFileReader(listaCanciones[indexMusica].CancionURL);
            IniciarMusica(ref audioFile);
        }

        private void BackBoton_Click(object sender, EventArgs e)
        {
            CausaStop = false;
            waveOutDevice.Stop(); // Detener la reproducción actual
            audioFile.Dispose(); // Liberar recursos del archivo actual

            if (indexMusica > 0)
            {
                indexMusica--;
            }
            else
            {
                indexMusica = 0;
            }
            // Cargar la nueva pista de audio
            audioFile = new AudioFileReader(listaCanciones[indexMusica].CancionURL);
            IniciarMusica(ref audioFile);
        }

        int indexPistas = 0;
        List<Pistas> listaPistas = new List<Pistas>();
        private void Ocultar ()
        {
            BotonPistas.Visible = false;
            PilotosBoton.Visible = false;
            ReglasBoton.Visible = false;
            EconomiaBoton.Visible = false;
            HistorialBoton.Visible = false;
            AutosBoton.Visible = false;
            CloseBoton.Visible = false;
            VolverBoton.Visible = true;
            
        }
        bool EconomiaMostrar = true;
        private void OcultarEconomia()
        {
            if (ComidaPictureBox.Visible==true)
            {
                ComidaPictureBox.Visible = false;
                AlquilerPictureBox.Visible = false;
                MueblesPictureBox.Visible = false;
                RopaPictureBox.Visible = false;
                FacturasPictureBox.Visible = false;
                ElectroPictureBox.Visible = false;
                EconomiaMostrar = true;

            }
            else
            {
                AhorrosPictureBox.Visible = false;
                GastosVariosPictureBox.Visible = false;
                HigienePictureBox.Visible = false;
                GarajePictureBox.Visible = false;
                CarDealerPictureBox.Visible = false;
                MecanicoPictureBox.Visible = false;
                EconomiaMostrar = true;
            }
            NextEconomia.Visible = false;
            BackEconomia.Visible = false;
            banderaEconomiaParaMostrar = false;
            
        }

        private void BotonPistas_Click(object sender, EventArgs e)
        {
            if (true)
            {
                Ocultar();
                PistaPictureBox.Visible = true;
                NombreCircuito.Visible = true;
                DistanciaTextbox.Visible = true;
                PaisTextBox.Visible = true;
                PistasBiografia.Visible = true;
                ModalidadTextBox.Visible = true;
                DistanciaTextbox.Visible = true;
                SiguientePistaBoton.Visible = true;
                AnteriorPistaBoton.Visible = true;
               
            }
            CargaBasePistas();
            
        }

        private void CargaBasePistas()
        {
            NegocioBaseDatos negocioBd = new NegocioBaseDatos();
            listaPistas = negocioBD.DevolverPistas();
            PistaPictureBox.Load(listaPistas[indexPistas].Imagenes);
            PistasBiografia.Text = listaPistas[indexPistas].BiografiaPista;
            PaisTextBox.Text = "Ubicación: " + listaPistas[indexPistas].Pais;
            ModalidadTextBox.Text = "Modalidad: " + listaPistas[indexPistas].ModalidadPreferida;
            DistanciaTextbox.Text = "Distancia: " + listaPistas[indexPistas].Distancia;
            NombreCircuito.Text = listaPistas[indexPistas].NombrePista;
            NombreCircuito.TextAlign = HorizontalAlignment.Center;
        }

        bool banderaVolverReglas = true;
        private void VolverBoton_Click(object sender, EventArgs e)
        {
            banderaVolverReglas = true;

            if (PistaPictureBox.Visible == true)
            {
                VolverBoton.Visible = false;
                PistaPictureBox.Visible = false;
                NombreCircuito.Visible = false;
                DistanciaTextbox.Visible = false;
                PaisTextBox.Visible = false;
                PistasBiografia.Visible = false;
                ModalidadTextBox.Visible = false;
                DistanciaTextbox.Visible = false;
                SiguientePistaBoton.Visible = false;
                AnteriorPistaBoton.Visible = false;
                imagen = true;
            }
            else if(PilotosPictureBox.Visible == true)
            {
                PilotosPictureBox.Visible = false;
                BiografiaPilotosTextBox.Visible = false;
                AutoPilotoPictureBox.Visible = false;
                PaisPictureBox.Visible = false;
                NombrePilotoTextBox.Visible = false;
                ApodoTextBox.Visible = false;
                EquipoTextBox.Visible = false;
                RivalTextBox.Visible = false;
                BackDriver.Visible = false;
                NextDriver.Visible = false;
            }
            else if (BanderasPictureBox.Visible == true)
            {
                FichaTecnicaPb.Visible = false;
                NombreAutoTextbox.Visible = false;
                BanderasPictureBox.Visible = false;
                AutosPictureBox.Visible = false;
                NextAuto.Visible = false;
                BackAuto.Visible = false;
            }
            else if(ModalidadesBoton.Visible == true)
            {
                ModalidadesBoton.Visible = false;
                CategoriasBoton.Visible = false;
                RankingBoton.Visible = false;
            }

            else if (FLabel.Visible == true)
            {
                ModalidadesBoton.Visible = true;
                CategoriasBoton.Visible = true;
                RankingBoton.Visible = true;
                FLabel.Visible = false;
                ELabel.Visible = false;
                DLabel.Visible = false;
                CLabel.Visible = false;
                Blabel.Visible = false;
                ALabel.Visible = false;
                SLabel.Visible = false;
                SPlusLabel.Visible = false;
                FTextbox.Visible = false;
                ETextbox.Visible = false;
                DTextbox.Visible = false;
                CTextbox.Visible = false;
                BTextbox.Visible = false;
                ATextbox.Visible = false;
                STextbox.Visible = false;
                SPlusTextbox.Visible = false;
                banderaVolverReglas = false;
                CategoriaTitulo.Visible = false;
            }
            else if (GatoTitulo.Visible == true || AletorioTextBox.Visible == true)
            {
                ModalidadesBoton.Visible = true;
                CategoriasBoton.Visible = true;
                RankingBoton.Visible = true;               
                SideTextBox.Visible = false;
                SideTitulo.Visible = false;
                GatoTextbox.Visible = false;
                GatoTitulo.Visible = false;
                AletorioTextBox.Visible = false;
                RandomTitulo.Visible = false;
                SubitaTextBox.Visible = false;
                SubitaTitulo.Visible = false;
                ModalidadesTitulo.Visible = false;
                NextModalidad.Visible = false;
                BackModalidad.Visible = false;
                banderaVolverReglas = false;
            }
            else if (RookieLabel.Visible == true || LeyendaLabel.Visible == true)
            {
                ModalidadesBoton.Visible = true;
                CategoriasBoton.Visible = true;
                RankingBoton.Visible = true;
                RankingPilotosLabel.Visible = false;
                RookieLabel.Visible = false;
                RookieTextBox.Visible = false;
                JuniorLabel.Visible = false;
                JuniorTextBox.Visible = false;
                AmateurLabel.Visible = false;
                AmateurTextBox.Visible = false;
                SemiProLabel.Visible = false;
                SemiProTextBox.Visible = false;
                BackRanking.Visible = false;
                NextRanking.Visible = false;
                ProfesionalLabel.Visible = false;
                ProfesionalTextbox.Visible = false;
                EstrellaLabel.Visible = false;
                EstrellaTextBox.Visible = false;
                LeyendaLabel.Visible = false;
                LeyendaTextBox.Visible = false;
                PromocionLabel.Visible = false;
                PromocionTextBox.Visible = false;
                banderaVolverReglas = false;
            }

            else if (ComidaPictureBox.Visible == true || MecanicoPictureBox.Visible == true)
            {
                ComidaPictureBox.Visible = false;
                AlquilerPictureBox.Visible = false;
                FacturasPictureBox.Visible = false;
                RopaPictureBox.Visible = false;
                MueblesPictureBox.Visible = false;
                ElectroPictureBox.Visible = false;
                MecanicoPictureBox.Visible = false;
                GastosVariosPictureBox.Visible = false;
                CarDealerPictureBox.Visible = false;
                HigienePictureBox.Visible = false;
                GarajePictureBox.Visible = false;
                AhorrosPictureBox.Visible = false;
                BackEconomia.Visible = false;
                NextEconomia.Visible = false;
            }
            else if (historialDGV.Visible == true)
            {
                historialDGV.Visible = false;
                FiltrosLabel.Visible = false;
                CampoCombo.Visible = false;
                CampoLabel.Visible = false;
                CriterioCombo.Visible = false;
                CriterioLabel.Visible = false;
                FiltroBusquedaLabel.Visible = false;
                FiltroTextBox.Visible = false;
                AgregarRegistroBoton.Visible = false;
                BorrarRegistroBoton.Visible = false;
                BuscarRegistroBoton.Visible = false;
                CampoCombo.Items.Clear();
                CriterioCombo.Items.Clear();
            }
            else if (alquileres1.Visible == true)
            {
                alquileres1.Visible = false;
                alquileres2.Visible = false;
                VolverAlquiler.Visible = false;
                SiguienteAlquiler.Visible = false;
                paginaAlquiler = 0;
            }

            else if (ShopPanel1.Visible == true)
            {
                ShopPanel1.Visible = false;
                ShopPanel2.Visible = false;
                ShopPanel3.Visible = false;
                ShopPanel4.Visible = false;
                ShopPanel5.Visible = false;
                ShopPanel6.Visible = false;
                ShopPanel7.Visible = false;
                ShopPanel8.Visible = false;
                NextRopaMuebleTecno.Visible = false;
                BackRopaMuebleTecno.Visible = false;
                bdCargaRopa = false;
                bdCargaMueble = false;
                bdCargaElectro = false;
            }

            else if (PagoLabel.Visible == true)
            {
                Servicios1.Visible = false;
                Servicios2.Visible = false;
                Servicios3.Visible = false;
                Servicios4.Visible = false;
                Servicios5.Visible = false;
                AbonarFacturas.Visible = false;
                PagoLabel.Visible = false;
            }

            if (banderaVolverReglas && banderaEconomiaParaMostrar)
            {
                BotonPistas.Visible = true;
                PilotosBoton.Visible = true;
                ReglasBoton.Visible = true;
                EconomiaBoton.Visible = true;
                HistorialBoton.Visible = true;
                AutosBoton.Visible = true;
                CloseBoton.Visible = true;
            }

            else if (banderaEconomiaParaMostrar==false)
            {
                if (EconomiaMostrar)
                {
                    ComidaPictureBox.Visible = true;
                    AlquilerPictureBox.Visible = true;
                    FacturasPictureBox.Visible = true;
                    RopaPictureBox.Visible = true;
                    MueblesPictureBox.Visible = true;
                    ElectroPictureBox.Visible = true;
                }
                else
                {
                    GastosVariosPictureBox.Visible = true;
                    MecanicoPictureBox.Visible = true;
                    CarDealerPictureBox.Visible = true;
                    HigienePictureBox.Visible = true;
                    AhorrosPictureBox.Visible = true;
                    GarajePictureBox.Visible = true;
                }
                NextEconomia.Visible = true;
                BackEconomia.Visible = true;
                banderaEconomiaParaMostrar = true;
            }

            
        }

        bool imagen = true;
        private void PistaPictureBox_Click(object sender, EventArgs e)
        {
            if (imagen)
            {
                PistaPictureBox.Load(listaPistas[indexPistas].Imagenes2);
                imagen = false;
            }
            else
            {
                PistaPictureBox.Load(listaPistas[indexPistas].Imagenes);
                imagen = true;
            }
        }

        private void SiguientePistaBoton_Click(object sender, EventArgs e)
        {
            if (indexPistas<listaPistas.Count()-1)
            {
                indexPistas++;
                CargaBasePistas();
            }
            imagen = true;
        }

        private void AnteriorPistaBoton_Click(object sender, EventArgs e)
        {
            if (indexPistas > 0)
            {
                indexPistas--;
                CargaBasePistas();
            }
            imagen = true;
        }

            NegocioBaseDatos negocioBDPilotos = new NegocioBaseDatos();
            List<Pilotos> listaPilotos = new List<Pilotos>();
            int indexPilotos = 0;
        private void PilotosBoton_Click(object sender, EventArgs e)
        {
            
            Ocultar();
            Cornering.Visible = true;
            PilotosPictureBox.Visible = true;
            AutoPilotoPictureBox.Visible = true;
            BiografiaPilotosTextBox.Visible = true;
            PaisPictureBox.Visible = true;
            Cornering.Visible = true;
            NombrePilotoTextBox.Visible = true;
            ApodoTextBox.Visible = true;
            EquipoTextBox.Visible = true;
            RivalTextBox.Visible = true;
            NextDriver.Visible = true;
            BackDriver.Visible = true;
            EdadTextBox.Visible = true;
            AlturaTextBox.Visible = true;
            PesoTextBox.Visible = true;
            VictoriaTextBox.Visible = true;
            DerrotaTextBox.Visible = true;
            WinRateTextBox.Visible = true;
            TotalTextBox.Visible = true;
            
            CargaPilotos();

        }

        private void CargaPilotos()
        {
            listaPilotos = negocioBDPilotos.DevolverPilotos();
            PilotosPictureBox.Load(listaPilotos[indexPilotos].Foto);
            BiografiaPilotosTextBox.Text = listaPilotos[indexPilotos].Biografia;
            AutoPilotoPictureBox.Load(listaPilotos[indexPilotos].Auto);
            PaisPictureBox.Load(listaPilotos[indexPilotos].Nacionalidad);
            if (listaPilotos[indexPilotos].Cornering < 10)
                Cornering.Location = new Point(53, 42);
            Cornering.Text = listaPilotos[indexPilotos].Cornering.ToString();
            if (listaPilotos[indexPilotos].Braking < 10)
                Braking.Location = new Point(163, 42);
            Braking.Text = listaPilotos[0].Braking.ToString();
            if (listaPilotos[indexPilotos].Reflexes < 10)
                Reflexes.Location = new Point(270, 42);
            Reflexes.Text = listaPilotos[indexPilotos].Reflexes.ToString();
            if (listaPilotos[indexPilotos].ManejoPresion < 10)
                Pressure.Location = new Point(53, 149);
            Pressure.Text = listaPilotos[indexPilotos].ManejoPresion.ToString();
            if (listaPilotos[indexPilotos].Experiencia < 10)
                Experience.Location = new Point(163, 149);
            Experience.Text = listaPilotos[indexPilotos].Experiencia.ToString();
            if (listaPilotos[indexPilotos].Pace < 10)
                Pace.Location = new Point(270, 149);
            Pace.Text = listaPilotos[indexPilotos].Pace.ToString();
            if (listaPilotos[indexPilotos].TyresManagement < 10)
                Tyres.Location = new Point(55, 255);
            Tyres.Text = listaPilotos[indexPilotos].TyresManagement.ToString();
            if (listaPilotos[indexPilotos].Agresividad < 10)
                Agressiveness.Location = new Point(163, 255);
            Agressiveness.Text = listaPilotos[indexPilotos].Agresividad.ToString();
            if (listaPilotos[indexPilotos].Overtaking < 10)
                Overtaking.Location = new Point(270, 255);
            Overtaking.Text = listaPilotos[indexPilotos].Overtaking.ToString();
            if (listaPilotos[indexPilotos].Concentracion < 10)
                Concentration.Location = new Point(53, 354);
            Concentration.Text = listaPilotos[indexPilotos].Concentracion.ToString();
            if (listaPilotos[indexPilotos].RainHability < 10)
                Rain.Location = new Point(166, 354);
            Rain.Text = listaPilotos[indexPilotos].RainHability.ToString();
            if (listaPilotos[indexPilotos].Defending < 10)
                Defending.Location = new Point(270, 354);
            Defending.Text = listaPilotos[indexPilotos].Defending.ToString();
            if (banderaSize)
            {
                Cornering.Location = new Point(48, 43);
                Braking.Location = new Point(155, 43);
                Reflexes.Location = new Point(262, 43);
                Pressure.Location = new Point(43, 159);
                Experience.Location = new Point(155, 159);
                Pace.Location = new Point(262, 159);
                Tyres.Location = new Point(43, 274);
                Agressiveness.Location = new Point(155, 274);
                Overtaking.Location = new Point(262, 274);
                Concentration.Location = new Point(45, 380);
                Rain.Location = new Point(165, 380);
                Defending.Location = new Point(262, 380);
                Overall.Location = new Point(465, 336);
                NombrePilotoTextBox.Location = new Point(118, 528);
                ApodoTextBox.Location = new Point(118, 565);
                EquipoTextBox.Location = new Point(118, 600);
                RivalTextBox.Location = new Point(118, 635);

                EdadTextBox.Location = new Point(433, 528);

                AlturaTextBox.Location = new Point(430, 570);

                PesoTextBox.Location = new Point(430, 603);

                VictoriaTextBox.Location = new Point(612, 530);

                DerrotaTextBox.Location = new Point(612, 565);

                WinRateTextBox.Location = new Point(612, 602);

                TotalTextBox.Location = new Point(612, 636);
            }
            NombrePilotoTextBox.Text = listaPilotos[indexPilotos].NombrePiloto;
            ApodoTextBox.Text = listaPilotos[indexPilotos].Apodo;
            EquipoTextBox.Text = listaPilotos[indexPilotos].Equipo;
            RivalTextBox.Text = listaPilotos[indexPilotos].Rival;
            EdadTextBox.Text = listaPilotos[indexPilotos].Edad.ToString();
            AlturaTextBox.Text = listaPilotos[indexPilotos].Altura;
            PesoTextBox.Text = listaPilotos[indexPilotos].Peso;
            VictoriaTextBox.Text = listaPilotos[indexPilotos].Victorias.ToString();
            DerrotaTextBox.Text = listaPilotos[indexPilotos].Derrotas.ToString();
            WinRateTextBox.Text = listaPilotos[indexPilotos].PorcentajeCarrerasGanadas.ToString()+"%";
            TotalTextBox.Text = listaPilotos[indexPilotos].CantidadDeCarreras.ToString();
        }

        int contadorImagenes = 0;
        private void AutoPilotoPictureBox_Click(object sender, EventArgs e)
        {
            contadorImagenes++;
            switch (contadorImagenes)
            {
                case 1:
                    AutoPilotoPictureBox.Load(listaPilotos[indexPilotos].AutoAtras);
                    break;
                case 2:
                    AutoPilotoPictureBox.Load(listaPilotos[indexPilotos].AutoFrontal);
                    break;
                case 3:
                    AutoPilotoPictureBox.Load(listaPilotos[indexPilotos].AutoDriving);
                    break;
                default:
                    contadorImagenes = 0;
                    AutoPilotoPictureBox.Load(listaPilotos[indexPilotos].Auto);
                    break;
            }
        }

        private void NextDriver_Click(object sender, EventArgs e)
        {
            indexPilotos++;
            contadorImagenes = 0;
            if (!(indexPilotos>=listaPilotos.Count()))
            {
                CargaPilotos();
            }
            else
            {
                indexPilotos = 0;
                CargaPilotos();
            }
        }

        private void BackDriver_Click(object sender, EventArgs e)
        {
            indexPilotos--;
            contadorImagenes = 0;
            if (!(indexPilotos < 0))
            {
                CargaPilotos();
            }
            else
            {
                indexPilotos = listaPilotos.Count()-1;
                CargaPilotos();
            }
        }

        NegocioBaseDatos negocioBDAutos;
        List<Autos> listaAutos = new List<Autos>();
        int indexAutos = 0;
        private void AutosBoton_Click(object sender, EventArgs e)
        {
            Ocultar();
            CargarAutos();
        }

        private void CargarAutos()
        {
            AutosPictureBox.Visible = true;
            //FichaTecnicaTextBox.Visible = true;
            BanderasPictureBox.Visible = true;
            NombreAutoTextbox.Visible = true;
            BackAuto.Visible = true;
            NextAuto.Visible = true;
            FichaTecnicaPb.Visible = true;
            negocioBDAutos = new NegocioBaseDatos();
            listaAutos = negocioBDAutos.DevolverAutos();
            NombreAutoTextbox.Text = listaAutos[indexAutos].NombreModelo;
            AutosPictureBox.Load(listaAutos[indexAutos].ImagenAuto);
            MarcaPictureBox.Load(listaAutos[indexAutos].MarcaAuto.ImagenMarca);
            BanderasPictureBox.Load(listaAutos[indexAutos].PaisFabricacion);
            YearLabel.Text = listaAutos[indexAutos].Anio.ToString();
            NmLabel.Text = listaAutos[indexAutos].Torque.ToString() + "  Nm";
            HpLabel.Text = listaAutos[indexAutos].HP.ToString() + "  Hp";
            KgLabel.Text = listaAutos[indexAutos].Peso.ToString() + "  Kg";
            KgHp.Text = listaAutos[indexAutos].RelacionPesoPotencia.ToString() + "  Kg/Hp";
            TopLabel.Text = listaAutos[indexAutos].TopSpeed.ToString() + "  Km/H";
            KmLabel.Text = listaAutos[indexAutos].Kilometraje.ToString() + "  Km";
            CatLabel.Text = listaAutos[indexAutos].Categoria;
            NombrePilotoLabel.Text = listaAutos[indexAutos].Piloto;
        }

        int contadorImagenAuto = 0;
        private void AutosPictureBox_Click(object sender, EventArgs e)
        {
            contadorImagenAuto++;
            switch (contadorImagenAuto)
            {
                case 1:
                    AutosPictureBox.Load(listaAutos[indexAutos].ImagenAutoSecundaria);
                    break;
                case 2:
                    AutosPictureBox.Load(listaAutos[indexAutos].ImagenAutoTres);
                    break;
                case 3:
                    AutosPictureBox.Load(listaAutos[indexAutos].ImagenAutoCuatro);
                    break;
                case 4:
                    AutosPictureBox.Load(listaAutos[indexAutos].ImagenAutoCinco);
                    break;
                default:
                    contadorImagenAuto = 0;
                    AutosPictureBox.Load(listaAutos[indexAutos].ImagenAuto);
                    break;
            }
        }

        private void NextAuto_Click(object sender, EventArgs e)
        {
            contadorImagenAuto = 0;
            if (indexAutos < listaAutos.Count() - 1)
            {
                indexAutos++;
                CargarAutos();
            }
            else
            {
                indexAutos = 0;
                CargarAutos();
            }
        }

        private void BackAuto_Click(object sender, EventArgs e)
        {
            indexAutos--;
            contadorImagenAuto = 0;
            if (!(indexAutos < 0))
            {
                CargarAutos();
            }
            else
            {
                indexAutos = listaAutos.Count() - 1;
                CargarAutos();
            }
        }

        private void ReglasBoton_Click(object sender, EventArgs e)
        {
            Ocultar();
            ModalidadesBoton.Visible = true;
            CategoriasBoton.Visible = true;
            RankingBoton.Visible = true;
        }

        private void CategoriasBoton_Click(object sender, EventArgs e)
        {
            ModalidadesBoton.Visible = false;
            CategoriasBoton.Visible = false;
            RankingBoton.Visible = false;
            FLabel.Visible = true;
            ELabel.Visible = true;
            DLabel.Visible = true;
            CLabel.Visible = true;
            Blabel.Visible = true;
            ALabel.Visible = true;
            SLabel.Visible = true;
            SPlusLabel.Visible = true;
            FTextbox.Visible = true;
            ETextbox.Visible = true;
            DTextbox.Visible = true;
            CTextbox.Visible = true;
            BTextbox.Visible = true;
            ATextbox.Visible = true;
            STextbox.Visible = true;
            SPlusTextbox.Visible = true;
            CategoriaTitulo.Visible = true;

        }

        bool ModalidadBd = false;
        private void ModalidadesBoton_MouseEnter(object sender, EventArgs e)
        {
            ModalidadBd = true;
        }
        private void ModalidadesBoton_MouseLeave(object sender, EventArgs e)
        {
            ModalidadBd = false;
        }
        private void ModalidadesBoton_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(ModalidadBd, e, ModalidadesBoton);
        }
        bool CategoriaBd = false;
        private void CategoriasBoton_MouseEnter(object sender, EventArgs e)
        {
            CategoriaBd = true;
        }
        private void CategoriasBoton_MouseLeave(object sender, EventArgs e)
        {
            CategoriaBd = false;
        }
        private void CategoriasBoton_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(CategoriaBd, e, CategoriasBoton);
        }
        bool RankingBd = false;
        private void RankingBoton_MouseEnter(object sender, EventArgs e)
        {
            RankingBd = true;
        }
        private void RankingBoton_MouseLeave(object sender, EventArgs e)
        {
            RankingBd = false;
        }
        private void RankingBoton_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(RankingBd, e, RankingBoton);
        }

        private void ModalidadesBoton_Click(object sender, EventArgs e)
        {
            SideTextBox.Visible = true;
            SideTitulo.Visible = true;
            GatoTextbox.Visible = true;
            GatoTitulo.Visible = true;
            ModalidadesTitulo.Visible = true;
            ModalidadesBoton.Visible = false;
            CategoriasBoton.Visible = false;
            RankingBoton.Visible = false;
            NextModalidad.Visible = true;
            BackModalidad.Visible = true;
        }

        private void NextModalidad_Click(object sender, EventArgs e)
        {
            if (SubitaTextBox.Visible==false)
            {
                AletorioTextBox.Visible = true;
                RandomTitulo.Visible = true;
                SubitaTextBox.Visible = true;
                SubitaTitulo.Visible = true;
                SideTextBox.Visible = false;
                SideTitulo.Visible = false;
                GatoTextbox.Visible = false;
                GatoTitulo.Visible = false;
            }
        }

        private void BackModalidad_Click(object sender, EventArgs e)
        {
            if (GatoTextbox.Visible == false)
            {
                AletorioTextBox.Visible = false;
                RandomTitulo.Visible = false;
                SubitaTextBox.Visible = false;
                SubitaTitulo.Visible = false;
                SideTextBox.Visible = true;
                SideTitulo.Visible = true;
                GatoTextbox.Visible = true;
                GatoTitulo.Visible = true;
            }
        }

        private void RankingBoton_Click(object sender, EventArgs e)
        {
            ModalidadesBoton.Visible = false;
            CategoriasBoton.Visible = false;
            RankingBoton.Visible = false;
            RankingPilotosLabel.Visible = true;
            RookieLabel.Visible = true;
            RookieTextBox.Visible = true;
            JuniorLabel.Visible = true;
            JuniorTextBox.Visible = true;
            AmateurLabel.Visible = true;
            AmateurTextBox.Visible = true;
            SemiProLabel.Visible = true;
            SemiProTextBox.Visible = true;
            BackRanking.Visible = true;
            NextRanking.Visible = true;
        }

        private void NextRanking_Click(object sender, EventArgs e)
        {
            if (RookieLabel.Visible == true)
            {
                RookieLabel.Visible = false;
                RookieTextBox.Visible = false;
                JuniorLabel.Visible = false;
                JuniorTextBox.Visible = false;
                AmateurLabel.Visible = false;
                AmateurTextBox.Visible = false;
                SemiProLabel.Visible = false;
                SemiProTextBox.Visible = false;
                ProfesionalLabel.Visible = true;
                ProfesionalTextbox.Visible = true;
                EstrellaLabel.Visible = true;
                EstrellaTextBox.Visible = true;
                LeyendaLabel.Visible = true;
                LeyendaTextBox.Visible = true;
                PromocionLabel.Visible = true;
                PromocionTextBox.Visible = true;
            }
            
        }

        private void BackRanking_Click(object sender, EventArgs e)
        {
            if (LeyendaLabel.Visible == true)
            {
                RookieLabel.Visible = true;
                RookieTextBox.Visible = true;
                JuniorLabel.Visible = true;
                JuniorTextBox.Visible = true;
                AmateurLabel.Visible = true;
                AmateurTextBox.Visible = true;
                SemiProLabel.Visible = true;
                SemiProTextBox.Visible = true;
                ProfesionalLabel.Visible = false;
                ProfesionalTextbox.Visible = false;
                EstrellaLabel.Visible = false;
                EstrellaTextBox.Visible = false;
                LeyendaLabel.Visible = false;
                LeyendaTextBox.Visible = false;
                PromocionLabel.Visible = false;
                PromocionTextBox.Visible = false;
            }
        }

        bool banderaEconomiaParaMostrar = true;
        private void EconomiaBoton_Click(object sender, EventArgs e)
        {
            Ocultar();
            ComidaPictureBox.Visible = true;
            AlquilerPictureBox.Visible = true;
            FacturasPictureBox.Visible = true;
            RopaPictureBox.Visible = true;
            MueblesPictureBox.Visible = true;
            ElectroPictureBox.Visible = true;
            BackEconomia.Visible = true;
            NextEconomia.Visible = true;
        }

        private void NextEconomia_Click(object sender, EventArgs e)
        {
            if (ComidaPictureBox.Visible == true)
            {
                ComidaPictureBox.Visible = false;
                AlquilerPictureBox.Visible = false;
                FacturasPictureBox.Visible = false;
                RopaPictureBox.Visible = false;
                MueblesPictureBox.Visible = false;
                ElectroPictureBox.Visible = false;
                MecanicoPictureBox.Visible = true;
                GastosVariosPictureBox.Visible = true;
                CarDealerPictureBox.Visible = true;
                HigienePictureBox.Visible = true;
                GarajePictureBox.Visible = true;
                AhorrosPictureBox.Visible = true;
            }
        }

        private void BackEconomia_Click(object sender, EventArgs e)
        {
            if (CarDealerPictureBox.Visible == true)
            {
                ComidaPictureBox.Visible = true;
                AlquilerPictureBox.Visible = true;
                FacturasPictureBox.Visible = true;
                RopaPictureBox.Visible = true;
                MueblesPictureBox.Visible = true;
                ElectroPictureBox.Visible = true;
                MecanicoPictureBox.Visible = false;
                GastosVariosPictureBox.Visible = false;
                CarDealerPictureBox.Visible = false;
                HigienePictureBox.Visible = false;
                GarajePictureBox.Visible = false;
                AhorrosPictureBox.Visible = false;
            }
        }

        private void MecanicoPictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverDriversBD, e, MecanicoPictureBox);
        }

        private void GastosVariosPictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverAutosBD, e, GastosVariosPictureBox);
        }

        private void HigienePictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverRulesBD, e, HigienePictureBox);
        }
        private void AhorrosPictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverEconomiaBD, e, MecanicoPictureBox);
        }
        private void GarajePictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverHistorialBD, e, GarajePictureBox);
        }
        private void CarDealerPictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverBotonBD, e, CarDealerPictureBox);
        }

        private void ComidaPictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverDriversBD, e, ComidaPictureBox);
        }

        private void AlquilerPictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverAutosBD, e, AlquilerPictureBox);

        }

        private void FacturasPictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverRulesBD, e, FacturasPictureBox);
        }

        private void RopaPictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverEconomiaBD, e, RopaPictureBox);
        }

        private void MueblesPictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverHistorialBD, e, MueblesPictureBox);
        }

        private void ElectroPictureBox_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(HoverBotonBD, e, ElectroPictureBox);
        }

        private void ComidaPictureBox_Click(object sender, EventArgs e)
        {

        }

        
        
        private void AlquilerPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarEconomia();
                PaginaUnoAlquiler();               
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void MostrarFacturas()
        {
            PagoLabel.Visible = true;
            Servicios1.Visible = true;
            Servicios2.Visible = true;
            Servicios3.Visible = true;
            Servicios4.Visible = true;
            Servicios5.Visible = true;
        }

        private void FacturasPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarEconomia();
                MostrarFacturas();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MecanicoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void AhorrosPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void HigienePictureBox_Click(object sender, EventArgs e)
        {

        }

        NegocioBaseDatos negocioHistorial = new NegocioBaseDatos();
        List<Historial> listaHistorial;
        private void RopaPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaRopa.Count >= 8)
                {
                    MostrarShopPanels(Color.Khaki, Color.FromArgb(255, 54, 54, 54));
                    PaginaUnoRopa();
                }
                else
                {
                    MessageBox.Show("En este momento estamos falta de Articulos! vuelva mas tarde");
                }
            }
            catch (Exception)
            {

                throw;
            } 
        }

        private void MostrarShopPanels(Color Back, Color Fore)
        {
            OcultarEconomia();
            ShopPanel1.BackColor = Back;
            ShopPanel1.Letras(Fore);
            ShopPanel2.BackColor = Back;
            ShopPanel2.Letras(Fore);
            ShopPanel3.BackColor = Back;
            ShopPanel3.Letras(Fore);
            ShopPanel4.BackColor = Back;
            ShopPanel4.Letras(Fore);
            ShopPanel5.BackColor = Back;
            ShopPanel5.Letras(Fore);
            ShopPanel6.BackColor = Back;
            ShopPanel6.Letras(Fore);
            ShopPanel7.BackColor = Back;
            ShopPanel7.Letras(Fore);
            ShopPanel8.BackColor = Back;
            ShopPanel8.Letras(Fore);
            banderaEconomiaParaMostrar = false;
            ShopPanel1.Visible = true;
            ShopPanel2.Visible = true;
            ShopPanel3.Visible = true;
            ShopPanel4.Visible = true;
            ShopPanel5.Visible = true;
            ShopPanel6.Visible = true;
            ShopPanel7.Visible = true;
            ShopPanel8.Visible = true;
            ShopPanel8.Visible = true;
            NextRopaMuebleTecno.Visible = true;
            BackRopaMuebleTecno.Visible = true;
        }

        private void GastosVariosPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void MueblesPictureBox_Click(object sender, EventArgs e)
        {
            if (listaMuebles.Count >= 8)
            {
                MostrarShopPanels(Color.FromArgb(240, 160, 82, 45), Color.GhostWhite);
                PaginaUnoMuebles();
            }
            else
            {
                MessageBox.Show("En este momento estamos falta de Articulos! vuelva mas tarde");
            }
        }

        private void GarajePictureBox_Click(object sender, EventArgs e)
        {
            
        }

        private void ElectroPictureBox_Click(object sender, EventArgs e)
        {
            if (listaElectro.Count >= 8)
            {
                MostrarShopPanels(Color.FromArgb(255, 40, 89, 255), Color.GhostWhite);
                PaginaUnoElectros();
            }
            else
            {
                MessageBox.Show("En este momento estamos falta de Articulos! vuelva mas tarde");
            }
        }

        private void CarDealerPictureBox_Click(object sender, EventArgs e)
        {

        }
        
        private void HistorialBoton_Click(object sender, EventArgs e)
        {
            listaHistorial = negocioHistorial.DevolverHistorial();
            historialDGV.DataSource = listaHistorial;
            historialDGV.Columns["Perdedor"].Visible = false;
            historialDGV.Columns["Id"].Visible = false;
            int ultimaColumna = historialDGV.Columns.Count - 1;
            historialDGV.Columns[ultimaColumna].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            historialDGV.Columns[ultimaColumna].FillWeight = 1;
            Ocultar();
            historialDGV.Visible = true;
            FiltrosLabel.Visible = true;
            CampoCombo.Visible = true;
            CampoLabel.Visible = true;
            CriterioCombo.Visible = true;
            CriterioLabel.Visible = true;
            FiltroBusquedaLabel.Visible = true;
            FiltroTextBox.Visible = true;
            AgregarRegistroBoton.Visible = true;
            BorrarRegistroBoton.Visible = true;
            BuscarRegistroBoton.Visible = true;
            CampoCombo.Items.Add("Circuito");
            CampoCombo.Items.Add("Piloto");
            CampoCombo.Items.Add("Rival");
            CampoCombo.Items.Add("AutoPiloto");
            CampoCombo.Items.Add("AutoRival");
            CampoCombo.Items.Add("Ganador");          
            CampoCombo.Items.Add("Perdedor");          
            CampoCombo.Items.Add("Clase");
            CampoCombo.Items.Add("Clima");
            CampoCombo.Items.Add("Tiempo");
            CampoCombo.Items.Add("Modalidad");
            CampoCombo.Items.Add("Promocion");
        }

        private void AgregarRegistroBoton_Click(object sender, EventArgs e)
        {
            int filas = historialDGV.Rows.Count;
            HistorialForms registroVenatana = new HistorialForms(Player);
            registroVenatana.ShowDialog();
            listaHistorial = negocioHistorial.DevolverHistorial();
            historialDGV.DataSource = listaHistorial;
            if (historialDGV.Rows.Count>filas)
            {
                NegocioBaseDatos negocioUpFecha = new NegocioBaseDatos();
                fechaAux.FechaManager = negocioUpFecha.UpdatearFecha(5);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
            }
        }

        private void BorrarRegistroBoton_Click(object sender, EventArgs e)
        {
            if (historialDGV.CurrentRow.DataBoundItem != null)
            {
               DialogResult resultado = MessageBox.Show("Seguro que desea eliminar","",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    NegocioBaseDatos negocioEliminar = new NegocioBaseDatos();
                    Historial aux = (Historial)historialDGV.CurrentRow.DataBoundItem;
                    negocioEliminar.EliminarRegistro(aux.Id);
                    listaHistorial = negocioHistorial.DevolverHistorial();
                    historialDGV.DataSource = listaHistorial;
                }

            }
            else
            {
                MessageBox.Show("No selecciono ningun registro a eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CampoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CriterioCombo.Items.Count==0)
            {
                CriterioCombo.Items.Add("Empieza Por");
                CriterioCombo.Items.Add("Contiene");
                CriterioCombo.Items.Add("Termina Por");
            }
        }

        private void BuscarRegistroBoton_Click(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioFiltro = new NegocioBaseDatos();
            listaHistorial = negocioFiltro.FiltrarDatosHistorial(CampoCombo.Text, CriterioCombo.Text, FiltroTextBox.Text);
            historialDGV.DataSource = listaHistorial;

        }

        bool estadoFacturas;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (fechaAux.FechaManager.Month != CambioMes.Month)
            {
                Alquilando = false;
                NegocioBaseDatos negocioAlquilerManager = new NegocioBaseDatos();
                negocioAlquilerManager.ActualizarAlquilando(Alquilando);
                CambioMes = fechaAux.FechaManager;
                MessageBox.Show("Cambio El Mes, Necesitas renovar el Alquiler");
                listaAlquiler = negocioAlquiler.DevolverAlquiler(true, CasaAlquilada);
                Ocultar();
                OcultarEconomia();
                OcultarHistorial();
                OcultarPaneles();
                VolverBoton.Visible = false;
                BuscarRegistroBoton.Visible = false;
                estadoFacturas = false;
                PaginaUnoAlquiler();    
            }
        }


        private void OcultarPaneles()
        {
            ShopPanel1.Visible = false;
            ShopPanel2.Visible = false;
            ShopPanel3.Visible = false;
            ShopPanel4.Visible = false;
            ShopPanel5.Visible = false;
            ShopPanel6.Visible = false;
            ShopPanel7.Visible = false;
            ShopPanel8.Visible = false;
            BackRopaMuebleTecno.Visible = false;
            NextRopaMuebleTecno.Visible = false;
        }

        private void OcultarHistorial()
        {
            historialDGV.Visible = false;
            FiltroBusquedaLabel.Visible = false;
            FiltrosLabel.Visible = false;
            FiltroTextBox.Visible = false;
            CampoCombo.Visible = false;
            CampoLabel.Visible = false;
            CriterioLabel.Visible = false;
            CriterioCombo.Visible = false;
            AgregarRegistroBoton.Visible = false;
            BorrarRegistroBoton.Visible = false;
        }

        int paginaAlquiler = 0;
        private void SiguienteAlquiler_Click(object sender, EventArgs e)
        {
            paginaAlquiler++;
            if (paginaAlquiler==1)
            {
                PaginaDosAlquiler();
            }
            if (paginaAlquiler == 2)
            {
                PaginaTresAlquiler();
            }
            if (paginaAlquiler==3)
            {
                paginaAlquiler = 2;
            }
        }

        private void VolverAlquiler_Click(object sender, EventArgs e)
        {
            paginaAlquiler--;
            if (paginaAlquiler == 1)
            {
                PaginaDosAlquiler();
            }
            else if (paginaAlquiler == 0)
            {
                PaginaUnoAlquiler();
            }
            else if (paginaAlquiler == -1)
            {
                paginaAlquiler = 0;
            }
        }

        private void PaginaUnoAlquiler()
        {
            alquileres1.Visible = true;
            alquileres2.Visible = true;
            VolverAlquiler.Visible = true;
            SiguienteAlquiler.Visible = true;
            banderaEconomiaParaMostrar = false;
            alquileres1.TituloDepa = listaAlquiler[0].NombreAlquiler;
            alquileres1.CargarImagenes(listaAlquiler[0].ImagenAlquiler);
            alquileres1.Pieza = "● " + listaAlquiler[0].CantidadDormitorios.ToString();
            alquileres1.Ducha = "● "+listaAlquiler[0].CantidadDuchas.ToString();
            alquileres1.Garaje = "● "+listaAlquiler[0].CantidadGarajes.ToString();
            alquileres1.Sala = "● "+ listaAlquiler[0].CantidadSalasEstar.ToString();
            alquileres1.Precio = "$ " + listaAlquiler[0].PrecioDepartamento.ToString();
            alquileres1.Id = listaAlquiler[0].NumeroRegistro;
            alquileres2.TituloDepa = listaAlquiler[1].NombreAlquiler;
            alquileres2.CargarImagenes(listaAlquiler[1].ImagenAlquiler);
            alquileres2.Pieza = "● " + listaAlquiler[1].CantidadDormitorios.ToString();
            alquileres2.Ducha = "● " + listaAlquiler[1].CantidadDuchas.ToString();
            alquileres2.Garaje = "● " + listaAlquiler[1].CantidadGarajes.ToString();
            alquileres2.Sala = "● "+listaAlquiler[1].CantidadSalasEstar.ToString();
            alquileres2.Precio = "$ " +  listaAlquiler[1].PrecioDepartamento.ToString();
            alquileres2.Id = listaAlquiler[1].NumeroRegistro;
        }
        private void PaginaDosAlquiler()
        {
            alquileres1.TituloDepa = listaAlquiler[2].NombreAlquiler;
            alquileres1.CargarImagenes(listaAlquiler[2].ImagenAlquiler);
            alquileres1.Pieza = "● " + listaAlquiler[2].CantidadDormitorios.ToString();
            alquileres1.Ducha = "● " + listaAlquiler[2].CantidadDuchas.ToString();
            alquileres1.Garaje = "● " + listaAlquiler[2].CantidadGarajes.ToString();
            alquileres1.Sala = "● " + listaAlquiler[2].CantidadSalasEstar.ToString();
            alquileres1.Precio = "$ " + listaAlquiler[2].PrecioDepartamento.ToString();
            alquileres1.Id = listaAlquiler[2].NumeroRegistro;
            alquileres2.TituloDepa = listaAlquiler[3].NombreAlquiler;
            alquileres2.CargarImagenes(listaAlquiler[3].ImagenAlquiler);
            alquileres2.Pieza = "● " + listaAlquiler[3].CantidadDormitorios.ToString();
            alquileres2.Ducha = "● " + listaAlquiler[3].CantidadDuchas.ToString();
            alquileres2.Garaje = "● " + listaAlquiler[3].CantidadGarajes.ToString();
            alquileres2.Sala = "● " + listaAlquiler[3].CantidadSalasEstar.ToString();
            alquileres2.Precio = "$ " + listaAlquiler[3].PrecioDepartamento.ToString();
            alquileres2.Id = listaAlquiler[3].NumeroRegistro;
        }
        private void PaginaTresAlquiler()
        {
            alquileres1.TituloDepa = listaAlquiler[4].NombreAlquiler;
            alquileres1.CargarImagenes(listaAlquiler[4].ImagenAlquiler);
            alquileres1.Pieza = "● " + listaAlquiler[4].CantidadDormitorios.ToString();
            alquileres1.Ducha = "● " + listaAlquiler[4].CantidadDuchas.ToString();
            alquileres1.Garaje = "● " + listaAlquiler[4].CantidadGarajes.ToString();
            alquileres1.Sala = "● " + listaAlquiler[4].CantidadSalasEstar.ToString();
            alquileres1.Precio = "$ " + listaAlquiler[4].PrecioDepartamento.ToString();
            alquileres1.Id = listaAlquiler[4].NumeroRegistro;
            alquileres2.TituloDepa = listaAlquiler[5].NombreAlquiler;
            alquileres2.CargarImagenes(listaAlquiler[5].ImagenAlquiler);
            alquileres2.Pieza = "● " + listaAlquiler[5].CantidadDormitorios.ToString();
            alquileres2.Ducha = "● " + listaAlquiler[5].CantidadDuchas.ToString();
            alquileres2.Garaje = "● " + listaAlquiler[5].CantidadGarajes.ToString();
            alquileres2.Sala = "● " + listaAlquiler[5].CantidadSalasEstar.ToString();
            alquileres2.Precio = "$ " + listaAlquiler[5].PrecioDepartamento.ToString();
            alquileres2.Id = listaAlquiler[5].NumeroRegistro;
        }


        private void MiUserControl_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoAlquiler(alquileres1.Id)>0)
            {
                Alquileres verificar = new Alquileres();
                miDinero.MiDinero -= negocioPago.PagoAlquiler(alquileres1.Id);
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                MessageBox.Show("Haz Alquilado  Esta Casa! Tu Dinero es de: " + miDinero.MiDinero + " USD");
                //VolverBoton.Visible = true;
                Alquilando = true;
                Alquilando = negocioPago.ActualizarAlquilando(Alquilando);
                CasaAlquilada = alquileres1.Id;
                CasaAlquilada = negocioPago.ActualizarCasaAlquilada(CasaAlquilada);
                fechaAux.FechaManager = negocioPago.UpdatearFecha(5);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                if (!estadoFacturas)
                {
                    alquileres1.Visible = false;
                    alquileres2.Visible = false;
                    VolverAlquiler.Visible = false;
                    SiguienteAlquiler.Visible = false;
                    MostrarFacturas();
                    MessageBox.Show("Necesita abonar los servicios del mes!");
                }
            }
            else
            {
                MessageBox.Show("No tiene dinero para pagar el alquiler, si no puede renovar el alquiler Pierde el juego");
            }
            
            
        }

        private void MiUserControl2_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoAlquiler(alquileres2.Id) > 0)
            {
                Alquileres verificar = new Alquileres();
                miDinero.MiDinero -= negocioPago.PagoAlquiler(alquileres2.Id);
                CasaAlquilada = alquileres2.Id;
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                MessageBox.Show("Haz Alquilado  Esta Casa! Tu Dinero es de: " + miDinero.MiDinero + " USD");
                VolverBoton.Visible = true;
                Alquilando = true;
                Alquilando = negocioPago.ActualizarAlquilando(Alquilando);
                CasaAlquilada = alquileres2.Id;
                CasaAlquilada = negocioPago.ActualizarCasaAlquilada(CasaAlquilada);
                fechaAux.FechaManager = negocioPago.UpdatearFecha(5);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                if (!estadoFacturas)
                {
                    alquileres1.Visible = false;
                    alquileres2.Visible = false;
                    VolverAlquiler.Visible = false;
                    SiguienteAlquiler.Visible = false;
                    MostrarFacturas();
                    MessageBox.Show("Necesita abonar los servicios del mes!");
                }
            }
            else
            {
                MessageBox.Show("No tiene dinero para pagar el alquiler, si no puede renovar el alquiler Pierde el juego");
            }
        }

        int eShopmanager = 0;
        private void ShopPanel1_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoArticulos(ShopPanel1.Id, eShopmanager) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoArticulos(ShopPanel1.Id, eShopmanager);
                negocioPago.ActualizarDinero(miDinero.MiDinero);

                negocioPago.DeshabilitarArticulo(ShopPanel1.Id, eShopmanager);
                MessageBox.Show("Articulo Comprado con exito! " + miDinero.MiDinero + " USD");
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel1.SoldOut();
                switch (eShopmanager)
                {
                    case 1:
                        if (!bdCargaRopa)
                            listaRopa[0].Comprado = false;
                        else
                            listaRopa[8].Comprado = false;
                        break;
                    case 2:
                        if (!bdCargaMueble)
                            listaMuebles[0].Comprado = false;
                        else
                            listaMuebles[8].Comprado = false;
                        break;
                    case 3:
                        if (!bdCargaElectro)
                            listaElectro[0].Comprado = false;
                        else
                            listaElectro[8].Comprado = false;
                        break;
                    default:
                        break;
                }

            }
            else
                MessageBox.Show("No tiene dinero para Comprar este producto.");
        }


        private void ShopPanel2_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoArticulos(ShopPanel2.Id, eShopmanager) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoArticulos(ShopPanel2.Id, eShopmanager);
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                negocioPago.DeshabilitarArticulo(ShopPanel2.Id, eShopmanager);
                MessageBox.Show("Articulo Comprado con exito! " + miDinero.MiDinero + " USD");
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel2.SoldOut();
                switch (eShopmanager)
                {
                    case 1:
                        if (!bdCargaRopa)
                            listaRopa[1].Comprado = false;
                        else
                            listaRopa[9].Comprado = false;
                        break;
                    case 2:
                        if (!bdCargaMueble)
                            listaMuebles[1].Comprado = false;
                        else
                            listaMuebles[9].Comprado = false;
                        break;
                    case 3:
                        if (!bdCargaElectro)
                            listaElectro[1].Comprado = false;
                        else
                            listaElectro[9].Comprado = false;
                        break;
                    default:
                        break;
                }

            }
            else
                MessageBox.Show("No tiene dinero para Comprar este producto.");
        }

        private void ShopPanel3_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoArticulos(ShopPanel3.Id, eShopmanager) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoArticulos(ShopPanel3.Id, eShopmanager);
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                negocioPago.DeshabilitarArticulo(ShopPanel3.Id, eShopmanager);
                MessageBox.Show("Articulo Comprado con exito! " + miDinero.MiDinero + " USD");
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel3.SoldOut();
                switch (eShopmanager)
                {
                    case 1:
                        if (!bdCargaRopa)
                            listaRopa[2].Comprado = false;
                        else
                            listaRopa[10].Comprado = false;
                        break;
                    case 2:
                        if (!bdCargaMueble)
                            listaMuebles[2].Comprado = false;
                        else
                            listaMuebles[10].Comprado = false;
                        break;
                    case 3:
                        if (!bdCargaElectro)
                            listaElectro[2].Comprado = false;
                        else
                            listaElectro[10].Comprado = false;
                        break;
                    default:
                        break;
                }

            }
            else
                MessageBox.Show("No tiene dinero para Comprar este producto.");
        }

        private void ShopPanel4_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoArticulos(ShopPanel4.Id, eShopmanager) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoArticulos(ShopPanel4.Id, eShopmanager);
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                negocioPago.DeshabilitarArticulo(ShopPanel4.Id, eShopmanager);
                MessageBox.Show("Articulo Comprado con exito! " + miDinero.MiDinero + " USD");
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel4.SoldOut();
                switch (eShopmanager)
                {
                    case 1:
                        if (!bdCargaRopa)
                            listaRopa[3].Comprado = false;
                        else
                            listaRopa[11].Comprado = false;
                        break;
                    case 2:
                        if (!bdCargaMueble)
                            listaMuebles[3].Comprado = false;
                        else
                            listaMuebles[11].Comprado = false;
                        break;
                    case 3:
                        if (!bdCargaElectro)
                            listaElectro[3].Comprado = false;
                        else
                            listaElectro[11].Comprado = false;
                        break;
                    default:
                        break;
                }

            }
            else
                MessageBox.Show("No tiene dinero para Comprar este producto.");
        }

        private void ShopPanel5_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoArticulos(ShopPanel5.Id, eShopmanager) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoArticulos(ShopPanel5.Id, eShopmanager);
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                negocioPago.DeshabilitarArticulo(ShopPanel5.Id, eShopmanager);
                MessageBox.Show("Articulo Comprado con exito! " + miDinero.MiDinero + " USD");
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel5.SoldOut();
                switch (eShopmanager)
                {
                    case 1:
                        if (!bdCargaRopa)
                            listaRopa[4].Comprado = false;
                        else
                            listaRopa[12].Comprado = false;
                        break;
                    case 2:
                        if (!bdCargaMueble)
                            listaMuebles[4].Comprado = false;
                        else
                            listaMuebles[12].Comprado = false;
                        break;
                    case 3:
                        if (!bdCargaElectro)
                            listaElectro[4].Comprado = false;
                        else
                            listaElectro[12].Comprado = false;
                        break;
                    default:
                        break;
                }

            }
            else
                MessageBox.Show("No tiene dinero para Comprar este producto.");
        }
        
        private void ShopPanel6_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoArticulos(ShopPanel6.Id, eShopmanager) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoArticulos(ShopPanel6.Id, eShopmanager);
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                negocioPago.DeshabilitarArticulo(ShopPanel6.Id, eShopmanager);
                MessageBox.Show("Articulo Comprado con exito! " + miDinero.MiDinero + " USD");
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel6.SoldOut();
                switch (eShopmanager)
                {
                    case 1:
                        if (!bdCargaRopa)
                            listaRopa[5].Comprado = false;
                        else
                            listaRopa[13].Comprado = false;
                        break;
                    case 2:
                        if (!bdCargaMueble)
                            listaMuebles[5].Comprado = false;
                        else
                            listaMuebles[13].Comprado = false;
                        break;
                    case 3:
                        if (!bdCargaElectro)
                            listaElectro[5].Comprado = false;
                        else
                            listaElectro[13].Comprado = false;
                        break;
                    default:
                        break;
                }
            }
            else
                MessageBox.Show("No tiene dinero para Comprar este producto.");
        }

        private void ShopPanel7_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoArticulos(ShopPanel7.Id, eShopmanager) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoArticulos(ShopPanel7.Id, eShopmanager);
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                negocioPago.DeshabilitarArticulo(ShopPanel7.Id, eShopmanager);
                MessageBox.Show("Articulo Comprado con exito! " + miDinero.MiDinero + " USD");
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel7.SoldOut();
                switch (eShopmanager)
                {
                    case 1:
                        if (!bdCargaRopa)
                            listaRopa[6].Comprado = false;
                        else
                            listaRopa[14].Comprado = false;
                        break;
                    case 2:
                        if (!bdCargaMueble)
                            listaMuebles[6].Comprado = false;
                        else
                            listaMuebles[14].Comprado = false;
                        break;
                    case 3:
                        if (!bdCargaElectro)
                            listaElectro[6].Comprado = false;
                        else
                            listaElectro[14].Comprado = false;
                        break;
                    default:
                        break;
                }

            }
            else
                MessageBox.Show("No tiene dinero para Comprar este producto.");
        }

        private void ShopPanel8_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoArticulos(ShopPanel8.Id, eShopmanager) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoArticulos(ShopPanel8.Id, eShopmanager);
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                negocioPago.DeshabilitarArticulo(ShopPanel8.Id, eShopmanager);
                MessageBox.Show("Articulo Comprado con exito! " + miDinero.MiDinero + " USD");
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel8.SoldOut();
                switch (eShopmanager)
                {
                    case 1:
                        if (!bdCargaRopa)
                            listaRopa[7].Comprado = false;
                        else
                            listaRopa[15].Comprado = false;
                        break;
                    case 2:
                        if (!bdCargaMueble)
                            listaMuebles[7].Comprado = false;
                        else
                            listaMuebles[15].Comprado = false;
                        break;
                    case 3:
                        if (!bdCargaElectro)
                            listaElectro[7].Comprado = false;
                        else
                            listaElectro[15].Comprado = false;
                        break;
                    default:
                        break;
                }
                

            }
            else
                MessageBox.Show("No tiene dinero para Comprar este producto.");
        }


        NegocioBaseDatos negocioMuebles = new NegocioBaseDatos();
        List<Mueble> listaMuebles;
        

        bool bdCargaRopa = false;
        bool bdCargaMueble = false;
        bool bdCargaElectro = false;
        private void BackRopaMuebleTecno_Click(object sender, EventArgs e)
        {
            if (ShopPanel1.BackColor == Color.Khaki)
            {
                if (bdCargaRopa)
                {
                    PaginaUnoRopa();
                    bdCargaRopa = false;
                }
            }
            else if (ShopPanel1.BackColor == Color.FromArgb(240, 160, 82, 45))
            {
                if (bdCargaMueble)
                {
                    PaginaUnoMuebles();
                    bdCargaMueble = false;
                }
            }
            else if (ShopPanel1.BackColor == Color.FromArgb(255, 40, 89, 255))
            {
                if (bdCargaElectro)
                {
                    PaginaUnoElectros();
                    bdCargaElectro = false;
                }
            }
            
        }
        private void NextRopaMuebleTecno_Click(object sender, EventArgs e)
        {
            if (ShopPanel1.BackColor == Color.Khaki)
            {
                if (!bdCargaRopa)
                {
                   if (listaRopa.Count >= 16)
                   {
                       PaginaDosRopa();
                       bdCargaRopa = true;
                   }
                    else
                       MessageBox.Show("No hay mas articulos que comprar!");
                } 
            }
            else if (ShopPanel1.BackColor == Color.FromArgb(240, 160, 82, 45))
            {
                if (!bdCargaMueble)
                {
                    if (listaMuebles.Count >= 16)
                    {
                        PaginaDosMuebles();
                        bdCargaMueble = true;
                    }
                    else
                        MessageBox.Show("No hay mas articulos que comprar!");
                }
            }
            else if (ShopPanel1.BackColor == Color.FromArgb(255, 40, 89, 255))
            {
                if (!bdCargaElectro)
                {
                    if (listaElectro.Count >= 16)
                    {
                        PaginaDosElectros();
                        bdCargaElectro = true;
                    }
                    else
                        MessageBox.Show("No hay mas articulos que comprar!");
                }
            }

        }

        NegocioBaseDatos negocioRopa = new NegocioBaseDatos();
        List<Ropa> listaRopa;
        private void PaginaUnoRopa()
        {
            eShopmanager = 1;
            ShopPanel1.Precio = "$ " + (listaRopa[0].Precio - 1).ToString() + ".99";
            ShopPanel1.CargarImagenes(listaRopa[0].Imagen);
            ShopPanel1.NombreProducto = listaRopa[0].NombreRopa;
            ShopPanel1.Id = listaRopa[0].Id;
            if (!listaRopa[0].Comprado)
                ShopPanel1.SoldOut();
            else
                ShopPanel1.OcultarSold();
            ShopPanel2.Precio = "$ " + (listaRopa[1].Precio - 1).ToString() + ".99";
            ShopPanel2.CargarImagenes(listaRopa[1].Imagen);
            ShopPanel2.NombreProducto = listaRopa[1].NombreRopa;
            ShopPanel2.Id = listaRopa[1].Id;
            if (!listaRopa[1].Comprado)
                ShopPanel2.SoldOut();
            else
                ShopPanel2.OcultarSold();
            ShopPanel3.Precio = "$ " + (listaRopa[2].Precio - 1).ToString() + ".99";
            ShopPanel3.CargarImagenes(listaRopa[2].Imagen);
            ShopPanel3.NombreProducto = listaRopa[2].NombreRopa;
            ShopPanel3.Id = listaRopa[2].Id;
            if (!listaRopa[2].Comprado)
                ShopPanel3.SoldOut();
            else
                ShopPanel3.OcultarSold();
            ShopPanel4.Precio = "$ " + (listaRopa[3].Precio - 1).ToString() + ".99";
            ShopPanel4.CargarImagenes(listaRopa[3].Imagen);
            ShopPanel4.NombreProducto = listaRopa[3].NombreRopa;
            ShopPanel4.Id = listaRopa[3].Id;
            if (!listaRopa[3].Comprado)
                ShopPanel4.SoldOut();
            else
                ShopPanel4.OcultarSold();
            ShopPanel5.Precio = "$ " + (listaRopa[4].Precio - 1).ToString() + ".99";
            ShopPanel5.CargarImagenes(listaRopa[4].Imagen);
            ShopPanel5.NombreProducto = listaRopa[4].NombreRopa;
            ShopPanel5.Id = listaRopa[4].Id;
            if (!listaRopa[4].Comprado)
                ShopPanel5.SoldOut();
            else
                ShopPanel5.OcultarSold();
            ShopPanel6.Precio = "$ " + (listaRopa[5].Precio - 1).ToString() + ".99";
            ShopPanel6.CargarImagenes(listaRopa[5].Imagen);
            ShopPanel6.NombreProducto = listaRopa[5].NombreRopa;
            ShopPanel6.Id = listaRopa[5].Id;
            if (!listaRopa[5].Comprado)
                ShopPanel6.SoldOut();
            else
                ShopPanel6.OcultarSold();
            ShopPanel7.Precio = "$ " + (listaRopa[6].Precio - 1).ToString() + ".99";
            ShopPanel7.CargarImagenes(listaRopa[6].Imagen);
            ShopPanel7.NombreProducto = listaRopa[6].NombreRopa;
            ShopPanel7.Id = listaRopa[6].Id;
            if (!listaRopa[6].Comprado)
                ShopPanel7.SoldOut();
            else
                ShopPanel7.OcultarSold();
            ShopPanel8.Precio = "$ " + (listaRopa[7].Precio - 1).ToString() + ".99";
            ShopPanel8.CargarImagenes(listaRopa[7].Imagen);
            ShopPanel8.NombreProducto = listaRopa[7].NombreRopa;
            ShopPanel8.Id = listaRopa[7].Id;
            if (!listaRopa[7].Comprado)
                ShopPanel8.SoldOut();
            else
                ShopPanel8.OcultarSold();
        }

        private void PaginaDosRopa()
        {
            eShopmanager = 1;
            ShopPanel1.Precio = "$ " + (listaRopa[8].Precio - 1).ToString() + ".99";
            ShopPanel1.CargarImagenes(listaRopa[8].Imagen);
            ShopPanel1.NombreProducto = listaRopa[8].NombreRopa;
            ShopPanel1.Id = listaRopa[8].Id;
            if (!listaRopa[8].Comprado)
                ShopPanel1.SoldOut();
            else
                ShopPanel1.OcultarSold();
            ShopPanel2.Precio = "$ " + (listaRopa[9].Precio - 1).ToString() + ".99";
            ShopPanel2.CargarImagenes(listaRopa[9].Imagen);
            ShopPanel2.NombreProducto = listaRopa[9].NombreRopa;
            ShopPanel2.Id = listaRopa[9].Id;
            if (!listaRopa[9].Comprado)
                ShopPanel2.SoldOut();
            else
                ShopPanel2.OcultarSold();
            ShopPanel3.Precio = "$ " + (listaRopa[10].Precio - 1).ToString() + ".99";
            ShopPanel3.CargarImagenes(listaRopa[10].Imagen);
            ShopPanel3.NombreProducto = listaRopa[10].NombreRopa;
            ShopPanel3.Id = listaRopa[10].Id;
            if (!listaRopa[10].Comprado)
                ShopPanel3.SoldOut();
            else
                ShopPanel3.OcultarSold();
            ShopPanel4.Precio = "$ " + (listaRopa[11].Precio - 1).ToString() + ".99";
            ShopPanel4.CargarImagenes(listaRopa[11].Imagen);
            ShopPanel4.NombreProducto = listaRopa[11].NombreRopa;
            ShopPanel4.Id = listaRopa[11].Id;
            if (!listaRopa[11].Comprado)
                ShopPanel4.SoldOut();
            else
                ShopPanel4.OcultarSold();
            ShopPanel5.Precio = "$ " + (listaRopa[12].Precio - 1).ToString() + ".99";
            ShopPanel5.CargarImagenes(listaRopa[12].Imagen);
            ShopPanel5.NombreProducto = listaRopa[12].NombreRopa;
            ShopPanel5.Id = listaRopa[12].Id;
            if (!listaRopa[12].Comprado)
                ShopPanel5.SoldOut();
            else
                ShopPanel5.OcultarSold();
            ShopPanel6.Precio = "$ " + (listaRopa[13].Precio - 1).ToString() + ".99";
            ShopPanel6.CargarImagenes(listaRopa[13].Imagen);
            ShopPanel6.NombreProducto = listaRopa[13].NombreRopa;
            ShopPanel6.Id = listaRopa[13].Id;
            if (!listaRopa[13].Comprado)
                ShopPanel6.SoldOut();
            else
                ShopPanel6.OcultarSold();
            ShopPanel7.Precio = "$ " + (listaRopa[14].Precio - 1).ToString() + ".99";
            ShopPanel7.CargarImagenes(listaRopa[14].Imagen);
            ShopPanel7.NombreProducto = listaRopa[14].NombreRopa;
            ShopPanel7.Id = listaRopa[14].Id;
            if (!listaRopa[14].Comprado)
                ShopPanel7.SoldOut();
            else
                ShopPanel7.OcultarSold();
            ShopPanel8.Precio = "$ " + (listaRopa[15].Precio - 1).ToString() + ".99";
            ShopPanel8.CargarImagenes(listaRopa[15].Imagen);
            ShopPanel8.NombreProducto = listaRopa[15].NombreRopa;
            ShopPanel8.Id = listaRopa[15].Id;
            if (!listaRopa[15].Comprado)
                ShopPanel8.SoldOut();
            else
                ShopPanel8.OcultarSold();
        }

        private void PaginaUnoMuebles()
        {
            eShopmanager = 2;
            ShopPanel1.Precio = "$ " + (listaMuebles[0].Precio - 1).ToString() + ".99";
            ShopPanel1.CargarImagenes(listaMuebles[0].Imagen);
            ShopPanel1.NombreProducto = listaMuebles[0].NombreMueble;
            ShopPanel1.Id = listaMuebles[0].Id;
            if (!listaMuebles[0].Comprado)
                ShopPanel1.SoldOut();
            else
                ShopPanel1.OcultarSold();
            ShopPanel2.Precio = "$ " + (listaMuebles[1].Precio - 1).ToString() + ".99";
            ShopPanel2.CargarImagenes(listaMuebles[1].Imagen);
            ShopPanel2.NombreProducto = listaMuebles[1].NombreMueble;
            ShopPanel2.Id = listaMuebles[1].Id;
            if (!listaMuebles[1].Comprado)
                ShopPanel2.SoldOut();
            else
                ShopPanel2.OcultarSold();
            ShopPanel3.Precio = "$ " + (listaMuebles[2].Precio - 1).ToString() + ".99";
            ShopPanel3.CargarImagenes(listaMuebles[2].Imagen);
            ShopPanel3.NombreProducto = listaMuebles[2].NombreMueble;
            ShopPanel3.Id = listaMuebles[2].Id;
            if (!listaMuebles[2].Comprado)
                ShopPanel3.SoldOut();
            else
                ShopPanel3.OcultarSold();
            ShopPanel4.Precio = "$ " + (listaMuebles[3].Precio - 1).ToString() + ".99";
            ShopPanel4.CargarImagenes(listaMuebles[3].Imagen);
            ShopPanel4.NombreProducto = listaMuebles[3].NombreMueble;
            ShopPanel4.Id = listaMuebles[3].Id;
            if (!listaMuebles[3].Comprado)
                ShopPanel4.SoldOut();
            else
                ShopPanel4.OcultarSold();
            ShopPanel5.Precio = "$ " + (listaMuebles[4].Precio - 1).ToString() + ".99";
            ShopPanel5.CargarImagenes(listaMuebles[4].Imagen);
            ShopPanel5.NombreProducto = listaMuebles[4].NombreMueble;
            ShopPanel5.Id = listaMuebles[4].Id;
            if (!listaMuebles[4].Comprado)
                ShopPanel5.SoldOut();
            else
                ShopPanel5.OcultarSold();
            ShopPanel6.Precio = "$ " + (listaMuebles[5].Precio - 1).ToString() + ".99";
            ShopPanel6.CargarImagenes(listaMuebles[5].Imagen);
            ShopPanel6.NombreProducto = listaMuebles[5].NombreMueble;
            ShopPanel6.Id = listaMuebles[5].Id;
            if (!listaMuebles[5].Comprado)
                ShopPanel6.SoldOut();
            else
                ShopPanel6.OcultarSold();
            ShopPanel7.Precio = "$ " + (listaMuebles[6].Precio - 1).ToString() + ".99";
            ShopPanel7.CargarImagenes(listaMuebles[6].Imagen);
            ShopPanel7.NombreProducto = listaMuebles[6].NombreMueble;
            ShopPanel7.Id = listaMuebles[6].Id;
            if (!listaMuebles[6].Comprado)
                ShopPanel7.SoldOut();
            else
                ShopPanel7.OcultarSold();
            ShopPanel8.Precio = "$ " + (listaMuebles[7].Precio - 1).ToString() + ".99";
            ShopPanel8.CargarImagenes(listaMuebles[7].Imagen);
            ShopPanel8.NombreProducto = listaMuebles[7].NombreMueble;
            ShopPanel8.Id = listaMuebles[7].Id;
            if (!listaMuebles[7].Comprado)
                ShopPanel8.SoldOut();
            else
                ShopPanel8.OcultarSold();
        }

        private void PaginaDosMuebles()
        {
            eShopmanager = 2;
            ShopPanel1.Precio = "$ " + (listaMuebles[8].Precio - 1).ToString() + ".99";
            ShopPanel1.CargarImagenes(listaMuebles[8].Imagen);
            ShopPanel1.NombreProducto = listaMuebles[8].NombreMueble;
            ShopPanel1.Id = listaMuebles[8].Id;
            if (!listaMuebles[8].Comprado)
                ShopPanel1.SoldOut();
            else
                ShopPanel1.OcultarSold();
            ShopPanel2.Precio = "$ " + (listaMuebles[9].Precio - 1).ToString() + ".99";
            ShopPanel2.CargarImagenes(listaMuebles[9].Imagen);
            ShopPanel2.NombreProducto = listaMuebles[9].NombreMueble;
            ShopPanel2.Id = listaMuebles[9].Id;
            if (!listaMuebles[9].Comprado)
                ShopPanel2.SoldOut();
            else
                ShopPanel2.OcultarSold();
            ShopPanel3.Precio = "$ " + (listaMuebles[10].Precio - 1).ToString() + ".99";
            ShopPanel3.CargarImagenes(listaMuebles[10].Imagen);
            ShopPanel3.NombreProducto = listaMuebles[10].NombreMueble;
            ShopPanel3.Id = listaMuebles[10].Id;
            if (!listaMuebles[10].Comprado)
                ShopPanel3.SoldOut();
            else
                ShopPanel3.OcultarSold();
            ShopPanel4.Precio = "$ " + (listaMuebles[11].Precio - 1).ToString() + ".99";
            ShopPanel4.CargarImagenes(listaMuebles[11].Imagen);
            ShopPanel4.NombreProducto = listaMuebles[11].NombreMueble;
            ShopPanel4.Id = listaMuebles[11].Id;
            if (!listaMuebles[11].Comprado)
                ShopPanel4.SoldOut();
            else
                ShopPanel4.OcultarSold();
            ShopPanel5.Precio = "$ " + (listaMuebles[12].Precio - 1).ToString() + ".99";
            ShopPanel5.CargarImagenes(listaMuebles[12].Imagen);
            ShopPanel5.NombreProducto = listaMuebles[12].NombreMueble;
            ShopPanel5.Id = listaMuebles[12].Id;
            if (!listaMuebles[12].Comprado)
                ShopPanel5.SoldOut();
            else
                ShopPanel5.OcultarSold();
            ShopPanel6.Precio = "$ " + (listaMuebles[13].Precio - 1).ToString() + ".99";
            ShopPanel6.CargarImagenes(listaMuebles[13].Imagen);
            ShopPanel6.NombreProducto = listaMuebles[13].NombreMueble;
            ShopPanel6.Id = listaMuebles[13].Id;
            if (!listaMuebles[13].Comprado)
                ShopPanel6.SoldOut();
            else
                ShopPanel6.OcultarSold();
            ShopPanel7.Precio = "$ " + (listaMuebles[14].Precio - 1).ToString() + ".99";
            ShopPanel7.CargarImagenes(listaMuebles[14].Imagen);
            ShopPanel7.NombreProducto = listaMuebles[14].NombreMueble;
            ShopPanel7.Id = listaMuebles[14].Id;
            if (!listaMuebles[14].Comprado)
                ShopPanel7.SoldOut();
            else
                ShopPanel7.OcultarSold();
            ShopPanel8.Precio = "$ " + (listaMuebles[15].Precio - 1).ToString() + ".99";
            ShopPanel8.CargarImagenes(listaMuebles[15].Imagen);
            ShopPanel8.NombreProducto = listaMuebles[15].NombreMueble;
            ShopPanel8.Id = listaMuebles[15].Id;
            if (!listaMuebles[15].Comprado)
                ShopPanel8.SoldOut();
            else
                ShopPanel8.OcultarSold();
        }

        List<Electronicos> listaElectro = new List<Electronicos>();
        NegocioBaseDatos negocioElectro = new NegocioBaseDatos();
        private void PaginaUnoElectros()
        {
            eShopmanager = 3;
            ShopPanel1.Precio = "$ " + (listaElectro[0].Precio - 1).ToString() + ".99";
            ShopPanel1.CargarImagenes(listaElectro[0].Imagen);
            ShopPanel1.NombreProducto = listaElectro[0].NombreElectronicos;
            ShopPanel1.Id = listaElectro[0].Id;
            if (!listaElectro[0].Comprado)
                ShopPanel1.SoldOut();
            else
                ShopPanel1.OcultarSold();
            ShopPanel2.Precio = "$ " + (listaElectro[1].Precio - 1).ToString() + ".99";
            ShopPanel2.CargarImagenes(listaElectro[1].Imagen);
            ShopPanel2.NombreProducto = listaElectro[1].NombreElectronicos;
            ShopPanel2.Id = listaElectro[1].Id;
            if (!listaElectro[1].Comprado)
                ShopPanel2.SoldOut();
            else
                ShopPanel2.OcultarSold();
            ShopPanel3.Precio = "$ " + (listaElectro[2].Precio - 1).ToString() + ".99";
            ShopPanel3.CargarImagenes(listaElectro[2].Imagen);
            ShopPanel3.NombreProducto = listaElectro[2].NombreElectronicos;
            ShopPanel3.Id = listaElectro[2].Id;
            if (!listaElectro[2].Comprado)
                ShopPanel3.SoldOut();
            else
                ShopPanel3.OcultarSold();
            ShopPanel4.Precio = "$ " + (listaElectro[3].Precio - 1).ToString() + ".99";
            ShopPanel4.CargarImagenes(listaElectro[3].Imagen);
            ShopPanel4.NombreProducto = listaElectro[3].NombreElectronicos;
            ShopPanel4.Id = listaElectro[3].Id;
            if (!listaElectro[3].Comprado)
                ShopPanel4.SoldOut();
            else
                ShopPanel4.OcultarSold();
            ShopPanel5.Precio = "$ " + (listaElectro[4].Precio - 1).ToString() + ".99";
            ShopPanel5.CargarImagenes(listaElectro[4].Imagen);
            ShopPanel5.NombreProducto = listaElectro[4].NombreElectronicos;
            ShopPanel5.Id = listaElectro[4].Id;
            if (!listaElectro[4].Comprado)
                ShopPanel5.SoldOut();
            else
                ShopPanel5.OcultarSold();
            ShopPanel6.Precio = "$ " + (listaElectro[5].Precio - 1).ToString() + ".99";
            ShopPanel6.CargarImagenes(listaElectro[5].Imagen);
            ShopPanel6.NombreProducto = listaElectro[5].NombreElectronicos;
            ShopPanel6.Id = listaElectro[5].Id;
            if (!listaElectro[5].Comprado)
                ShopPanel6.SoldOut();
            else
                ShopPanel6.OcultarSold();
            ShopPanel7.Precio = "$ " + (listaElectro[6].Precio - 1).ToString() + ".99";
            ShopPanel7.CargarImagenes(listaElectro[6].Imagen);
            ShopPanel7.NombreProducto = listaElectro[6].NombreElectronicos;
            ShopPanel7.Id = listaElectro[6].Id;
            if (!listaElectro[6].Comprado)
                ShopPanel7.SoldOut();
            else
                ShopPanel7.OcultarSold();
            ShopPanel8.Precio = "$ " + (listaElectro[7].Precio - 1).ToString() + ".99";
            ShopPanel8.CargarImagenes(listaElectro[7].Imagen);
            ShopPanel8.NombreProducto = listaElectro[7].NombreElectronicos;
            ShopPanel8.Id = listaElectro[7].Id;
            if (!listaElectro[7].Comprado)
                ShopPanel8.SoldOut();
            else
                ShopPanel8.OcultarSold();
        }

        private void PaginaDosElectros()
        {
            eShopmanager = 3;
            ShopPanel1.Precio = "$ " + (listaElectro[8].Precio - 1).ToString() + ".99";
            ShopPanel1.CargarImagenes(listaElectro[8].Imagen);
            ShopPanel1.NombreProducto = listaElectro[8].NombreElectronicos;
            ShopPanel1.Id = listaElectro[8].Id;
            if (!listaElectro[8].Comprado)
                ShopPanel1.SoldOut();
            else
                ShopPanel1.OcultarSold();
            ShopPanel2.Precio = "$ " + (listaElectro[9].Precio - 1).ToString() + ".99";
            ShopPanel2.CargarImagenes(listaElectro[9].Imagen);
            ShopPanel2.NombreProducto = listaElectro[9].NombreElectronicos;
            ShopPanel2.Id = listaElectro[9].Id;
            if (!listaElectro[9].Comprado)
                ShopPanel2.SoldOut();
            else
                ShopPanel2.OcultarSold();
            ShopPanel3.Precio = "$ " + (listaElectro[10].Precio - 1).ToString() + ".99";
            ShopPanel3.CargarImagenes(listaElectro[10].Imagen);
            ShopPanel3.NombreProducto = listaElectro[10].NombreElectronicos;
            ShopPanel3.Id = listaElectro[10].Id;
            if (!listaElectro[10].Comprado)
                ShopPanel3.SoldOut();
            else
                ShopPanel3.OcultarSold();
            ShopPanel4.Precio = "$ " + (listaElectro[11].Precio - 1).ToString() + ".99";
            ShopPanel4.CargarImagenes(listaElectro[11].Imagen);
            ShopPanel4.NombreProducto = listaElectro[11].NombreElectronicos;
            ShopPanel4.Id = listaElectro[11].Id;
            if (!listaElectro[11].Comprado)
                ShopPanel4.SoldOut();
            else
                ShopPanel4.OcultarSold();
            ShopPanel5.Precio = "$ " + (listaElectro[12].Precio - 1).ToString() + ".99";
            ShopPanel5.CargarImagenes(listaElectro[12].Imagen);
            ShopPanel5.NombreProducto = listaElectro[12].NombreElectronicos;
            ShopPanel5.Id = listaElectro[12].Id;
            if (!listaElectro[12].Comprado)
                ShopPanel5.SoldOut();
            else
                ShopPanel5.OcultarSold();
            ShopPanel6.Precio = "$ " + (listaElectro[13].Precio - 1).ToString() + ".99";
            ShopPanel6.CargarImagenes(listaElectro[13].Imagen);
            ShopPanel6.NombreProducto = listaElectro[13].NombreElectronicos;
            ShopPanel6.Id = listaElectro[13].Id;
            if (!listaElectro[13].Comprado)
                ShopPanel6.SoldOut();
            else
                ShopPanel6.OcultarSold();
            ShopPanel7.Precio = "$ " + (listaElectro[14].Precio - 1).ToString() + ".99";
            ShopPanel7.CargarImagenes(listaElectro[14].Imagen);
            ShopPanel7.NombreProducto = listaElectro[14].NombreElectronicos;
            ShopPanel7.Id = listaElectro[14].Id;
            if (!listaElectro[14].Comprado)
                ShopPanel7.SoldOut();
            else
                ShopPanel7.OcultarSold();
            ShopPanel8.Precio = "$ " + (listaElectro[15].Precio - 1).ToString() + ".99";
            ShopPanel8.CargarImagenes(listaElectro[15].Imagen);
            ShopPanel8.NombreProducto = listaElectro[15].NombreElectronicos;
            ShopPanel8.Id = listaElectro[15].Id;
            if (!listaElectro[15].Comprado)
                ShopPanel8.SoldOut();
            else
                ShopPanel8.OcultarSold();
        }

        private void Servicios1_CheckedChanged(object sender, EventArgs e)
        {
            if (AbonarFacturas.Visible == false)
                AbonarFacturas.Visible = true;
        }

        private void AbonarFacturas_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Pagar estos servicios?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == resultado)
            {
                NegocioBaseDatos negocioPagarfacturas = new NegocioBaseDatos();
                if (Servicios1.Checked == true)
                {
                    if (miDinero.MiDinero-75>=0)
                    {
                        negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero - 75);
                        estadoFacturas = true;
                        MessageBox.Show("Se realizo el pago correctamente! Recuerda que todos los meses debes abonar tus servicios");
                    }
                    else
                    {
                        MessageBox.Show("No tiene el suficiente dinero para abonar el servicio basico, GameOver");
                    }
                }
                else if (Servicios2.Checked == true)
                {
                    if (miDinero.MiDinero - 100 >= 0)
                    {
                        negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero - 100);
                        estadoFacturas = true;
                        MessageBox.Show("Se realizo el pago correctamente! Recuerda que todos los meses debes abonar tus servicios");
                    }
                    else
                    {
                        MessageBox.Show("No tiene el suficiente dinero para abonar el esta opcion, elija una mas barata");
                    }
                }
                else if (Servicios3.Checked == true)
                {
                    if (miDinero.MiDinero - 125 >= 0)
                    {
                        negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero - 125);
                        estadoFacturas = true;
                        MessageBox.Show("Se realizo el pago correctamente! Recuerda que todos los meses debes abonar tus servicios");
                    }
                    else
                    {
                        MessageBox.Show("No tiene el suficiente dinero para abonar el esta opcion, elija una mas barata");
                    }
                }
                else if (Servicios4.Checked == true)
                {
                    if (miDinero.MiDinero - 150 >= 0)
                    {
                        negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero - 150);
                        estadoFacturas = true;
                        MessageBox.Show("Se realizo el pago correctamente! Recuerda que todos los meses debes abonar tus servicios");
                    }
                    else
                    {
                        MessageBox.Show("No tiene el suficiente dinero para abonar el esta opcion, elija una mas barata");
                    }
                }
                else
                {
                    if (miDinero.MiDinero - 180 >= 0)
                    {
                        negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero - 180);
                        estadoFacturas = true;
                        MessageBox.Show("Se realizo el pago correctamente! Recuerda que todos los meses debes abonar tus servicios");
                    }
                    else
                    {
                        MessageBox.Show("No tiene el suficiente dinero para abonar el esta opcion, elija una mas barata");
                    }
                }
            }
        }
    }

}
