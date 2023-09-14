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
            //MessageBox.Show("" + Formato);
            //FormatearFecha(fechaAux);
            //MessageBox.Show("" + Formato);
            NegocioBaseDatos alquilerBDManager = new NegocioBaseDatos();
            Alquilando = alquilerBDManager.LeerBanderaAlquiler();
            CasaAlquilada = alquilerBDManager.LeerCasaAlquilada();
            listaAlquiler = negocioAlquiler.DevolverAlquiler(true, CasaAlquilada);
            miDinero.MiDinero = Dinero.DevolverDinero();
            MessageBox.Show("Tu Dinero es: " + miDinero.MiDinero);
            alquileres1.ButtonClick += MiUserControl_ButtonClick;
            alquileres2.ButtonClick += MiUserControl2_ButtonClick;
            if (!Alquilando)
            {
                Ocultar();
                MessageBox.Show("Debe Pagar el Alquiler Moroso!");
                PaginaUnoAlquiler();
                VolverBoton.Visible = false;
            }

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

            if (banderaVolverReglas && banderaEconomiaParaMostrar)
            {
                BotonPistas.Visible = true;
                PilotosBoton.Visible = true;
                ReglasBoton.Visible = true;
                EconomiaBoton.Visible = true;
                HistorialBoton.Visible = true;
                AutosBoton.Visible = true;
                CloseBoton.Visible = true;
                //BackEconomia.Visible = true;
                //NextEconomia.Visible = true;
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

        private void FacturasPictureBox_Click(object sender, EventArgs e)
        {

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

        private void RopaPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void GastosVariosPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void MueblesPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void GarajePictureBox_Click(object sender, EventArgs e)
        {

        }

        private void ElectroPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void CarDealerPictureBox_Click(object sender, EventArgs e)
        {

        }
        NegocioBaseDatos negocioHistorial = new NegocioBaseDatos();
        List<Historial> listaHistorial;
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
                VolverBoton.Visible = false;
                BuscarRegistroBoton.Visible = false;
                PaginaUnoAlquiler();    
            }
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
            alquileres1.Pieza = listaAlquiler[0].CantidadDormitorios.ToString();
            alquileres1.Ducha = listaAlquiler[0].CantidadDuchas.ToString();
            alquileres1.Garaje = listaAlquiler[0].CantidadGarajes.ToString();
            alquileres1.Sala = listaAlquiler[0].CantidadSalasEstar.ToString();
            alquileres1.Sala = listaAlquiler[0].CantidadSalasEstar.ToString();
            alquileres1.Precio = listaAlquiler[0].PrecioDepartamento.ToString();
            alquileres1.Id = listaAlquiler[0].NumeroRegistro;
            alquileres2.TituloDepa = listaAlquiler[1].NombreAlquiler;
            alquileres2.CargarImagenes(listaAlquiler[1].ImagenAlquiler);
            alquileres2.Pieza = listaAlquiler[1].CantidadDormitorios.ToString();
            alquileres2.Ducha = listaAlquiler[1].CantidadDuchas.ToString();
            alquileres2.Garaje = listaAlquiler[1].CantidadGarajes.ToString();
            alquileres2.Sala = listaAlquiler[1].CantidadSalasEstar.ToString();
            alquileres2.Sala = listaAlquiler[1].CantidadSalasEstar.ToString();
            alquileres2.Precio = listaAlquiler[1].PrecioDepartamento.ToString();
            alquileres2.Id = listaAlquiler[1].NumeroRegistro;
        }
        private void PaginaDosAlquiler()
        {
            alquileres1.TituloDepa = listaAlquiler[2].NombreAlquiler;
            alquileres1.CargarImagenes(listaAlquiler[2].ImagenAlquiler);
            alquileres1.Pieza = listaAlquiler[2].CantidadDormitorios.ToString();
            alquileres1.Ducha = listaAlquiler[2].CantidadDuchas.ToString();
            alquileres1.Garaje = listaAlquiler[2].CantidadGarajes.ToString();
            alquileres1.Sala = listaAlquiler[2].CantidadSalasEstar.ToString();
            alquileres1.Sala = listaAlquiler[2].CantidadSalasEstar.ToString();
            alquileres1.Precio = listaAlquiler[2].PrecioDepartamento.ToString();
            alquileres1.Id = listaAlquiler[2].NumeroRegistro;
            alquileres2.TituloDepa = listaAlquiler[3].NombreAlquiler;
            alquileres2.CargarImagenes(listaAlquiler[3].ImagenAlquiler);
            alquileres2.Pieza = listaAlquiler[3].CantidadDormitorios.ToString();
            alquileres2.Ducha = listaAlquiler[3].CantidadDuchas.ToString();
            alquileres2.Garaje = listaAlquiler[3].CantidadGarajes.ToString();
            alquileres2.Sala = listaAlquiler[3].CantidadSalasEstar.ToString();
            alquileres2.Sala = listaAlquiler[3].CantidadSalasEstar.ToString();
            alquileres2.Precio = listaAlquiler[3].PrecioDepartamento.ToString();
            alquileres2.Id = listaAlquiler[3].NumeroRegistro;
        }
        private void PaginaTresAlquiler()
        {
            alquileres1.TituloDepa = listaAlquiler[4].NombreAlquiler;
            alquileres1.CargarImagenes(listaAlquiler[4].ImagenAlquiler);
            alquileres1.Pieza = listaAlquiler[4].CantidadDormitorios.ToString();
            alquileres1.Ducha = listaAlquiler[4].CantidadDuchas.ToString();
            alquileres1.Garaje = listaAlquiler[4].CantidadGarajes.ToString();
            alquileres1.Sala = listaAlquiler[4].CantidadSalasEstar.ToString();
            alquileres1.Sala = listaAlquiler[4].CantidadSalasEstar.ToString();
            alquileres1.Precio = listaAlquiler[4].PrecioDepartamento.ToString();
            alquileres1.Id = listaAlquiler[4].NumeroRegistro;
            alquileres2.TituloDepa = listaAlquiler[5].NombreAlquiler;
            alquileres2.CargarImagenes(listaAlquiler[5].ImagenAlquiler);
            alquileres2.Pieza = listaAlquiler[5].CantidadDormitorios.ToString();
            alquileres2.Ducha = listaAlquiler[5].CantidadDuchas.ToString();
            alquileres2.Garaje = listaAlquiler[5].CantidadGarajes.ToString();
            alquileres2.Sala = listaAlquiler[5].CantidadSalasEstar.ToString();
            alquileres2.Sala = listaAlquiler[5].CantidadSalasEstar.ToString();
            alquileres2.Precio = listaAlquiler[5].PrecioDepartamento.ToString();
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
                VolverBoton.Visible = true;
                Alquilando = true;
                Alquilando = negocioPago.ActualizarAlquilando(Alquilando);
                CasaAlquilada = alquileres1.Id;
                CasaAlquilada = negocioPago.ActualizarCasaAlquilada(CasaAlquilada);
            }
            else
            {
                MessageBox.Show("No tiene dinero para pagar el alquiler, si no puede renovar el alquiler Pierde el juego");
            }
            
            
        }

        private void MiUserControl2_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoAlquiler(alquileres1.Id) > 0)
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
            }
            else
            {
                MessageBox.Show("No tiene dinero para pagar el alquiler, si no puede renovar el alquiler Pierde el juego");
            }
        }

    }

}
