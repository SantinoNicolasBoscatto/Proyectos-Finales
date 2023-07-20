using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClaseNegocio;
using ModeloDeDominio;
using NAudio.Wave;

namespace PokedexProyecto
{
    public partial class Form3 : Form
    {
        int x;
        bool bdSprite = true;
        public Form3()
        {
            InitializeComponent();
            x = accesoValor.ObtenerIndice();
            CargarEstadisticas();
            PokemonBox.Load(listaDePokemones[x].Sprite);
        }

        Point mouseLoc;
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLoc = e.Location;
        }
        private void Form3_MouseMove(object sender, MouseEventArgs e)
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
        private void CloseStats_Click(object sender, EventArgs e)
        {
            Close();    
        }
        List<Pokemon> listaDePokemones = new List<Pokemon>();
        frmPokemons accesoValor = new frmPokemons();


        public void CargarEstadisticas()
        {
            
            ConexionPokemonDataBase PokemonNegocio = new ConexionPokemonDataBase();
            listaDePokemones = PokemonNegocio.ListarPokemon();     
            HpBar.Value = listaDePokemones[x].EstadisticasBase.HP;
            HPNumber.Text = listaDePokemones[x].EstadisticasBase.HP.ToString("000");
            AtaqueBar.Value = listaDePokemones[x].EstadisticasBase.Ataque;
            AtaqueNumber.Text = listaDePokemones[x].EstadisticasBase.Ataque.ToString("000");
            DefensaBar.Value = listaDePokemones[x].EstadisticasBase.Defensa;
            DefNumber.Text = listaDePokemones[x].EstadisticasBase.Defensa.ToString("000");
            EspBar.Value = listaDePokemones[x].EstadisticasBase.AtaqueEspecial;
            EspNumber.Text = listaDePokemones[x].EstadisticasBase.AtaqueEspecial.ToString("000");
            VelocidadBar.Value = listaDePokemones[x].EstadisticasBase.Velocidad;
            VelNumber.Text = listaDePokemones[x].EstadisticasBase.Velocidad.ToString("000");
            DefEspBar.Value = listaDePokemones[x].EstadisticasBase.DefensaEspecial;
            EspDefNumber.Text = listaDePokemones[x].EstadisticasBase.DefensaEspecial.ToString("000");
            using (AudioFileReader audioFileReader = new AudioFileReader(listaDePokemones[x].GritoPokemon))
            {
                using (WaveOutEvent waveOutEvent = new WaveOutEvent())
                {
                    waveOutEvent.Volume = 0.05f;
                    waveOutEvent.Init(audioFileReader);
                    waveOutEvent.Play();
                }
            }
            using (SoundPlayer Cry = new SoundPlayer(listaDePokemones[x].GritoPokemon))
            {
                Cry.Play();
            }
            if (HpBar.Value < 30)
                HpBar.ForeColor = Color.Red;
            else if (HpBar.Value < 60)
                HpBar.ForeColor = Color.Orange;
            else if (HpBar.Value < 80)
                HpBar.ForeColor = Color.Yellow;
            else if (HpBar.Value <= 100)
                HpBar.ForeColor = Color.YellowGreen;
            else if (HpBar.Value < 120)
                HpBar.ForeColor = Color.GreenYellow;
            else if (HpBar.Value <= 150)
                HpBar.ForeColor = Color.Green;
            else if (HpBar.Value > 150)
                HpBar.ForeColor = Color.MintCream;

            if (AtaqueBar.Value < 30)
                AtaqueBar.ForeColor = Color.Red;
            else if (AtaqueBar.Value < 60)
                AtaqueBar.ForeColor = Color.Orange;
            else if (AtaqueBar.Value < 80)
                AtaqueBar.ForeColor = Color.Yellow;
            else if (AtaqueBar.Value <= 100)
                AtaqueBar.ForeColor = Color.YellowGreen;
            else if (AtaqueBar.Value < 120)
                AtaqueBar.ForeColor = Color.GreenYellow;
            else if (AtaqueBar.Value <= 150)
                AtaqueBar.ForeColor = Color.Green;
            else if (AtaqueBar.Value > 150)
                AtaqueBar.ForeColor = Color.MintCream;

            if (DefensaBar.Value < 30)
                DefensaBar.ForeColor = Color.Red;
            else if (DefensaBar.Value < 60)
                DefensaBar.ForeColor = Color.Orange;
            else if (DefensaBar.Value < 80)
                DefensaBar.ForeColor = Color.Yellow;
            else if (DefensaBar.Value <= 100)
                DefensaBar.ForeColor = Color.YellowGreen;
            else if (DefensaBar.Value < 120)
                DefensaBar.ForeColor = Color.GreenYellow;
            else if (DefensaBar.Value <= 150)
                DefensaBar.ForeColor = Color.Green;
            else if (DefensaBar.Value > 150)
                DefensaBar.ForeColor = Color.MintCream;

            if (EspBar.Value < 30)
                EspBar.ForeColor = Color.Red;
            else if (EspBar.Value < 60)
                EspBar.ForeColor = Color.Orange;
            else if (EspBar.Value < 80)
                EspBar.ForeColor = Color.Yellow;
            else if (EspBar.Value <= 100)
                EspBar.ForeColor = Color.YellowGreen;
            else if (EspBar.Value < 120)
                EspBar.ForeColor = Color.GreenYellow;
            else if (EspBar.Value <= 150)
                EspBar.ForeColor = Color.Green;
            else if (EspBar.Value > 150)
                EspBar.ForeColor = Color.MintCream;

            if (DefEspBar.Value < 30)
                DefEspBar.ForeColor = Color.Red;
            else if (DefEspBar.Value < 60)
                DefEspBar.ForeColor = Color.Orange;
            else if (DefEspBar.Value < 80)
                DefEspBar.ForeColor = Color.Yellow;
            else if (DefEspBar.Value <= 100)
                DefEspBar.ForeColor = Color.YellowGreen;
            else if (DefEspBar.Value < 120)
                DefEspBar.ForeColor = Color.GreenYellow;
            else if (DefEspBar.Value <= 150)
                DefEspBar.ForeColor = Color.Green;
            else if (DefEspBar.Value > 150)
                DefEspBar.ForeColor = Color.MintCream;

            if (VelocidadBar.Value < 30)
                VelocidadBar.ForeColor = Color.Red;
            else if (VelocidadBar.Value < 60)
                VelocidadBar.ForeColor = Color.Orange;
            else if (VelocidadBar.Value < 80)
                VelocidadBar.ForeColor = Color.Yellow;
            else if (VelocidadBar.Value <= 100)
                VelocidadBar.ForeColor = Color.YellowGreen;
            else if (VelocidadBar.Value < 120)
                VelocidadBar.ForeColor = Color.GreenYellow;
            else if (VelocidadBar.Value <= 150)
                VelocidadBar.ForeColor = Color.Green;
            else if (VelocidadBar.Value > 150)
                VelocidadBar.ForeColor = Color.MintCream;
        }

        private void SiguienteBoton_Click(object sender, EventArgs e)
        {
            try
            {
                x++;
                CargarEstadisticas();
                if(bdSprite==false)
                PokemonBox.Load(listaDePokemones[x].Sprite3d);
                else
                    PokemonBox.Load(listaDePokemones[x].Sprite);
            }
            catch (Exception)
            {
                x--;
            }
            
        }

        private void AtrasBoton_Click(object sender, EventArgs e)
        {
            try
            {
                x--;
                CargarEstadisticas();
                if (bdSprite == false)
                    PokemonBox.Load(listaDePokemones[x].Sprite3d);
                else
                    PokemonBox.Load(listaDePokemones[x].Sprite);
            }
            catch (Exception)
            {
                x++;
                
            }
        }

        private void CloseStats_MouseEnter(object sender, EventArgs e)
        {
            Color mouseOverColor = Color.FromArgb(128, CloseStats.BackColor);
            CloseStats.FlatAppearance.MouseOverBackColor = mouseOverColor;
        }

        private void CloseStats_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el color de fondo original del botón
            CloseStats.FlatAppearance.MouseOverBackColor = CloseStats.BackColor;
        }

        private void PokemonBox_MouseEnter(object sender, EventArgs e)
        {
            Color mouseOverColor = Color.FromArgb(128, CloseStats.BackColor);
            PokemonBox.BackColor = mouseOverColor;
        }

        private void PokemonBox_MouseLeave(object sender, EventArgs e)
        {
            PokemonBox.BackColor = Color.Transparent;
        }

        private void PokemonBox_Click(object sender, EventArgs e)
        {
            if (bdSprite)
            {
                PokemonBox.Load(listaDePokemones[x].Sprite3d);
                bdSprite = false;
            }
            else
            {
                PokemonBox.Load(listaDePokemones[x].Sprite);
                bdSprite = true;
            }
            
        }
    }
}
