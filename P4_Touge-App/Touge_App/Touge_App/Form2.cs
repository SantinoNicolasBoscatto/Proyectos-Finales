using System;
using System.Drawing;
using System.Windows.Forms;

namespace Touge_App
{
    public partial class Form2 : Form
    {
        public Form2()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public void Mostrar(string aux)
        {
            label1.Text = aux;
            this.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(Screen.AllScreens.Length >= 2)
            {
                // Obtener la segunda pantalla
                Screen segundaPantalla = Screen.AllScreens[1];

                // Obtener el formulario actual
                Form formulario = this;

                // Centrar el formulario en la segunda pantalla
                formulario.Location = new Point(2430, 260);
            }
        }
    }
}
