using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClaseNegocio;
using ModeloDeDominio;

namespace PokedexProyecto
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Pokemon pokeModificar = null;
        bool bdAgregarModificar = true;
        public Form2(Pokemon PokeMod)
        {
            InitializeComponent();
            pokeModificar = PokeMod;
            bdAgregarModificar = false;

        }
        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            ConexionPokemonDataBase conexionAgregar = new ConexionPokemonDataBase();  
            try
            {
                    pokeModificar.Nombre = NombreBox.Text;
                    pokeModificar.NumeroPokedex = (int)NumeroBox.Value;
                    pokeModificar.DescripcionDePokemon = DescripcionBox.Text;
                    pokeModificar.Sprite = ImagenBox.Text;
                    pokeModificar.Sprite3d = Imagen3dBox.Text;
                    pokeModificar.EstadisticasBase.HP = (int)HpBox.Value;
                    pokeModificar.EstadisticasBase.Ataque = (int)AtaqueBox.Value;
                    pokeModificar.EstadisticasBase.Defensa = (int)DefensaBox.Value;
                    pokeModificar.EstadisticasBase.AtaqueEspecial = (int)AtaqueEspBox.Value;
                    pokeModificar.EstadisticasBase.DefensaEspecial = (int)DefEspBox.Value;
                    pokeModificar.EstadisticasBase.Velocidad = (int)VelocidadBox.Value;
                    pokeModificar.GritoPokemon = GritoBox.Text;
                    pokeModificar.TipoDeElemento = (Tipo)TipoComboBox.SelectedItem;
                    pokeModificar.TipoDeElemento2 = (Tipo)Tipo2ComboBox.SelectedItem;
                    pokeModificar.Debilidad = (Tipo)DebComboBox.SelectedItem;
                if (bdAgregarModificar)
                    conexionAgregar.AgregarPokemon(pokeModificar);
                else
                    conexionAgregar.ModificarPokemon(pokeModificar);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show("Datos Mal Cargados, Revise los datos");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ConexionPokemonDataBase CargarTipos = new ConexionPokemonDataBase();
            TipoComboBox.DataSource = CargarTipos.ListarTipo();
            TipoComboBox.ValueMember = "Id";
            TipoComboBox.DisplayMember = "TipoPokemon";
            Tipo2ComboBox.DataSource = CargarTipos.ListarTipoSecundario();
            Tipo2ComboBox.ValueMember = "Id";
            Tipo2ComboBox.DisplayMember = "TipoPokemon";
            DebComboBox.DataSource = CargarTipos.ListarTipo();
            DebComboBox.ValueMember = "Id";
            DebComboBox.DisplayMember = "TipoPokemon";
            
            try
            {
                if (pokeModificar != null)
                {
                    this.Text = "Modificacion de Pokemon";
                    AgregarButton.Text = "Modificar";
                    NombreBox.Text = pokeModificar.Nombre;
                    NumeroBox.Value = pokeModificar.NumeroPokedex;
                    DescripcionBox.Text = pokeModificar.DescripcionDePokemon;
                    ImagenBox.Text = pokeModificar.Sprite;
                    CargarSprite(pokeModificar.Sprite);
                    HpBox.Value = pokeModificar.EstadisticasBase.HP;
                    AtaqueBox.Value = pokeModificar.EstadisticasBase.Ataque;
                    DefensaBox.Value = pokeModificar.EstadisticasBase.Defensa;
                    AtaqueEspBox.Value = pokeModificar.EstadisticasBase.AtaqueEspecial;
                    DefEspBox.Value = pokeModificar.EstadisticasBase.DefensaEspecial;
                    VelocidadBox.Value =pokeModificar.EstadisticasBase.Velocidad;
                    Imagen3dBox.Text = pokeModificar.Sprite3d;
                    CargarSprite3d(pokeModificar.Sprite3d);
                    GritoBox.Text = pokeModificar.GritoPokemon;
                    TipoComboBox.SelectedValue = pokeModificar.TipoDeElemento.Id;
                    Tipo2ComboBox.SelectedValue = pokeModificar.TipoDeElemento2.Id;
                    DebComboBox.SelectedValue = pokeModificar.Debilidad.Id;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void ImagenBox_Leave(object sender, EventArgs e)
        {
            try
            {
                CargarSprite(ImagenBox.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void CargarSprite(string Sprite2d)
        {
            try
            {
                this.Sprite2d.Load(Sprite2d);
            }
            catch (Exception)
            {
                this.Sprite2d.Load("https://static.wikia.nocookie.net/bec6f033-936d-48c5-9c1e-7fb7207e28af/scale-to-width/755");
            }
        }
        private void CargarSprite3d(string Sprite3d)
        {
            try
            {
                this.Sprite3d.Load(Sprite3d);
            }
            catch (Exception)
            {
                this.Sprite3d.Load("https://static.wikia.nocookie.net/bec6f033-936d-48c5-9c1e-7fb7207e28af/scale-to-width/755");
            }
        }
        private void Imagen3dBox_Leave(object sender, EventArgs e)
        {
            try
            {
                CargarSprite3d(Imagen3dBox.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
