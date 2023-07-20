using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;
using ModeloDeDominio;
using ClaseNegocio;

namespace PokedexProyecto
{
    public partial class frmPokemons : Form
    {
        //Variables/Objetos
        public static int x = 0;
        List<Pokemon> listaDePokemones = new List<Pokemon>();
        bool bdSprite = true;
        bool banderaDescripcionTipo = true;
        int conta = 0;
        ConexionPokemonDataBase PokemonNegocio = new ConexionPokemonDataBase();
        //Inicio Del Forms
        public frmPokemons()
        {
            InitializeComponent();
            PictureBoxPokemon.BackColor = Color.Transparent;
            PictureBoxPokemon.Parent = Pokedex;
            PictureBoxPokemon.Visible = true;
            Apagado.BackColor = Color.Transparent;
            Apagado.Parent = Pokedex;
            Apagado.Visible = true;
            SiguientePokemon.BackColor = Color.Transparent;
            SiguientePokemon.Parent = Pokedex;
            SiguientePokemon.Visible = true;
            AnteriorPokemon.BackColor = Color.Transparent;
            AnteriorPokemon.Parent = Pokedex;
            AnteriorPokemon.Visible = true;
            Buscar.BackColor = Color.Transparent;
            Buscar.Parent = Pokedex;
            Buscar.Visible = true;
            Sprite3d.BackColor = Color.Transparent;
            Sprite3d.Parent = Pokedex;
            Sprite3d.Visible = true;
            GritoBoton.BackColor = Color.Transparent;
            GritoBoton.Parent = Pokedex;
            GritoBoton.Visible = true;
            NumeroBox.Parent = Pokedex;
            NumeroBox.Visible = true;
            alphaBlendTextBox1.Parent = Pokedex;
            alphaBlendTextBox1.Visible = true;
            Agregar.Parent = Pokedex;
            Agregar.Visible = true;
            PictureBoxPokemon.Parent = Pokedex;
            PictureBoxPokemon.Visible = true;
            StatsBaseBoton.BackColor = Color.Transparent;
            StatsBaseBoton.Parent = Pokedex;
            StatsBaseBoton.Visible = true;
            VerTipoBoton.BackColor = Color.Transparent;
            VerTipoBoton.Parent = Pokedex;
            VerTipoBoton.Visible = true;
            TipoBox1.BackColor = Color.Transparent;
            TipoBox1.Parent = Pokedex;
            TipoBox1.Visible = true;
            TipoBox2.BackColor = Color.Transparent;
            TipoBox2.Parent = Pokedex;
            TipoBox2.Visible = true;
            ModificarBoton.BackColor = Color.Transparent;
            ModificarBoton.Parent = Pokedex;
            ModificarBoton.Visible = true;
        }        
        //Carga Total Funcion
        public void CargarTabla ()
        {
            listaDePokemones = PokemonNegocio.ListarPokemon();
            if (bdSprite)
                CargarSprite(listaDePokemones[x].Sprite);
            else
                CargarSprite(listaDePokemones[x].Sprite3d);

            CargarEntradaPokedex(listaDePokemones[x].DescripcionDePokemon);
            CargarNumeroPokedex(listaDePokemones[x].NumeroPokedex);
            using (AudioFileReader audioFileReader = new AudioFileReader(listaDePokemones[x].GritoPokemon))
            {
                using (WaveOutEvent waveOutEvent = new WaveOutEvent())
                {
                    // Bajar el volumen a la mitad (0.5)
                    waveOutEvent.Volume = 0.05f;

                    // Conectar el AudioFileReader al WaveOutEvent
                    waveOutEvent.Init(audioFileReader);

                    // Reproducir el sonido con el volumen ajustado
                    waveOutEvent.Play();
                }

            }
            using (SoundPlayer Cry = new SoundPlayer(listaDePokemones[x].GritoPokemon))
            {
                Cry.Play();
            }
        }
        //Carga del FORMS
        private void frmPokemons_Load(object sender, EventArgs e)
        {
            CargarTabla();
             conta = PokemonNegocio.PokeBichosConta();
        }
        //CARGAS
        private void CargarSprite(string Sprite2d)
        {
            try
            {
                PictureBoxPokemon.Load(Sprite2d);
            }
            catch (Exception)
            {
                PictureBoxPokemon.Load("https://static.wikia.nocookie.net/bec6f033-936d-48c5-9c1e-7fb7207e28af/scale-to-width/755");
            }
        }
        private void CargarEntradaPokedex(string descripcion)
        {
            try
            {
                alphaBlendTextBox1.Text = descripcion;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void CargarNumeroPokedex(int num)
        {
            try
            {
                NumeroBox.Text = num.ToString();
            }
            catch (Exception)
            {
                NumeroBox.Text = "Error";
            }
            
        }
        private void CargarGrito()
        {
            try
            {
                using (SoundPlayer Cry = new SoundPlayer(listaDePokemones[x].GritoPokemon))
                { Cry.Play(); }
            }
            catch (Exception)
            {
                throw;
            }

        }
        //TIPOS DE CARGA, CORREGIR FUNCION EN 1
        private void CargarTipos(string Tipo)
        {
            try
            {
                TipoBox1.Load(Tipo);
            }
            catch (Exception)
            {
                TipoBox1.Load("");
            }
        }
        private void CargarTipos2(string Tipo2)
        {
            try
            {
                TipoBox2.Load(Tipo2);
            }
            catch (Exception)
            {
                TipoBox2.Load("https://static.wikia.nocookie.net/bec6f033-936d-48c5-9c1e-7fb7207e28af/scale-to-width/755");
            }
        } 
        //MOUSE FUNCION
        Point mouseLoc;
        private void frmPokemons_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLoc = e.Location;
        }
        private void frmPokemons_MouseMove(object sender, MouseEventArgs e)
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
        //BOTONES
        private void SiguientePokemon_Click(object sender, EventArgs e)
        {
            try
            {x++; 
             CargarTabla();
                CargarTipos(listaDePokemones[x].TipoDeElemento.ImagenTipo);
                CargarTipos2(listaDePokemones[x].TipoDeElemento2.ImagenTipo);
            }
            catch (Exception)
            {x--;}     
        }
        private void AnteriorPokemon_Click(object sender, EventArgs e)
        {
            try
            {x--;
             CargarTabla();
                CargarTipos(listaDePokemones[x].TipoDeElemento.ImagenTipo);
                CargarTipos2(listaDePokemones[x].TipoDeElemento2.ImagenTipo);
            }
            catch (Exception)
            {x++;}
        }
        private void GritoBoton_Click(object sender, EventArgs e)
        {
            CargarGrito();
        }
        private void Agregar_Click(object sender, EventArgs e)
        {   
            Form2 segundaVentana = new Form2();
            segundaVentana.ShowDialog();
            CargarTabla();
        }
        private void Sprite3d_Click(object sender, EventArgs e)
        {
            try
            {
                if (bdSprite)
                {
                    CargarSprite(listaDePokemones[x].Sprite3d);
                    CargarGrito();
                    bdSprite = false;
                    Sprite3d.Text = "2D";
                }
                else
                {
                    CargarSprite(listaDePokemones[x].Sprite);
                    CargarGrito();
                    bdSprite = true;
                    Sprite3d.Text = "3D";
                }

            }
            catch (Exception)
            {

                throw;
            }
            
            
        }
        int y;
        bool bd = true;
        private void Buscar_Click(object sender, EventArgs e)
        {
        
            try
            {
                y = int.Parse(NumeroBox.Text);
                //for (int i = 0; i < 15; i++)
                int i = 0; 
                while(i<conta)
                {
                    if (y == listaDePokemones[i].NumeroPokedex)
                    {
                        x = i;
                        i = conta;
                        CargarTabla();
                        bd = false;
                    }
                    i++;
                }
                if (bd)
                {
                    MessageBox.Show("El Pokemon no existe");
                    NumeroBox.Text = listaDePokemones[x].NumeroPokedex.ToString("0");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
                y = ObtenerIndice();
                NumeroBox.Text = listaDePokemones[y].NumeroPokedex.ToString("0");
            }
        }
        private void Apagado_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int ObtenerIndice()
        {
            return x;
        }
        private void StatsBaseBoton_Click(object sender, EventArgs e)
        {
            Form3 TercerVentana = new Form3();
            TercerVentana.ShowDialog();
        }
        private void NumeroBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)&& !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }

        }
        private void VerTipoBoton_Click(object sender, EventArgs e)
        {
            if (banderaDescripcionTipo)
            {
                alphaBlendTextBox1.Visible = false;
                TipoBox1.Visible = true;
                TipoBox2.Visible = true;
                CargarTipos(listaDePokemones[x].TipoDeElemento.ImagenTipo);
                CargarTipos2(listaDePokemones[x].TipoDeElemento2.ImagenTipo);
                //TipoBox1.Load("C:/Users/Santino/Desktop/C#/Repositorio GITHUB/Mini_Proyectos/PokedexProyecto/PokedexProyecto/TiposSimbolos/Acero.png");
                banderaDescripcionTipo = false;
                VerTipoBoton.Text = "Entr";
            }
            else
            {
                alphaBlendTextBox1.Visible = true;
                banderaDescripcionTipo = true;
                VerTipoBoton.Text = "Tipo";
            }

        }

        private void ModificarBoton_Click(object sender, EventArgs e)
        {
            Pokemon pokeMod = listaDePokemones[x];
            Form2 segundaVentana = new Form2(listaDePokemones[x]);
            segundaVentana.ShowDialog();
            CargarTabla();
        }
        string saver;
        private void NumeroBox_KeyUp(object sender, KeyEventArgs e)
        {
            List<Pokemon> listaFiltrada=null;
            try
            {
                if 
                (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                {
                    if (NumeroBox.Text != "")
                    {
                        listaFiltrada = listaDePokemones.FindAll(INDEX => INDEX.NumeroPokedex.ToString() == NumeroBox.Text);
                        PictureBoxPokemon.Load(listaFiltrada[0].Sprite);
                        if (bdSprite)
                            CargarSprite(listaFiltrada[0].Sprite);
                        else
                            CargarSprite(listaFiltrada[0].Sprite3d);
                        CargarEntradaPokedex(listaFiltrada[0].DescripcionDePokemon);
                        CargarNumeroPokedex(listaFiltrada[0].NumeroPokedex);
                        CargarTipos(listaFiltrada[0].TipoDeElemento.ImagenTipo);
                        CargarTipos2(listaFiltrada[0].TipoDeElemento2.ImagenTipo);
                        using (AudioFileReader audioFileReader = new AudioFileReader(listaFiltrada[0].GritoPokemon))
                        {
                            using (WaveOutEvent waveOutEvent = new WaveOutEvent())
                            {
                                // Bajar el volumen a la mitad (0.5)
                                waveOutEvent.Volume = 0.05f;

                                // Conectar el AudioFileReader al WaveOutEvent
                                waveOutEvent.Init(audioFileReader);

                                // Reproducir el sonido con el volumen ajustado
                                waveOutEvent.Play();
                            }

                        }
                        using (SoundPlayer Cry = new SoundPlayer(listaFiltrada[0].GritoPokemon))
                        {
                            Cry.Play();
                        }
                        saver = NumeroBox.Text;
                        x = int.Parse(NumeroBox.Text);
                        x--;
                    }
                }
                
            }
            catch (Exception)
            {
                //MessageBox.Show("Este Pokemon no esta Registrado");
                NumeroBox.Text = saver;
            }

        }

        private void NumeroBox_TextChanged(object sender, EventArgs e)
        {
            int selector = NumeroBox.SelectionLength;
            selector++;
            NumeroBox.SelectionStart = selector;
            if (NumeroBox.Text!="")
            {
                NumeroBox.Select(39,0);
            }
        }
    }
}
