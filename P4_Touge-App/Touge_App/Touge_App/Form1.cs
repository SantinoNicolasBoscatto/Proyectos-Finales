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
        //PRECIOS
        readonly int aceite = 85;
        readonly int manMotor = 125;
        readonly int manAuto = 75;
        readonly int makeAWD = 2500;
        readonly int turbo = 5000;
        readonly int repro = 750;
        readonly int swapEngine = 0;
        readonly int reduccionWeight = 235;
        readonly int carWash = 50;
        readonly int seguro = 750;
        readonly int dryTyres = 1120;
        readonly int rainTyres = 1260;
        readonly int vinilos = 35;
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
        string Player = "Santino Boscatto";
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
                NombrePilotoLabel.Parent = FichaTecnicaPb;
                NombrePilotoLabel.Location = new Point(8, 535);
                DineroPb.Location = new Point(670, 722);
                BackEconomia.Location = new Point(0, 338);
                NextEconomia.Location = new Point(1311, 338);
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
        
        //CARGA DEL FORMS
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
            ShopPanel1.ButtonClick += ShopPanel1_ButtonClick; ShopPanel2.ButtonClick += ShopPanel2_ButtonClick; ShopPanel3.ButtonClick += ShopPanel3_ButtonClick; ShopPanel4.ButtonClick += ShopPanel4_ButtonClick; ShopPanel5.ButtonClick += ShopPanel5_ButtonClick; ShopPanel6.ButtonClick += ShopPanel6_ButtonClick; ShopPanel7.ButtonClick += ShopPanel7_ButtonClick;ShopPanel8.ButtonClick += ShopPanel8_ButtonClick;
            PanelComida1.ButtonClick += PanelComida1_ButtonClick;
            PanelComida2.ButtonClick += PanelComida2_ButtonClick;
            PanelComida3.ButtonClick += PanelComida3_ButtonClick;
            PanelComida4.ButtonClick += PanelComida4_ButtonClick;
            mecanico1.ButtonClick += Mecanico1_ButtonClick;
            mecanico2.ButtonClick += Mecanico2_ButtonClick;
            mecanico3.ButtonClick += Mecanico3_ButtonClick;
            mecanico4.ButtonClick += Mecanico4_ButtonClick;
            timerCompra.Tick += Timer1_Tick;
            timerCursor.Tick += Timer2_Tick;
            timerCompra.Enabled = false;
            Higiene1.ButtonClick += Higiene1_ButtonClick;
            Higiene2.ButtonClick += Higiene2_ButtonClick;
            Higiene3.ButtonClick += Higiene3_ButtonClick;
            gastosDiarios1.ButtonClick += GastosDiarios1_ButtonClick;
            gastosDiarios2.ButtonClick += GastosDiarios2_ButtonClick;
            gastosDiarios3.ButtonClick += GastosDiarios3_ButtonClick;
            gastosDiarios4.ButtonClick += GastosDiarios4_ButtonClick;
            gastosDiarios5.ButtonClick += GastosDiarios5_ButtonClick;
            gastosDiarios6.ButtonClick += GastosDiarios6_ButtonClick;
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
            if (!estadoSeguro)
            {
                MessageBox.Show("Necesita Pagar el Seguro! Si su auto se destroza no percibira nada de dinero");
            }
            if (!Alquilando)
            {
                Ocultar();
                MessageBox.Show("Debe Pagar el Alquiler Moroso!");
                PaginaUnoAlquiler();
                VolverBoton.Visible = false;
            }
            else if (!estadoFacturas)
            {
                Ocultar();
                MessageBox.Show("Debe Pagar Sus Facturas Moroso!");
                MostrarFacturas();
                VolverBoton.Visible = false;
            }
            else if(!estadoComida)
            {
                Ocultar();
                ComidaPaginaUno();
                MessageBox.Show("Debe Hacer las Compras!");
                PanelComida1.Visible = true;
                PanelComida2.Visible = true;
                PanelComida3.Visible = true;
                PanelComida4.Visible = true;
                BackComida.Visible = true;
                NextComida.Visible = true;
                VolverBoton.Visible = false;
            }
            else if (higieneManager==2)
            {
                Ocultar();
                HigienePagina();
                MessageBox.Show("Debe Pagar Sus Facturas Moroso!");
                VolverBoton.Visible = false;
            }
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
            RepintadoBotones(HoverClose, e, CloseButton);
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
            RepintadoBotones(ModalidadBd, e, ModalidadesBoton);
        }
        // Idem
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
        // Idem
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
        //PAINTS DE SUBMODULOS
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
            PilotoNameAuto.Parent = FichaTecnicaPb;
            PilotoNameAuto.Location = new Point(23, 508);
            CargaPistasAutosPilotosEconomia.Parent = PictureBoxBack;
            CargaPistasAutosPilotosEconomia.Visible = false;
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
        }

        // FUNCION PARA FORMATEAR FECHA
        private void FormatearFecha(Fecha aux)
        {
            fechaManager = DateTime.Parse(aux.FechaManager.ToString());
            Formato = fechaManager.ToString("dd/MM/yy", CultureInfo.InvariantCulture);
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
            Volumen = VolumenControl.Value/100.00f;
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
            int RandomNumero = randomFondo.Next(8);
            PictureBoxBack.BackgroundImageLayout = ImageLayout.Stretch;
            switch (RandomNumero)
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

        //FUNCIONES PARA MOSTRAR
        bool EconomiaMostrar = true;
        private void Ocultar ()
        {
            BotonPistas.Visible = false;
            PilotosBoton.Visible = false;
            ReglasBoton.Visible = false;
            EconomiaBoton.Visible = false;
            HistorialBoton.Visible = false;
            AutosBoton.Visible = false;
            CloseButton.Visible = false;
            VolverBoton.Visible = true;
            
        }
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
                CargaPistasAutosPilotosEconomia.Visible = true;
            }
            CargaBasePistas();
            
        }
        private void CargaBasePistas()
        {
            //NegocioBaseDatos negocioBd; //AsignacionCorreccion
            listaPistas = negocioBD.DevolverPistas();
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
            if (imagen==1)
            {
                PistaPictureBox.Load(listaPistas[indexPistas].Imagenes);
            }
            else if (imagen ==2)
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
                CargaPistasAutosPilotosEconomia.Visible = false;
                imagen = 1;
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
                CargaPistasAutosPilotosEconomia.Visible = false;
            }
            else if (BanderasPictureBox.Visible == true)
            {
                FichaTecnicaPb.Visible = false;
                NombreAutoTextbox.Visible = false;
                BanderasPictureBox.Visible = false;
                AutosPictureBox.Visible = false;
                NextAuto.Visible = false;
                BackAuto.Visible = false;
                CargaPistasAutosPilotosEconomia.Visible = false;
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

            else if (gastosDiarios1.Visible==true)
            {
                gastosDiarios1.Visible = false;
                gastosDiarios2.Visible = false;
                gastosDiarios3.Visible = false;
                gastosDiarios4.Visible = false;
                gastosDiarios5.Visible = false;
                gastosDiarios6.Visible = false;
                EconomiaMostrar = false;
            }

            else if (MiAutoPB.Visible==true)
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

            else if (listaMisCosas[0].Visible==true)
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
                    MisCosasPictureBox.Visible = true;
                    GarajePictureBox.Visible = true;
                    EconomiaMostrar = true;
                }
                NextEconomia.Visible = true;
                BackEconomia.Visible = true;
                banderaEconomiaParaMostrar = true;
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
            string formatin = "0.0";
            WinRateTextBox.Text = listaPilotos[indexPilotos].PorcentajeCarrerasGanadas.ToString(formatin)+"%";
            TotalTextBox.Text = listaPilotos[indexPilotos].CantidadDeCarreras.ToString();
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

        //CONFIGURACION DEL MODULO AUTOS Y SUS MANEJADORES
        int indexAutos = 0;
        int contadorImagenAuto = 0;
        private void AutosBoton_Click(object sender, EventArgs e)
        {
            Ocultar();
            CargaPistasAutosPilotosEconomia.Visible = true;
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
            string formato = "0.00";
            KgHp.Text = listaAutos[indexAutos].RelacionPesoPotencia.ToString(formato) + "  Kg/Hp";
            TopLabel.Text = listaAutos[indexAutos].TopSpeed.ToString() + "  Km/H";
            KmLabel.Text = listaAutos[indexAutos].Kilometraje.ToString() + "  Km";
            CatLabel.Text = listaAutos[indexAutos].Categoria;
            PilotoNameAuto.Text = listaAutos[indexAutos].Piloto;
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
                MessageBox.Show("No selecciono ningun registro a eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        fechaAux.FechaManager = negocioUpFecha.UpdatearFecha(5);
                        FormatearFecha(fechaAux);
                        MessageBox.Show("" + Formato);
                        NegocioBaseDatos negocioUpdateComponentes = new NegocioBaseDatos();
                        if (registroVentana.PlayerBool)
                        {
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
                            registroVentana.PlayerBool = false;
                        }

                        if (aceiteManager >= 5)
                        {
                            negocioUpdateComponentes.UpEstadoAuto(1);
                            estadoAceite = false;
                            //MessageBox.Show("Cambie Aceite");
                        }
                        if (motorManager >= 4)
                        {
                            negocioUpdateComponentes.UpEstadoAuto(2);
                            estadoMotor = false;
                            //MessageBox.Show("Cambie Motor");
                        }
                        if (autoManager >= 3)
                        {
                            negocioUpdateComponentes.UpEstadoAuto(3);
                            estadoAuto = false;
                            //MessageBox.Show("Cambie Auto");
                        }
                        if (gomasManager >= 7)
                        {
                            negocioUpdateComponentes.UpEstadoAuto(13);
                        }
                        if (gomasDeLluviaManager >= 4)
                        {
                            MessageBox.Show("Cambie gomas de lluvia!");
                        }
                        if (limpiezaManager >= 2)
                        {
                            negocioUpdateComponentes.UpEstadoAuto(12);
                            estadoLimpieza = false;
                            MessageBox.Show("Limpialo Sucio");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No tiene gomas para competir! Compre Gomas");
                }

            }
            else
            {
                MessageBox.Show("No tiene la Gasolina suficiente para correr! Vaya a cargarla");
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
                ComidaPaginaUno();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ComidaPaginaUno()
        {
            comidaManager = 1;
            PanelComida1.Titulo = ListaComida[0].NombrePack;
            PanelComida2.Titulo = ListaComida[1].NombrePack;
            PanelComida3.Titulo = ListaComida[2].NombrePack;
            PanelComida4.Titulo = ListaComida[3].NombrePack;
            PanelComida1.Id = ListaComida[0].Id;
            PanelComida2.Id = ListaComida[1].Id;
            PanelComida3.Id = ListaComida[2].Id;
            PanelComida4.Id = ListaComida[3].Id;
            PanelComida1.Comprado = ListaComida[0].Comprado;
            PanelComida2.Comprado = ListaComida[1].Comprado;
            PanelComida3.Comprado = ListaComida[2].Comprado;
            PanelComida4.Comprado = ListaComida[3].Comprado;
            PanelComida1.Precio = "$ "+ (ListaComida[0].Precio-1).ToString() +".99";
            PanelComida2.Precio = "$ " + (ListaComida[1].Precio - 1).ToString() + ".99";
            PanelComida3.Precio = "$ " + (ListaComida[2].Precio - 1).ToString() + ".99";
            PanelComida4.Precio = "$ " + (ListaComida[3].Precio - 1).ToString() + ".99";
            PanelComida1.CargarImagenes(ListaComida[0].Imagen);
            PanelComida2.CargarImagenes(ListaComida[1].Imagen);
            PanelComida3.CargarImagenes(ListaComida[2].Imagen);
            PanelComida4.CargarImagenes(ListaComida[3].Imagen);
            if (!ListaComida[0].Comprado)
                PanelComida1.SoldOut();
            else
                PanelComida1.OcultarSold();
            if (!ListaComida[1].Comprado)
                PanelComida2.SoldOut();
            else
                PanelComida2.OcultarSold();
            if (!ListaComida[2].Comprado)
                PanelComida3.SoldOut();
            else
                PanelComida3.OcultarSold();
            if (!ListaComida[3].Comprado)
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
        private void ComidaPaginaDos()
        {
            comidaManager = 2;
            PanelComida1.Titulo = ListaComida[4].NombrePack;
            PanelComida2.Titulo = ListaComida[5].NombrePack;
            PanelComida3.Titulo = ListaComida[6].NombrePack;
            PanelComida4.Titulo = ListaComida[7].NombrePack;
            PanelComida1.Id = ListaComida[4].Id;
            PanelComida2.Id = ListaComida[5].Id;
            PanelComida3.Id = ListaComida[6].Id;
            PanelComida4.Id = ListaComida[7].Id;
            PanelComida1.Comprado = ListaComida[4].Comprado;
            PanelComida2.Comprado = ListaComida[5].Comprado;
            PanelComida3.Comprado = ListaComida[6].Comprado;
            PanelComida4.Comprado = ListaComida[7].Comprado;
            PanelComida1.Precio = "$ " + (ListaComida[4].Precio - 1).ToString() + ".99";
            PanelComida2.Precio = "$ " + (ListaComida[5].Precio - 1).ToString() + ".99";
            PanelComida3.Precio = "$ " + (ListaComida[6].Precio - 1).ToString() + ".99";
            PanelComida4.Precio = "$ " + (ListaComida[7].Precio - 1).ToString() + ".99";
            PanelComida1.CargarImagenes(ListaComida[4].Imagen);
            PanelComida2.CargarImagenes(ListaComida[5].Imagen);
            PanelComida3.CargarImagenes(ListaComida[6].Imagen);
            PanelComida4.CargarImagenes(ListaComida[7].Imagen);
            if (!ListaComida[4].Comprado)
                PanelComida1.SoldOut();
            else
                PanelComida1.OcultarSold();
            if (!ListaComida[5].Comprado)
                PanelComida2.SoldOut();
            else
                PanelComida2.OcultarSold();
            if (!ListaComida[6].Comprado)
                PanelComida3.SoldOut();
            else
                PanelComida3.OcultarSold();
            if (!ListaComida[7].Comprado)
                PanelComida4.SoldOut();
            else
                PanelComida4.OcultarSold();
        }
        private void ComidaPaginaTres()
        {
            comidaManager = 3;
            PanelComida1.Titulo = ListaComida[8].NombrePack;
            PanelComida2.Titulo = ListaComida[9].NombrePack;
            PanelComida3.Titulo = ListaComida[10].NombrePack;
            PanelComida4.Titulo = ListaComida[11].NombrePack;
            PanelComida1.Id = ListaComida[8].Id;
            PanelComida2.Id = ListaComida[9].Id;
            PanelComida3.Id = ListaComida[10].Id;
            PanelComida4.Id = ListaComida[11].Id;
            PanelComida1.Comprado = ListaComida[8].Comprado;
            PanelComida2.Comprado = ListaComida[9].Comprado;
            PanelComida3.Comprado = ListaComida[10].Comprado;
            PanelComida4.Comprado = ListaComida[11].Comprado;
            PanelComida1.Precio = "$ " + (ListaComida[8].Precio - 1).ToString() + ".99";
            PanelComida2.Precio = "$ " + (ListaComida[9].Precio - 1).ToString() + ".99";
            PanelComida3.Precio = "$ " + (ListaComida[10].Precio - 1).ToString() + ".99";
            PanelComida4.Precio = "$ " + (ListaComida[11].Precio - 1).ToString() + ".99";
            PanelComida1.CargarImagenes(ListaComida[8].Imagen);
            PanelComida2.CargarImagenes(ListaComida[9].Imagen);
            PanelComida3.CargarImagenes(ListaComida[10].Imagen);
            PanelComida4.CargarImagenes(ListaComida[11].Imagen);
            if (!ListaComida[8].Comprado)
                PanelComida1.SoldOut();
            else
                PanelComida1.OcultarSold();
            if (!ListaComida[9].Comprado)
                PanelComida2.SoldOut();
            else
                PanelComida2.OcultarSold();
            if (!ListaComida[10].Comprado)
                PanelComida3.SoldOut();
            else
                PanelComida3.OcultarSold();
            if (!ListaComida[11].Comprado)
                PanelComida4.SoldOut();
            else
                PanelComida4.OcultarSold();
        }
        int contadorPagComida = 0;
        private void NextComida_Click(object sender, EventArgs e)
        {
            contadorPagComida++;
            if (contadorPagComida == 1)
            {
                ComidaPaginaDos();
            }
            else if (contadorPagComida == 2)
            {
                ComidaPaginaTres();
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
                ComidaPaginaDos();
            }
            else if (contadorPagComida == 0)
            {
                ComidaPaginaUno();
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
                if (miDinero.MiDinero - negocioPago.PagoArticulos(PanelComida1.Id, 4) > 0)
                {
                    miDinero.MiDinero -= negocioPago.PagoArticulos(PanelComida1.Id, 4);
                    negocioPago.ActualizarDinero(miDinero.MiDinero);
                    estadoComida = true;
                    negocioPago.ActualizarComida(estadoComida);
                    plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                    DineroMostrarLabel.Text = plataFormato;
                    fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                    FormatearFecha(fechaAux);
                    MessageBox.Show("" + Formato);
                    VolverBoton.Visible = true;
                    CloseButton.Visible = false;
                    PanelComida1.SoldOut();
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
                        MessageBox.Show("Debe Comprar Las Cosas de Higiene!");
                        VolverBoton.Visible = false;
                    }
                }
                else
                    MessageBox.Show("No tiene dinero para Comprar este producto.");
            }
            else
                MessageBox.Show("Usted ya realizo la compra mensual! Espere al proximo mes para volver a comprar.");
        }
        private void PanelComida2_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (!estadoComida)
            {
                if (miDinero.MiDinero - negocioPago.PagoArticulos(PanelComida2.Id, 4) > 0)
                {
                    miDinero.MiDinero -= negocioPago.PagoArticulos(PanelComida2.Id, 4);
                    negocioPago.ActualizarDinero(miDinero.MiDinero);
                    estadoComida = true;
                    negocioPago.ActualizarComida(estadoComida);
                    plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                    DineroMostrarLabel.Text = plataFormato;
                    fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                    FormatearFecha(fechaAux);
                    MessageBox.Show("" + Formato);
                    VolverBoton.Visible = true;
                    PanelComida2.SoldOut();
                    switch (comidaManager)
                    {
                        case 1:
                            ListaComida[1].Comprado = false;
                            break;
                        case 2:
                            ListaComida[5].Comprado = false;
                            break;
                        case 3:
                            ListaComida[9].Comprado = false;
                            break;
                        default:
                            break;
                    }
                    if (higieneManager == 2)
                    {
                        OcultarComida();
                        HigienePagina();
                        MessageBox.Show("Debe Pagar Sus Facturas Moroso!");
                        VolverBoton.Visible = false;
                    }
                }
                else
                    MessageBox.Show("No tiene dinero para Comprar este producto.");
            }
            else
                MessageBox.Show("Usted ya realizo la compra mensual! Espere al proximo mes para volver a comprar.");
        }
        private void PanelComida3_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (!estadoComida)
            {
                if (miDinero.MiDinero - negocioPago.PagoArticulos(PanelComida3.Id, 4) > 0)
                {
                    miDinero.MiDinero -= negocioPago.PagoArticulos(PanelComida3.Id, 4);
                    negocioPago.ActualizarDinero(miDinero.MiDinero);
                    estadoComida = true;
                    negocioPago.ActualizarComida(estadoComida);
                    plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                    DineroMostrarLabel.Text = plataFormato; ;
                    fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                    FormatearFecha(fechaAux);
                    MessageBox.Show("" + Formato);
                    VolverBoton.Visible = true;
                    PanelComida3.SoldOut();
                    switch (comidaManager)
                    {
                        case 1:
                            ListaComida[2].Comprado = false;
                            break;
                        case 2:
                            ListaComida[6].Comprado = false;
                            break;
                        case 3:
                            ListaComida[10].Comprado = false;
                            break;
                        default:
                            break;
                    }
                    if (higieneManager == 2)
                    {
                        OcultarComida();
                        HigienePagina();
                        MessageBox.Show("Debe Pagar Sus Facturas Moroso!");
                        VolverBoton.Visible = false;
                    }
                }
                else
                    MessageBox.Show("No tiene dinero para Comprar este producto.");
            }
            else
                MessageBox.Show("Usted ya realizo la compra mensual! Espere al proximo mes para volver a comprar.");
        }
        private void PanelComida4_ButtonClick(object sender, EventArgs e)
        {
            NegocioBaseDatos negocioPago = new NegocioBaseDatos();
            if (!estadoComida)
            {
                if (miDinero.MiDinero - negocioPago.PagoArticulos(PanelComida4.Id, 4) > 0)
                {
                    miDinero.MiDinero -= negocioPago.PagoArticulos(PanelComida4.Id, 4);
                    negocioPago.ActualizarDinero(miDinero.MiDinero);
                    estadoComida = true;
                    negocioPago.ActualizarComida(estadoComida);
                    plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                    DineroMostrarLabel.Text = plataFormato;
                    fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                    FormatearFecha(fechaAux);
                    MessageBox.Show("" + Formato);
                    VolverBoton.Visible = true;
                    PanelComida4.SoldOut();
                    switch (comidaManager)
                    {
                        case 1:
                            ListaComida[3].Comprado = false;
                            break;
                        case 2:
                            ListaComida[7].Comprado = false;
                            break;
                        case 3:
                            ListaComida[11].Comprado = false;
                            break;
                        default:
                            break;
                    }
                    if (higieneManager == 2)
                    {
                        OcultarComida();
                        HigienePagina();
                        MessageBox.Show("Debe Pagar Sus Facturas Moroso!");
                        VolverBoton.Visible = false;
                    }
                }
                else
                    MessageBox.Show("No tiene dinero para Comprar este producto.");
            }
            else
                MessageBox.Show("Usted ya realizo la compra mensual! Espere al proximo mes para volver a comprar..");

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
                MessageBox.Show("" + Formato);
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
                MessageBox.Show("" + Formato);
                compraSonido.Dispose();
                if (!estadoFacturas)
                {
                    alquileres1.Visible = false;
                    alquileres2.Visible = false;
                    VolverAlquiler.Visible = false;
                    SiguienteAlquiler.Visible = false;
                    VolverBoton.Visible = false;
                    MostrarFacturas();
                    MessageBox.Show("Necesita abonar los servicios del mes!");
                }
            }
            else
            {
                MessageBox.Show("No tiene dinero para pagar el alquiler, si no puede renovar el alquiler Pierde el juego");
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
            DialogResult resultado = MessageBox.Show("¿Desea Pagar estos servicios?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == resultado)
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
                            if (!estadoComida)
                            {
                                MessageBox.Show("Debe Realizar la compra Mensual!");
                                OcultarEconomia();
                                Servicios1.Visible = false;
                                Servicios2.Visible = false;
                                Servicios3.Visible = false;
                                Servicios4.Visible = false;
                                Servicios5.Visible = false;
                                AbonarFacturas.Visible = false;
                                PagoLabel.Visible = false;
                                ComidaPaginaUno();
                            }
                            else
                                VolverBoton.Visible = true;
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
                            compraSonido.Play();
                            miDinero.MiDinero -= 100;
                            negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero);
                            estadoFacturas = true;
                            negocioPagarfacturas.ActualizarFactura(estadoFacturas);
                            plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                            DineroMostrarLabel.Text = plataFormato;
                            compraSonido.Dispose();
                            if (!estadoComida)
                            {
                                MessageBox.Show("Debe Realizar la compra Mensual!");
                                OcultarEconomia();
                                Servicios1.Visible = false;
                                Servicios2.Visible = false;
                                Servicios3.Visible = false;
                                Servicios4.Visible = false;
                                Servicios5.Visible = false;
                                AbonarFacturas.Visible = false;
                                PagoLabel.Visible = false;
                                ComidaPaginaUno();
                            }
                            else
                                VolverBoton.Visible = true;
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
                            compraSonido.Play();
                            miDinero.MiDinero -= 125;
                            negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero);
                            estadoFacturas = true;
                            negocioPagarfacturas.ActualizarFactura(estadoFacturas);
                            plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                            DineroMostrarLabel.Text = plataFormato;
                            compraSonido.Dispose();
                            if (!estadoComida)
                            {
                                MessageBox.Show("Debe Realizar la compra Mensual!");
                                OcultarEconomia();
                                Servicios1.Visible = false;
                                Servicios2.Visible = false;
                                Servicios3.Visible = false;
                                Servicios4.Visible = false;
                                Servicios5.Visible = false;
                                AbonarFacturas.Visible = false;
                                PagoLabel.Visible = false;
                                ComidaPaginaUno();
                            }
                            else
                                VolverBoton.Visible = true;
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
                            compraSonido.Play();
                            miDinero.MiDinero -= 150;
                            negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero);
                            estadoFacturas = true;
                            negocioPagarfacturas.ActualizarFactura(estadoFacturas);
                            plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                            DineroMostrarLabel.Text = plataFormato;
                            compraSonido.Dispose();
                            if (!estadoComida)
                            {
                                MessageBox.Show("Debe Realizar la compra Mensual!");
                                OcultarEconomia();
                                Servicios1.Visible = false;
                                Servicios2.Visible = false;
                                Servicios3.Visible = false;
                                Servicios4.Visible = false;
                                Servicios5.Visible = false;
                                AbonarFacturas.Visible = false;
                                PagoLabel.Visible = false;
                                ComidaPaginaUno();
                            }
                            else
                                VolverBoton.Visible = true;
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
                            compraSonido.Play();
                            miDinero.MiDinero -= 180;
                            negocioPagarfacturas.ActualizarDinero(miDinero.MiDinero);
                            estadoFacturas = true;
                            negocioPagarfacturas.ActualizarFactura(estadoFacturas);
                            plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                            DineroMostrarLabel.Text = plataFormato;
                            compraSonido.Dispose();
                            if (!estadoComida)
                            {
                                MessageBox.Show("Debe Realizar la compra Mensual!");
                                OcultarEconomia();
                                Servicios1.Visible = false;
                                Servicios2.Visible = false;
                                Servicios3.Visible = false;
                                Servicios4.Visible = false;
                                Servicios5.Visible = false;
                                AbonarFacturas.Visible = false;
                                PagoLabel.Visible = false;
                                ComidaPaginaUno();
                            }
                            else
                                VolverBoton.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("No tiene el suficiente dinero para abonar el esta opcion, elija una mas barata");
                        }
                    }
                }
                else
                    MessageBox.Show("Usted Ya abono los servicios este mes!");

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
                    PaginaUnoRopa();
                    MostrarShopPanels(Color.Khaki, Color.FromArgb(255, 54, 54, 54));
                    CargaPistasAutosPilotosEconomia.Visible = true;
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
        //MUEBLES
        private void MueblesPictureBox_Click(object sender, EventArgs e)
        {
            if (listaMuebles.Count >= 8)
            {
                PaginaUnoMuebles();
                MostrarShopPanels(Color.FromArgb(240, 160, 82, 45), Color.GhostWhite);
                CargaPistasAutosPilotosEconomia.Visible = true;
            }
            else
            {
                MessageBox.Show("En este momento estamos falta de Articulos! vuelva mas tarde");
            }
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
        //ELECTRO
        private void ElectroPictureBox_Click(object sender, EventArgs e)
        {
            if (listaElectro.Count >= 8)
            {
                PaginaUnoElectros();
                MostrarShopPanels(Color.FromArgb(255, 40, 89, 255), Color.GhostWhite);
                CargaPistasAutosPilotosEconomia.Visible = true;
            }
            else
            {
                MessageBox.Show("En este momento estamos falta de Articulos! vuelva mas tarde");
            }
        }
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
            if (miDinero.MiDinero - negocioPago.PagoArticulos(ShopPanel1.Id, eShopmanager) > 0)
            {
                miDinero.MiDinero -= negocioPago.PagoArticulos(ShopPanel1.Id, eShopmanager);
                negocioPago.ActualizarDinero(miDinero.MiDinero);
                compraSonido.Play();
                negocioPago.DeshabilitarArticulo(ShopPanel1.Id, eShopmanager);
                //MessageBox.Show("Articulo Comprado con exito! " + miDinero.MiDinero + " USD");
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato;
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel1.SoldOut();
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
                compraSonido.Play();
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato;
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel2.SoldOut();
                compraSonido.Dispose();
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
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                compraSonido.Play();
                DineroMostrarLabel.Text = plataFormato;
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel3.SoldOut();
                compraSonido.Dispose();
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
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                compraSonido.Play();
                DineroMostrarLabel.Text = plataFormato;
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel4.SoldOut();
                compraSonido.Dispose();
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
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                compraSonido.Play();
                DineroMostrarLabel.Text = plataFormato;
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel5.SoldOut();
                compraSonido.Dispose();
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
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                compraSonido.Play();
                DineroMostrarLabel.Text = plataFormato;
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel6.SoldOut();
                compraSonido.Dispose();
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
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                compraSonido.Play();
                DineroMostrarLabel.Text = plataFormato;
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel7.SoldOut();
                compraSonido.Dispose();
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
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                compraSonido.Play();
                DineroMostrarLabel.Text = plataFormato;
                fechaAux.FechaManager = negocioPago.UpdatearFecha(1);
                FormatearFecha(fechaAux);
                MessageBox.Show("" + Formato);
                ShopPanel8.SoldOut();
                compraSonido.Dispose();
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
            Higiene1.NombreProducto = ListaHigiene[0].NombrePack;
            Higiene2.NombreProducto = ListaHigiene[1].NombrePack;
            Higiene3.NombreProducto = ListaHigiene[2].NombrePack;
            Higiene1.Id = ListaHigiene[0].Id;
            Higiene2.Id = ListaHigiene[1].Id;
            Higiene3.Id = ListaHigiene[2].Id;
            Higiene1.Comprado = ListaHigiene[0].Comprado;
            Higiene2.Comprado = ListaHigiene[1].Comprado;
            Higiene3.Comprado = ListaHigiene[2].Comprado;
            Higiene1.Precio = "$ " + (ListaHigiene[0].Precio - 1).ToString() + ".99";
            Higiene2.Precio = "$ " + (ListaHigiene[1].Precio - 1).ToString() + ".99";
            Higiene3.Precio = "$ " + (ListaHigiene[2].Precio - 1).ToString() + ".99";
            Higiene1.CargarImagenes(ListaHigiene[0].Imagen);
            Higiene2.CargarImagenes(ListaHigiene[1].Imagen);
            Higiene3.CargarImagenes(ListaHigiene[2].Imagen);
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
                    MessageBox.Show("" + Formato);
                    VolverBoton.Visible = true;
                    Higiene1.SoldOut();
                }
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
                    MessageBox.Show("" + Formato);
                    VolverBoton.Visible = true;
                    Higiene2.SoldOut();
                }
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
                    MessageBox.Show("" + Formato);
                    VolverBoton.Visible = true;
                    Higiene3.SoldOut();
                }
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
            mecanico1.Precio = string.Format("$ {0:N0}", aceite);
            mecanico2.Precio = string.Format("$ {0:N0}", manAuto);
            mecanico3.Precio = string.Format("$ {0:N0}", manMotor);
            mecanico4.Precio = string.Format("$ {0:N0}", reduccionWeight);
            if (mecanico1.Visible==false)
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
            mecanico1.Precio = string.Format("$ {0:N0}", repro);
            mecanico2.Precio = string.Format("$ {0:N0}", turbo);
            mecanico3.Precio = string.Format("$ {0:N0}", makeAWD);
            mecanico4.Precio = string.Format("$ {0:N0}", swapEngine);
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
                if (miDinero.MiDinero - aceite > 0)
                {
                    if (!estadoAceite)
                    {
                        compraSonido.Play();
                        estadoAceite = true;
                        NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                        negocioMecanico.UpEstadoAuto(7);
                        miDinero.MiDinero -= aceite;
                        SonidosMecanico(1);
                        negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                        plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                        DineroMostrarLabel.Text = plataFormato;
                        compraSonido.Dispose();
                        aceiteManager = 0;
                        negocioMecanico.UpdatearComponentes(aceiteManager, motorManager, autoManager, gomasManager, gomasDeLluviaManager, limpiezaManager);
                        //MessageBox.Show("" + MiAuto.HP);
                    }
                    else
                        MessageBox.Show("El Mecanico dice que tu aceite esta correcto por ahora y no requiere cambiarlo!");
                }
                else
                {
                    MessageBox.Show("No tiene el suficiente dinero Para Hacer el cambio de Aceite");
                }
            }
            else
            {
                if (miDinero.MiDinero - repro > 0)
                {

                    if (!estadoRepro)
                    {
                        estadoRepro = true;
                        compraSonido.Play();
                        NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                        negocioMecanico.UpEstadoAuto(4);
                        miDinero.MiDinero -= repro;
                        negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                        negocioMecanico.UpPesoPotencia();
                        plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                        DineroMostrarLabel.Text = plataFormato;
                        MiAuto = negocioMecanico.DevolverMiAuto();
                        compraSonido.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Tu Vehiculo ya tiene una Repro!");
                    }
                }
                else
                {
                    MessageBox.Show("No tiene el suficiente dinero Para Hacerle Una Repro al auto");
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
                if (miDinero.MiDinero - manAuto > 0)
                {
                    if (!estadoAuto)
                    {
                        estadoAuto = true;
                        compraSonido.Play();
                        NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                        miDinero.MiDinero -= manAuto;
                        negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                        negocioMecanico.UpEstadoAuto(9);
                        plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                        DineroMostrarLabel.Text = plataFormato;
                        compraSonido.Dispose();
                        autoManager = 0;
                        negocioMecanico.UpdatearComponentes(aceiteManager, motorManager, autoManager, gomasManager, gomasDeLluviaManager, limpiezaManager);
                    }
                    else
                        MessageBox.Show("El Mecanico esta muy Ocupado! Vuelve otro dia");

                }
                else
                {
                    MessageBox.Show("No tiene el suficiente dinero Para Hacer Mantenimiento del Auto");
                }
            }
            else
            {
                if (miDinero.MiDinero - turbo > 0)
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
                        miDinero.MiDinero -= turbo;
                        negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                        plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                        DineroMostrarLabel.Text = plataFormato;
                        compraSonido.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Tu Vehiculo ya tiene un Turbo!");
                    }
                }
                else
                {
                    MessageBox.Show("No tiene el suficiente dinero Para Colocarle un turbo al Auto");
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
                if (miDinero.MiDinero - manMotor > 0)
                {
                    if (!estadoMotor)
                    {
                        estadoMotor = true;
                        compraSonido.Play();
                        NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                        miDinero.MiDinero -= manMotor;
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
                        MessageBox.Show("El Mecanico dice que tu motor esta bien, no le hace falta mantenimiento");
                }
                else
                {
                    MessageBox.Show("No tiene el suficiente dinero Para Hacer Mantenimiento del Motor");
                }
            }
            else
            {
                if (miDinero.MiDinero - makeAWD > 0)
                {
                    if (!estadoAWD && MiAuto.Traccion != "AWD")
                    {
                        estadoAWD = true;
                        compraSonido.Play();
                        NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                        negocioMecanico.UpEstadoAuto(6);
                        negocioMecanico.UpdateMiAuto("AWD", 2);
                        miDinero.MiDinero -= makeAWD;
                        negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                        plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                        DineroMostrarLabel.Text = plataFormato;
                        MiAuto = negocioMecanico.DevolverMiAuto();
                        compraSonido.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Tu Vehiculo ya Es AWD!");
                    }
                }
                else
                {
                    MessageBox.Show("No tiene el suficiente dinero Para realizarle la modficicacion AWD al auto");
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
                if (miDinero.MiDinero - reduccionWeight > 0)
                {
                    compraSonido.Play();
                    NegocioBaseDatos negocioMecanico = new NegocioBaseDatos();
                    miDinero.MiDinero -= reduccionWeight;
                    negocioMecanico.ActualizarDinero(miDinero.MiDinero);
                    negocioMecanico.UpEstadoAuto(11, MiAuto.Peso);
                    negocioMecanico.UpPesoPotencia();
                    plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                    DineroMostrarLabel.Text = plataFormato;

                    compraSonido.Dispose();
                }
                else
                {
                    MessageBox.Show("No tiene el suficiente dinero Para Hacer una Reduccion de Peso");
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
            gastosDiarios1.Precio = string.Format("$ {0:N0}", carWash);
            gastosDiarios2.Precio = "$2,5 C/L";
            gastosDiarios3.Precio = string.Format("$ {0:N0}", dryTyres);
            gastosDiarios4.Precio = string.Format("$ {0:N0}", rainTyres);
            gastosDiarios5.Precio = string.Format("$ {0:N0}", seguro);
            gastosDiarios6.Precio = string.Format("$ {0:N0}", vinilos);
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
            if (miDinero.MiDinero - carWash >= 0)
            {
                compraSonido.Play();
                SonidosMecanico(4);
                NegocioBaseDatos negocioGastos = new NegocioBaseDatos();
                negocioGastos.UpEstadoAuto(12, 0, true);
                miDinero.MiDinero -= carWash;
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
                MessageBox.Show("No tiene el suficiente dinero Para Lavar tu auto");
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
                MessageBox.Show("Tiene Tanque Lleno, no hace falta recargar");
            }
        }
        private void GastosDiarios3_ButtonClick(object sender, EventArgs e)
        {
            if (miDinero.MiDinero - dryTyres >= 0)
            {
                compraSonido.Play();
                SonidosMecanico(5);
                NegocioBaseDatos negocioGastos = new NegocioBaseDatos();
                negocioGastos.UpEstadoAuto(14);
                miDinero.MiDinero -= dryTyres;
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
            if (miDinero.MiDinero - rainTyres >= 0)
            {
                compraSonido.Play();
                SonidosMecanico(5);
                NegocioBaseDatos negocioGastos = new NegocioBaseDatos();
                negocioGastos.UpEstadoAuto(16);
                miDinero.MiDinero -= rainTyres;
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
            if (miDinero.MiDinero - seguro >= 0)
            {
                compraSonido.Play();
                NegocioBaseDatos negocioGastos = new NegocioBaseDatos();
                negocioGastos.UpdateSeguro(true);
                miDinero.MiDinero -= seguro;
                negocioGastos.ActualizarDinero(miDinero.MiDinero);
                plataFormato = string.Format("$ {0:N0}", miDinero.MiDinero);
                DineroMostrarLabel.Text = plataFormato;
                compraSonido.Dispose();
            }
        }
        private void GastosDiarios6_ButtonClick(object sender, EventArgs e)
        {
            if (miDinero.MiDinero - vinilos >= 0)
            {
                compraSonido.Play();
                NegocioBaseDatos negocioGastos = new NegocioBaseDatos();
                negocioGastos.Vinilos();
                miDinero.MiDinero -= vinilos;
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
            if (myCar.Aceite)
            {
                AceiteMiAuto2.Text = "OK";
                AceiteMiAuto2.ForeColor = Color.LimeGreen;
            }
            if (myCar.Motor)
            {
                MotorMiAuto2.Text = "OK";
                MotorMiAuto2.ForeColor = Color.LimeGreen;
            }
            if (myCar.Mantenimiento)
            {
                MantMiAuto2.Text = "OK";
                MantMiAuto2.ForeColor = Color.LimeGreen;
            }
            if (!myCar.Lavado)
            {
                LimpMiAuto2.Text = "Limpio";
                LimpMiAuto2.ForeColor = Color.SpringGreen;
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
            if (listaObjetosAux==null)
            {
                listaObjetosAux = new List<MisObjetos>();
                conexionObjetos.CargarListasAuxiliares(ref listaObjetosAux);
            }
            listaMisCosas = CrearObjetos();
            if (listaMisCosas.Count > 0)
            {
                try
                {
                    OcultarEconomia();
                    NextObjeto.Visible = true;
                    BackObjeto.Visible = true;
                    PaginaUno();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                MessageBox.Show("No Tienes Objetos");
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
                    PaginaDos();
                    break;
                case 3:
                    PaginaTres();
                    break;
                case 4:
                    PaginaCuatro();
                    break;
                case 5:
                    PaginaCinco();
                    break;
                case 6:
                    PaginaSeis();
                    break;
                case 7:
                    PaginaSiete();
                    break;
                case 8:
                    PaginaOcho();
                    break;
                case 9:
                    PaginaNueve();
                    break;
                case 10:
                    PaginaDiez();
                    break;
                case 11:
                    PaginaOnce();
                    break;
                case 12:
                    PaginaDoce();
                    break;
                case 13:
                    PaginaTrece();
                    break;
                case 14:
                    PaginaCatorce();
                    break;
                case 15:
                    PaginaQuince();
                    break;
                case 16:
                    PaginaDieciseis();
                    break;
                case 17:
                    PaginaDiecisiete();
                    break;
                case 18:
                    PaginaDieciocho();
                    break;
                case 19:
                    PaginaDiecinueve();
                    break;
                case 20:
                    PaginaVeinte();
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
                    PaginaUno();
                    break;
                case 2:
                    PaginaDos();
                    break;
                case 3:
                    PaginaTres();
                    break;
                case 4:
                    PaginaCuatro();
                    break;
                case 5:
                    PaginaCinco();
                    break;
                case 6:
                    PaginaSeis();
                    break;
                case 7:
                    PaginaSiete();
                    break;
                case 8:
                    PaginaOcho();
                    break;
                case 9:
                    PaginaNueve();
                    break;
                case 10:
                    PaginaDiez();
                    break;
                case 11:
                    PaginaOnce();
                    break;
                case 12:
                    PaginaDoce();
                    break;
                case 13:
                    PaginaTrece();
                    break;
                case 14:
                    PaginaCatorce();
                    break;
                case 15:
                    PaginaQuince();
                    break;
                case 16:
                    PaginaDieciseis();
                    break;
                case 17:
                    PaginaDiecisiete();
                    break;
                case 18:
                    PaginaDieciocho();
                    break;
                case 19:
                    PaginaDiecinueve();
                    break;
                default:
                    MisObjetosPaginaManager++;
                    break;
            }
        }
        int MisObjetosPaginaManager = 1; //El Manager de las Paginas de mis Items
        int indexM; //Maneja el index de la lista de mis Objetos
        private void PaginaUno()
        {
            if (MisObjetosPaginaManager == 1)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 0;
                    int aux = listaMisCosas.Count - indexM;
                    switch (aux)
                    {
                        case 1:
                            listaMisCosas[indexM].Location = ShopPanel1.Location;
                            listaMisCosas[indexM].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[indexM].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            break;
                        case 2:
                            listaMisCosas[indexM].Location = ShopPanel1.Location;
                            listaMisCosas[indexM].NombreProducto = listaObjetosAux[8].NombreProducto;
                            listaMisCosas[indexM].CargarImagenes(listaObjetosAux[8].Imagen);
                            listaMisCosas[indexM + 1].Location = ShopPanel2.Location;
                            listaMisCosas[indexM + 1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[indexM + 1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            break;
                        case 3:
                            listaMisCosas[indexM].Location = ShopPanel1.Location;
                            listaMisCosas[indexM].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[indexM].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[indexM + 1].Location = ShopPanel2.Location;
                            listaMisCosas[indexM + 1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[indexM + 1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[indexM + 2].Location = ShopPanel3.Location;
                            listaMisCosas[indexM + 2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[indexM + 2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            break;
                        case 4:
                            listaMisCosas[indexM].Location = ShopPanel1.Location;
                            listaMisCosas[indexM].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[indexM].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[indexM + 1].Location = ShopPanel2.Location;
                            listaMisCosas[indexM + 1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[indexM + 1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[indexM + 2].Location = ShopPanel3.Location;
                            listaMisCosas[indexM + 2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[indexM + 2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            listaMisCosas[indexM + 3].Location = ShopPanel4.Location;
                            listaMisCosas[indexM + 3].NombreProducto = listaObjetosAux[indexM + 3].NombreProducto;
                            listaMisCosas[indexM + 3].CargarImagenes(listaObjetosAux[indexM + 3].Imagen);
                            break;
                        case 5:
                            listaMisCosas[indexM].Location = ShopPanel1.Location;
                            listaMisCosas[indexM].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[indexM].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[indexM + 1].Location = ShopPanel2.Location;
                            listaMisCosas[indexM + 1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[indexM + 1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[indexM + 2].Location = ShopPanel3.Location;
                            listaMisCosas[indexM + 2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[indexM + 2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            listaMisCosas[indexM + 3].Location = ShopPanel4.Location;
                            listaMisCosas[indexM + 3].NombreProducto = listaObjetosAux[indexM + 3].NombreProducto;
                            listaMisCosas[indexM + 3].CargarImagenes(listaObjetosAux[indexM + 3].Imagen);
                            listaMisCosas[indexM + 4].Location = ShopPanel5.Location;
                            listaMisCosas[indexM + 4].NombreProducto = listaObjetosAux[indexM + 4].NombreProducto;
                            listaMisCosas[indexM + 4].CargarImagenes(listaObjetosAux[indexM + 4].Imagen);
                            break;
                        case 6:
                            listaMisCosas[indexM].Location = ShopPanel1.Location;
                            listaMisCosas[indexM].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[indexM].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[indexM + 1].Location = ShopPanel2.Location;
                            listaMisCosas[indexM + 1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[indexM + 1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[indexM + 2].Location = ShopPanel3.Location;
                            listaMisCosas[indexM + 2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[indexM + 2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            listaMisCosas[indexM + 3].Location = ShopPanel4.Location;
                            listaMisCosas[indexM + 3].NombreProducto = listaObjetosAux[indexM + 3].NombreProducto;
                            listaMisCosas[indexM + 3].CargarImagenes(listaObjetosAux[indexM + 3].Imagen);
                            listaMisCosas[indexM + 4].Location = ShopPanel5.Location;
                            listaMisCosas[indexM + 4].NombreProducto = listaObjetosAux[indexM + 4].NombreProducto;
                            listaMisCosas[indexM + 4].CargarImagenes(listaObjetosAux[indexM + 4].Imagen);
                            listaMisCosas[indexM + 5].Location = ShopPanel6.Location;
                            listaMisCosas[indexM + 5].NombreProducto = listaObjetosAux[indexM + 5].NombreProducto;
                            listaMisCosas[indexM + 5].CargarImagenes(listaObjetosAux[indexM + 5].Imagen);
                            break;
                        case 7:
                            listaMisCosas[indexM].Location = ShopPanel1.Location;
                            listaMisCosas[indexM].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[indexM].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[indexM + 1].Location = ShopPanel2.Location;
                            listaMisCosas[indexM + 1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[indexM + 1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[indexM + 2].Location = ShopPanel3.Location;
                            listaMisCosas[indexM + 2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[indexM + 2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            listaMisCosas[indexM + 3].Location = ShopPanel4.Location;
                            listaMisCosas[indexM + 3].NombreProducto = listaObjetosAux[indexM + 3].NombreProducto;
                            listaMisCosas[indexM + 3].CargarImagenes(listaObjetosAux[indexM + 3].Imagen);
                            listaMisCosas[indexM + 4].Location = ShopPanel5.Location;
                            listaMisCosas[indexM + 4].NombreProducto = listaObjetosAux[indexM + 4].NombreProducto;
                            listaMisCosas[indexM + 4].CargarImagenes(listaObjetosAux[indexM + 4].Imagen);
                            listaMisCosas[indexM + 5].Location = ShopPanel6.Location;
                            listaMisCosas[indexM + 5].NombreProducto = listaObjetosAux[indexM + 5].NombreProducto;
                            listaMisCosas[indexM + 5].CargarImagenes(listaObjetosAux[indexM + 5].Imagen);
                            listaMisCosas[indexM + 6].Location = ShopPanel7.Location;
                            listaMisCosas[indexM + 6].NombreProducto = listaObjetosAux[indexM + 6].NombreProducto;
                            listaMisCosas[indexM + 6].CargarImagenes(listaObjetosAux[indexM + 6].Imagen);
                            break;
                        default:
                            listaMisCosas[indexM].Location = ShopPanel1.Location;
                            listaMisCosas[indexM].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                            listaMisCosas[indexM].CargarImagenes(listaObjetosAux[indexM].Imagen);
                            listaMisCosas[indexM + 1].Location = ShopPanel2.Location;
                            listaMisCosas[indexM + 1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                            listaMisCosas[indexM + 1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                            listaMisCosas[indexM + 2].Location = ShopPanel3.Location;
                            listaMisCosas[indexM + 2].NombreProducto = listaObjetosAux[indexM + 2].NombreProducto;
                            listaMisCosas[indexM + 2].CargarImagenes(listaObjetosAux[indexM + 2].Imagen);
                            listaMisCosas[indexM + 3].Location = ShopPanel4.Location;
                            listaMisCosas[indexM + 3].NombreProducto = listaObjetosAux[indexM + 3].NombreProducto;
                            listaMisCosas[indexM + 3].CargarImagenes(listaObjetosAux[indexM + 3].Imagen);
                            listaMisCosas[indexM + 4].Location = ShopPanel5.Location;
                            listaMisCosas[indexM + 4].NombreProducto = listaObjetosAux[indexM + 4].NombreProducto;
                            listaMisCosas[indexM + 4].CargarImagenes(listaObjetosAux[indexM + 4].Imagen);
                            listaMisCosas[indexM + 5].Location = ShopPanel6.Location;
                            listaMisCosas[indexM + 5].NombreProducto = listaObjetosAux[indexM + 5].NombreProducto;
                            listaMisCosas[indexM + 5].CargarImagenes(listaObjetosAux[indexM + 5].Imagen);
                            listaMisCosas[indexM + 6].Location = ShopPanel7.Location;
                            listaMisCosas[indexM + 6].NombreProducto = listaObjetosAux[indexM + 6].NombreProducto;
                            listaMisCosas[indexM + 6].CargarImagenes(listaObjetosAux[indexM + 6].Imagen);
                            listaMisCosas[indexM + 7].Location = ShopPanel8.Location;
                            listaMisCosas[indexM + 7].NombreProducto = listaObjetosAux[indexM + 7].NombreProducto;
                            listaMisCosas[indexM + 7].CargarImagenes(listaObjetosAux[indexM + 7].Imagen);
                            break;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaDos()
        {
            if (MisObjetosPaginaManager == 2)
            {
                try
                {
                    indexM = 8;
                    int aux = listaObjetosAux.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }


                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaTres()
        {
            if (MisObjetosPaginaManager == 3)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 16;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaCuatro()
        {
            if (MisObjetosPaginaManager == 4)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 24;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaCinco()
        {
            if (MisObjetosPaginaManager == 5)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 32;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaSeis()
        {
            if (MisObjetosPaginaManager == 6)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 40;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaSiete()
        {
            if (MisObjetosPaginaManager == 7)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 48;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaOcho()
        {
            if (MisObjetosPaginaManager == 8)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 56;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaNueve()
        {
            if (MisObjetosPaginaManager == 9)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 64;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaDiez()
        {
            if (MisObjetosPaginaManager == 10)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 72;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaOnce()
        {
            if (MisObjetosPaginaManager == 11)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 80;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaDoce()
        {
            if (MisObjetosPaginaManager == 12)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 88;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaTrece()
        {
            if (MisObjetosPaginaManager == 13)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 96;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaCatorce()
        {
            if (MisObjetosPaginaManager == 14)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 104;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaQuince()
        {
            if (MisObjetosPaginaManager == 15)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 112;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaDieciseis()
        {
            if (MisObjetosPaginaManager == 16)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 120;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaDiecisiete()
        {
            if (MisObjetosPaginaManager == 17)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 128;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaDieciocho()
        {
            if (MisObjetosPaginaManager == 18)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 136;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaDiecinueve()
        {
            if (MisObjetosPaginaManager == 19)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 144;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        private void PaginaVeinte()
        {
            if (MisObjetosPaginaManager == 20)
            {
                try
                {
                    OcultarEconomia();
                    indexM = 152;
                    int aux = listaMisCosas.Count - indexM;
                    if (aux > 0)
                    {
                        switch (aux)
                        {
                            case 1:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = "";
                                listaMisCosas[1].PictureBoxFalse();
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
                                break;
                            case 2:
                                listaMisCosas[0].Location = ShopPanel1.Location;
                                listaMisCosas[0].NombreProducto = listaObjetosAux[indexM].NombreProducto;
                                listaMisCosas[0].CargarImagenes(listaObjetosAux[indexM].Imagen);
                                listaMisCosas[1].Location = ShopPanel2.Location;
                                listaMisCosas[1].NombreProducto = listaObjetosAux[indexM + 1].NombreProducto;
                                listaMisCosas[1].CargarImagenes(listaObjetosAux[indexM + 1].Imagen);
                                listaMisCosas[2].Location = ShopPanel3.Location;
                                listaMisCosas[2].NombreProducto = "";
                                listaMisCosas[2].PictureBoxFalse();
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[3].Location = ShopPanel4.Location;
                                listaMisCosas[3].NombreProducto = "";
                                listaMisCosas[3].PictureBoxFalse();
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[4].Location = ShopPanel5.Location;
                                listaMisCosas[4].NombreProducto = "";
                                listaMisCosas[4].PictureBoxFalse();
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[5].Location = ShopPanel6.Location;
                                listaMisCosas[5].NombreProducto = "";
                                listaMisCosas[5].PictureBoxFalse();
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[6].Location = ShopPanel7.Location;
                                listaMisCosas[6].NombreProducto = "";
                                listaMisCosas[6].PictureBoxFalse();
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                                listaMisCosas[7].Location = ShopPanel8.Location;
                                listaMisCosas[7].NombreProducto = "";
                                listaMisCosas[7].PictureBoxFalse();
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
                    else
                    {
                        MessageBox.Show("No Tiene Mas objetos");
                        MisObjetosPaginaManager--;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

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
                    MessageBox.Show("Aceite Cambiado con exito!");
                    break;
                case 2:
                    MessageBox.Show("Mantenimiento del Motor Realizado!");
                    break;
                case 3:
                    MessageBox.Show("Se Le agrego un Turbo a tu auto!");
                    break;
                case 4:
                    MessageBox.Show("Tu Auto Quedo Reluciente!");
                    break;
                case 5:
                    MessageBox.Show("Gomas nuevas Compradas con exito!");
                    break;
                case 6:
                    MessageBox.Show("Tanque Lleno!");
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
                MessageBox.Show("Cambio El Mes, Necesitas renovar el Alquiler");
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
                MessageBox.Show("Necesita  Abonar su seguro Anual! Sino sin seguro ante destruccion del auto no percibira dinero");
                estadoSeguro = false;
                NegocioBaseDatos negocioSeguro = new NegocioBaseDatos();
                negocioSeguro.UpdateSeguro(estadoSeguro);
            }
        }

        //INCOMPLETO
        //Falta la configuracion de la pagina y subirla al Hosting 4.12
        private void CarDealerPictureBox_Click(object sender, EventArgs e)
        {
            string url = "https://gtdb.io/gt7/used-cars/";
            System.Diagnostics.Process.Start(url);
        }


        int modoDesarrollador = 0;
        bool bdHumilde = true;
        private void CargaPistasAutosPilotosEconomia_Click(object sender, EventArgs e)
        {
            if (modoDesarrollador == 9)
            {
                try
                {
                    if (bdHumilde)
                    {
                        MessageBox.Show("Desbloqueo el Modo Developer");
                        bdHumilde = false;
                    }
                    if (PistaPictureBox.Visible == true)
                    {
                        CargaPista ventanaPistas = new CargaPista();
                        ventanaPistas.ShowDialog();
                    }

                    else if (AutosPictureBox.Visible == true)
                    {

                        CargaAutos ventanaAutos = new CargaAutos();
                        ventanaAutos.ShowDialog();
                        CargarAutos();
                    }

                    else if (PilotosPictureBox.Visible == true)
                    {
                        CargaPilotos ventanaPistas = new CargaPilotos();
                        ventanaPistas.ShowDialog();
                        CargaPilotos();
                    }

                    else if (ShopPanel1.Visible == true)
                    {

                    }
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
            else
                modoDesarrollador++;
        }
    }
}
