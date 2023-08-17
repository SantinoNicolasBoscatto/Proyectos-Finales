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
namespace Touge_App
{
    public partial class Form1 : Form
    {
        private WaveOutEvent waveOutDevice = new WaveOutEvent();
        private AudioFileReader audioFile;
        NegocioBaseDatos negocioBD = new NegocioBaseDatos();
        List<Musica> listaCanciones;

        public Form1()
        {
            InitializeComponent();
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
            Trasparentado(CloseBoton, ConfiguracionBoton, VolumenControl);
            //Pido un Fondo Random
            RandomFondo();
            //Inicio en Segunda pantalla si hay
            Screen secondScreen = Screen.AllScreens.Length > 1 ? Screen.AllScreens[1] : Screen.PrimaryScreen;
            Location = secondScreen.Bounds.Location;
        }
        //Aca se Valida mediante un bool cuando el Mouse entra o sale de los botones y el evento de repintado

        bool HoverBotonBD = false;
        private void HoverBoton_MouseEnter(object sender, EventArgs e)
        { HoverBotonBD = true; }
        private void HoverBoton_MouseLeave(object sender, EventArgs e)
        { HoverBotonBD = false; }
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
        private void Trasparentado(Button Boton, Button Boton2, TrackBar Barra)
        {
            Boton.BackColor = Color.Transparent;
            Boton.Parent = PictureBoxBack;
            Boton.Visible = true;
            Boton2.BackColor = Color.Transparent;
            Boton2.Parent = PictureBoxBack;
            Boton2.Visible = true;
            Barra.BackColor = Color.Black;
            Barra.Parent = PictureBoxBack;
            Barra.Visible = false;
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
        }


        //Dispara la Primera pista de Musica

        float Volumen = 0.5f;
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
                    VolumenControl.Maximum = 100;
                    VolumenControl.Value = 5;
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
        private void BotonPistas_Click(object sender, EventArgs e)
        {
            if (true)
            {
                BotonPistas.Visible = false;
                PilotosBoton.Visible = false;
                ReglasBoton.Visible = false;
                EconomiaBoton.Visible = false;
                HistorialBoton.Visible = false;
                AutosBoton.Visible = false;
                CloseBoton.Visible = false;
                VolverBoton.Visible = true;
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
            BotonPistas.Visible = true;
            PilotosBoton.Visible = true;
            ReglasBoton.Visible = true;
            EconomiaBoton.Visible = true;
            HistorialBoton.Visible = true;
            AutosBoton.Visible = true;
            CloseBoton.Visible = true;
            imagen = true;
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
    }
}
