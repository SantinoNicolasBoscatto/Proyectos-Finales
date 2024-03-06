using System;
using NAudio.Wave;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Modelo_Clases;
using Negocio_Base_Datos;
using System.Globalization;
using System.Media;

namespace Touge_App
{
    public partial class TougeForms : Form
    {
        //SONIDOS, AUDIO Y MUSICA
        enum Precios
        {
            aceite = 85,
            manMotor = 125,
            manAuto = 75,
            makeAWD = 2500,
            turbo = 5000,
            repro = 750,
            swapEngine = 0,
            reduccionWeight = 235,
            carWash = 50,
            seguro = 750,
            dryTyres = 1120,
            rainTyres = 1260,
            vinilos = 35
        }
        private readonly WaveOutEvent waveOutDevice = new WaveOutEvent();
        readonly private SoundPlayer compraSonido = new SoundPlayer("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/Musica/Mp3Sounds/Buying.wav");
        readonly private SoundPlayer aceiteSonido = new SoundPlayer(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\Musica\Mp3Sounds\AceiteSonido.wav");
        readonly private SoundPlayer mantenimientoMotorSonido = new SoundPlayer(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\Musica\Mp3Sounds\MotorMantenimiento.wav");
        readonly private SoundPlayer TurboSonido = new SoundPlayer(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\Musica\Mp3Sounds\Sutututu.wav");
        readonly private SoundPlayer LimpiarSonido = new SoundPlayer(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\Musica\Mp3Sounds\limpiar.wav");
        readonly private SoundPlayer PitsSonido = new SoundPlayer(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\Musica\Mp3Sounds\Pits.wav");
        readonly private SoundPlayer GasSonido = new SoundPlayer(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\Musica\Mp3Sounds\Gas.wav");
        private AudioFileReader audioFile;
        List<Musica> listaCanciones;
        //NEGOCIOS
        readonly NegocioBaseDatos negocioBD = new NegocioBaseDatos();
        readonly NegocioBaseDatos negocioAlquiler = new NegocioBaseDatos();
        readonly NegocioBaseDatos Dinero = new NegocioBaseDatos();
        readonly NegocioBaseDatos negocioComida = new NegocioBaseDatos();
        readonly NegocioBaseDatos negocioHigiene = new NegocioBaseDatos();
        readonly NegocioBaseDatos negocioBDPilotos = new NegocioBaseDatos();
        NegocioBaseDatos negocioBDAutos;
        readonly NegocioBaseDatos negocioHistorial = new NegocioBaseDatos();
        readonly NegocioBaseDatos negocioRopa = new NegocioBaseDatos();
        readonly NegocioBaseDatos negocioMuebles = new NegocioBaseDatos();
        readonly NegocioBaseDatos negocioElectro = new NegocioBaseDatos();
        //LISTAS
        public List<Modelo_Clases.Comida> ListaComida { get; private set; }
        public List<Modelo_Clases.Higiene> ListaHigiene { get; private set; }
        List<Alquiler> listaAlquiler = new List<Alquiler>();
        List<Pilotos> listaPilotos = new List<Pilotos>();
        List<Autos> listaAutos = new List<Autos>();
        List<Historial> listaHistorial;
        List<Pistas> listaPistas = new List<Pistas>();
        List<Ropa> listaRopa;
        List<Mueble> listaMuebles;
        List<Electronicos> listaElectro = new List<Electronicos>();
        List<EShopPanels> listaMisCosas; //Lista De Paneles (8-Max)
        List<MisObjetos> listaObjetosAux = null; //Lista de Mis Objetos

        //Fecha
        Fecha fechaAux;
        DateTime fechaManager;
        DateTime CambioMes;
        string Formato;
        //MANGERS
        int higieneManager;
        int aceiteManager;
        int motorManager;
        int autoManager;
        int gomasManager;
        int gomasDeLluviaManager;
        int limpiezaManager;
        int eShopmanager = 0;
        int CasaAlquilada;
        //BOOL ESTADOS
        bool estadoFacturas;
        bool estadoComida;
        bool estadoSeguro;
        bool estadoLimpieza;
        bool estadoAceite;
        bool estadoMotor;
        bool estadoAuto;
        bool estadoRepro;
        bool estadoTurbo;
        bool estadoAWD;
        bool Alquilando;
        //DINERO
        readonly Economia miDinero = new Economia();
        string plataFormato;
        //PLAYER DATOS
        readonly string Player = "Santino Boscatto";
        Autos MiAuto;
        //TIMERS
        readonly Timer timerCompra = new Timer();
        readonly Timer timerCursor = new Timer();
        //SIZE Y FUNCION DEL RESIZING
        bool banderaSize = false;
        private Size initialSize;
        private void TougeForms_Resize(object sender, EventArgs e)
        {
            // Obtener el tamaño actual del formulario
            Size currentSize = this.ClientSize;

            // Comparar el tamaño actual con el tamaño inicial
            if (currentSize.Width > initialSize.Width || currentSize.Height > initialSize.Height)
            {
                banderaSize = true;
                PilotoLabel.Location = new Point(145, 480);
                DineroPb.Location = new Point(670, 722);
                BackEconomia.Location = new Point(0, 327);
                NextEconomia.Location = new Point(1310, 327);
                PilotoNameAuto.Location = new Point(23, 545);
                Font nuevoFont = new Font("F1 Turbo", 18);
                Rain.Location = new Point(155, 354);
                PilotoNameAuto.Font = nuevoFont;
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

        //CONSTRUCTOR DEL FORMS
        public TougeForms()
        {
            InitializeComponent();
            //CONFIGURACION DEL DGV
            initialSize = this.ClientSize;
            this.Resize += TougeForms_Resize;
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.MidnightBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
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

        Form2 mensajeBox = new Form2();
        //CARGA DEL FORMS
        private void Form1_Load(object sender, EventArgs e)
        {
            VolverBoton.Visible = false;
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
            Trasparentado(CloseButton, ConfiguracionBoton);
            //Pido un Fondo Random
            RandomFondo();
            //Inicio en Segunda pantalla si hay
            Screen secondScreen = Screen.AllScreens.Length > 1 ? Screen.AllScreens[1] : Screen.PrimaryScreen;
            Location = secondScreen.Bounds.Location;
            //RECUPERO FECHA Y LA FORMATEO
            NegocioBaseDatos negocioFecha = new NegocioBaseDatos();
            fechaAux = negocioFecha.DevolverFecha();
            CambioMes = fechaAux.FechaManager;
            FormatearFecha(fechaAux);
            // DEVUELVO LISTA DE ALQUILERES
            NegocioBaseDatos alquilerBDManager = new NegocioBaseDatos();
            Alquilando = alquilerBDManager.LeerBanderaAlquiler();
            CasaAlquilada = alquilerBDManager.LeerCasaAlquilada();
            estadoFacturas = alquilerBDManager.LeerBanderaFacturas();
            estadoComida = alquilerBDManager.LeerBanderaComida();
            listaAlquiler = negocioAlquiler.DevolverAlquiler(true, CasaAlquilada);
            //GET DE MI DINERO
            miDinero.MiDinero = Dinero.DevolverDinero();
            //SUSCRIBO A LOS EVENTOS DE ALQUILER, SHOP, PANELSCOMIDA, MECANICO, HIGIENE, TIMER Y GASTOS DIARIOS
            alquileres1.ButtonClick += MiUserControl_ButtonClick;
            alquileres2.ButtonClick += MiUserControl2_ButtonClick;
            ShopPanel1.ButtonClick += ShopPanel1_ButtonClick; ShopPanel2.ButtonClick += ShopPanel1_ButtonClick; ShopPanel3.ButtonClick += ShopPanel1_ButtonClick; ShopPanel4.ButtonClick += ShopPanel1_ButtonClick; ShopPanel5.ButtonClick += ShopPanel1_ButtonClick; ShopPanel6.ButtonClick += ShopPanel1_ButtonClick; ShopPanel7.ButtonClick += ShopPanel1_ButtonClick; ShopPanel8.ButtonClick += ShopPanel1_ButtonClick;
            PanelComida1.ButtonClick += PanelComida1_ButtonClick; PanelComida2.ButtonClick += PanelComida1_ButtonClick; PanelComida3.ButtonClick += PanelComida1_ButtonClick; PanelComida4.ButtonClick += PanelComida1_ButtonClick;
            mecanico1.ButtonClick += Mecanico1_ButtonClick; mecanico2.ButtonClick += Mecanico2_ButtonClick; mecanico3.ButtonClick += Mecanico3_ButtonClick; mecanico4.ButtonClick += Mecanico4_ButtonClick;
            timerCompra.Tick += Timer1_Tick;
            timerCursor.Tick += Timer2_Tick;
            timerCompra.Enabled = false;
            Higiene1.ButtonClick += Higiene1_ButtonClick; Higiene2.ButtonClick += Higiene2_ButtonClick; Higiene3.ButtonClick += Higiene3_ButtonClick;
            gastosDiarios1.ButtonClick += GastosDiarios1_ButtonClick; gastosDiarios2.ButtonClick += GastosDiarios2_ButtonClick; gastosDiarios3.ButtonClick += GastosDiarios3_ButtonClick; gastosDiarios4.ButtonClick += GastosDiarios4_ButtonClick; gastosDiarios5.ButtonClick += GastosDiarios5_ButtonClick; gastosDiarios6.ButtonClick += GastosDiarios6_ButtonClick;
            // HAGO GET A  ROPA, MUEBLES, ELECTRONICOS, COMIDA, HIGIENE
            listaRopa = negocioRopa.DevolverRopa();
            listaMuebles = negocioMuebles.DevolverMuebles();
            listaElectro = negocioElectro.DevolverElectros();
            ListaComida = negocioComida.DevolverComida();
            ListaHigiene = negocioHigiene.DevolverHigiene();
            // GET HIGIENE-MANAGER PARA SABER SI DEBO COMPRAR
            higieneManager = negocioHigiene.LeerHigieneMes();
            //FORMATEO DINERO
            plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
            DineroMostrarLabel.Text = plataFormato;
            // DEVUELVO EL ESTADO DE MI AUTO
            NegocioBaseDatos negocioMiAuto = new NegocioBaseDatos();
            estadoAceite = negocioMiAuto.DevolverEstadosAuto(1);
            estadoMotor = negocioMiAuto.DevolverEstadosAuto(2);
            estadoAuto = negocioMiAuto.DevolverEstadosAuto(3);
            estadoRepro = negocioMiAuto.DevolverEstadosAuto(4);
            estadoTurbo = negocioMiAuto.DevolverEstadosAuto(5);
            estadoAWD = negocioMiAuto.DevolverEstadosAuto(6);
            estadoLimpieza = negocioMiAuto.DevolverEstadosAuto(7);
            //NOSE
            List<int> auxLista;
            auxLista = negocioMiAuto.DevolverEstadoComponentes();
            aceiteManager = auxLista[0];
            motorManager = auxLista[1];
            autoManager = auxLista[2];
            gomasManager = auxLista[3];
            limpiezaManager = auxLista[4];
            gomasDeLluviaManager = auxLista[5];
            // GET A CUAL ES MI AUTO
            MiAuto = negocioMiAuto.DevolverMiAuto();
            // GET AL SEGURO
            estadoSeguro = negocioMiAuto.LeerSeguro();
            //VERIFICACIONES DE LAS OLBIGACIONES A PAGAR PAGOS
            FechaLabel.Text = Formato;
            VolumenControl.Size = new Size(250, 50);
            NextBoton.Location = new Point(380, 625);
            BackBoton.Location = new Point(334, 625);
            VolumenControl.Location = new Point(80, 625);
            if (!estadoSeguro)
            {
                mensajeBox.Mostrar("Necesita Pagar el Seguro! Si su auto se destroza no percibira nada de dinero");
            }
            if (!Alquilando)
            {
                Ocultar();
                mensajeBox.Mostrar("Debe Pagar el Alquiler Moroso!");
                PaginaUnoAlquiler();
                VolverBoton.Visible = false;
            }
            else if (!estadoFacturas)
            {
                Ocultar();
                mensajeBox.Mostrar("Debe Pagar Sus Facturas Moroso!");
                MostrarFacturas();
                VolverBoton.Visible = false;
            }
            else if (!estadoComida)
            {
                Ocultar();
                ComidaPaginaUno(0);
                mensajeBox.Mostrar("Debe Hacer las Compras!");
                PanelComida1.Visible = true;
                PanelComida2.Visible = true;
                PanelComida3.Visible = true;
                PanelComida4.Visible = true;
                BackComida.Visible = true;
                NextComida.Visible = true;
                VolverBoton.Visible = false;
            }
            else if (higieneManager == 2)
            {
                Ocultar();
                HigienePagina();
                mensajeBox.Mostrar("Debe Comprar sus productos de higiene!");
                VolverBoton.Visible = false;
            }
        }
        //Aca se Valida mediante un bool cuando el Mouse entra o sale de los botones y el evento de repintado
        bool HoverBotonBD = false;
        private void HoverBoton_MouseEnter(object sender, EventArgs e)
        {
            HoverBotonBD = true;
        }
        private void HoverBoton_MouseLeave(object sender, EventArgs e)
        {
            HoverBotonBD = false;
        }
        private void BotonPistas_Paint(object sender, PaintEventArgs e)
        { RepintadoBotones(HoverBotonBD, e, (Button)sender); }
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
            RepintadoBotones(HoverAutosBD, e, (Button)sender);
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
            RepintadoBotones(HoverRulesBD, e, (Button)sender);
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
            RepintadoBotones(HoverEconomiaBD, e, (Button)sender);
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
            RepintadoBotones(HoverConfiguracion, e, (Button)sender);
        }
        // Idem
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
            RepintadoBotones(ModalidadBd, e, (Button)sender);
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
            PilotosPictureBox.Location = new Point(686, 14);
            AutoPilotoPictureBox.Location = new Point(14, 445);
            PaisPictureBox.Location = new Point(437, 445);
            BiografiaPilotosTextBox.Location = new Point(14, 24);
            VolverBoton.Location = new Point(1295, 628);
            BackDriver.Location = new Point(960, 628);
            NextDriver.Location = new Point(1020, 628);
            VolverBoton.Location = new Point(1295, 628);
            CloseButton.Location = new Point(1295, 625);
            ConfiguracionBoton.Location = new Point(20, 625);
            VolumenControl.Location = new Point(80, 620);
            VolumenControl.Size = new Size(245, 54);
            FichaTecnicaPb.Size = new Size(422, 603);
            BackBoton.Location = new Point(324, 625);
            NextBoton.Location = new Point(370, 625);
            CargaPistasAutosPilotosEconomia.Location = new Point(0, -5);
            FiltrarPilotosPistasAutos.Location = new Point(-5, 627);
            UpdateBoton.Location = new Point(1348, 630);
            RopaPictureBox.Location = new Point(59, 305);
            ElectroPictureBox.Location = new Point(892, 305);
            MueblesPictureBox.Location = new Point(476, 305);
            BackAuto.Location = new Point(987, 560);
            NextAuto.Location = new Point(1152, 560);
            KgHp.Location = new Point(5, 300);
            TopLabel.Location = new Point(220, 400);
            CarDealerPictureBox.Location = ElectroPictureBox.Location;
            GastosVariosPictureBox.Location = RopaPictureBox.Location;
            GarajePictureBox.Location = MueblesPictureBox.Location;
            PilotoNameAuto.BackColor = Color.FromArgb(1, 128, 128, 255);
            BackModalidad.Location = new Point(616, 235);
            NextModalidad.Location = new Point(616, 285);
            BackRanking.Location = new Point(633, 292);
            NextRanking.Location = new Point(633, 327);
            BackComida.Location = new Point(601, 210);
            NextComida.Location = new Point(601, 260);
            SiguienteAlquiler.Location = new Point(1305, 230);
            VolverAlquiler.Location = new Point(0, 230);
            NextEconomia.Location = new Point(0, 245);
            BackEconomia.Location = new Point(5, 240);
            BackMecanico.Location = new Point(608, 205);
            NextMecanico.Location = new Point(608, 255);
            FiltrarPilotosPistasAutos.Parent = PictureBoxBack;
            FiltrarPilotosPistasAutos.Visible = true;
            UpdateBoton.Parent = PictureBoxBack;
            UpdateBoton.Visible = true;
            PilotoNameAuto.Parent = FichaTecnicaPb;
            panel1.Parent = PictureBoxBack;
            panel1.BackColor = Color.FromArgb(128, 50, 50, 50);
            CargaPistasAutosPilotosEconomia.Parent = PictureBoxBack;
            CargaPistasAutosPilotosEconomia.Visible = true;
            BackObjeto.Parent = PictureBoxBack;
            NextObjeto.Parent = PictureBoxBack;
            NextObjeto.Location = new Point(1307, 320);
            NombreMiauto.Parent = PictureBoxBack;
            MiAutoPB.Parent = PictureBoxBack;
            BanderaMiAuto.Parent = PictureBoxBack;
            PanelGaraje.Parent = BanderaMiAuto;
            PlusBoton.Parent = PanelGaraje;
            PanelGaraje.Location = new Point(0, 0);
            PanelGaraje.BackColor = Color.FromArgb(75, 75, 75, 55);
            DineroPb.Parent = PictureBoxBack;
            DineroMostrarLabel.Parent = PictureBoxBack;
            Boton.BackColor = Color.Transparent;
            Boton.Parent = PictureBoxBack;
            Boton.Visible = true;
            Boton2.BackColor = Color.Transparent;
            Boton2.Parent = PictureBoxBack;
            Boton2.Visible = true;
            AnteriorPistaBoton.Location = new Point(986, 570);
            SiguientePistaBoton.Location = new Point(1151, 570);
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
            AutoPilotoPictureBox.BackColor = Color.Transparent;
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
            PromocionTextBox.Location = SemiProTextBox.Location;
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
            MisCosasPictureBox.Parent = PictureBoxBack;
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
            BackComida.Parent = PictureBoxBack;
            NextComida.Parent = PictureBoxBack;
            AbonarFacturas.Parent = PictureBoxBack;
            Servicios1.BackColor = Color.FromArgb(135, 30, 30, 30);
            Servicios2.BackColor = Color.FromArgb(135, 30, 30, 30);
            Servicios3.BackColor = Color.FromArgb(135, 30, 30, 30);
            Servicios4.BackColor = Color.FromArgb(135, 30, 30, 30);
            Servicios5.BackColor = Color.FromArgb(135, 30, 30, 30);
            PagoLabel.BackColor = Color.FromArgb(135, 30, 30, 30);
            BackComida.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            BackComida.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            NextComida.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 65, 65);
            NextComida.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 50, 50, 50);
            DineroMostrarLabel.BackColor = Color.FromArgb(135, 30, 30, 30);
            BackMecanico.Parent = PictureBoxBack;
            NextMecanico.Parent = PictureBoxBack;
            RookieLabel.BackColor = Color.FromArgb(150, 170, 170, 170);
            JuniorLabel.BackColor = Color.FromArgb(150, 170, 170, 170);
            AmateurLabel.BackColor = Color.FromArgb(150, 170, 170, 170);
            SemiProLabel.BackColor = Color.FromArgb(150, 170, 170, 170);
            ProfesionalLabel.BackColor = Color.FromArgb(150, 170, 170, 170);
            EstrellaLabel.BackColor = Color.FromArgb(150, 170, 170, 170);
            LeyendaLabel.BackColor = Color.FromArgb(150, 170, 170, 170);
            PromocionLabel.BackColor = Color.FromArgb(150, 170, 170, 170);
        }

        // FUNCION PARA FORMATEAR FECHA
        private void FormatearFecha(Fecha aux)
        {
            fechaManager = DateTime.Parse(aux.FechaManager.ToString());
            Formato = fechaManager.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            dateTimePicker1.Value = fechaAux.FechaManager;
        }
        //EVENTO RESIZE
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            Size newResolution = ClientSize; //AsignacionCorreccion         
        }

        //Dispara la Primera pista de Musica

        float Volumen = 0.1f;
        int indexMusica = 0;
        bool primeraVuelta = true;
        private void IniciarMusica(ref AudioFileReader Musica)
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
            Volumen = VolumenControl.Value / 100.00f;
            audioFile.Volume = Volumen;
        }

        //EJECUTA UNA CANCION RANDOM AL INICIO AL GENERAR UN NUMERO RANDOM
        readonly Random randomCancion = new Random();
        private int RandomNumero()
        {
            int RandomNumero = randomCancion.Next(listaCanciones.Count());
            return RandomNumero;
        }

        //NEXT Y BACK MUSICA
        bool CausaStop = true; //VERIFICA SI LA MUSICA SE PARO POR TERMINAR O POR CAMBIO
        int indexPistas = 0;
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

        //PONE UN FONDO RANDOM AL INICIO AL GENERAR UN NUMERO RANDOM
        readonly Random randomFondo = new Random();
        private void RandomFondo()
        {
            int RandomNumero = randomFondo.Next(1, 5);
            PictureBoxBack.BackgroundImageLayout = ImageLayout.Stretch;
            switch (RandomNumero)
            {
                case 0:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/1_Fondo.gif");
                    FiltrosLabel.ForeColor = Color.Red;
                    CampoLabel.ForeColor = Color.Red;
                    CriterioLabel.ForeColor = Color.Red;
                    FiltroBusquedaLabel.ForeColor = Color.Red;
                    break;
                case 1:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/3_Fondo.gif");
                    break;
                case 2:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/4_Fondo.gif");
                    break;
                case 3:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/7_Fondo.gif");
                    break;
                case 4:
                    PictureBoxBack.Load("C:/Users/Santino/Desktop/Repositorio GITHUB/Proyectos Finales/P4_Touge-App/Touge_App/Touge_App/img/Fondos-Pantalla/10_Fondo.gif");
                    break;
            }
        }

        //FUNCIONES PARA MOSTRAR
        bool EconomiaMostrar = true;
        private void Ocultar()
        {
            BotonPistas.Visible = false;
            PilotosBoton.Visible = false;
            ReglasBoton.Visible = false;
            EconomiaBoton.Visible = false;
            HistorialBoton.Visible = false;
            AutosBoton.Visible = false;
            CloseButton.Visible = false;
            VolverBoton.Visible = true;
            panel1.Visible = false;

        }
        private void OcultarEconomia()
        {
            if (ComidaPictureBox.Visible == true)
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
                MisCosasPictureBox.Visible = false;
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

        //MUESTRA Y CARGA DE PISTAS
        private void BotonPistas_Click(object sender, EventArgs e)
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
            CargaPistasAutosPilotosEconomia.Visible = true;
            listaPistas = negocioBD.DevolverPistas();
            CargaBasePistas();

        }
        private void CargaBasePistas()
        {
            PistaPictureBox.Load(listaPistas[indexPistas].Imagenes);
            PistasBiografia.Text = listaPistas[indexPistas].BiografiaPista;
            PaisTextBox.Text = "Ubicación: " + listaPistas[indexPistas].Pais;
            ModalidadTextBox.Text = "Modalidad: " + listaPistas[indexPistas].ModalidadPreferida;
            DistanciaTextbox.Text = "Distancia: " + listaPistas[indexPistas].Distancia;
            NombreCircuito.Text = listaPistas[indexPistas].NombrePista;
            NombreCircuito.TextAlign = HorizontalAlignment.Center;
        }
        int imagen = 1;
        private void PistaPictureBox_Click(object sender, EventArgs e)
        {
            imagen++;
            if (imagen == 1)
            {
                PistaPictureBox.Load(listaPistas[indexPistas].Imagenes);
            }
            else if (imagen == 2)
            {
                PistaPictureBox.Load(listaPistas[indexPistas].Imagenes2);
            }
            else if (imagen == 3)
            {
                PistaPictureBox.Load(listaPistas[indexPistas].Lay);
                imagen = 0;
            }
        }
        //BACK-NEXT DE LAS PISTAS
        private void SiguientePistaBoton_Click(object sender, EventArgs e)
        {
            if (indexPistas < listaPistas.Count() - 1)
            {
                indexPistas++;
                CargaBasePistas();
            }
            imagen = 1;
        }
        private void AnteriorPistaBoton_Click(object sender, EventArgs e)
        {
            if (indexPistas > 0)
            {
                indexPistas--;
                CargaBasePistas();
            }
            imagen = 1;
        }
        //CONFIGURACION DEL BOTON VOLVER
        bool banderaVolverReglas = true;
        private void VolverBoton_Click(object sender, EventArgs e)
        {
            try
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
                    CargaPistasAutosPilotosEconomia.Visible = true;
                    imagen = 1;
                }
                else if (PilotosPictureBox.Visible == true)
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
                    CargaPistasAutosPilotosEconomia.Visible = true;
                }
                else if (BanderasPictureBox.Visible == true)
                {
                    FichaTecnicaPb.Visible = false;
                    NombreAutoTextbox.Visible = false;
                    BanderasPictureBox.Visible = false;
                    AutosPictureBox.Visible = false;
                    NextAuto.Visible = false;
                    BackAuto.Visible = false;
                    CargaPistasAutosPilotosEconomia.Visible = true;
                }
                else if (ModalidadesBoton.Visible == true)
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
                    MisCosasPictureBox.Visible = false;
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
                    CargaPistasAutosPilotosEconomia.Visible = false;
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
                else if (PanelComida1.Visible == true)
                {
                    PanelComida1.Visible = false;
                    PanelComida2.Visible = false;
                    PanelComida4.Visible = false;
                    PanelComida3.Visible = false;
                    BackComida.Visible = false;
                    NextComida.Visible = false;
                }
                else if (Higiene1.Visible == true)
                {
                    Higiene1.Visible = false;
                    Higiene2.Visible = false;
                    Higiene3.Visible = false;
                    EconomiaMostrar = false;
                }
                else if (mecanico1.Visible == true)
                {
                    mecanico1.Visible = false;
                    mecanico2.Visible = false;
                    mecanico3.Visible = false;
                    mecanico4.Visible = false;
                    BackMecanico.Visible = false;
                    NextMecanico.Visible = false;
                    EconomiaMostrar = false;
                    banderaPaginaMecanico = false;
                }
                else if (gastosDiarios1.Visible == true)
                {
                    gastosDiarios1.Visible = false;
                    gastosDiarios2.Visible = false;
                    gastosDiarios3.Visible = false;
                    gastosDiarios4.Visible = false;
                    gastosDiarios5.Visible = false;
                    gastosDiarios6.Visible = false;
                    EconomiaMostrar = false;
                }
                else if (MiAutoPB.Visible == true)
                {
                    MiAutoPB.Visible = false;
                    PanelGaraje.Visible = false;
                    BanderaMiAuto.Visible = false;
                    PlusBoton.Visible = false;
                    NombreMiauto.Visible = false;
                    HpMiauto.Visible = false;
                    HpMiauto2.Visible = false;
                    PesoMiAuto.Visible = false;
                    PesoMiAuto2.Visible = false;
                    PPMiAuto.Visible = false;
                    PPMiAuto2.Visible = false;
                    TorqueMiAuto.Visible = false;
                    TorqueLabel2.Visible = false;
                    AceiteMiAuto.Visible = false;
                    AceiteMiAuto2.Visible = false;
                    MotorMiAuto.Visible = false;
                    MotorMiAuto2.Visible = false;
                    MantMiAuto.Visible = false;
                    MantMiAuto2.Visible = false;
                    LimpMiAuto.Visible = false;
                    LimpMiAuto2.Visible = false;
                    ReproMiAuto.Visible = false;
                    ReproMiAuto2.Visible = false;
                    ASpMiAuto.Visible = false;
                    ASpMiAuto2.Visible = false;
                    GomasMojado.Visible = false;
                    GomasMojado2.Visible = false;
                    GomasSeco.Visible = false;
                    GomasSeco2.Visible = false;
                    TraccionMiauto.Visible = false;
                    TraccionMiauto2.Visible = false;
                    GasofaMiauto.Visible = false;
                    GasofaMiauto2.Visible = false;
                    EconomiaMostrar = false;
                }
                else if (listaMisCosas[0].Visible == true && listaMisCosas[0] != null)
                {
                    BackObjeto.Visible = false;
                    NextObjeto.Visible = false;
                    MisObjetosPaginaManager = 1;
                    switch (listaMisCosas.Count)
                    {
                        case 1:
                            listaMisCosas[0].Visible = false;
                            break;
                        case 2:
                            listaMisCosas[0].Visible = false;
                            listaMisCosas[1].Visible = false;
                            break;
                        case 3:
                            listaMisCosas[0].Visible = false;
                            listaMisCosas[1].Visible = false;
                            listaMisCosas[2].Visible = false;
                            break;
                        case 4:
                            listaMisCosas[0].Visible = false;
                            listaMisCosas[1].Visible = false;
                            listaMisCosas[2].Visible = false;
                            listaMisCosas[3].Visible = false;
                            break;
                        case 5:
                            listaMisCosas[0].Visible = false;
                            listaMisCosas[1].Visible = false;
                            listaMisCosas[2].Visible = false;
                            listaMisCosas[3].Visible = false;
                            listaMisCosas[4].Visible = false;
                            break;
                        case 6:
                            listaMisCosas[0].Visible = false;
                            listaMisCosas[1].Visible = false;
                            listaMisCosas[2].Visible = false;
                            listaMisCosas[3].Visible = false;
                            listaMisCosas[4].Visible = false;
                            listaMisCosas[5].Visible = false;
                            break;
                        case 7:
                            listaMisCosas[0].Visible = false;
                            listaMisCosas[1].Visible = false;
                            listaMisCosas[2].Visible = false;
                            listaMisCosas[3].Visible = false;
                            listaMisCosas[4].Visible = false;
                            listaMisCosas[5].Visible = false;
                            listaMisCosas[6].Visible = false;
                            break;
                        case 8:
                            listaMisCosas[0].Visible = false;
                            listaMisCosas[1].Visible = false;
                            listaMisCosas[2].Visible = false;
                            listaMisCosas[3].Visible = false;
                            listaMisCosas[4].Visible = false;
                            listaMisCosas[5].Visible = false;
                            listaMisCosas[6].Visible = false;
                            listaMisCosas[7].Visible = false;
                            break;
                        default:
                            break;
                    }
                    EconomiaMostrar = false;
                }
                if (banderaVolverReglas && banderaEconomiaParaMostrar)
                {
                    BotonPistas.Visible = true;
                    PilotosBoton.Visible = true;
                    ReglasBoton.Visible = true;
                    EconomiaBoton.Visible = true;
                    HistorialBoton.Visible = true;
                    AutosBoton.Visible = true;
                    CloseButton.Visible = true;
                    panel1.Visible = true;
                }
                else if (banderaEconomiaParaMostrar == false)
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
                        MisCosasPictureBox.Visible = true;
                        GarajePictureBox.Visible = true;
                        EconomiaMostrar = true;
                    }
                    NextEconomia.Visible = true;
                    BackEconomia.Visible = true;
                    banderaEconomiaParaMostrar = true;
                }
            }
            catch (Exception)
            {
            }
            
        }

        //CONFIGURACION DEL MODULO PILOTOS Y SUS MANEJADORES
        int indexPilotos = 0;
        int contadorImagenes = 0;
        private void PilotosBoton_Click(object sender, EventArgs e)
        {
            CargaPistasAutosPilotosEconomia.Visible = true;
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
            listaPilotos = negocioBDPilotos.DevolverPilotos();
            CargaPilotos();

        }
        private void CargaPilotos()
        {

            PilotosPictureBox.Load(listaPilotos[indexPilotos].Foto);
            BiografiaPilotosTextBox.Text = listaPilotos[indexPilotos].Biografia;
            AutoPilotoPictureBox.Load(listaPilotos[indexPilotos].Auto);
            PaisPictureBox.Load(listaPilotos[indexPilotos].Nacionalidad);
            if (listaPilotos[indexPilotos].Cornering < 10)
                Cornering.Location = new Point(53, 42);
            Cornering.Text = listaPilotos[indexPilotos].Cornering.ToString();
            if (listaPilotos[indexPilotos].Braking < 10)
                Braking.Location = new Point(163, 42);
            Braking.Text = listaPilotos[indexPilotos].Braking.ToString();
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
                Rain.Location = new Point(158, 354);
            Rain.Text = listaPilotos[indexPilotos].RainHability.ToString();
            if (listaPilotos[indexPilotos].Defending < 10)
                Defending.Location = new Point(255, 354);
            Defending.Text = listaPilotos[indexPilotos].Defending.ToString();
            if (listaPilotos[indexPilotos].Overall < 10)
                Overall.Location = new Point(0, 0);
            Overall.Text = listaPilotos[indexPilotos].Overall.ToString();
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
                Rain.Location = new Point(158, 380);
                Defending.Location = new Point(262, 380);
                Overall.Location = new Point(465, 336);
                NombrePilotoTextBox.Location = new Point(118, 540);
                ApodoTextBox.Location = new Point(118, 577);
                EquipoTextBox.Location = new Point(118, 615);
                RivalTextBox.Location = new Point(118, 650);

                EdadTextBox.Location = new Point(425, 540);
                AlturaTextBox.Location = new Point(429, 580);
                PesoTextBox.Location = new Point(425, 615);
                VictoriaTextBox.Location = new Point(612, 540);
                DerrotaTextBox.Location = new Point(612, 577);
                WinRateTextBox.Location = new Point(612, 615);
                TotalTextBox.Location = new Point(612, 650);
            }
            NombrePilotoTextBox.Text = listaPilotos[indexPilotos].NombrePiloto;
            ApodoTextBox.Text = listaPilotos[indexPilotos].Apodo;
            EquipoTextBox.Text = listaPilotos[indexPilotos].Equipo;
            RivalTextBox.Text = listaPilotos[indexPilotos].Ranking;
            EdadTextBox.Text = listaPilotos[indexPilotos].Edad.ToString();
            AlturaTextBox.Text = listaPilotos[indexPilotos].Altura;
            PesoTextBox.Text = listaPilotos[indexPilotos].Peso;
            VictoriaTextBox.Text = listaPilotos[indexPilotos].Victorias.ToString();
            DerrotaTextBox.Text = listaPilotos[indexPilotos].Derrotas.ToString();
            string formatin = "0.0";
            WinRateTextBox.Text = listaPilotos[indexPilotos].PorcentajeCarrerasGanadas.ToString(formatin) + "%";
            TotalTextBox.Text = listaPilotos[indexPilotos].Total.ToString();
        }
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
            if (!(indexPilotos >= listaPilotos.Count()))
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
                indexPilotos = listaPilotos.Count() - 1;
                CargaPilotos();
            }
        }

        //CONFIGURACION DEL MODULO AUTOS Y SUS MANEJADORES
        int indexAutos = 0;
        int contadorImagenAuto = 0;
        private void AutosBoton_Click(object sender, EventArgs e)
        {
            Ocultar();
            CargaPistasAutosPilotosEconomia.Visible = true;
            negocioBDAutos = new NegocioBaseDatos();
            listaAutos = negocioBDAutos.DevolverAutos();
            CargarAutos();
        }
        private void CargarAutos()
        {
            try
            {
                AutosPictureBox.Visible = true;
                //FichaTecnicaTextBox.Visible = true;
                BanderasPictureBox.Visible = true;
                NombreAutoTextbox.Visible = true;
                BackAuto.Visible = true;
                NextAuto.Visible = true;
                FichaTecnicaPb.Visible = true;
                NombreAutoTextbox.Text = listaAutos[indexAutos].NombreModelo;
                AutosPictureBox.Load(listaAutos[indexAutos].ImagenAuto);
                MarcaPictureBox.Load(listaAutos[indexAutos].MarcaAuto.ImagenMarca);
                BanderasPictureBox.Load(listaAutos[indexAutos].PaisFabricacion);
                YearLabel.Text = listaAutos[indexAutos].Anio.ToString();
                NmLabel.Text = listaAutos[indexAutos].Torque.ToString() + "  Nm";
                HpLabel.Text = listaAutos[indexAutos].HP.ToString() + "  Hp";
                KgLabel.Text = listaAutos[indexAutos].Peso.ToString() + "  Kg";
                string formato = "0.00";
                KgHp.Text = listaAutos[indexAutos].RelacionPesoPotencia.ToString(formato) + "  Kg/Hp";
                TopLabel.Text = listaAutos[indexAutos].TopSpeed.ToString() + "  Km/H";
                KmLabel.Text = listaAutos[indexAutos].Kilometraje.ToString() + "  Km";
                CatLabel.Text = listaAutos[indexAutos].Categoria;
                PilotoNameAuto.Text = listaAutos[indexAutos].Piloto;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
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

        //APARTDO REGLAS
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

        //CONFIGURACION DE MODALIDADES CON NEXT-BACK
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
            if (SubitaTextBox.Visible == false)
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
        //CONFIGURACION DE RANKING CON NEXT-BACK
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

        //MODULOS HISTORIAL, VISUAL, CARGA DE HISTORIA, BORRAR Y FILTRAR
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
        private void BorrarRegistroBoton_Click(object sender, EventArgs e)
        {
            if (historialDGV.CurrentRow.DataBoundItem != null)
            {
                DialogResult resultado = MessageBox.Show("Seguro que desea eliminar", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                mensajeBox.Mostrar("No selecciono ningun registro a eliminar");
            }
        }
        private void CampoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CriterioCombo.Items.Count == 0)
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
        //AGREGAR REGISTROS Y OCULTAR
        private HistorialForms registroVentana;
        private void AgregarRegistroBoton_Click(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioUpFecha = new NegocioBaseDatos();
            if (negocioUpFecha.CombustibleMiAuto() > 0)
            {
                if (negocioUpFecha.LeerGomas() > 0)
                {
                    registroVentana = new HistorialForms(Player);
                    int filas = historialDGV.Rows.Count;
                    registroVentana.ShowDialog();
                    listaHistorial = negocioHistorial.DevolverHistorial();
                    historialDGV.DataSource = listaHistorial;
                    if (historialDGV.Rows.Count > filas)
                    {
                        fechaAux.FechaManager = negocioUpFecha.UpdatearFecha(3);
                        FormatearFecha(fechaAux);
                        FechaLabel.Text = Formato;
                        NegocioBaseDatos negocioUpdateComponentes = new NegocioBaseDatos();
                        aceiteManager++;
                        motorManager++;
                        autoManager++;
                        limpiezaManager++;

                        if (registroVentana.IndiceSeleccionado < 4)
                            gomasManager++;
                        else
                            gomasDeLluviaManager++;

                        negocioUpFecha.CombustibleMiAuto(true);
                        negocioUpdateComponentes.UpdatearComponentes(aceiteManager, motorManager, autoManager, gomasManager, gomasDeLluviaManager, limpiezaManager);
                        //registroVentana.PlayerBool = false;
                        if (aceiteManager >= 5)
                        {
                            negocioUpdateComponentes.UpEstadoAuto(1);
                            estadoAceite = false;
                            mensajeBox.Mostrar("Necesita Un Cambio de Aceite", Color.Red, Color.Gold);
                        }
                        if (motorManager >= 4)
                        {
                            negocioUpdateComponentes.UpEstadoAuto(2);
                            estadoMotor = false;

                            mensajeBox.Mostrar("Necesita hacerle un Mantenimiento al Motor", Color.Red, Color.Gold);
                        }
                        if (autoManager >= 3)
                        {
                            negocioUpdateComponentes.UpEstadoAuto(3);
                            estadoAuto = false;
                            mensajeBox.Mostrar("Necesita hacerle un Mantenimiento al Auto", Color.Red, Color.Gold);
                        }
                        if (gomasManager >= 7)
                        {
                            negocioUpdateComponentes.UpEstadoAuto(13);
                            mensajeBox.Mostrar("Se Gasto El Set de Gomas De Seco", Color.Red, Color.Gold);
                        }
                        if (gomasDeLluviaManager >= 4)
                        {
                            negocioUpdateComponentes.UpEstadoAuto(15);
                            mensajeBox.Mostrar("Se Gasto El Set de Gomas De Lluvia", Color.Red, Color.Gold);
                        }
                        if (limpiezaManager >= 2)
                        {
                            negocioUpdateComponentes.UpEstadoAuto(12);
                            estadoLimpieza = false;
                            mensajeBox.Mostrar("El Auto Se encuentra Sucio! Porfavor vaya al lavadero", Color.Orange, Color.White);
                        }
                    }
                    NegocioBaseDatos negocio = new NegocioBaseDatos();
                    plataFormato = string.Format("$ {0:N0}", negocio.DevolverDinero());
                    DineroMostrarLabel.Text = plataFormato;
                }
                else
                {
                    mensajeBox.Mostrar("No tiene gomas para competir! Compre Gomas");
                }

            }
            else
            {
                mensajeBox.Mostrar("No tiene la Gasolina suficiente para correr! Vaya a cargarla");
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
        //CONFIGURACION VISUAL DE ECONOMIA, PERMITE EL INGRESO A SUS SUBMODULOS INDICE: 4
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
                MisCosasPictureBox.Visible = true;
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
                MisCosasPictureBox.Visible = false;
            }
        }

        //CONFIGURACION DE LA PAGINA COMIDA, NEXT-BACK, OCULTAR Y EVENTO PANELES INDICE: 4.1
        int comidaManager;
        private void ComidaPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarEconomia();
                ComidaPaginaUno(0);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ComidaPaginaUno(int valor)
        {
            PanelComida1.Titulo = ListaComida[valor].NombrePack;
            PanelComida2.Titulo = ListaComida[valor + 1].NombrePack;
            PanelComida3.Titulo = ListaComida[valor + 2].NombrePack;
            PanelComida4.Titulo = ListaComida[valor + 3].NombrePack;
            PanelComida1.Id = ListaComida[valor].Id;
            PanelComida2.Id = ListaComida[valor + 1].Id;
            PanelComida3.Id = ListaComida[valor + 2].Id;
            PanelComida4.Id = ListaComida[valor + 3].Id;
            PanelComida1.Comprado = ListaComida[valor].Comprado;
            PanelComida2.Comprado = ListaComida[valor + 1].Comprado;
            PanelComida3.Comprado = ListaComida[valor + 2].Comprado;
            PanelComida4.Comprado = ListaComida[valor + 3].Comprado;
            PanelComida1.Precio = "$ " + (ListaComida[valor].Precio - 1).ToString() + ".99";
            PanelComida2.Precio = "$ " + (ListaComida[valor + 1].Precio - 1).ToString() + ".99";
            PanelComida3.Precio = "$ " + (ListaComida[valor + 2].Precio - 1).ToString() + ".99";
            PanelComida4.Precio = "$ " + (ListaComida[valor + 3].Precio - 1).ToString() + ".99";
            PanelComida1.CargarImagenes(ListaComida[valor].Imagen);
            PanelComida2.CargarImagenes(ListaComida[valor + 1].Imagen);
            PanelComida3.CargarImagenes(ListaComida[valor + 2].Imagen);
            PanelComida4.CargarImagenes(ListaComida[valor + 3].Imagen);
            if (!ListaComida[valor].Comprado)
                PanelComida1.SoldOut();
            else
                PanelComida1.OcultarSold();
            if (!ListaComida[valor + 1].Comprado)
                PanelComida2.SoldOut();
            else
                PanelComida2.OcultarSold();
            if (!ListaComida[valor + 2].Comprado)
                PanelComida3.SoldOut();
            else
                PanelComida3.OcultarSold();
            if (!ListaComida[valor + 3].Comprado)
                PanelComida4.SoldOut();
            else
                PanelComida4.OcultarSold();
            PanelComida1.Visible = true;
            PanelComida2.Visible = true;
            PanelComida3.Visible = true;
            PanelComida4.Visible = true;
            BackComida.Visible = true;
            NextComida.Visible = true;
        }
        int contadorPagComida = 0;
        private void NextComida_Click(object sender, EventArgs e)
        {
            contadorPagComida++;
            if (contadorPagComida == 1)
            {
                ComidaPaginaUno(4);
            }
            else if (contadorPagComida == 2)
            {
                ComidaPaginaUno(8);
            }
            else if (contadorPagComida > 2)
            {
                contadorPagComida = 2;
            }
        }
        private void BackComida_Click(object sender, EventArgs e)
        {
            contadorPagComida--;
            if (contadorPagComida == 1)
            {
                ComidaPaginaUno(4);
            }
            else if (contadorPagComida == 0)
            {
                ComidaPaginaUno(0);
            }
            else if (contadorPagComida < 0)
            {
                contadorPagComida = 0;
            }
        }
        private void OcultarComida()
        {
            PanelComida1.Visible = false;
            PanelComida2.Visible = false;
            PanelComida4.Visible = false;
            PanelComida3.Visible = false;
            BackComida.Visible = false;
            NextComida.Visible = false;
        }
        private void PanelComida1_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (!estadoComida)
            {
                if (miDinero.MiDinero - negocioPago.PagoArticulos(((Comida)sender).Id, 4) > 0)
                {
                    miDinero.MiDinero -= negocioPago.PagoArticulos(((Comida)sender).Id, 4);
                    negocioPago.ActualizarDinero(miDinero.MiDinero);
                    estadoComida = true;
                    negocioPago.ActualizarComida(estadoComida);
                    plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                    DineroMostrarLabel.Text = plataFormato;
                    fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                    FormatearFecha(fechaAux);
                    FechaLabel.Text = Formato;
                    VolverBoton.Visible = true;
                    CloseButton.Visible = false;
                    ((Comida)sender).SoldOut();
                    switch (comidaManager)
                    {
                        case 1:
                            ListaComida[0].Comprado = false;
                            break;
                        case 2:
                            ListaComida[4].Comprado = false;
                            break;
                        case 3:
                            ListaComida[8].Comprado = false;
                            break;
                        default:
                            break;
                    }
                    if (higieneManager == 2)
                    {
                        OcultarComida();
                        HigienePagina();
                        mensajeBox.Mostrar("Debe Comprar Las Cosas de Higiene!");
                        VolverBoton.Visible = false;
                    }
                }
                else
                    mensajeBox.Mostrar("No tiene dinero para Comprar este producto.");
            }
            else
                mensajeBox.Mostrar("Usted ya realizo la compra mensual! Espere al proximo mes para volver a comprar.");
        }
        //MOSTRAR MODULO ALQUILER, NEXT-BACK Y PAGINAS INDICE: 4.2
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
        int paginaAlquiler = 0;
        private void SiguienteAlquiler_Click(object sender, EventArgs e)
        {
            paginaAlquiler++;
            if (paginaAlquiler == 1)
            {
                PaginaDosAlquiler();
            }
            if (paginaAlquiler == 2)
            {
                PaginaTresAlquiler();
            }
            if (paginaAlquiler == 3)
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

            alquileres1.TituloDepa = listaAlquiler[0].NombreAlquiler;
            alquileres1.CargarImagenes(listaAlquiler[0].ImagenAlquiler);
            alquileres1.Pieza = "● " + listaAlquiler[0].CantidadDormitorios.ToString();
            alquileres1.Ducha = "● " + listaAlquiler[0].CantidadDuchas.ToString();
            alquileres1.Garaje = "● " + listaAlquiler[0].CantidadGarajes.ToString();
            alquileres1.Sala = "● " + listaAlquiler[0].CantidadSalasEstar.ToString();
            alquileres1.Precio = "$ " + listaAlquiler[0].PrecioDepartamento.ToString();
            alquileres1.Id = listaAlquiler[0].NumeroRegistro;
            alquileres2.TituloDepa = listaAlquiler[1].NombreAlquiler;
            alquileres2.CargarImagenes(listaAlquiler[1].ImagenAlquiler);
            alquileres2.Pieza = "● " + listaAlquiler[1].CantidadDormitorios.ToString();
            alquileres2.Ducha = "● " + listaAlquiler[1].CantidadDuchas.ToString();
            alquileres2.Garaje = "● " + listaAlquiler[1].CantidadGarajes.ToString();
            alquileres2.Sala = "● " + listaAlquiler[1].CantidadSalasEstar.ToString();
            alquileres2.Precio = "$ " + listaAlquiler[1].PrecioDepartamento.ToString();
            alquileres2.Id = listaAlquiler[1].NumeroRegistro;
            alquileres1.Visible = true;
            alquileres2.Visible = true;
            VolverAlquiler.Visible = true;
            SiguienteAlquiler.Visible = true;
            banderaEconomiaParaMostrar = false;
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
        //EVENTOS DE COMPRA DE ALQUILER
        private void MiUserControl_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoAlquiler(alquileres1.Id) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoAlquiler(alquileres1.Id);
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato; //Exito
                Alquilando = true;
                compraSonido.Play();
                Alquilando = negocioPago.ActualizarAlquilando(Alquilando);
                CasaAlquilada = alquileres1.Id;
                CasaAlquilada = negocioPago.ActualizarCasaAlquilada(CasaAlquilada);
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                FechaLabel.Text = Formato;
                VolverBoton.Visible = true;
                CloseButton.Visible = false;
                compraSonido.Dispose();
                if (!estadoFacturas)
                {
                    alquileres1.Visible = false;
                    alquileres2.Visible = false;
                    VolverAlquiler.Visible = false;
                    SiguienteAlquiler.Visible = false;
                    VolverBoton.Visible = false;
                    MostrarFacturas();
                    mensajeBox.Mostrar("Necesita abonar los servicios del mes!");
                }

            }
            else
            {
                mensajeBox.Mostrar("No tiene dinero para pagar el alquiler, si no puede renovar el alquiler Pierde el juego");
            }


        }
        private void MiUserControl2_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoAlquiler(alquileres2.Id) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoAlquiler(alquileres2.Id);
                CasaAlquilada = alquileres2.Id;
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato;
                VolverBoton.Visible = true;
                CloseButton.Visible = false;
                Alquilando = true;
                compraSonido.Play();
                Alquilando = negocioPago.ActualizarAlquilando(Alquilando);
                CasaAlquilada = alquileres2.Id;
                CasaAlquilada = negocioPago.ActualizarCasaAlquilada(CasaAlquilada);
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                FechaLabel.Text = Formato;
                compraSonido.Dispose();
                if (!estadoFacturas)
                {
                    alquileres1.Visible = false;
                    alquileres2.Visible = false;
                    VolverAlquiler.Visible = false;
                    SiguienteAlquiler.Visible = false;
                    VolverBoton.Visible = false;
                    MostrarFacturas();
                    mensajeBox.Mostrar("Necesita abonar los servicios del mes!");
                }
            }
            else
            {
                mensajeBox.Mostrar("No tiene dinero para pagar el alquiler, si no puede renovar el alquiler Pierde el juego");
            }
        }
        //MOSTRAR MODULO FACTURAS INDICE: 4.3
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
        private void MostrarFacturas()
        {
            PagoLabel.Visible = true;
            Servicios1.Visible = true;
            Servicios2.Visible = true;
            Servicios3.Visible = true;
            Servicios4.Visible = true;
            Servicios5.Visible = true;
        }
        private void AbonarFacturas_Click(object sender, EventArgs e)
        {
            bool pagado = false;
            DialogResult resultado = MessageBox.Show("¿Desea Pagar estos servicios?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == resultado)
            {
                while (!pagado)
                {
                    if (!estadoFacturas)
                    {
                        NegocioBaseDatos negocioPagarfacturas = new NegocioBaseDatos();
                        if (Servicios1.Checked == true)
                        {
                            if (miDinero.MiDinero - 75 >= 0)
                            {
                                compraSonido.Play();
                                miDinero.MiDinero -= 75;
                                negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero);
                                estadoFacturas = true;
                                negocioPagarfacturas.ActualizarFactura(estadoFacturas);
                                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                                DineroMostrarLabel.Text = plataFormato;
                                compraSonido.Dispose();
                                pagado = true;
                            }
                            else
                            {
                                mensajeBox.Mostrar("No tiene el suficiente dinero para abonar el servicio basico, GameOver");
                            }
                        }
                        else if (Servicios2.Checked == true)
                        {
                            if (miDinero.MiDinero - 100 >= 0)
                            {
                                compraSonido.Play();
                                miDinero.MiDinero -= 100;
                                negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero);
                                estadoFacturas = true;
                                negocioPagarfacturas.ActualizarFactura(estadoFacturas);
                                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                                DineroMostrarLabel.Text = plataFormato;
                                compraSonido.Dispose();
                                pagado = true;
                            }
                            else
                            {
                                mensajeBox.Mostrar("No tiene el suficiente dinero para abonar el esta opcion, elija una mas barata");
                            }
                        }
                        else if (Servicios3.Checked == true)
                        {
                            if (miDinero.MiDinero - 125 >= 0)
                            {
                                compraSonido.Play();
                                miDinero.MiDinero -= 125;
                                negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero);
                                estadoFacturas = true;
                                negocioPagarfacturas.ActualizarFactura(estadoFacturas);
                                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                                DineroMostrarLabel.Text = plataFormato;
                                compraSonido.Dispose();
                                pagado = true;
                            }
                            else
                            {
                                mensajeBox.Mostrar("No tiene el suficiente dinero para abonar el esta opcion, elija una mas barata");
                            }
                        }
                        else if (Servicios4.Checked == true)
                        {
                            if (miDinero.MiDinero - 150 >= 0)
                            {
                                compraSonido.Play();
                                miDinero.MiDinero -= 150;
                                negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero);
                                estadoFacturas = true;
                                negocioPagarfacturas.ActualizarFactura(estadoFacturas);
                                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                                DineroMostrarLabel.Text = plataFormato;
                                compraSonido.Dispose();
                                pagado = true;
                            }
                            else
                            {
                                mensajeBox.Mostrar("No tiene el suficiente dinero para abonar el esta opcion, elija una mas barata");
                            }
                        }
                        else
                        {
                            if (miDinero.MiDinero - 180 >= 0)
                            {
                                compraSonido.Play();
                                miDinero.MiDinero -= 180;
                                negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero);
                                estadoFacturas = true;
                                negocioPagarfacturas.ActualizarFactura(estadoFacturas);
                                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                                DineroMostrarLabel.Text = plataFormato;
                                compraSonido.Dispose();
                                pagado = true;
                            }
                            else
                            {
                                mensajeBox.Mostrar("No tiene el suficiente dinero para abonar el esta opcion, elija una mas barata");
                            }
                        }
                    }
                    else
                    {
                        mensajeBox.Mostrar("Usted Ya abono los servicios este mes!");
                        pagado = true;
                    }

                }
                if (!estadoComida)
                {
                    mensajeBox.Mostrar("Debe Realizar la compra Mensual!");
                    OcultarEconomia();
                    Servicios1.Visible = false;
                    Servicios2.Visible = false;
                    Servicios3.Visible = false;
                    Servicios4.Visible = false;
                    Servicios5.Visible = false;
                    AbonarFacturas.Visible = false;
                    PagoLabel.Visible = false;
                    ComidaPaginaUno(0);
                }
                else
                    VolverBoton.Visible = true;
            }

        }
        private void Servicios1_CheckedChanged(object sender, EventArgs e)
        {
            if (AbonarFacturas.Visible == false)
                AbonarFacturas.Visible = true;
        }
        //MOSTRAR MODULO ROPA, MUEBLES Y ELECTRONICOS INDICE: 4.4 INDICE: 4.5 INDICE: 4.6
        private void RopaPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaRopa.Count >= 8)
                {
                    PaginaUnoRopa(0);
                    MostrarShopPanels(Color.Khaki, Color.FromArgb(255, 54, 54, 54));
                    CargaPistasAutosPilotosEconomia.Visible = true;
                }
                else
                {
                    mensajeBox.Mostrar("En este momento estamos falta de Articulos! vuelva mas tarde");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void PaginaUnoRopa(int validador)
        {
            eShopmanager = 1;
            ShopPanel1.Precio = "$ " + (listaRopa[validador].Precio - 1).ToString() + ".99";
            ShopPanel1.CargarImagenes(listaRopa[validador].Imagen);
            ShopPanel1.NombreProducto = listaRopa[validador].NombreRopa;
            ShopPanel1.Id = listaRopa[validador].Id;
            if (!listaRopa[validador].Comprado)
                ShopPanel1.SoldOut();
            else
                ShopPanel1.OcultarSold();
            ShopPanel2.Precio = "$ " + (listaRopa[validador + 1].Precio - 1).ToString() + ".99";
            ShopPanel2.CargarImagenes(listaRopa[validador + 1].Imagen);
            ShopPanel2.NombreProducto = listaRopa[validador + 1].NombreRopa;
            ShopPanel2.Id = listaRopa[validador + 1].Id;
            if (!listaRopa[validador + 1].Comprado)
                ShopPanel2.SoldOut();
            else
                ShopPanel2.OcultarSold();
            ShopPanel3.Precio = "$ " + (listaRopa[validador + 2].Precio - 1).ToString() + ".99";
            ShopPanel3.CargarImagenes(listaRopa[validador + 2].Imagen);
            ShopPanel3.NombreProducto = listaRopa[validador + 2].NombreRopa;
            ShopPanel3.Id = listaRopa[validador + 2].Id;
            if (!listaRopa[validador + 2].Comprado)
                ShopPanel3.SoldOut();
            else
                ShopPanel3.OcultarSold();
            ShopPanel4.Precio = "$ " + (listaRopa[validador + 3].Precio - 1).ToString() + ".99";
            ShopPanel4.CargarImagenes(listaRopa[validador + 3].Imagen);
            ShopPanel4.NombreProducto = listaRopa[validador + 3].NombreRopa;
            ShopPanel4.Id = listaRopa[validador + 3].Id;
            if (!listaRopa[validador + 3].Comprado)
                ShopPanel4.SoldOut();
            else
                ShopPanel4.OcultarSold();
            ShopPanel5.Precio = "$ " + (listaRopa[validador + 4].Precio - 1).ToString() + ".99";
            ShopPanel5.CargarImagenes(listaRopa[validador + 4].Imagen);
            ShopPanel5.NombreProducto = listaRopa[validador + 4].NombreRopa;
            ShopPanel5.Id = listaRopa[validador + 4].Id;
            if (!listaRopa[validador + 4].Comprado)
                ShopPanel5.SoldOut();
            else
                ShopPanel5.OcultarSold();
            ShopPanel6.Precio = "$ " + (listaRopa[validador + 5].Precio - 1).ToString() + ".99";
            ShopPanel6.CargarImagenes(listaRopa[validador + 5].Imagen);
            ShopPanel6.NombreProducto = listaRopa[validador + 5].NombreRopa;
            ShopPanel6.Id = listaRopa[validador + 5].Id;
            if (!listaRopa[validador + 5].Comprado)
                ShopPanel6.SoldOut();
            else
                ShopPanel6.OcultarSold();
            ShopPanel7.Precio = "$ " + (listaRopa[validador + 6].Precio - 1).ToString() + ".99";
            ShopPanel7.CargarImagenes(listaRopa[validador + 6].Imagen);
            ShopPanel7.NombreProducto = listaRopa[validador + 6].NombreRopa;
            ShopPanel7.Id = listaRopa[validador + 6].Id;
            if (!listaRopa[validador + 6].Comprado)
                ShopPanel7.SoldOut();
            else
                ShopPanel7.OcultarSold();
            ShopPanel8.Precio = "$ " + (listaRopa[validador + 7].Precio - 1).ToString() + ".99";
            ShopPanel8.CargarImagenes(listaRopa[validador + 7].Imagen);
            ShopPanel8.NombreProducto = listaRopa[validador + 7].NombreRopa;
            ShopPanel8.Id = listaRopa[validador + 7].Id;
            if (!listaRopa[validador + 7].Comprado)
                ShopPanel8.SoldOut();
            else
                ShopPanel8.OcultarSold();
        }
        //MUEBLES
        private void MueblesPictureBox_Click(object sender, EventArgs e)
        {
            if (listaMuebles.Count >= 8)
            {
                PaginaUnoMuebles(0);
                MostrarShopPanels(Color.FromArgb(240, 160, 82, 45), Color.GhostWhite);
                CargaPistasAutosPilotosEconomia.Visible = true;
            }
            else
            {
                mensajeBox.Mostrar("En este momento estamos falta de Articulos! vuelva mas tarde");
            }
        }
        private void PaginaUnoMuebles(int valor)
        {
            eShopmanager = 2;
            ShopPanel1.Precio = "$ " + (listaMuebles[valor].Precio - 1).ToString() + ".99";
            ShopPanel1.CargarImagenes(listaMuebles[valor].Imagen);
            ShopPanel1.NombreProducto = listaMuebles[valor].NombreMueble;
            ShopPanel1.Id = listaMuebles[valor].Id;
            if (!listaMuebles[valor].Comprado)
                ShopPanel1.SoldOut();
            else
                ShopPanel1.OcultarSold();
            ShopPanel2.Precio = "$ " + (listaMuebles[valor + 1].Precio - 1).ToString() + ".99";
            ShopPanel2.CargarImagenes(listaMuebles[valor + 1].Imagen);
            ShopPanel2.NombreProducto = listaMuebles[valor + 1].NombreMueble;
            ShopPanel2.Id = listaMuebles[valor + 1].Id;
            if (!listaMuebles[valor + 1].Comprado)
                ShopPanel2.SoldOut();
            else
                ShopPanel2.OcultarSold();
            ShopPanel3.Precio = "$ " + (listaMuebles[valor + 2].Precio - 1).ToString() + ".99";
            ShopPanel3.CargarImagenes(listaMuebles[valor + 2].Imagen);
            ShopPanel3.NombreProducto = listaMuebles[valor + 2].NombreMueble;
            ShopPanel3.Id = listaMuebles[valor + 2].Id;
            if (!listaMuebles[valor + 2].Comprado)
                ShopPanel3.SoldOut();
            else
                ShopPanel3.OcultarSold();
            ShopPanel4.Precio = "$ " + (listaMuebles[valor + 3].Precio - 1).ToString() + ".99";
            ShopPanel4.CargarImagenes(listaMuebles[valor + 3].Imagen);
            ShopPanel4.NombreProducto = listaMuebles[valor + 3].NombreMueble;
            ShopPanel4.Id = listaMuebles[valor + 3].Id;
            if (!listaMuebles[valor + 3].Comprado)
                ShopPanel4.SoldOut();
            else
                ShopPanel4.OcultarSold();
            ShopPanel5.Precio = "$ " + (listaMuebles[valor + 4].Precio - 1).ToString() + ".99";
            ShopPanel5.CargarImagenes(listaMuebles[valor + 4].Imagen);
            ShopPanel5.NombreProducto = listaMuebles[valor + 4].NombreMueble;
            ShopPanel5.Id = listaMuebles[valor + 4].Id;
            if (!listaMuebles[valor + 4].Comprado)
                ShopPanel5.SoldOut();
            else
                ShopPanel5.OcultarSold();
            ShopPanel6.Precio = "$ " + (listaMuebles[valor + 5].Precio - 1).ToString() + ".99";
            ShopPanel6.CargarImagenes(listaMuebles[valor + 5].Imagen);
            ShopPanel6.NombreProducto = listaMuebles[valor + 5].NombreMueble;
            ShopPanel6.Id = listaMuebles[valor + 5].Id;
            if (!listaMuebles[valor + 5].Comprado)
                ShopPanel6.SoldOut();
            else
                ShopPanel6.OcultarSold();
            ShopPanel7.Precio = "$ " + (listaMuebles[valor + 6].Precio - 1).ToString() + ".99";
            ShopPanel7.CargarImagenes(listaMuebles[valor + 6].Imagen);
            ShopPanel7.NombreProducto = listaMuebles[valor + 6].NombreMueble;
            ShopPanel7.Id = listaMuebles[valor + 6].Id;
            if (!listaMuebles[valor + 6].Comprado)
                ShopPanel7.SoldOut();
            else
                ShopPanel7.OcultarSold();
            ShopPanel8.Precio = "$ " + (listaMuebles[valor + 7].Precio - 1).ToString() + ".99";
            ShopPanel8.CargarImagenes(listaMuebles[valor + 7].Imagen);
            ShopPanel8.NombreProducto = listaMuebles[valor + 7].NombreMueble;
            ShopPanel8.Id = listaMuebles[valor + 7].Id;
            if (!listaMuebles[valor + 7].Comprado)
                ShopPanel8.SoldOut();
            else
                ShopPanel8.OcultarSold();
        }
        //ELECTRO
        private void ElectroPictureBox_Click(object sender, EventArgs e)
        {
            if (listaElectro.Count >= 8)
            {
                PaginaUnoElectros(0);
                MostrarShopPanels(Color.FromArgb(255, 40, 89, 255), Color.GhostWhite);
                CargaPistasAutosPilotosEconomia.Visible = true;
            }
            else
            {
                mensajeBox.Mostrar("En este momento estamos falta de Articulos! vuelva mas tarde");
            }
        }
        private void PaginaUnoElectros(int validador)
        {
            eShopmanager = 3;
            ShopPanel1.Precio = "$ " + (listaElectro[validador].Precio - 1).ToString() + ".99";
            ShopPanel1.CargarImagenes(listaElectro[validador].Imagen);
            ShopPanel1.NombreProducto = listaElectro[validador].NombreElectronicos;
            ShopPanel1.Id = listaElectro[validador].Id;
            if (!listaElectro[validador].Comprado)
                ShopPanel1.SoldOut();
            else
                ShopPanel1.OcultarSold();
            ShopPanel2.Precio = "$ " + (listaElectro[validador + 1].Precio - 1).ToString() + ".99";
            ShopPanel2.CargarImagenes(listaElectro[validador + 1].Imagen);
            ShopPanel2.NombreProducto = listaElectro[validador + 1].NombreElectronicos;
            ShopPanel2.Id = listaElectro[validador + 1].Id;
            if (!listaElectro[validador + 1].Comprado)
                ShopPanel2.SoldOut();
            else
                ShopPanel2.OcultarSold();
            ShopPanel3.Precio = "$ " + (listaElectro[validador + 2].Precio - 1).ToString() + ".99";
            ShopPanel3.CargarImagenes(listaElectro[validador + 2].Imagen);
            ShopPanel3.NombreProducto = listaElectro[validador + 2].NombreElectronicos;
            ShopPanel3.Id = listaElectro[validador + 2].Id;
            if (!listaElectro[validador + 2].Comprado)
                ShopPanel3.SoldOut();
            else
                ShopPanel3.OcultarSold();
            ShopPanel4.Precio = "$ " + (listaElectro[validador + 3].Precio - 1).ToString() + ".99";
            ShopPanel4.CargarImagenes(listaElectro[validador + 3].Imagen);
            ShopPanel4.NombreProducto = listaElectro[validador + 3].NombreElectronicos;
            ShopPanel4.Id = listaElectro[validador + 3].Id;
            if (!listaElectro[validador + 3].Comprado)
                ShopPanel4.SoldOut();
            else
                ShopPanel4.OcultarSold();
            ShopPanel5.Precio = "$ " + (listaElectro[validador + 4].Precio - 1).ToString() + ".99";
            ShopPanel5.CargarImagenes(listaElectro[validador + 4].Imagen);
            ShopPanel5.NombreProducto = listaElectro[validador + 4].NombreElectronicos;
            ShopPanel5.Id = listaElectro[validador + 4].Id;
            if (!listaElectro[validador + 4].Comprado)
                ShopPanel5.SoldOut();
            else
                ShopPanel5.OcultarSold();
            ShopPanel6.Precio = "$ " + (listaElectro[validador + 5].Precio - 1).ToString() + ".99";
            ShopPanel6.CargarImagenes(listaElectro[validador + 5].Imagen);
            ShopPanel6.NombreProducto = listaElectro[validador + 5].NombreElectronicos;
            ShopPanel6.Id = listaElectro[validador + 5].Id;
            if (!listaElectro[validador + 5].Comprado)
                ShopPanel6.SoldOut();
            else
                ShopPanel6.OcultarSold();
            ShopPanel7.Precio = "$ " + (listaElectro[validador + 6].Precio - 1).ToString() + ".99";
            ShopPanel7.CargarImagenes(listaElectro[validador + 6].Imagen);
            ShopPanel7.NombreProducto = listaElectro[validador + 6].NombreElectronicos;
            ShopPanel7.Id = listaElectro[validador + 6].Id;
            if (!listaElectro[validador + 6].Comprado)
                ShopPanel7.SoldOut();
            else
                ShopPanel7.OcultarSold();
            ShopPanel8.Precio = "$ " + (listaElectro[validador + 7].Precio - 1).ToString() + ".99";
            ShopPanel8.CargarImagenes(listaElectro[validador + 7].Imagen);
            ShopPanel8.NombreProducto = listaElectro[validador + 7].NombreElectronicos;
            ShopPanel8.Id = listaElectro[validador + 7].Id;
            if (!listaElectro[validador + 7].Comprado)
                ShopPanel8.SoldOut();
            else
                ShopPanel8.OcultarSold();
        }

        //BACK-NEXT ROPA/MUEBLES/ELECTRO
        bool bdCargaRopa = false;
        bool bdCargaMueble = false;
        bool bdCargaElectro = false;
        private void BackRopaMuebleTecno_Click(object sender, EventArgs e)
        {
            if (ShopPanel1.BackColor == Color.Khaki)
            {
                if (bdCargaRopa)
                {
                    PaginaUnoRopa(0);
                    bdCargaRopa = false;
                }
            }
            else if (ShopPanel1.BackColor == Color.FromArgb(240, 160, 82, 45))
            {
                if (bdCargaMueble)
                {
                    PaginaUnoMuebles(0);
                    bdCargaMueble = false;
                }
            }
            else if (ShopPanel1.BackColor == Color.FromArgb(255, 40, 89, 255))
            {
                if (bdCargaElectro)
                {
                    PaginaUnoElectros(0);
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
                        PaginaUnoRopa(8);
                        bdCargaRopa = true;
                    }
                    else
                        mensajeBox.Mostrar("No hay mas articulos que comprar!");
                }
            }
            else if (ShopPanel1.BackColor == Color.FromArgb(240, 160, 82, 45))
            {
                if (!bdCargaMueble)
                {
                    if (listaMuebles.Count >= 16)
                    {
                        PaginaUnoMuebles(8);
                        bdCargaMueble = true;
                    }
                    else
                        mensajeBox.Mostrar("No hay mas articulos que comprar!");
                }
            }
            else if (ShopPanel1.BackColor == Color.FromArgb(255, 40, 89, 255))
            {
                if (!bdCargaElectro)
                {
                    if (listaElectro.Count >= 16)
                    {
                        PaginaUnoElectros(8);
                        bdCargaElectro = true;
                    }
                    else
                        mensajeBox.Mostrar("No hay mas articulos que comprar!");
                }
            }

        }
        //PANELES DE ROPA, ELECTRONICOS Y MUEBLES INDICE: 4.4 INDICE: 4.5 INDICE: 4.6
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
        private void ShopPanel1_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (miDinero.MiDinero - negocioPago.PagoArticulos(((EShopPanels)sender).Id, eShopmanager) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoArticulos(((EShopPanels)sender).Id, eShopmanager);
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                compraSonido.Play();
                negocioPago.DeshabilitarArticulo(((EShopPanels)sender).Id, eShopmanager);
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato;
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                FechaLabel.Text = Formato;
                ((EShopPanels)sender).SoldOut();
                compraSonido.Dispose();
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
                mensajeBox.Mostrar("No tiene dinero para Comprar este producto.");
        }
        //MOSTRAR MODULO HIGIENE, EVENTOS Y PAGINA INDICE: 4.7
        private void HigienePictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarEconomia();
                HigienePagina();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void HigienePagina()
        {
            Higiene1.NombreProducto = "Pack Basico Higiene Personal";
            Higiene2.NombreProducto = "Pack Mediano Higiene Personal";
            Higiene3.NombreProducto = "Pack Deluxe Higiene Personal";
            Higiene1.Id = ListaHigiene[0].Id;
            Higiene2.Id = ListaHigiene[1].Id;
            Higiene3.Id = ListaHigiene[2].Id;
            Higiene1.Comprado = ListaHigiene[0].Comprado;
            Higiene2.Comprado = ListaHigiene[1].Comprado;
            Higiene3.Comprado = ListaHigiene[2].Comprado;
            Higiene1.Precio = "$ " + (150 - 1).ToString() + ".99";
            Higiene2.Precio = "$ " + (195 - 1).ToString() + ".99";
            Higiene3.Precio = "$ " + (250 - 1).ToString() + ".99";
            Higiene1.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Higiene\Pack1.png");
            Higiene2.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Higiene\Pack2.png");
            Higiene3.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Higiene\Pack3.png");
            if (!ListaHigiene[0].Comprado)
                Higiene1.SoldOut();
            else
                Higiene1.OcultarSold();
            if (!ListaHigiene[1].Comprado)
                Higiene2.SoldOut();
            else
                Higiene2.OcultarSold();
            if (!ListaHigiene[2].Comprado)
                Higiene3.SoldOut();
            else
                Higiene3.OcultarSold();
            Higiene1.Visible = true;
            Higiene2.Visible = true;
            Higiene3.Visible = true;
            Higiene1.SetearColores(Color.Black);
            Higiene2.SetearColores(Color.Black);
            Higiene3.SetearColores(Color.Black);
        }
        private void Higiene1_ButtonClick(object sender, EventArgs e)
        {
            if (higieneManager == 2)
            {
                if (miDinero.MiDinero - ListaHigiene[0].Precio > 0)
                {
                    miDinero.MiDinero -= negocioHigiene.PagoArticulos(Higiene1.Id, 5);
                    negocioHigiene.ActualizarDinero(miDinero.MiDinero);
                    higieneManager = 0;
                    ListaHigiene[0].Comprado = false;
                    negocioHigiene.ActualizarHigieneManager(higieneManager);
                    plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                    DineroMostrarLabel.Text = plataFormato;
                    FormatearFecha(fechaAux);
                    FechaLabel.Text = Formato;
                    VolverBoton.Visible = true;
                    Higiene1.SoldOut();
                }
                else
                {
                    mensajeBox.Mostrar("No me alcanza el dinero");
                }
            }
            else
            {
                mensajeBox.Mostrar("Todavia Tengo productos de Higiene, no es necesario");
            }
        }
        private void Higiene2_ButtonClick(object sender, EventArgs e)
        {
            if (higieneManager == 2)
            {
                if (miDinero.MiDinero - ListaHigiene[1].Precio > 0)
                {
                    miDinero.MiDinero -= negocioHigiene.PagoArticulos(Higiene2.Id, 5);
                    negocioHigiene.ActualizarDinero(miDinero.MiDinero);
                    higieneManager = 0;
                    ListaHigiene[1].Comprado = false;
                    negocioHigiene.ActualizarHigieneManager(higieneManager);
                    plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                    DineroMostrarLabel.Text = plataFormato;
                    FormatearFecha(fechaAux);
                    FechaLabel.Text = Formato;
                    VolverBoton.Visible = true;
                    Higiene2.SoldOut();
                }
                else
                {
                    mensajeBox.Mostrar("No me alcanza el dinero");
                }
            }
            else
            {
                mensajeBox.Mostrar("Todavia Tengo productos de Higiene, no es necesario");
            }
        }
        private void Higiene3_ButtonClick(object sender, EventArgs e)
        {
            if (higieneManager == 2)
            {
                if (miDinero.MiDinero - ListaHigiene[2].Precio > 0)
                {
                    miDinero.MiDinero -= negocioHigiene.PagoArticulos(Higiene3.Id, 5);
                    negocioHigiene.ActualizarDinero(miDinero.MiDinero);
                    higieneManager = 0;
                    ListaHigiene[2].Comprado = false;
                    negocioHigiene.ActualizarHigieneManager(higieneManager);
                    plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                    DineroMostrarLabel.Text = plataFormato;
                    FormatearFecha(fechaAux);
                    FechaLabel.Text = Formato;
                    VolverBoton.Visible = true;
                    Higiene3.SoldOut();
                }
                else
                {
                    mensajeBox.Mostrar("No me alcanza el dinero");
                }
            }
            else
            {
                mensajeBox.Mostrar("Todavia Tengo productos de Higiene, no es necesario");
            }
        }
        //MOSTRAR MODULO MECANICO, NEXT-BACK, PAGINAS Y EVENTOS INDICE: 4.9
        private void MecanicoPictureBox_Click(object sender, EventArgs e)
        {
            MostrarMecanicoPaginaUno();
        }
        private void MostrarMecanicoPaginaUno()
        {
            OcultarEconomia();
            mecanico1.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Cambio-Aceite.jpg");
            mecanico2.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Mantenimiento Auto.jpg");
            mecanico3.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Motor.jpg");
            mecanico4.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\ReduccionDePeso.jpg");
            mecanico1.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Botones\Aceite-Boton.png");
            mecanico2.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Botones\Car-Service-Boton.png");
            mecanico3.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Botones\Motor.png");
            mecanico4.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Botones\Peso.png");
            mecanico1.Precio = string.Format("$ {0:N0}", (int)Precios.aceite);
            mecanico2.Precio = string.Format("$ {0:N0}", (int)Precios.manAuto);
            mecanico3.Precio = string.Format("$ {0:N0}", (int)Precios.manMotor);
            mecanico4.Precio = string.Format("$ {0:N0}", (int)Precios.reduccionWeight);
            if (mecanico1.Visible == false)
            {
                mecanico1.Visible = true;
                mecanico2.Visible = true;
                mecanico3.Visible = true;
                mecanico4.Visible = true;
                BackMecanico.Visible = true;
                NextMecanico.Visible = true;
            }
        }
        private void MostrarMecanicoSegundaPagina()
        {
            mecanico1.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Repro.jpg");
            mecanico2.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\ColocarTurbo.jpg");
            mecanico3.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\MakeAWD.jpg");
            mecanico4.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\EngineSwap.jpg");
            mecanico1.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Botones\Repro.png");
            mecanico2.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Botones\Turbo.Png");
            mecanico3.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Botones\AWD.png");
            mecanico4.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Mecanico\Botones\Swap.png");
            mecanico1.Precio = string.Format("$ {0:N0}", (int)Precios.repro);
            mecanico2.Precio = string.Format("$ {0:N0}", (int)Precios.turbo);
            mecanico3.Precio = string.Format("$ {0:N0}", (int)Precios.makeAWD);
            mecanico4.Precio = string.Format("$ {0:N0}", (int)Precios.swapEngine);
        }
        bool banderaPaginaMecanico = false;
        private void BackMecanico_Click(object sender, EventArgs e)
        {
            if (banderaPaginaMecanico)
            {
                MostrarMecanicoPaginaUno();
                banderaPaginaMecanico = false;
            }
        }
        private void NextMecanico_Click(object sender, EventArgs e)
        {
            if (!banderaPaginaMecanico)
            {
                MostrarMecanicoSegundaPagina();
                banderaPaginaMecanico = true;
            }
        }
        private void Mecanico1_ButtonClick(object sender, EventArgs e)
        {
            if (!banderaPaginaMecanico)
            {
                if (miDinero.MiDinero - (int)Precios.aceite > 0)
                {
                    if (!estadoAceite)
                    {
                        compraSonido.Play();
                        estadoAceite = true;
                        NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                        negocioMecanico.UpEstadoAuto(7);
                        miDinero.MiDinero -= (int)Precios.aceite;
                        SonidosMecanico(1);
                        negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                        plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                        DineroMostrarLabel.Text = plataFormato;
                        compraSonido.Dispose();
                        aceiteManager = 0;
                        negocioMecanico.UpdatearComponentes(aceiteManager, motorManager, autoManager, gomasManager, gomasDeLluviaManager, limpiezaManager);
                    }
                    else
                        mensajeBox.Mostrar("El Mecanico dice que tu aceite esta correcto por ahora y no requiere cambiarlo!");
                }
                else
                {
                    mensajeBox.Mostrar("No tiene el suficiente dinero Para Hacer el cambio de Aceite");
                }
            }
            else
            {
                if (miDinero.MiDinero - (int)Precios.repro > 0)
                {

                    if (!estadoRepro)
                    {
                        estadoRepro = true;
                        compraSonido.Play();
                        NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                        negocioMecanico.UpEstadoAuto(4);
                        miDinero.MiDinero -= (int)Precios.repro;
                        negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                        negocioMecanico.UpPesoPotencia();
                        plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                        DineroMostrarLabel.Text = plataFormato;
                        MiAuto = negocioMecanico.DevolverMiAuto();
                        compraSonido.Dispose();
                    }
                    else
                    {
                        mensajeBox.Mostrar("Tu Vehiculo ya tiene una Repro!");
                    }
                }
                else
                {
                    mensajeBox.Mostrar("No tiene el suficiente dinero Para Hacerle Una Repro al auto");
                }
            }
            if (estadoAceite && estadoMotor && estadoAuto)
            {
                NegocioBaseDatos negociobase = new NegocioBaseDatos();
                negociobase.UpEstadoAuto(10);
            }
        }
        private void Mecanico2_ButtonClick(object sender, EventArgs e)
        {
            if (!banderaPaginaMecanico)
            {
                if (miDinero.MiDinero - (int)Precios.manAuto > 0)
                {
                    if (!estadoAuto)
                    {
                        estadoAuto = true;
                        compraSonido.Play();
                        NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                        miDinero.MiDinero -= (int)Precios.manAuto;
                        negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                        negocioMecanico.UpEstadoAuto(9);
                        plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                        DineroMostrarLabel.Text = plataFormato;
                        compraSonido.Dispose();
                        autoManager = 0;
                        negocioMecanico.UpdatearComponentes(aceiteManager, motorManager, autoManager, gomasManager, gomasDeLluviaManager, limpiezaManager);
                    }
                    else
                        mensajeBox.Mostrar("El Mecanico esta muy Ocupado! Vuelve otro dia");

                }
                else
                {
                    mensajeBox.Mostrar("No tiene el suficiente dinero Para Hacer Mantenimiento del Auto");
                }
            }
            else
            {
                if (miDinero.MiDinero - (int)Precios.turbo > 0)
                {
                    if (!estadoTurbo && MiAuto.Aspiracion != "T")
                    {
                        estadoTurbo = true;
                        compraSonido.Play();
                        NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                        negocioMecanico.UpEstadoAuto(5);
                        negocioMecanico.UpdateMiAuto("T", 1);
                        SonidosMecanico(3);
                        MiAuto = negocioMecanico.DevolverMiAuto();
                        negocioMecanico.UpPesoPotencia();
                        miDinero.MiDinero -= (int)Precios.turbo;
                        negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                        plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                        DineroMostrarLabel.Text = plataFormato;
                        compraSonido.Dispose();
                    }
                    else
                    {
                        mensajeBox.Mostrar("Tu Vehiculo ya tiene un Turbo!");
                    }
                }
                else
                {
                    mensajeBox.Mostrar("No tiene el suficiente dinero Para Colocarle un turbo al Auto");
                }
            }
            if (estadoAceite && estadoMotor && estadoAuto)
            {
                NegocioBaseDatos negociobase = new NegocioBaseDatos();
                negociobase.UpEstadoAuto(10);
            }
        }
        private void Mecanico3_ButtonClick(object sender, EventArgs e)
        {
            if (!banderaPaginaMecanico)
            {
                if (miDinero.MiDinero - (int)Precios.manMotor > 0)
                {
                    if (!estadoMotor)
                    {
                        estadoMotor = true;
                        compraSonido.Play();
                        NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                        miDinero.MiDinero -= (int)Precios.manMotor;
                        negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                        negocioMecanico.UpEstadoAuto(8);
                        SonidosMecanico(2);
                        plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                        DineroMostrarLabel.Text = plataFormato;
                        MiAuto = negocioMecanico.DevolverMiAuto();
                        compraSonido.Dispose();
                        motorManager = 0;
                        negocioMecanico.UpdatearComponentes(aceiteManager, motorManager, autoManager, gomasManager, gomasDeLluviaManager, limpiezaManager);
                    }
                    else
                        mensajeBox.Mostrar("El Mecanico dice que tu motor esta bien, no le hace falta mantenimiento");
                }
                else
                {
                    mensajeBox.Mostrar("No tiene el suficiente dinero Para Hacer Mantenimiento del Motor");
                }
            }
            else
            {
                if (miDinero.MiDinero - (int)Precios.makeAWD > 0)
                {
                    if (!estadoAWD && MiAuto.Traccion != "AWD")
                    {
                        estadoAWD = true;
                        compraSonido.Play();
                        NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                        negocioMecanico.UpEstadoAuto(6);
                        negocioMecanico.UpdateMiAuto("AWD", 2);
                        miDinero.MiDinero -= (int)Precios.makeAWD;
                        negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                        plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                        DineroMostrarLabel.Text = plataFormato;
                        MiAuto = negocioMecanico.DevolverMiAuto();
                        compraSonido.Dispose();
                    }
                    else
                    {
                        mensajeBox.Mostrar("Tu Vehiculo ya Es AWD!");
                    }
                }
                else
                {
                    mensajeBox.Mostrar("No tiene el suficiente dinero Para realizarle la modficicacion AWD al auto");
                }
            }
            if (estadoAceite && estadoMotor && estadoAuto)
            {
                NegocioBaseDatos negociobase = new NegocioBaseDatos();
                negociobase.UpEstadoAuto(10);
            }
        }
        private void Mecanico4_ButtonClick(object sender, EventArgs e)
        {
            if (!banderaPaginaMecanico)
            {
                if (miDinero.MiDinero - (int)Precios.reduccionWeight > 0)
                {
                    compraSonido.Play();
                    NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                    miDinero.MiDinero -= (int)Precios.reduccionWeight;
                    negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                    negocioMecanico.UpEstadoAuto(11, MiAuto.Peso);
                    negocioMecanico.UpPesoPotencia();
                    plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                    DineroMostrarLabel.Text = plataFormato;

                    compraSonido.Dispose();
                }
                else
                {
                    mensajeBox.Mostrar("No tiene el suficiente dinero Para Hacer una Reduccion de Peso");
                }
            }
            else
            {

            }
            if (estadoAceite && estadoMotor && estadoAuto)
            {
                NegocioBaseDatos negociobase = new NegocioBaseDatos();
                negociobase.UpEstadoAuto(10);
            }
        }

        //MOSTRAR MODULO GAstosVarios Y EVENTOS INDICE: 4.10
        private void GastosVariosPictureBox_Click(object sender, EventArgs e)
        {
            MostrarGastosDiarios();
        }
        private void MostrarGastosDiarios()
        {
            OcultarEconomia();
            gastosDiarios1.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\GastosDiarios\Wash.jpg");
            gastosDiarios2.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\GastosDiarios\Gasolinera.jpg");
            gastosDiarios3.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\GastosDiarios\SemiSlick.jpg");
            gastosDiarios4.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\GastosDiarios\WetTyre.jpg");
            gastosDiarios5.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\GastosDiarios\Seguro.jpg");
            gastosDiarios6.CargarImagenes(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\GastosDiarios\Vinilos.jpg");
            gastosDiarios1.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\\GastosDiarios\Botones\CarWash.png");
            gastosDiarios2.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\\GastosDiarios\Botones\Nafta.png");
            gastosDiarios3.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\\GastosDiarios\Botones\Tyres.png");
            gastosDiarios4.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\\GastosDiarios\Botones\Tyres.png");
            gastosDiarios5.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\\GastosDiarios\Botones\Seguro.png");
            gastosDiarios6.CargarImagenesBoton(@"C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\\GastosDiarios\Botones\BBS.png");
            gastosDiarios1.Precio = string.Format("$ {0:N0}", (int)Precios.carWash);
            gastosDiarios2.Precio = "$2,5 C/L";
            gastosDiarios3.Precio = string.Format("$ {0:N0}", (int)Precios.dryTyres);
            gastosDiarios4.Precio = string.Format("$ {0:N0}", (int)Precios.rainTyres);
            gastosDiarios5.Precio = string.Format("$ {0:N0}", (int)Precios.seguro);
            gastosDiarios6.Precio = string.Format("$ {0:N0}", (int)Precios.vinilos);
            if (gastosDiarios1.Visible == false)
            {
                gastosDiarios1.Visible = true;
                gastosDiarios2.Visible = true;
                gastosDiarios3.Visible = true;
                gastosDiarios4.Visible = true;
                gastosDiarios5.Visible = true;
                gastosDiarios6.Visible = true;
            }
        }
        private void GastosDiarios1_ButtonClick(object sender, EventArgs e)
        {
            if (miDinero.MiDinero - (int)Precios.carWash >= 0)
            {
                compraSonido.Play();
                SonidosMecanico(4);
                NegocioBaseDatos negocioGastos = new NegocioBaseDatos();
                negocioGastos.UpEstadoAuto(12, 0, true);
                miDinero.MiDinero -= (int)Precios.carWash;
                negocioGastos.ActualizarDinero(miDinero.MiDinero);
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato;
                MiAuto = negocioGastos.DevolverMiAuto();
                compraSonido.Dispose();
                limpiezaManager = 0;
                negocioGastos.UpdatearComponentes(aceiteManager, motorManager, autoManager, gomasManager, gomasDeLluviaManager, limpiezaManager);
            }
            else
            {
                mensajeBox.Mostrar("No tiene el suficiente dinero Para Lavar tu auto");

            }
        }
        private void GastosDiarios2_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioGastos = new NegocioBaseDatos();
            if (negocioGastos.LeerTanques())
            {
                compraSonido.Play();
                SonidosMecanico(6);
                int precio = negocioGastos.CombustibleRecarga();
                miDinero.MiDinero -= precio;
                negocioGastos.ActualizarDinero(miDinero.MiDinero);
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato;
                MiAuto = negocioGastos.DevolverMiAuto();
                compraSonido.Dispose();
            }
            else
            {
                mensajeBox.Mostrar("Tiene Tanque Lleno, no hace falta recargar");
            }
        }
        private void GastosDiarios3_ButtonClick(object sender, EventArgs e)
        {
            if (miDinero.MiDinero - (int)Precios.dryTyres >= 0)
            {
                compraSonido.Play();
                SonidosMecanico(5);
                NegocioBaseDatos negocioGastos = new NegocioBaseDatos();
                negocioGastos.UpEstadoAuto(14);
                miDinero.MiDinero -= (int)Precios.dryTyres;
                negocioGastos.ActualizarDinero(miDinero.MiDinero);
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato;
                MiAuto = negocioGastos.DevolverMiAuto();
                compraSonido.Dispose();
                negocioGastos.UpdatearComponentes(aceiteManager, motorManager, autoManager, gomasManager, gomasDeLluviaManager, limpiezaManager);
            }
        }
        private void GastosDiarios4_ButtonClick(object sender, EventArgs e)
        {
            if (miDinero.MiDinero - (int)Precios.rainTyres >= 0)
            {
                compraSonido.Play();
                SonidosMecanico(5);
                NegocioBaseDatos negocioGastos = new NegocioBaseDatos();
                negocioGastos.UpEstadoAuto(16);
                miDinero.MiDinero -= (int)Precios.rainTyres;
                negocioGastos.ActualizarDinero(miDinero.MiDinero);
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato;
                MiAuto = negocioGastos.DevolverMiAuto();
                compraSonido.Dispose();
                negocioGastos.UpdatearComponentes(aceiteManager, motorManager, autoManager, gomasManager, gomasDeLluviaManager, limpiezaManager);
            }
        }
        private void GastosDiarios5_ButtonClick(object sender, EventArgs e)
        {
            if (miDinero.MiDinero - (int)Precios.seguro >= 0)
            {
                compraSonido.Play();
                NegocioBaseDatos negocioGastos = new NegocioBaseDatos();
                negocioGastos.UpdateSeguro(true);
                miDinero.MiDinero -= (int)Precios.seguro;
                negocioGastos.ActualizarDinero(miDinero.MiDinero);
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato;
                compraSonido.Dispose();
            }
        }
        private void GastosDiarios6_ButtonClick(object sender, EventArgs e)
        {
            if (miDinero.MiDinero - (int)Precios.vinilos >= 0)
            {
                compraSonido.Play();
                NegocioBaseDatos negocioGastos = new NegocioBaseDatos();
                negocioGastos.Vinilos();
                miDinero.MiDinero -= (int)Precios.vinilos;
                negocioGastos.ActualizarDinero(miDinero.MiDinero);
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato;
                compraSonido.Dispose();
            }
        }

        //MOSTRAR MODULO Garaje Y EVENTOS INDICE: 4.11
        private void GarajePictureBox_Click(object sender, EventArgs e)
        {
            MostrarGaraje();
        }
        private void MostrarGaraje()
        {
            OcultarEconomia();
            MiAutoPB.Visible = true;
            BanderaMiAuto.Visible = true;
            PanelGaraje.Visible = true;
            NombreMiauto.Visible = true;
            plus = true;
            HpMiauto.Visible = true;
            HpMiauto2.Visible = true;
            PesoMiAuto.Visible = true;
            PesoMiAuto2.Visible = true;
            PPMiAuto.Visible = true;
            PPMiAuto2.Visible = true;
            TorqueMiAuto.Visible = true;
            TorqueLabel2.Visible = true;
            AceiteMiAuto.Visible = true;
            AceiteMiAuto2.Visible = true;
            MotorMiAuto.Visible = true;
            MotorMiAuto2.Visible = true;
            MantMiAuto.Visible = true;
            MantMiAuto2.Visible = true;
            LimpMiAuto.Visible = true;
            LimpMiAuto2.Visible = true;
            ReproMiAuto.Visible = true;
            ReproMiAuto2.Visible = true;
            ASpMiAuto.Visible = true;
            ASpMiAuto2.Visible = true;
            PlusBoton.Visible = true;
            CargarMiauto();
        }
        private void OcultarDatos()
        {
            if (plus)
            {
                plus = false;
                HpMiauto.Visible = false;
                HpMiauto2.Visible = false;
                PesoMiAuto.Visible = false;
                PesoMiAuto2.Visible = false;
                PPMiAuto.Visible = false;
                PPMiAuto2.Visible = false;
                TorqueMiAuto.Visible = false;
                TorqueLabel2.Visible = false;
                AceiteMiAuto.Visible = false;
                AceiteMiAuto2.Visible = false;
                MotorMiAuto.Visible = false;
                MotorMiAuto2.Visible = false;
                MantMiAuto.Visible = false;
                MantMiAuto2.Visible = false;
                LimpMiAuto.Visible = false;
                LimpMiAuto2.Visible = false;
                ReproMiAuto.Visible = false;
                ReproMiAuto2.Visible = false;
                ASpMiAuto.Visible = false;
                ASpMiAuto2.Visible = false;
                GomasMojado.Visible = true;
                GomasMojado2.Visible = true;
                GomasSeco.Visible = true;
                GomasSeco2.Visible = true;
                TraccionMiauto.Visible = true;
                TraccionMiauto2.Visible = true;
                GasofaMiauto.Visible = true;
                GasofaMiauto2.Visible = true;
            }
            else
            {
                plus = true;
                HpMiauto.Visible = true;
                HpMiauto2.Visible = true;
                PesoMiAuto.Visible = true;
                PesoMiAuto2.Visible = true;
                PPMiAuto.Visible = true;
                PPMiAuto2.Visible = true;
                TorqueMiAuto.Visible = true;
                TorqueLabel2.Visible = true;
                AceiteMiAuto.Visible = true;
                AceiteMiAuto2.Visible = true;
                MotorMiAuto.Visible = true;
                MotorMiAuto2.Visible = true;
                MantMiAuto.Visible = true;
                MantMiAuto2.Visible = true;
                LimpMiAuto.Visible = true;
                LimpMiAuto2.Visible = true;
                ReproMiAuto.Visible = true;
                ReproMiAuto2.Visible = true;
                ASpMiAuto.Visible = true;
                ASpMiAuto2.Visible = true;
                GomasMojado.Visible = false;
                GomasMojado2.Visible = false;
                GomasSeco.Visible = false;
                GomasSeco2.Visible = false;
                TraccionMiauto.Visible = false;
                TraccionMiauto2.Visible = false;
                GasofaMiauto.Visible = false;
                GasofaMiauto2.Visible = false;
            }
        }
        private void CargarMiauto()
        {
            NegocioBaseDatos negocioMiAuto = new NegocioBaseDatos();
            MiAuto myCar;

            myCar = negocioMiAuto.GetMiAuto();
            MiAutoPB.Load(myCar.Imagen);
            HpMiauto2.Text = myCar.Hp.ToString() + " Hp";
            PesoMiAuto2.Text = myCar.Peso.ToString() + " Kg";
            PPMiAuto2.Text = myCar.PesoPotencia.ToString("0.00") + " Kg/Hp";
            TorqueMiAuto.Text = myCar.Torque.ToString() + "Nm";
            NombreMiauto.Text = myCar.Nombre;
            GomasSeco2.Text = myCar.GomasSemiSlick.ToString();
            GomasMojado2.Text = myCar.GomasWet.ToString();
            TraccionMiauto2.Text = myCar.Traccion;
            if (myCar.Aceite && estadoAceite)
            {
                AceiteMiAuto2.Text = "OK";
                AceiteMiAuto2.ForeColor = Color.LimeGreen;
            }
            else
            {
                AceiteMiAuto2.Text = "Cambio";
                AceiteMiAuto2.ForeColor = Color.FromArgb(128,120,0);
            }
            if (myCar.Motor && estadoMotor)
            {
                MotorMiAuto2.Text = "OK";
                MotorMiAuto2.ForeColor = Color.LimeGreen;
            }
            else
            {
                MotorMiAuto2.Text = "Malo";
                MotorMiAuto2.ForeColor = Color.Red;
            }
            if (myCar.Mantenimiento && estadoAuto)
            {
                MantMiAuto2.Text = "OK";
                MantMiAuto2.ForeColor = Color.LimeGreen;
            }
            else
            {
                MantMiAuto2.Text = "Malo";
                MantMiAuto2.ForeColor = Color.Red;
            }
            if (!myCar.Lavado)
            {
                LimpMiAuto2.Text = "Limpio";
                LimpMiAuto2.ForeColor = Color.SpringGreen;
            }
            else
            {
                AceiteMiAuto2.Text = "Sucio";
                AceiteMiAuto2.ForeColor = Color.SaddleBrown;
            }
            if (myCar.Repro)
            {
                ReproMiAuto2.Text = "Si";
                ReproMiAuto2.ForeColor = Color.LimeGreen;
            }
            if (myCar.Asp == "NA")
            {
                ASpMiAuto2.Text = "NA";
                ASpMiAuto2.ForeColor = Color.Wheat;
            }
            else if (myCar.Asp == "T")
            {
                ASpMiAuto2.Text = "T";
                ASpMiAuto2.ForeColor = Color.LightCyan;
            }
            else
            {
                ASpMiAuto2.Text = "SC";
                ASpMiAuto2.ForeColor = Color.Blue;
            }
            GasofaMiauto2.Text = myCar.TanqueActual + "/" + myCar.TanqueTotal;
            if (myCar.TanqueActual / myCar.TanqueTotal == 1)
                GasofaMiauto2.ForeColor = Color.Green;
            else if (myCar.TanqueActual / myCar.TanqueTotal >= 0.75)
                GasofaMiauto2.ForeColor = Color.YellowGreen;
            else if (myCar.TanqueActual / myCar.TanqueTotal >= 0.5)
                GasofaMiauto2.ForeColor = Color.Yellow;
            else if (myCar.TanqueActual / myCar.TanqueTotal >= 0.20)
                GasofaMiauto2.ForeColor = Color.OrangeRed;
            else
                GasofaMiauto2.ForeColor = Color.OrangeRed;
            estadoAceite = negocioMiAuto.DevolverEstadosAuto(1);
            estadoMotor = negocioMiAuto.DevolverEstadosAuto(2);
            estadoAuto = negocioMiAuto.DevolverEstadosAuto(3);
            estadoRepro = negocioMiAuto.DevolverEstadosAuto(4);
            estadoTurbo = negocioMiAuto.DevolverEstadosAuto(5);
            estadoAWD = negocioMiAuto.DevolverEstadosAuto(6);
            estadoLimpieza = negocioMiAuto.DevolverEstadosAuto(7);
        }
        bool plus = true;
        private void PlusBoton_Click(object sender, EventArgs e)
        {
            OcultarDatos();
        }

        //Modulo MIS OBJETOS INDICE 4.8
        private void MisCosasPictureBox_Click(object sender, EventArgs e)
        {
            NegocioBaseDatos conexionObjetos = new NegocioBaseDatos();
            if (listaObjetosAux == null)
            {
                listaObjetosAux = new List<MisObjetos>();
                conexionObjetos.CargarListasAuxiliares(ref listaObjetosAux);
            }
            listaObjetosAux = new List<MisObjetos>();
            conexionObjetos.CargarListasAuxiliares(ref listaObjetosAux);
            listaMisCosas = CrearObjetos();
            int prub = listaObjetosAux.Count;
            if (listaMisCosas.Count > 0)
            {
                try
                {
                    OcultarEconomia();
                    NextObjeto.Visible = true;
                    BackObjeto.Visible = true;
                    PaginaUno(0);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                mensajeBox.Mostrar("No Tienes Objetos");
        }
        int managerMisObjetos = 0;//Detecta cuantos objetos son y da la orden de crear los paneles
        private List<EShopPanels> CrearObjetos()
        {
            List<EShopPanels> listaDeMisCosas = new List<EShopPanels>();
            NegocioBaseDatos conexionObjetos = new NegocioBaseDatos();
            managerMisObjetos = conexionObjetos.NumeroDeMisObjetos();
            if (managerMisObjetos > 8)
            {
                for (int i = 0; i < 8; i++)
                {
                    EShopPanels panelPrueba = new EShopPanels
                    {
                        Size = new Size(379, 377),
                        Visible = true,
                        Parent = PictureBoxBack,
                        BackColor = Color.Silver,
                        ForeColor = Color.Black
                    };
                    panelPrueba.Ocultar();
                    listaDeMisCosas.Add(panelPrueba);
                }
            }
            else
            {
                for (int i = 0; i < managerMisObjetos; i++)
                {
                    EShopPanels panelPrueba = new EShopPanels
                    {
                        Size = new Size(379, 377),
                        Visible = true,
                        Parent = PictureBoxBack,
                        BackColor = Color.Silver,
                        ForeColor = Color.Black
                    };
                    panelPrueba.Ocultar();
                    listaDeMisCosas.Add(panelPrueba);
                }
            }
            return listaDeMisCosas;
        }//Crea Los Paneles
        private void NextObjeto_Click(object sender, EventArgs e)
        {
            MisObjetosPaginaManager++;
            switch (MisObjetosPaginaManager)
            {
                case 2:
                    PaginaUno(8);
                    break;
                case 3:
                    PaginaUno(16);
                    break;
                case 4:
                    PaginaUno(24);
                    break;
                case 5:
                    PaginaUno(32);
                    break;
                case 6:
                    PaginaUno(40);
                    break;
                case 7:
                    PaginaUno(48);
                    break;
                case 8:
                    PaginaUno(56);
                    break;
                case 9:
                    PaginaUno(64);
                    break;
                case 10:
                    PaginaUno(72);
                    break;
                case 11:
                    PaginaUno(80);
                    break;
                case 12:
                    PaginaUno(88);
                    break;
                case 13:
                    PaginaUno(96);
                    break;
                case 14:
                    PaginaUno(104);
                    break;
                case 15:
                    PaginaUno(112);
                    break;
                case 16:
                    PaginaUno(120);
                    break;
                case 17:
                    PaginaUno(128);
                    break;
                case 18:
                    PaginaUno(136);
                    break;
                case 19:
                    PaginaUno(144);
                    break;
                case 20:
                    PaginaUno(152);
                    break;

                default:
                    MisObjetosPaginaManager--;
                    break;
            }
        }
        private void BackObjeto_Click(object sender, EventArgs e)
        {
            MisObjetosPaginaManager--;
            switch (MisObjetosPaginaManager)
            {
                case 1:
                    PaginaUno(0);
                    break;
                case 2:
                    PaginaUno(8);
                    break;
                case 3:
                    PaginaUno(16);
                    break;
                case 4:
                    PaginaUno(24);
                    break;
                case 5:
                    PaginaUno(32);
                    break;
                case 6:
                    PaginaUno(40);
                    break;
                case 7:
                    PaginaUno(48);
                    break;
                case 8:
                    PaginaUno(56);
                    break;
                case 9:
                    PaginaUno(64);
                    break;
                case 10:
                    PaginaUno(72);
                    break;
                case 11:
                    PaginaUno(80);
                    break;
                case 12:
                    PaginaUno(88);
                    break;
                case 13:
                    PaginaUno(96);
                    break;
                case 14:
                    PaginaUno(104);
                    break;
                case 15:
                    PaginaUno(112);
                    break;
                case 16:
                    PaginaUno(120);
                    break;
                case 17:
                    PaginaUno(128);
                    break;
                case 18:
                    PaginaUno(136);
                    break;
                case 19:
                    PaginaUno(144);
                    break;
                default:
                    MisObjetosPaginaManager++;
                    break;
            }
        }
        int MisObjetosPaginaManager = 1; //El Manager de las Paginas de mis Items
        int indexM; //Maneja el index de la lista de mis Objetos
        private void PaginaUno(int index)
        {
            int dummy = indexM;
            indexM = index;
            if (listaObjetosAux.Count > indexM)
            {
                try
                {
                    if (RopaPictureBox.Visible == false && CarDealerPictureBox.Visible == false)
                    {
                        OcultarEconomia();
                    }
                    int aux = listaObjetosAux.Count - indexM;
                    switch (aux)
                    {
                        case 1:
                            listaMisCosas[0].Location = ShopPanel1.Location;
                            listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            break;
                        case 2:
                            listaMisCosas[0].Location = ShopPanel1.Location;
                            listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[1].Location = ShopPanel2.Location;
                            listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            break;
                        case 3:
                            listaMisCosas[0].Location = ShopPanel1.Location;
                            listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[1].Location = ShopPanel2.Location;
                            listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[2].Location = ShopPanel3.Location;
                            listaMisCosas[2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            break;
                        case 4:
                            listaMisCosas[0].Location = ShopPanel1.Location;
                            listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[1].Location = ShopPanel2.Location;
                            listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[2].Location = ShopPanel3.Location;
                            listaMisCosas[2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            listaMisCosas[3].Location = ShopPanel4.Location;
                            listaMisCosas[3].NombreProducto = listaObjetosAux[indexM + 3].NombreProducto;
                            listaMisCosas[3].CargarImagenes(listaObjetosAux[indexM + 3].Imagen);
                            break;
                        case 5:
                            listaMisCosas[0].Location = ShopPanel1.Location;
                            listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[1].Location = ShopPanel2.Location;
                            listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[2].Location = ShopPanel3.Location;
                            listaMisCosas[2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            listaMisCosas[3].Location = ShopPanel4.Location;
                            listaMisCosas[3].NombreProducto = listaObjetosAux[indexM + 3].NombreProducto;
                            listaMisCosas[3].CargarImagenes(listaObjetosAux[indexM + 3].Imagen);
                            listaMisCosas[4].Location = ShopPanel5.Location;
                            listaMisCosas[4].NombreProducto = listaObjetosAux[indexM + 4].NombreProducto;
                            listaMisCosas[4].CargarImagenes(listaObjetosAux[indexM + 4].Imagen);
                            break;
                        case 6:
                            listaMisCosas[0].Location = ShopPanel1.Location;
                            listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[1].Location = ShopPanel2.Location;
                            listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[2].Location = ShopPanel3.Location;
                            listaMisCosas[2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            listaMisCosas[3].Location = ShopPanel4.Location;
                            listaMisCosas[3].NombreProducto = listaObjetosAux[indexM + 3].NombreProducto;
                            listaMisCosas[3].CargarImagenes(listaObjetosAux[indexM + 3].Imagen);
                            listaMisCosas[4].Location = ShopPanel5.Location;
                            listaMisCosas[4].NombreProducto = listaObjetosAux[indexM + 4].NombreProducto;
                            listaMisCosas[4].CargarImagenes(listaObjetosAux[indexM + 4].Imagen);
                            listaMisCosas[5].Location = ShopPanel6.Location;
                            listaMisCosas[5].NombreProducto = listaObjetosAux[indexM + 5].NombreProducto;
                            listaMisCosas[5].CargarImagenes(listaObjetosAux[indexM + 5].Imagen);
                            break;
                        case 7:
                            listaMisCosas[0].Location = ShopPanel1.Location;
                            listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[1].Location = ShopPanel2.Location;
                            listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[2].Location = ShopPanel3.Location;
                            listaMisCosas[2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            listaMisCosas[3].Location = ShopPanel4.Location;
                            listaMisCosas[3].NombreProducto = listaObjetosAux[indexM + 3].NombreProducto;
                            listaMisCosas[3].CargarImagenes(listaObjetosAux[indexM + 3].Imagen);
                            listaMisCosas[4].Location = ShopPanel5.Location;
                            listaMisCosas[4].NombreProducto = listaObjetosAux[indexM + 4].NombreProducto;
                            listaMisCosas[4].CargarImagenes(listaObjetosAux[indexM + 4].Imagen);
                            listaMisCosas[5].Location = ShopPanel6.Location;
                            listaMisCosas[5].NombreProducto = listaObjetosAux[indexM + 5].NombreProducto;
                            listaMisCosas[5].CargarImagenes(listaObjetosAux[indexM + 5].Imagen);
                            listaMisCosas[6].Location = ShopPanel7.Location;
                            listaMisCosas[6].NombreProducto = listaObjetosAux[indexM + 6].NombreProducto;
                            listaMisCosas[6].CargarImagenes(listaObjetosAux[indexM + 6].Imagen);
                            break;
                        default:
                            listaMisCosas[0].Location = ShopPanel1.Location;
                            listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[1].Location = ShopPanel2.Location;
                            listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[2].Location = ShopPanel3.Location;
                            listaMisCosas[2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            listaMisCosas[3].Location = ShopPanel4.Location;
                            listaMisCosas[3].NombreProducto = listaObjetosAux[indexM + 3].NombreProducto;
                            listaMisCosas[3].CargarImagenes(listaObjetosAux[indexM + 3].Imagen);
                            listaMisCosas[4].Location = ShopPanel5.Location;
                            listaMisCosas[4].NombreProducto = listaObjetosAux[indexM + 4].NombreProducto;
                            listaMisCosas[4].CargarImagenes(listaObjetosAux[indexM + 4].Imagen);
                            listaMisCosas[5].Location = ShopPanel6.Location;
                            listaMisCosas[5].NombreProducto = listaObjetosAux[indexM + 5].NombreProducto;
                            listaMisCosas[5].CargarImagenes(listaObjetosAux[indexM + 5].Imagen);
                            listaMisCosas[6].Location = ShopPanel7.Location;
                            listaMisCosas[6].NombreProducto = listaObjetosAux[indexM + 6].NombreProducto;
                            listaMisCosas[6].CargarImagenes(listaObjetosAux[indexM + 6].Imagen);
                            listaMisCosas[7].Location = ShopPanel8.Location;
                            listaMisCosas[7].NombreProducto = listaObjetosAux[indexM + 7].NombreProducto;
                            listaMisCosas[7].CargarImagenes(listaObjetosAux[indexM + 7].Imagen);
                            break;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
            else
            {
                mensajeBox.Mostrar("No Tienes Mas Articulos");
                indexM = dummy;
                MisObjetosPaginaManager--;
            }
        }


        //TIMER QUE EJECUTAN EL SONIDO DE LA COMPRA EN MECANICO O GASTOS DIARIOS
        int sonido = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            timerCursor.Enabled = true;
            switch (sonido)
            {
                case 1:
                    timerCursor.Interval = 8500;
                    aceiteSonido.Play();
                    aceiteSonido.Dispose();
                    timerCompra.Stop();
                    timerCompra.Enabled = false;
                    break;
                case 2:
                    timerCursor.Interval = 6300;
                    mantenimientoMotorSonido.Play();
                    mantenimientoMotorSonido.Dispose();
                    timerCompra.Stop();
                    timerCompra.Enabled = false;
                    break;
                case 3:
                    timerCursor.Interval = 2800;
                    TurboSonido.Play();
                    TurboSonido.Dispose();
                    timerCompra.Stop();
                    timerCompra.Enabled = false;
                    break;
                case 4:
                    timerCursor.Interval = 12000;
                    LimpiarSonido.Play();
                    LimpiarSonido.Dispose();
                    timerCompra.Stop();
                    timerCompra.Enabled = false;
                    break;
                case 5:
                    timerCursor.Interval = 10500;
                    PitsSonido.Play();
                    PitsSonido.Dispose();
                    timerCompra.Stop();
                    timerCompra.Enabled = false;
                    break;
                case 6:
                    timerCursor.Interval = 19200;
                    GasSonido.Play();
                    GasSonido.Dispose();
                    timerCompra.Stop();
                    timerCompra.Enabled = false;
                    break;
            }

        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            Cursor.Show();
            timerCursor.Enabled = false;
            timerCursor.Stop();
            switch (sonido)
            {
                case 1:
                    mensajeBox.Mostrar("Aceite Cambiado con exito!");
                    break;
                case 2:
                    mensajeBox.Mostrar("Mantenimiento del Motor Realizado!");
                    break;
                case 3:
                    mensajeBox.Mostrar("Se Le agrego un Turbo a tu auto!");
                    break;
                case 4:
                    mensajeBox.Mostrar("Tu Auto Quedo Reluciente!");
                    break;
                case 5:
                    mensajeBox.Mostrar("Gomas nuevas Compradas con exito!");
                    break;
                case 6:
                    mensajeBox.Mostrar("Tanque Lleno!");
                    break;
            }

        }
        private void SonidosMecanico(int numero)
        {
            Cursor.Hide();
            sonido = numero;
            timerCompra.Enabled = true;
            timerCompra.Interval = 700;
        }

        //CONFIGURACION DEL VISUALIZADOR DE DINERO
        bool DineroVer = false;
        Point originalLocation;
        private void DineroPb_Click(object sender, EventArgs e)
        {
            if (!DineroVer)
            {
                if (!banderaSize)
                {
                    originalLocation = DineroPb.Location;
                    DineroPb.Location = new Point(585, 675);
                    DineroMostrarLabel.Visible = true;
                    DineroVer = true;
                }
                else
                {
                    originalLocation = DineroPb.Location;
                    DineroPb.Location = new Point(603, 720);
                    DineroMostrarLabel.Location = new Point(640, 722);
                    DineroMostrarLabel.Visible = true;
                    DineroVer = true;
                }

            }
            else
            {
                DineroPb.Location = originalLocation;
                DineroMostrarLabel.Visible = false;
                DineroVer = false;
            }
        }

        //DATETIMEMANAGER, 
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (fechaAux.FechaManager.Month != CambioMes.Month)
            {
                Alquilando = false;
                NegocioBaseDatos negocioAlquilerManager = new NegocioBaseDatos();
                negocioAlquilerManager.ActualizarAlquilando(Alquilando);
                CambioMes = fechaAux.FechaManager;
                mensajeBox.Mostrar("Cambio El Mes, Necesitas renovar el Alquiler");
                listaAlquiler = negocioAlquiler.DevolverAlquiler(true, CasaAlquilada);
                Ocultar();
                OcultarEconomia();
                OcultarHistorial();
                OcultarPaneles();
                VolverBoton.Visible = false;
                BuscarRegistroBoton.Visible = false;
                estadoFacturas = false;
                estadoComida = false;
                higieneManager++;
                negocioHigiene.ActualizarHigieneManager(higieneManager);
                negocioAlquilerManager.ActualizarFactura(estadoFacturas);
                negocioAlquilerManager.ActualizarComida(estadoComida);
                PaginaUnoAlquiler();
            }
            else if (fechaAux.FechaManager.Year != CambioMes.Year)
            {
                mensajeBox.Mostrar("Necesita  Abonar su seguro Anual! Sino sin seguro ante destruccion del auto no percibira dinero");
                estadoSeguro = false;
                NegocioBaseDatos negocioSeguro = new NegocioBaseDatos();
                negocioSeguro.UpdateSeguro(estadoSeguro);
            }
        }

        // Carga De elementos
        int modoDesarrollador = 0;
        bool bdHumilde = true;
        private void CargaPistasAutosPilotosEconomia_Click(object sender, EventArgs e)
        {
            if (modoDesarrollador == 4)
            {
                try
                {
                    if (bdHumilde)
                    {
                        mensajeBox.Mostrar("Desbloqueo el Modo Developer");
                        bdHumilde = false;
                    }
                    if (PistaPictureBox.Visible == true)
                    {
                        CargaPista ventanaPistas = new CargaPista();
                        ventanaPistas.ShowDialog();
                        listaPistas = negocioBD.DevolverPistas();
                        CargaBasePistas();
                    }

                    else if (AutosPictureBox.Visible == true)
                    {

                        CargaAutos ventanaAutos = new CargaAutos();
                        ventanaAutos.ShowDialog();
                        negocioBDAutos = new NegocioBaseDatos();
                        listaAutos = negocioBDAutos.DevolverAutos();
                        CargarAutos();
                    }

                    else if (PilotosPictureBox.Visible == true)
                    {
                        CargaPilotos ventanaPistas = new CargaPilotos();
                        ventanaPistas.ShowDialog();
                        listaPilotos = negocioBDPilotos.DevolverPilotos();
                        CargaPilotos();
                    }

                    else if (ShopPanel1.Visible == true)
                    {
                        CargarProductos ventanaProductos = new CargarProductos();
                        ventanaProductos.Show();
                    }
                    else if (alquileres1.Visible == true)
                    {
                        CargaAlquileres ventanaAlquiler = new CargaAlquileres();
                        ventanaAlquiler.Show();
                    }
                    else if (FLabel.Visible == true)
                    {
                        CargaMarca ventanaMarca = new CargaMarca();
                        ventanaMarca.ShowDialog();
                    }
                    else
                    {
                        CargarMusica ventanaMusica = new CargarMusica();
                        ventanaMusica.ShowDialog();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error en la Carga, Revisa los datos");
                }

            }
            else
                modoDesarrollador++;
        }
        //Filtrar
        private void FiltrarPilotosPistasAutos_Click(object sender, EventArgs e)
        {
            if (PistaPictureBox.Visible == true)
            {
                FiltroPistas filtroPistas = new FiltroPistas
                {
                    Verificador = 1
                };
                filtroPistas.ShowDialog();
                if (filtroPistas.Bandera)
                {
                    imagen = 1;
                    //CargaPistasAutosPilotosEconomia.Visible = true;
                    NombreCircuito.Text = filtroPistas.PistaFiltrada.NombrePista;
                    PistaPictureBox.Load(filtroPistas.PistaFiltrada.Imagenes);
                    DistanciaTextbox.Text = "Distancia: " + filtroPistas.PistaFiltrada.Distancia;
                    PaisTextBox.Text = "Pais: " + filtroPistas.PistaFiltrada.Pais;
                    ModalidadTextBox.Text = "Modalidad: " + filtroPistas.PistaFiltrada.ModalidadPreferida;
                    PistasBiografia.Text = filtroPistas.PistaFiltrada.BiografiaPista;
                    indexPistas = filtroPistas.PistaFiltrada.Combo;
                }
            }

            else if (AutosPictureBox.Visible == true)
            {
                FiltroPistas filtroAutos = new FiltroPistas
                {
                    Verificador = 2
                };
                filtroAutos.ShowDialog();
                if (filtroAutos.Bandera)
                {
                    contadorImagenAuto = 0;
                    indexAutos = filtroAutos.AutoFiltrado.Combo;
                    negocioBDAutos = new NegocioBaseDatos();
                    NombreAutoTextbox.Text = filtroAutos.AutoFiltrado.NombreModelo;
                    AutosPictureBox.Load(filtroAutos.AutoFiltrado.ImagenAuto);
                    MarcaPictureBox.Load(filtroAutos.AutoFiltrado.MarcaAuto.ImagenMarca);
                    BanderasPictureBox.Load(filtroAutos.AutoFiltrado.PaisFabricacion);
                    YearLabel.Text = filtroAutos.AutoFiltrado.Anio.ToString();
                    NmLabel.Text = filtroAutos.AutoFiltrado.Torque.ToString() + "  Nm";
                    HpLabel.Text = filtroAutos.AutoFiltrado.HP.ToString() + "  Hp";
                    KgLabel.Text = filtroAutos.AutoFiltrado.Peso.ToString() + "  Kg";
                    string formato = "0.00";
                    KgHp.Text = filtroAutos.AutoFiltrado.RelacionPesoPotencia.ToString(formato) + "  Kg/Hp";
                    TopLabel.Text = filtroAutos.AutoFiltrado.TopSpeed.ToString() + "  Km/H";
                    KmLabel.Text = filtroAutos.AutoFiltrado.Kilometraje.ToString() + "  Km";
                    CatLabel.Text = filtroAutos.AutoFiltrado.Categoria;
                    PilotoNameAuto.Text = filtroAutos.AutoFiltrado.Piloto;
                }
            }

            else if (BiografiaPilotosTextBox.Visible == true)
            {
                FiltroPistas filtroPilotos = new FiltroPistas
                {
                    Verificador = 3
                };
                filtroPilotos.ShowDialog();
                if (filtroPilotos.Bandera)
                {
                    contadorImagenes = 0;
                    indexPilotos = filtroPilotos.PilotoFiltrado.Combo;
                    PilotosPictureBox.Load(filtroPilotos.PilotoFiltrado.Foto);
                    BiografiaPilotosTextBox.Text = filtroPilotos.PilotoFiltrado.Biografia;
                    AutoPilotoPictureBox.Load(filtroPilotos.PilotoFiltrado.Auto);
                    PaisPictureBox.Load(filtroPilotos.PilotoFiltrado.Nacionalidad);
                    if (filtroPilotos.PilotoFiltrado.Cornering < 10)
                        Cornering.Location = new Point(53, 42);
                    Cornering.Text = filtroPilotos.PilotoFiltrado.Cornering.ToString();
                    if (filtroPilotos.PilotoFiltrado.Braking < 10)
                        Braking.Location = new Point(163, 42);
                    Braking.Text = filtroPilotos.PilotoFiltrado.Braking.ToString();
                    if (filtroPilotos.PilotoFiltrado.Reflexes < 10)
                        Reflexes.Location = new Point(270, 42);
                    Reflexes.Text = filtroPilotos.PilotoFiltrado.Reflexes.ToString();
                    if (filtroPilotos.PilotoFiltrado.ManejoPresion < 10)
                        Pressure.Location = new Point(53, 149);
                    Pressure.Text = filtroPilotos.PilotoFiltrado.ManejoPresion.ToString();
                    if (filtroPilotos.PilotoFiltrado.Experiencia < 10)
                        Experience.Location = new Point(163, 149);
                    Experience.Text = filtroPilotos.PilotoFiltrado.Experiencia.ToString();
                    if (filtroPilotos.PilotoFiltrado.Pace < 10)
                        Pace.Location = new Point(270, 149);
                    Pace.Text = filtroPilotos.PilotoFiltrado.Pace.ToString();
                    if (filtroPilotos.PilotoFiltrado.TyresManagement < 10)
                        Tyres.Location = new Point(55, 255);
                    Tyres.Text = filtroPilotos.PilotoFiltrado.TyresManagement.ToString();
                    if (filtroPilotos.PilotoFiltrado.Agresividad < 10)
                        Agressiveness.Location = new Point(163, 255);
                    Agressiveness.Text = filtroPilotos.PilotoFiltrado.Agresividad.ToString();
                    if (filtroPilotos.PilotoFiltrado.Overtaking < 10)
                        Overtaking.Location = new Point(270, 255);
                    Overtaking.Text = filtroPilotos.PilotoFiltrado.Overtaking.ToString();
                    if (filtroPilotos.PilotoFiltrado.Concentracion < 10)
                        Concentration.Location = new Point(53, 354);
                    Concentration.Text = filtroPilotos.PilotoFiltrado.Concentracion.ToString();
                    if (filtroPilotos.PilotoFiltrado.RainHability < 10)
                        Rain.Location = new Point(166, 354);
                    Rain.Text = filtroPilotos.PilotoFiltrado.RainHability.ToString();
                    if (filtroPilotos.PilotoFiltrado.Defending < 10)
                        Defending.Location = new Point(270, 354);
                    Defending.Text = filtroPilotos.PilotoFiltrado.Defending.ToString();
                    if (filtroPilotos.PilotoFiltrado.Overall < 10)
                        Overall.Location = new Point(0, 0);
                    Overall.Text = filtroPilotos.PilotoFiltrado.Overall.ToString();
                    NombrePilotoTextBox.Text = filtroPilotos.PilotoFiltrado.NombrePiloto;
                    ApodoTextBox.Text = filtroPilotos.PilotoFiltrado.Apodo;
                    EquipoTextBox.Text = filtroPilotos.PilotoFiltrado.Equipo;
                    RivalTextBox.Text = filtroPilotos.PilotoFiltrado.Rival;
                    EdadTextBox.Text = filtroPilotos.PilotoFiltrado.Edad.ToString();
                    AlturaTextBox.Text = filtroPilotos.PilotoFiltrado.Altura;
                    PesoTextBox.Text = filtroPilotos.PilotoFiltrado.Peso;
                    VictoriaTextBox.Text = filtroPilotos.PilotoFiltrado.Victorias.ToString();
                    DerrotaTextBox.Text = filtroPilotos.PilotoFiltrado.Derrotas.ToString();
                    string formatin = "0.0";
                    WinRateTextBox.Text = filtroPilotos.PilotoFiltrado.PorcentajeCarrerasGanadas.ToString(formatin) + "%";
                    int aux = filtroPilotos.PilotoFiltrado.Victorias + filtroPilotos.PilotoFiltrado.Derrotas;
                    TotalTextBox.Text = aux.ToString();
                }
                

            }
        }
        //Falta la configuracion de la pagina y subirla al Hosting 4.12
        private void CarDealerPictureBox_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:9095/";
            System.Diagnostics.Process.Start(url);
        }

        //Update
        int modoDesarrolladorUp = 0;
        bool listoPapa = true;
        private void UpdateBoton_Click(object sender, EventArgs e)
        {
            if (modoDesarrolladorUp >= 4)
            {
                if (listoPapa)
                {
                    mensajeBox.Mostrar("Modo Desarrolador Activado");
                    listoPapa = false;
                }

                if (PistaPictureBox.Visible)
                {
                    CargaPista ventanaPistas = new CargaPista(listaPistas[indexPistas]);
                    ventanaPistas.ShowDialog();
                    listaPistas = negocioBD.DevolverPistas();
                    CargaBasePistas();
                }
                else if (AutosPictureBox.Visible == true)
                {
                    CargaAutos ventanaAutos = new CargaAutos(listaAutos[indexAutos]);
                    ventanaAutos.ShowDialog();
                    listaAutos = negocioBDAutos.DevolverAutos();
                    CargarAutos();
                }

                else if (PilotosPictureBox.Visible == true)
                {
                    CargaPilotos ventanaPilotos = new CargaPilotos(listaPilotos[indexPilotos]);
                    ventanaPilotos.ShowDialog();
                    listaPilotos = negocioBDPilotos.DevolverPilotos();
                    CargaPilotos();
                }
            }
            else
            {
                modoDesarrolladorUp++;
            }
        }
    }
}
