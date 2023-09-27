using Modelo_Clases;
using Negocio_Base_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touge_App
{
    public partial class HistorialForms : Form
    {
        string Player;
        public HistorialForms(string jugador)
        {
            InitializeComponent();
            TiempoTextBox.KeyPress += TiempoTextbox_KeyPress;
            CargarCombos();
            Player = jugador;
        }
        private void HistorialForms_Load(object sender, EventArgs e)
        {     
            SetPlaceholderText();
            Trasparentar();
            NegocioBaseDatos negocioBd = new NegocioBaseDatos();
            negocioBd.NombrePiloto(PilotoComboBox);
            negocioBd.NombrePiloto(RivalComboBox);
            negocioBd.NombrePista(CircuitoComboBox);
            negocioBd.NombreAuto(AutoComboBox);
            negocioBd.NombreAuto(AutoRivalComboBox);
            
        }

        private void CargarCombos()
        {
            ClaseComboBox.Items.Add("F");
            ClaseComboBox.Items.Add("E");
            ClaseComboBox.Items.Add("D");
            ClaseComboBox.Items.Add("C");
            ClaseComboBox.Items.Add("B");
            ClaseComboBox.Items.Add("A");
            ClaseComboBox.Items.Add("S");
            ClaseComboBox.Items.Add("S++");
            ModalidadBox.Items.Add("Side By Side");
            ModalidadBox.Items.Add("El Gato Y El Rato");
            ModalidadBox.Items.Add("Muerte Subita");
            ModalidadBox.Items.Add("Batalla Aleatoria");
            ClimaComboBox.Items.Add("Despejado");
            ClimaComboBox.Items.Add("Semi-Nublado");
            ClimaComboBox.Items.Add("Nublado");
            ClimaComboBox.Items.Add("Neblinoso");
            ClimaComboBox.Items.Add("Tormentoso");
            ClimaComboBox.Items.Add("Lluvia Leve");
            ClimaComboBox.Items.Add("Lluvia");
            ClimaComboBox.Items.Add("Lluvia Fuerte");
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
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
        Point mouseLoc;
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLoc = e.Location;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void Trasparentar()
        {
            PanelFondo.BackColor = Color.FromArgb(165, 0, 0, 0);
            CircuitoLabel.Parent = PanelFondo;
            CircuitoComboBox.Parent = PanelFondo;
            CircuitoLabel.BackColor = Color.Transparent; 
            RadioButtonSi.Parent = PanelFondo;
            RadioButtonSi.BackColor = Color.Transparent;            
            RadioButtonNo.Parent = PanelFondo;
            RadioButtonNo.BackColor = Color.Transparent;

        }
       
        private void CancelarBoton_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void AgregarBoton_Click(object sender, EventArgs e)
        {

            if (CircuitoComboBox.Text != "" && PilotoComboBox.Text != "" && RivalComboBox.Text != "" && AutoRival.Text != "" && AutoComboBox.Text != "" && ClaseComboBox.Text != "" && TiempoTextBox.Text != "" &&
                ClimaComboBox.Text != "" && ModalidadBox.Text != "" && TiempoTextBox.TextLength == 9 &&(RadioButtonSi.Checked || RadioButtonNo.Checked))
            {
                NegocioBaseDatos negocioDeBaseDatos = new NegocioBaseDatos();
                Historial aux = new Historial
                {
                    Circuito = CircuitoComboBox.Text,
                    PilotoA = PilotoComboBox.Text,
                    PilotoB = RivalComboBox.Text, //Combo Box Modificable, si no existe el Piloto se preguntara si desea generar UNO
                    AutoA = AutoComboBox.Text,
                    AutoB = AutoRivalComboBox.Text,
                    Ganador = GanadorComboBox.Text,
                    Perdedor = PerdedorCombobox.Text,
                    Clima = ClimaComboBox.Text,
                    Clase = ClaseComboBox.Text,
                    Modalidad = ModalidadBox.Text, //ComboBox de 4 Elecciones
                    Tiempo = TiempoTextBox.Text // Corregir
                };
                if (RadioButtonNo.Checked)
                    aux.Promocion = "No";
                else
                    aux.Promocion = "Si";
                negocioDeBaseDatos.InsertarRegistro(aux);
                if (banderaGanador==true && banderaPerdedor==true)
                {
                    negocioDeBaseDatos.ActualizarEstadisticas(aux.Ganador, aux.Perdedor);
                }
                if (aux.Ganador == Player)
                {
                    int dineroGanador;
                    switch (aux.Clase)
                    {
                        case "F":
                            dineroGanador = 250;
                            break;
                        case "E":
                            dineroGanador = 500;
                            break;
                        case "D":
                            dineroGanador = 750;
                            break;
                        case "C":
                            dineroGanador = 1250;
                            break;
                        case "B":
                            dineroGanador = 2250;
                            break;
                        case "A":
                            dineroGanador = 4000;
                            break;
                        case "S":
                            dineroGanador = 10000;
                            break;
                        case "S++":
                            dineroGanador = 20000;
                            break;
                        default:
                            dineroGanador = 0;
                            break;
                    }
                    NegocioBaseDatos dineroNegocio = new NegocioBaseDatos();
                    dineroGanador += dineroNegocio.DevolverDinero();
                    dineroNegocio.ActualizarDinero(dineroGanador);
                    MessageBox.Show("Su cantidad de dinero es: " + dineroNegocio.DevolverDinero());
                }
                else if (aux.Perdedor == Player)
                {
                    int dineroPerdedor;
                    switch (aux.Clase)
                    {
                        case "F":
                            dineroPerdedor = 250;
                            break;
                        case "E":
                            dineroPerdedor = 500;
                            break;
                        case "D":
                            dineroPerdedor = 750;
                            break;
                        case "C":
                            dineroPerdedor = 1250;
                            break;
                        case "B":
                            dineroPerdedor = 2250;
                            break;
                        case "A":
                            dineroPerdedor = 4000;
                            break;
                        case "S":
                            dineroPerdedor = 10000;
                            break;
                        case "S++":
                            dineroPerdedor = 20000;
                            break;
                        default:
                            dineroPerdedor = 0;
                            break;
                    }
                    NegocioBaseDatos dineroNegocio = new NegocioBaseDatos();
                    dineroPerdedor += dineroNegocio.DevolverDinero();
                    dineroNegocio.ActualizarDinero(dineroPerdedor);
                    MessageBox.Show("Su cantidad de dinero es: " + dineroNegocio.DevolverDinero());
                }
                MessageBox.Show("Registro Agregado con exito");
                this.Close();
            }
            else
                MessageBox.Show("Faltan Datos por cargar, porfavor revise bien");
        }



        private void TiempoTextBox_Enter(object sender, EventArgs e)
        {
            TiempoTextBox.ForeColor = SystemColors.WindowText;  
            TiempoTextBox.Text = "";
            TiempoTextBox.MaxLength = 9;
            TiempoTextBox.ForeColor = Color.Black;
        }
        private void SetPlaceholderText()
        {
            TiempoTextBox.ForeColor = SystemColors.ControlLight;
        }
        private void TiempoTextBox_Leave(object sender, EventArgs e)
        {
            if (TiempoTextBox.Text == "")
            {
                SetPlaceholderText();
            }
        }

        private void TiempoTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                string text = TiempoTextBox.Text;
                if (text.Length == 2)
                {
                    text += ":";
                }
                else if (text.Length == 5)
                {
                    text += ":";
                }
                TiempoTextBox.Text = text;
                TiempoTextBox.SelectionStart = TiempoTextBox.Text.Length;
            }
            else if (e.KeyChar == '\b') // Verificar si se presionó la tecla Retroceso (BackSpace)
            {
                string text = TiempoTextBox.Text;

                // Eliminar el último carácter si es un dos puntos o un dígito
                if (!string.IsNullOrEmpty(text))
                {
                    text = text.Substring(0, text.Length - 1);
                }
                TiempoTextBox.Text = text;

                // Establecer el cursor al final del texto
                TiempoTextBox.SelectionStart = TiempoTextBox.Text.Length;
                e.Handled = true;
            }
            else
            {
                // Evitar que se ingresen caracteres que no sean dígitos ni Retroceso
                e.Handled = true;
            }
        }
        private void GanadorComboBox_Enter(object sender, EventArgs e)
        {
            if (PilotoComboBox.Text != "" && RivalComboBox.Text != "")
            {
                if (GanadorComboBox.Items.Count==0)
                {
                    GanadorComboBox.Items.Add(PilotoComboBox.Text);
                    GanadorComboBox.Items.Add(RivalComboBox.Text);
                } 
            }
            else
            {
                MessageBox.Show("Antes Cargue a Los Pilotos!");
                if (PilotoComboBox.Text == "")
                    PilotoComboBox.Focus();
                else
                    RivalComboBox.Focus();
            }
                
        }

        private void PilotoComboBox_Enter(object sender, EventArgs e)
        {
            GanadorComboBox.Items.Clear();
            PerdedorCombobox.Items.Clear();
        }

        private void PerdedorCombobox_Enter(object sender, EventArgs e)
        {
            if (PilotoComboBox.Text != "" && RivalComboBox.Text != "")
            {
                if (GanadorComboBox.Text == "" && PerdedorCombobox.Items.Count==0)
                {
                    PerdedorCombobox.Items.Add(PilotoComboBox.Text);
                    PerdedorCombobox.Items.Add(RivalComboBox.Text);
                }
               
            }
            else
            {
                MessageBox.Show("Antes Cargue a Los Pilotos!");
                if (PilotoComboBox.Text == "")
                    PilotoComboBox.Focus();
                else
                    RivalComboBox.Focus();
            }
        }

        bool banderaIndex = true;
        private void GanadorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (banderaIndex)
            {
                banderaIndex = false;
                if (GanadorComboBox.Text != "")
                {
                    string nombreUno = PilotoComboBox.Text;
                    string nombreDos = RivalComboBox.Text;
                    if (GanadorComboBox.Text == nombreUno)
                    {
                        PerdedorCombobox.Items.Clear();
                        PerdedorCombobox.Items.Add(nombreDos);
                        PerdedorCombobox.Text = nombreDos;
                    }
                    else
                    {
                        PerdedorCombobox.Items.Clear();
                        PerdedorCombobox.Items.Add(nombreUno);
                        PerdedorCombobox.Text = nombreUno;
                    }

                }
            }
            
            
        }

        private void PerdedorCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (banderaIndex)
            {
                if (PerdedorCombobox.Text != "")
                {
                    string nombreUno = PilotoComboBox.Text;
                    string nombreDos = RivalComboBox.Text;
                    if (PerdedorCombobox.Text == nombreUno)
                    {
                        GanadorComboBox.Items.Clear();
                        GanadorComboBox.Items.Add(nombreDos);
                        GanadorComboBox.Items.Add(nombreUno);
                        GanadorComboBox.SelectedIndex = 0;
                        GanadorComboBox.Text = nombreDos;
                    }
                    else
                    {
                        GanadorComboBox.Items.Clear();
                        GanadorComboBox.Items.Add(nombreUno);
                        GanadorComboBox.Items.Add(nombreDos);
                        GanadorComboBox.SelectedIndex = 0;
                        GanadorComboBox.Text = nombreUno;
                    }
                }
            }
            banderaIndex = true;
            
        }

        bool banderaGanador = false;
        private void PilotoComboBox_Leave(object sender, EventArgs e)
        {
            if (!close)
            {
                string NombreDePiloto = PilotoComboBox.Text;
                if (!PilotoComboBox.Items.Contains(NombreDePiloto) && NombreDePiloto != "")
                {
                    DialogResult resultado = MessageBox.Show("Este Piloto No existe en la Base de Datos. ¿desea ingresarlo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        MessageBox.Show("En Desarrollo");
                        banderaGanador = true;
                    }     
                    else
                    {
                        MessageBox.Show("Este resultado no afectara En la estadisticas de ningun piloto");
                        banderaGanador = false;
                    }
                        
                }
                else
                    banderaGanador = true;
            }
            
        }
        bool banderaPerdedor = false;
        private void RivalComboBox_Leave(object sender, EventArgs e)
        {
            if (!close)
            {
                string NombreDePiloto = RivalComboBox.Text;
                if (!PilotoComboBox.Items.Contains(NombreDePiloto) && NombreDePiloto != "")
                {
                    DialogResult resultado = MessageBox.Show("Este Piloto No existe en la Base de Datos. ¿desea ingresarlo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        MessageBox.Show("En Desarrollo");
                        banderaPerdedor = true;
                    }
                        
                    else
                    {
                        MessageBox.Show("Este resultado no afectara En la estadisticas de ningun piloto");
                        banderaPerdedor = false;
                    }
                        
                }
                else
                    banderaPerdedor = true;
            }
            
        }

        private void CircuitoComboBox_Leave(object sender, EventArgs e)
        {
            if (!close)
            {
                string pistaNombre = CircuitoComboBox.Text;
                if (!CircuitoComboBox.Items.Contains(pistaNombre) && pistaNombre != "")
                {
                    DialogResult resultado = MessageBox.Show("Esta Pista no esta cargada en la base de datos. ¿Desea ingresarlo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                        MessageBox.Show("En Desarrollo");
                }
            }
            
        }

        bool close = false;
        private void CancelarBoton_MouseEnter(object sender, EventArgs e)
        {
            close = true;
        }
    }
}
