using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModeloDeDominio;
using NegocioConDB;

namespace AppCodigoDeArticulos
{
    public partial class Form1 : Form
    {
        NegocioProductos negocio = new NegocioProductos();
        List<Articulo> listaDeArticulos = new List<Articulo>();
        public Form1()
        {
            InitializeComponent();
            ProductosPictureBox.BringToFront();
        }
        public void CargarImagen(string imagen)
        {
            try
            {
              ProductosPictureBox.Load(imagen);   
            }
            catch (Exception)
            {
                ProductosPictureBox.Load("https://thumbs.dreamstime.com/b/icono-de-producto-no-disponible-ilustraci%C3%B3n-vectores-plano-y-aislado-con-dise%C3%B1o-m%C3%ADnimo-sombra-larga-117825738.jpg");
            }
        }
        //Funcion de Cargar Listas
        public void CargarListadoCompleto ()
        {
            listaDeArticulos = negocio.ListarArticulos();
            DgvProductos.DataSource = listaDeArticulos;
            DgvProductos.Columns["Id"].Visible = false;
            DgvProductos.Columns["ImagenDelProducto"].Visible = false;
            DgvProductos.Columns["CodigoDeArticulo"].Visible = false;
            DgvProductos.Columns["CategoriaDelProducto"].Width = 85;
            DgvProductos.RowHeadersWidth = 40;
            DgvProductos.Columns["MarcaDelProducto"].Width = 90;
            DgvProductos.Columns["PrecioDelProducto"].Width = 100;
            DgvProductos.Columns["DescripcionDeArticulo"].Visible = false;
            DgvProductos.Columns["NombreDeArticulo"].Width = 150;
            CargarImagen(listaDeArticulos[0].ImagenDelProducto);
            CampoComboBox.Items.Add("Codigo");
            CampoComboBox.Items.Add("Nombre");
            CampoComboBox.Items.Add("Descripcion");
            CampoComboBox.Items.Add("Precio");
        }
        //Carga del formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarListadoCompleto();

        }

        //Explicado en el interior
        private void DgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulo Seleccionado = (Articulo)DgvProductos.CurrentRow.DataBoundItem;
                CargarImagen(Seleccionado.ImagenDelProducto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + "Ocurrio un error inesperado, pongase en contacto con su programador");
            }
            //Evento que se acciona cuando cambio de Item en la DGV, esta lo que permite es cargar la imagen del producto 
            //seleccionado. Lo que hacemos es crear una variable articulo, la cual sera rellenada con el objeto que seleccionemos
            //del DGV (deberemos castearlo debido a que el DGV trabaja todos los objetos como object) y de ahi accederemos al
            //string de la imagen del producto para utilizarlo en la funcion cargar imagen.
        }

        //Se encarga de limpiar los campos de filtrado.
        private void LimpiezaDeRecarga()
        {
            CampoComboBox.Items.Clear();
            CriterioComboBox.Items.Clear();
            TextoFiltradoBox.Text = "";
            LimpiarBoton.Visible = false;
        }

        //Boton que permite el reseteo del listado completo, tambien resetea filtros.
        private void ListaCompletaBoton_Click(object sender, EventArgs e)
        {
            LimpiezaDeRecarga();
            CargarListadoCompleto();
            ProductosPictureBox.Visible = true;
            //CampoComboBox.SelectedIndex = -1;
            //CriterioComboBox.SelectedIndex = -1;
        }

        //Esto abrira el FORMS de carga, cuando se cierre limpiara los filtros y Cargara el listado actualizado
        private void AgregarBoton_Click(object sender, EventArgs e)
        {
            Form2 ventanaAgregar = new Form2();
            ventanaAgregar.ShowDialog();
            LimpiezaDeRecarga();
            CargarListadoCompleto();
        }

        //Esto eliminara un Articulo fisicamente de la Base de datos, antes se le muestra un Message y si confirma se borra
        //el articulo. Tambien valida que si la Fila actual es nula tirara un mensaje para seleccionar una celda.
        private void EliminarBoton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea eliminar este articulo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    if (DgvProductos.CurrentRow != null)
                    {
                        int x = DgvProductos.CurrentRow.Index;
                        negocio.EliminarArticulo(listaDeArticulos[x].Id);
                        LimpiezaDeRecarga();
                        CargarListadoCompleto();
                    }
                    else
                        MessageBox.Show("Seleccione el articulo que desea eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + "Ocurrio un error inesperado, pongase en contacto con su programador");
            }
        }

        //Este combina el agregar (en la parte de abrir un forms nuevo) y eliminar (ya que valida si la celda seleccionada
        //es null o no). Tambien crea una validacion en el FORMS 2, ya que este le pasa al forms2 un Articulo por constructor
        //que utilizaremos como validador mas adelante.
        private void ModificarBoton_Click(object sender, EventArgs e)
        {
            try
            {             
                if (DgvProductos.CurrentRow != null)
                {
                    Articulo Modificado = (Articulo)DgvProductos.CurrentRow.DataBoundItem;
                    Form2 ventanaAgregar = new Form2(Modificado);
                    ventanaAgregar.ShowDialog();
                    LimpiezaDeRecarga();
                    CargarListadoCompleto();
                }
                else
                    MessageBox.Show("Porfavor Selecione el articulo que quiera quiera modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + "Ocurrio un error inesperado, pongase en contacto con su programador");
            }

        }

        //Estos 2 funciones sirven para mover la app sin tener que agarrarla desde la ventana.
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
        //Este evento lo que hace es que segun el Text del campo genere X objetos en el Criterio, cada distinta seleccion
        //limpia los anteriores y genera nuevos.
        private void CampoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CampoComboBox.Text != "Precio")
                {
                    LimpiarBoton.Visible = true;
                    CriterioComboBox.Items.Clear();
                    TextoFiltradoBox.Text = "";
                    CriterioComboBox.Items.Add("Empieza Por");
                    CriterioComboBox.Items.Add("Termina Por");
                    CriterioComboBox.Items.Add("Contiene");
                }
                else
                {
                    LimpiarBoton.Visible = true;
                    CriterioComboBox.Items.Clear();
                    TextoFiltradoBox.Text = "";
                    TextoFiltradoBox.Text = "";
                    CriterioComboBox.Items.Add("Es Mayor a");
                    CriterioComboBox.Items.Add("Es Menor a");
                    CriterioComboBox.Items.Add("Es Igual a");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + "Ocurrio un error inesperado, pongase en contacto con su programador");
            }
        }

        //Esta es la funcion del filtro avanzado, creo el negocio y el listado de articulos a traer, paso el campo, criterio y
        // el texto a filtrar y los mando a la funcion del negocio ListaFiltrada. Todo esto sera guardado en la lista 
        // filtrada. Tambien agregamos una funcion de que si no hay celdas se desactive la visibilidad de la PictureBox,
        //asi no muestra ninguna imagen, ya que no corresponde.
        private void FiltrarAvanzado()
        {
            try
            {
                NegocioProductos negocio = new NegocioProductos();
                List<Articulo> filtrado = new List<Articulo>();
                string campo = CampoComboBox.Text;
                string criterio = CriterioComboBox.Text;
                string texto = TextoFiltradoBox.Text;
                filtrado = negocio.ListaFiltrada(campo, criterio, texto);
                DgvProductos.DataSource = filtrado;
                if (DgvProductos.Rows.Count == 0)
                    ProductosPictureBox.Visible = false;
                else
                    ProductosPictureBox.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + "Ocurrio un error inesperado, pongase en contacto con su programador");
            }

        }

        //Aca Ocurre las validaciones para el filtrado, para que este no se rompa, tanto el obligar a seleccionar campo, criterio
        //El pedir numeros en el campo numerico entre otras, todo con la funcion de evitar algun error.
        private void BuscarFiltradoBoton_Click(object sender, EventArgs e)
        {
            try
            {

                if (CampoComboBox.Text != "")
                {
                    if(CriterioComboBox.Text != "")
                    {
                        if (CampoComboBox.Text == "Precio" && TextoFiltradoBox.Text!="" && TextoFiltradoBox.Text != "." && TextoFiltradoBox.Text != ",")
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(TextoFiltradoBox.Text, "[a-zA-Z!@#$%^&*()]"))
                            {
                                MessageBox.Show("El Precio contiene letras o símbolos, porfavor cargue un valor numerico valido");
                                TextoFiltradoBox.Focus();
                            }
                            else
                            {
                                if(TextoFiltradoBox.Text.Contains(","))
                                TextoFiltradoBox.Text = TextoFiltradoBox.Text.Replace(",", ".");
                                FiltrarAvanzado();
                            }
                        }
                        else if(CampoComboBox.Text != "Precio")
                        {
                            FiltrarAvanzado();
                        }
                        else
                        {
                            MessageBox.Show("Por Favor Cargue un numero para utilizar el filtro numerico", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }         
                    else
                        MessageBox.Show("Por Favor Cargue el Criterio antes de filtrar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Por Favor Cargue el Campo antes de filtrar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + "Ocurrio un error inesperado, pongase en contacto con su programador");
            }

        }

        //Esta complementa validaciones anteriores, evita que cuando se seleccione precio se introduzcan letras u otros caracteres
        //No numericos.
        private void TextoFiltradoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CampoComboBox.Text=="Precio")
            {
                if (TextoFiltradoBox.Text.Contains(".")|| TextoFiltradoBox.Text.Contains(","))
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        e.Handled = true; // Ignorar el carácter ingresado
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
                        e.Handled = true; // Ignorar el carácter ingresado                       
                }
            }
        }

        //Evento que limpia los filtros.
        private void LimpiarBoton_Click(object sender, EventArgs e)
        {
            LimpiezaDeRecarga();
            CampoComboBox.Items.Add("Codigo");
            CampoComboBox.Items.Add("Nombre");
            CampoComboBox.Items.Add("Descripcion");
            CampoComboBox.Items.Add("Precio");
        }

        //Evite el despliegue vacio del criterio al no seleccionar campo, Opcional.
        private void CriterioComboBox_Click(object sender, EventArgs e)
        {
            if(CampoComboBox.Text=="")
            {
                MessageBox.Show("Seleccione el campo antes porfavor");
            }
        }

        //Manon de GPT para trasparentar la imagen.
        public void TrasparentarImagen(PictureBox pictureBox, float trasparencia)
        {
            try
            {
                if (pictureBox.Image != null)
                {
                    // Crea una matriz de colores para aplicar la transparencia
                    ColorMatrix colorMatrix = new ColorMatrix();
                    colorMatrix.Matrix33 = trasparencia; // Ajusta este valor para cambiar la transparencia (0.0f a 1.0f)

                    // Crea un objeto ImageAttributes y establece la matriz de colores
                    ImageAttributes imageAttributes = new ImageAttributes();
                    imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    // Dibuja la imagen en un nuevo bitmap utilizando las configuraciones de transparencia
                    Bitmap transparentImage = new Bitmap(pictureBox.Image.Width, pictureBox.Image.Height);
                    using (Graphics graphics = Graphics.FromImage(transparentImage))
                    {
                        graphics.DrawImage(pictureBox.Image, new Rectangle(0, 0, transparentImage.Width, transparentImage.Height),
                            0, 0, pictureBox.Image.Width, pictureBox.Image.Height, GraphicsUnit.Pixel, imageAttributes);
                    }
                    pictureBox.Image = transparentImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + "Ocurrio un error inesperado, pongase en contacto con su programador");
            }

        }

        private Image original;
        //Al entrar al PictureBox guardo el color original de la imagen y ejecuto la funcion trasparentar
        private void ProductosPictureBox_MouseEnter(object sender, EventArgs e)
        {
            original = ProductosPictureBox.Image;
            TrasparentarImagen(ProductosPictureBox, 0.7f);
        }

        //Al salir restalezco la trasparencia del PB
        private void ProductosPictureBox_MouseLeave(object sender, EventArgs e)
        {
            //ProductosPictureBox.BackColor = Color.Transparent;
            ProductosPictureBox.Image = original;
        }

        //Decimos que si la seleccion del DGV no es nula abra una ventana nueva con la info del producto seleccionado.
        //Para pasarle la Info del producto lo hacemos por constructor.
        Form3 detalle=null;
        private void ProductosPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvProductos.CurrentRow != null)
                {
                    TrasparentarImagen(ProductosPictureBox, 0.25f);
                    detalle = new Form3((Articulo)DgvProductos.CurrentRow.DataBoundItem);
                    detalle.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + "Ocurrio un error inesperado, pongase en contacto con su programador");
            }
        }

        //Pone visible y oculta elementos
        private void BotonMarca_Click(object sender, EventArgs e)
        {
            Agregar.Visible = true;
            Cancelar.Visible = true;
            AgregarMarcaCategoria.Visible = true;
            AgregarMarcaCategoria.Text = "";
            BuscarFiltradoBoton.Visible = false;
            LimpiarBoton.Visible = false;
            CampoComboBox.Visible = false;
            CriterioComboBox.Visible = false;
            TextoFiltradoBox.Visible = false;
            MarcaLabel.Location = new Point(647, 218);
            MarcaLabel.Visible = true;
            label1.Visible = false;
            CampoLabel.Visible = false;
            CriterioLabel.Visible = false;
            CategoriaLabel.Visible = false;
            ListaCompletaBoton.Visible = false;
            AgregarMarcaCategoria.BackColor = Color.White;
        }
        //Pone visible y oculta elementos
        private void BotonCategori_Click(object sender, EventArgs e)
        {
            Agregar.Visible = true;
            Cancelar.Visible = true;
            AgregarMarcaCategoria.Visible = true;
            AgregarMarcaCategoria.Text = "";
            BuscarFiltradoBoton.Visible = false;
            LimpiarBoton.Visible = false;
            CampoComboBox.Visible = false;
            CriterioComboBox.Visible = false;
            TextoFiltradoBox.Visible = false;
            CategoriaLabel.Location = new Point(638, 218);
            CategoriaLabel.Visible = true;
            MarcaLabel.Visible = false;
            label1.Visible = false;
            CampoLabel.Visible = false;
            CriterioLabel.Visible = false;
            ListaCompletaBoton.Visible = false;
            AgregarMarcaCategoria.BackColor = Color.White;
        }
        //Pone visible y oculta elementos
        private void Cancelar_Click(object sender, EventArgs e)
        {
            reset();
        }

        //Ejecuta la funcion de agregar marca/categoria
        bool banderaValidar = false;
        private void Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                    if (MarcaLabel.Visible == true)
                    {
                        if (AgregarMarcaCategoria.Text != "")
                        {
                            NegocioProductos negocioMarca = new NegocioProductos();
                            negocio.AgregarMarca(AgregarMarcaCategoria.Text);
                            MessageBox.Show("Marca Agregada con exito");
                            banderaValidar = true;
                        }
                        else
                            AgregarMarcaCategoria.BackColor = Color.Red;
                    }
                    else
                    {
                        if (AgregarMarcaCategoria.Text != "")
                        {
                            NegocioProductos negocioCategoria = new NegocioProductos();
                            negocioCategoria.AgregarCategoria(AgregarMarcaCategoria.Text);
                            MessageBox.Show("Categoria Agregada con exito");
                            banderaValidar = true;
                    }
                        else
                            AgregarMarcaCategoria.BackColor = Color.Red;
                    }
                    if(banderaValidar)
                        reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + "Ocurrio un error inesperado, pongase en contacto con su programador");
            }
        }
        //Pone visible y oculta elementos
        private void reset()
        {
            Agregar.Visible = false;
            Cancelar.Visible = false;
            AgregarMarcaCategoria.Visible = false;
            BuscarFiltradoBoton.Visible = true;
            CampoComboBox.Visible = true;
            CriterioComboBox.Visible = true;
            TextoFiltradoBox.Visible = true;
            CategoriaLabel.Visible = false;
            MarcaLabel.Visible = false;
            label1.Visible = true;
            CampoLabel.Visible = true;
            CriterioLabel.Visible = true;
            ListaCompletaBoton.Visible = true;
            banderaValidar = false;
            AgregarMarcaCategoria.BackColor = Color.White;
            AgregarMarcaCategoria.Text = "";
            if (CampoComboBox.Text != "" || TextoFiltradoBox.Text != "")
                LimpiarBoton.Visible = true;
        }
    }
    
}
