using ModeloDeDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCodigoDeArticulos
{
    public partial class Form3 : Form
    {
        Articulo detalle = null;
        public Form3()
        {
            InitializeComponent();
            
        }
        public Form3(Articulo aux)
        {
            InitializeComponent();
            detalle = aux;
            Nombre.Text = detalle.NombreDeArticulo;
            Precio.Text = detalle.PrecioDelProducto.ToString();
            Codigo.Text = detalle.CodigoDeArticulo;
            Marca.Text = detalle.MarcaDelProducto.NombreMarca;
            Categoria.Text = detalle.CategoriaDelProducto.NombreCategoria;
            
        }
        //Funcion que define los maximos caracteres por linea (40) y que si el indice es menor a la descripcion
        //del articulo entonces se ejecutara el WHILE. SI el indice y los caracteres por linea son menores
        // o igual a la longitud de la descripcion entonces lo que haremos sera concatenar en el texto
        //formateado la descripcion desde la linea 0 a las siguientes 40 lineas y aumentamos el valor del
        //indice hasta la linea 40 (Ultimo caracter) Y ahi volvera a preguntar.
        // Lo que hace esta funcion es tirar un ENTER cada 40 caracteres de la cadena
        private void EnterParrafo()
        {
            int caracteresPorLinea = 40;
            int indice = 0;
            string textoFormateado = "";
            while (indice < detalle.DescripcionDeArticulo.Length)
            {
                if (indice + caracteresPorLinea <= detalle.DescripcionDeArticulo.Length)
                {
                    textoFormateado += detalle.DescripcionDeArticulo.Substring(indice, caracteresPorLinea) + Environment.NewLine;
                    indice += caracteresPorLinea;
                }
                else
                {
                    textoFormateado += detalle.DescripcionDeArticulo.Substring(indice) + Environment.NewLine;
                    break;
                }
            }
            Descrpcion.Text = textoFormateado;
        }

        public void CargarImagen(string imagen)
        {
            try
            {
                PictureBoxImagen.Load(imagen);
            }
            catch (Exception)
            {
                PictureBoxImagen.Load("https://thumbs.dreamstime.com/b/icono-de-producto-no-disponible-ilustraci%C3%B3n-vectores-plano-y-aislado-con-dise%C3%B1o-m%C3%ADnimo-sombra-larga-117825738.jpg");
            }
        }

        //Poder mover la ventana agarrandola con el Mouse directamente
        Point mouseLoc;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLoc = e.Location;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
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

        //Trasparentado de imagen
        Image original;
        private void PictureBoxImagen_MouseEnter(object sender, EventArgs e)
        {
            Form1 trasparencia = new Form1();
            original = PictureBoxImagen.Image;
            trasparencia.TrasparentarImagen(PictureBoxImagen, 0.5f);
        }
        private void PictureBoxImagen_MouseLeave(object sender, EventArgs e)
        {
            PictureBoxImagen.Image = original;
        }
        //Cierre
        private void PictureBoxImagen_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CargarImagen(detalle.ImagenDelProducto);
            EnterParrafo();
        }
    }
}
