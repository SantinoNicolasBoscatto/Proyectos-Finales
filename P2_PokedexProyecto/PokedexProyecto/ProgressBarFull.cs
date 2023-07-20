using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokedexProyecto
{
    class ProgressBarFull : ProgressBar
    {
        public ProgressBarFull()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }

        private SolidBrush brush = null;

        protected override void OnPaint(PaintEventArgs e)
        {
            if (brush == null || brush.Color != this.ForeColor)
                brush = new SolidBrush(this.ForeColor);

            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);


            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);


            if (Value != 0)
            {
                Rectangle r1 = new Rectangle(0, 0, rec.Width, rec.Height);
                int Altura = (int)(((double)Value * (double)this.Height) / 100);
                r1.Y = r1.Bottom - Altura;
                r1.Height = Altura;

                e.Graphics.FillRectangle(brush, 0, r1.Y, rec.Width, rec.Height);
            }
        }
    }
}
