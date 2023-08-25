using System;
using NAudio.Wave;
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
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Touge_App
{
    public partial class TougeForms : Form
    {
        private WaveOutEvent waveOutDevice = new WaveOutEvent();
        private AudioFileReader audioFile;
        NegocioBaseDatos negocioBD = new NegocioBaseDatos();
        List<Musica> listaCanciones;
        private Size initialSize;

        public TougeForms()
        {
            InitializeComponent();
            initialSize = this.ClientSize;
            this.Resize += TougeForms_Resize;
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
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            Size newResolution = this.ClientSize;
            
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
            FichaTecnicaTextBox.Parent = BanderasPictureBox;
            FichaTecnicaTextBox.Location = new Point(0, 0);
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

        private void VolverBoton_Click(object sender, EventArgs e)
        {
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
            else if (FichaTecnicaTextBox.Visible == true)
            {
                FichaTecnicaTextBox.Visible = false;
                NombreAutoTextbox.Visible = false;
                BanderasPictureBox.Visible = false;
                AutosPictureBox.Visible = false;
                NextAuto.Visible = false;
                BackAuto.Visible = false;
            }
            BotonPistas.Visible = true;
            PilotosBoton.Visible = true;
            ReglasBoton.Visible = true;
            EconomiaBoton.Visible = true;
            HistorialBoton.Visible = true;
            AutosBoton.Visible = true;
            CloseBoton.Visible = true;
            
           
            
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
            AutosPictureBox.Visible = true;
            FichaTecnicaTextBox.Visible = true;
            BanderasPictureBox.Visible = true;
            NombreAutoTextbox.Visible = true;
            BackAuto.Visible = true;
            NextAuto.Visible = true;
            negocioBDAutos = new NegocioBaseDatos();
            listaAutos = negocioBDAutos.DevolverAutos();
            NombreAutoTextbox.Text = listaAutos[indexAutos].NombreModelo;
            AutosPictureBox.Load(listaAutos[indexAutos].ImagenAuto);
            MarcaPictureBox.Load(listaAutos[indexAutos].MarcaAuto.ImagenMarca);
            BanderasPictureBox.Load(listaAutos[indexAutos].PaisFabricacion);
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
    }
}
