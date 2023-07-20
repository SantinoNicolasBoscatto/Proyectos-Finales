using ModeloDeDominio;
using NegocioConDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace AppCodigoDeArticulos
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }
        //Este Constructor es el que llamaremos al querer modificar un archivo. La modificacion y agregacion ocurrira en el 
        //mismo Forms pero tomara configuraciones diferentes, en este caso segun el valor del Articulo, Si es NULL se va a 
        //agregar un nuevo articulo, sino se quiere modificar una existente. Mediante el constructor lo que hago es traer el 
        //articulo seleccionado de la fila y cambio el valor null del auxiliar
        public Form2(Articulo Modificar)
        {
            InitializeComponent();
            auxiliar = Modificar;
            this.Text = "Modificacion De Productos";
            AgregarBoton.Text = "Modificar";
            //Icon icono = new Icon("C:\\Users\\Santino\\source\\repos\\TPFinalNivel2_Boscatto\\AppCodigoDeArticulos\\Imagenes\\126794.ico");
            //this.Icon = icono;
        }
        Articulo auxiliar = null;

        //Cuando Cargue el Forms traemos las listas de Categoria y Marca y le damos su Key valor y el valor a mostrar(Value y Display)
        //Si el auxiliar no es nulo cargo todos sus datos, en el Combo lo que hago es decir que su selected value es el nombre de la
        //categoria o Marca.
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                NegocioProductos negocio = new NegocioProductos();
                CategoriaCombo.DataSource = negocio.ListarCategorias();
                CategoriaCombo.ValueMember = "NombreCategoria";
                CategoriaCombo.DisplayMember = "NombreCategoria";
                MarcaCombo.DataSource = negocio.ListarMarcas();
                MarcaCombo.ValueMember = "NombreMarca";
                MarcaCombo.DisplayMember = "NombreMarca";
                //Con el ID en Value no me funciono, pero si con el nombre
                if (auxiliar != null)
                {
                    CodigoBox.Text = auxiliar.CodigoDeArticulo;
                    NombreBox.Text = auxiliar.NombreDeArticulo;
                    PrecioBox.Text = auxiliar.PrecioDelProducto.ToString();
                    DescripcionBox.Text = auxiliar.DescripcionDeArticulo;
                    ImagenBox.Text = auxiliar.ImagenDelProducto;
                    CargarImagen(ImagenBox.Text);
                    CategoriaCombo.SelectedValue = auxiliar.CategoriaDelProducto.NombreCategoria;
                    MarcaCombo.SelectedValue = auxiliar.MarcaDelProducto.NombreMarca;
                }
                //Si es nulo el auxiliar los combo se cargan vacio por defecto.
                else
                {
                    CategoriaCombo.SelectedIndex = -1;
                    MarcaCombo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        //funcion de Cargar Imagen, que ademas valida una bandera, esta para obligar a cargar una imagen valida localmente
        public void CargarImagen(string imagen)
        {
            try
            {
                ImagenPictureBox.Load(imagen);
                ImagenPictureBox.Visible = true;
            }
            catch (Exception)
            {
                ImagenPictureBox.Load("https://w7.pngwing.com/pngs/686/439/png-transparent-computer-icons-empty-set-symbol-others-angle-triangle-logo.png");
                //ImagenPictureBox.Visible = false;
            }
        }

        //Evento Agregar/Modificar
        private void AgregarBoton_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioProductos negocio = new NegocioProductos();
                bool banderaCerrado = true;
                bool bdApoyo = true;
                //Aca se Define Si la funcion a llamar sera agregar o Modificar, si es null es porque no se llamo al segundo
                //constructor por ende no se acciono el evento modificar. Si es modificacion los textbox los voy a cargar
                //Con la info del articulo
                if (auxiliar == null)
                {
                    auxiliar = new Articulo();
                    auxiliar.CodigoDeArticulo = CodigoBox.Text;
                    auxiliar.NombreDeArticulo = NombreBox.Text;
                    auxiliar.DescripcionDeArticulo = DescripcionBox.Text;
                    auxiliar.ImagenDelProducto = ImagenBox.Text;
                    //Verifico con se cargue un valor numerico valido con el While y la bandera
                    while (bdApoyo)
                    {
                        if (PrecioBox.Text != "")
                        {
                            auxiliar.PrecioDelProducto = decimal.Parse(PrecioBox.Text);
                            bdApoyo = false;
                        }
                        else
                        {
                            MessageBox.Show("No se cargo ningun valor numerico, Porfavor ponga un precio valido");
                            auxiliar = null;
                            return;
                        }
                    }
                    //Verificador de Categoria y Marca, si el Index!=-1 es categoria valida, sino selecciono una por defecto
                    //Y permito que elija si esa no es la correcta.
                    while (banderaCerrado)
                    {
                        if (CategoriaCombo.SelectedIndex != -1)
                        {
                            auxiliar.CategoriaDelProducto = (Categoria)CategoriaCombo.SelectedItem;
                            if (MarcaCombo.SelectedIndex != -1)
                            {
                                auxiliar.MarcaDelProducto = (Marca)MarcaCombo.SelectedItem;
                                //Si Categoria, Marca y Numeros estan OK verifico Imagen
                                if (!(bdApoyo))
                                {
                                    //Si existe el OpenFile y el campo no contiene http y el campo no esta vacio entra
                                    if (cargarImagenPC != null && !(ImagenBox.Text.ToLower().Contains("http")) && !(ImagenBox.Text.ToLower().Contains("data:image")) && ImagenBox.Text != "")
                                    {
                                        //Verifica la extension de la imagen y al Nuevo Nombre le asigna el horario actual.
                                            string nombreNuevoArchivo="";
                                        if (cargarImagenPC.FileName.Contains(".jpg"))
                                            nombreNuevoArchivo = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
                                        else if (cargarImagenPC.FileName.Contains(".png"))
                                            nombreNuevoArchivo = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
                                        else if (cargarImagenPC.FileName.Contains(".gif"))
                                            nombreNuevoArchivo = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".gif";
                                        else
                                        {
                                            MessageBox.Show("La imagen Cargada no tiene un formato valido, porfavor seleccione otra imagen tipo PNG, JPG o GIF");
                                            return;
                                        }

                                        //string ruta = cargarImagenPC.FileName;
                                        //string nombreArchivo = System.IO.Path.GetFileName(ruta);
                                        //if (!(File.Exists(Path.Combine(ConfigurationManager.AppSettings["Fotos"], nombreArchivo))))
                                        //{
                                        //Copio el archivo y lo llevo a la Carpeta configurada en AppSettings y le agrego el nuevo nombre.
                                        File.Copy(cargarImagenPC.FileName, ConfigurationManager.AppSettings["Fotos"] + nombreNuevoArchivo);
                                                auxiliar.ImagenDelProducto = Path.Combine(ConfigurationManager.AppSettings["Fotos"], nombreNuevoArchivo);
                                            //}
                                            //else
                                               // auxiliar.ImagenDelProducto = Path.Combine(ConfigurationManager.AppSettings["Fotos"], nombreArchivo);
                                    }
                                    //Si esta vacio pido imagen. Los auxiliares NULL son para que en el siguiente intento de agregar 
                                    //no ejecute modificar, paso varias veces jajaja.
                                    else if (ImagenBox.Text == "")
                                    {
                                        MessageBox.Show("No deje vacio el campo Imagen Porfavor");
                                        auxiliar = null;
                                        return;
                                    }
                                    //Agrego, tiro mensaje y cierro el while y FORMS
                                    negocio.AgregarArticulo(auxiliar);
                                    MessageBox.Show("Agregado Con exito");
                                    banderaCerrado = false;
                                    Close();
                                }
                                else
                                {
                                    auxiliar = null;
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Coloco una Marca invalida, se le colocara una por defecto, puede cambiarla si lo desea");
                                auxiliar = null;
                                MarcaCombo.SelectedIndex = 0;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Coloco una Categoria, invalida, se le colocara una por defecto, puede cambiarla si lo desea");
                            auxiliar = null;
                            CategoriaCombo.SelectedIndex = 0;
                            return; 
                        }
                    } 
                }
                //Si no pasa la validacion del null entonces se hara una modificacion. El procedimiento es similar.
                else
                {
                    banderaCerrado = true;
                    auxiliar.CodigoDeArticulo = CodigoBox.Text;
                    auxiliar.NombreDeArticulo = NombreBox.Text;
                    auxiliar.DescripcionDeArticulo = DescripcionBox.Text;
                    auxiliar.ImagenDelProducto = ImagenBox.Text;
                    auxiliar.PrecioDelProducto = decimal.Parse(PrecioBox.Text);
                    while (bdApoyo)
                    {
                        if (PrecioBox.Text != "")
                        {
                            auxiliar.PrecioDelProducto = decimal.Parse(PrecioBox.Text);
                            bdApoyo = false;
                        }
                        else
                        {
                            MessageBox.Show("No se cargo ningun valor numerico, Porfavor ponga un precio valido");
                            return;
                        }
                    }

                    auxiliar.CategoriaDelProducto = (Categoria)CategoriaCombo.SelectedItem;
                    auxiliar.MarcaDelProducto = (Marca)MarcaCombo.SelectedItem;

                    if (cargarImagenPC != null && !(ImagenBox.Text.ToLower().Contains("http")) && !(ImagenBox.Text.ToLower().Contains("data:image")) && ImagenBox.Text != "")
                    {
                        string nombreNuevoArchivo = "";
                        if (cargarImagenPC.FileName.Contains(".jpg") &&  ImagenBox.Text.Contains(".jpg"))
                            nombreNuevoArchivo = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
                        else if (cargarImagenPC.FileName.Contains(".png") && ImagenBox.Text.Contains(".png"))
                            nombreNuevoArchivo = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
                        else if (cargarImagenPC.FileName.Contains(".gif") && ImagenBox.Text.Contains(".gif"))
                            nombreNuevoArchivo = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".gif";
                        else
                        {
                            MessageBox.Show("La imagen Cargada no tiene un formato valido, porfavor seleccione otra imagen tipo PNG, JPG o GIF");
                            return;
                        }
                        //string ruta = cargarImagenPC.FileName;
                        //string nombreArchivo = System.IO.Path.GetFileName(ruta);
                        //if (!(File.Exists(Path.Combine(ConfigurationManager.AppSettings["Fotos"], nombreArchivo))))
                        //{
                        File.Copy(cargarImagenPC.FileName, ConfigurationManager.AppSettings["Fotos"] + nombreNuevoArchivo);
                        auxiliar.ImagenDelProducto = Path.Combine(ConfigurationManager.AppSettings["Fotos"], nombreNuevoArchivo);
                        //}
                        //else
                        // auxiliar.ImagenDelProducto = Path.Combine(ConfigurationManager.AppSettings["Fotos"], nombreArchivo);
                    }
                    else if (ImagenBox.Text == "")
                    {
                        MessageBox.Show("No deje vacio el campo Imagen Porfavor");
                        return;
                    }
                    negocio.Modificar(auxiliar);
                    MessageBox.Show("Modificado Con exito");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()+"\n\n"+"Ocurrio un error en la carga de un nuevo articulo, revise sus datos y vuelva a intentar");
            }

        }

        //Cierro Forms2
        private void CancelarBoton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Valido que en el precio solo se pueda ingresar numeros y ,
        private void PrecioBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
                if (PrecioBox.Text.Contains(","))
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        e.Handled = true; // El HANDLED si es verdadero ignora el caracter que se quiso ingresar
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)&& e.KeyChar != ',')
                        e.Handled = true;
                }
            
        }

        //Obligo que al Salir haya un numero cargado, si hay una coma la cambio por un 0
        //Tambien valido si alguien logro poner letras (Ctrl+C/Ctrl+V) Tampoco deje salir
        private void PrecioBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (PrecioBox.Text == "")
                {
                    DialogResult resultado;
                    resultado = MessageBox.Show("Cargue el precio, Excepto que desee salir del Formulario." + "\n\n" + "Pulse SI, si desea seguir cargando el Articulo o NO para salir", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultado == DialogResult.Yes)
                        PrecioBox.Focus();
                    else
                        this.Close();
                }
                if (PrecioBox.Text == ",")
                {
                    PrecioBox.Text = "0";
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(PrecioBox.Text, "[a-zA-Z!@#$%^&*()]"))
                {
                    MessageBox.Show("El Precio contiene letras o símbolos, porfavor cargue un valor numerico");
                    PrecioBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + "Ocurrio un error inesperado, pongase en contacto con su programador");
            }
        }
        //Cargar Imagen desde la PC, Creo y configuro el OpenFileDialog
        OpenFileDialog cargarImagenPC;
        private void CargarPc_Click(object sender, EventArgs e)
        {
            cargarImagenPC = new OpenFileDialog();
            cargarImagenPC.Filter = "jpg|*.jpg| png|*.png| gif|*.gif";
            try
            {
                if (cargarImagenPC.ShowDialog() == DialogResult.OK)
                {
                    ImagenBox.Text = cargarImagenPC.FileName;
                    CargarImagen(ImagenBox.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + "Ocurrio un error inesperado, pongase en contacto con su programador");
            }
            
        }

        //Creo una funcion que define que si un Textbox esta vacio lo vuelva rojo y sino blanco
        private void ColoreadoTextBox(TextBox textbox)
        {
            if (textbox.Text == "")
            {
                textbox.BackColor = Color.Red;
            }
            else
                textbox.BackColor = Color.White;
        }

        //Esta funcion se ejecutara en el Leave y TextChanged, es una forma de avisar que quedaron campos vacios, que aunque
        //No esta mal es una forma de avisar un posible error.
        private void CodigoBox_Leave(object sender, EventArgs e)
        {
            ColoreadoTextBox(CodigoBox);
        }
        private void NombreBox_Leave(object sender, EventArgs e)
        {
            ColoreadoTextBox(NombreBox);
        }
        private void DescripcionBox_Leave(object sender, EventArgs e)
        {
            ColoreadoTextBox(DescripcionBox);
        }
        private void ImagenBox_Leave(object sender, EventArgs e)
        {
            ColoreadoTextBox(ImagenBox);
            if (ImagenBox.Text.ToLower().Contains("http") || ImagenBox.Text.ToLower().Contains("data:image"))
            {
                CargarImagen(ImagenBox.Text); 
            }
            else if (cargarImagenPC!=null)
                ImagenPictureBox.Visible = true;
            else
                CargarImagen(ImagenBox.Text);
        }

        private void CodigoBox_TextChanged(object sender, EventArgs e)
        {
            ColoreadoTextBox(CodigoBox);
        }
        private void NombreBox_TextChanged(object sender, EventArgs e)
        {
            ColoreadoTextBox(NombreBox);
        }       
        private void DescripcionBox_TextChanged(object sender, EventArgs e)
        {
            ColoreadoTextBox(DescripcionBox);
        }       
        private void ImagenBox_TextChanged(object sender, EventArgs e)
        {
            ColoreadoTextBox(ImagenBox);
        }
        
    }
}
