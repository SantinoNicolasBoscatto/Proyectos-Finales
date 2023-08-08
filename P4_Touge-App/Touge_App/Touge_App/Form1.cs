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
    public partial class Form1 : Form
    {

        bool trackBD = false;
        bool AutosBD;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PictureBoxBack.Load("https://gifdb.com/images/high/initial-d-yellow-and-red-car-muihlavvagfracpq.gif");
        }
        private void TrackButton_MouseEnter(object sender, EventArgs e)
        {
            trackBD = true;
        }
        private void TrackButton_MouseLeave(object sender, EventArgs e)
        {
            trackBD = false;
        }      
        private void AutosBoton_MouseEnter(object sender, EventArgs e)
        {
            AutosBD = true;
        }
        private void AutosBoton_MouseLeave(object sender, EventArgs e)
        {
            AutosBD = false;
        }

        private void BotonPistas_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(trackBD, e, BotonPistas);
        }

        private void AutosBoton_Paint(object sender, PaintEventArgs e)
        {
            RepintadoBotones(AutosBD, e, AutosBoton);
        }

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
    }
}
