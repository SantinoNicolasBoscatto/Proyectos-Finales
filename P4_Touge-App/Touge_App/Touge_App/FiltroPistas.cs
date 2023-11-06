using Modelo_Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio_Base_Datos;
namespace Touge_App
{
    public partial class FiltroPistas : Form
    {
        public Pistas PistaFiltrada { get; set; }
        public Autos AutoFiltrado { get; set; }
        public Pilotos PilotoFiltrado { get; set; }
        public bool Bandera { get; set; }
        public int Verificador { get; set; }
        public FiltroPistas()
        {
            InitializeComponent();
        }

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

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Bandera = false;
            Close();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (AutoComboBox.Text!="")
            {
                NegocioBaseDatos negociobd = new NegocioBaseDatos();
                try
                {
                    if (Verificador==1)
                    {
                        PistaFiltrada = negociobd.FiltrarPistas(AutoComboBox.Text);
                        PistaFiltrada.Combo = AutoComboBox.SelectedIndex;
                    }
                    else if (Verificador == 2)
                    {
                        AutoFiltrado = negociobd.FiltrarAutos(AutoComboBox.Text);
                        AutoFiltrado.Combo = AutoComboBox.SelectedIndex;
                    }
                    else
                    {
                        PilotoFiltrado = negociobd.FiltrarPilotos(AutoComboBox.Text);
                        PilotoFiltrado.Combo = AutoComboBox.SelectedIndex;
                    }
                    
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    Bandera = true;
                    Close();
                }
            }
            else
            {
                mensajeBox.Mostrar("Cargue Auto");
            }
        }
        Form2 mensajeBox = new Form2();

        private void FiltroPistas_Load(object sender, EventArgs e)
        {
            Bandera = false;
            NegocioBaseDatos negociobd = new NegocioBaseDatos();
            if (Verificador==1)
            {
                List<Pistas> listaPistas = negociobd.DevolverPistas();
                int index = 0;
                while (index < listaPistas.Count)
                {
                    AutoComboBox.Items.Add(listaPistas[index].NombrePista);
                    index++;
                }
            }
            else if (Verificador==2)
            {
                List<Autos> listaAutos = negociobd.DevolverAutos();
                int index = 0;
                NombreLabel.Text = "Nombre Auto";
                while (index < listaAutos.Count)
                {
                    AutoComboBox.Items.Add(listaAutos[index].NombreModelo);
                    index++;
                }
            }
            else 
            {
                List<Pilotos> listaPilotos = negociobd.DevolverPilotos();
                int index = 0;
                NombreLabel.Text = "Nombre Piloto";
                while (index < listaPilotos.Count)
                {
                    AutoComboBox.Items.Add(listaPilotos[index].NombrePiloto);
                    index++;
                }
            }

        }
    }
}
