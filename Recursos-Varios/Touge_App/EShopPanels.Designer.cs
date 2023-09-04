
namespace Touge_App
{
    partial class EShopPanels
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EShopPanels));
            this.BuyBoton = new System.Windows.Forms.PictureBox();
            this.RopaLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuRating1 = new Bunifu.UI.WinForms.BunifuRating();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.ProductoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BuyBoton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BuyBoton
            // 
            this.BuyBoton.Image = ((System.Drawing.Image)(resources.GetObject("BuyBoton.Image")));
            this.BuyBoton.Location = new System.Drawing.Point(305, 271);
            this.BuyBoton.Name = "BuyBoton";
            this.BuyBoton.Size = new System.Drawing.Size(54, 47);
            this.BuyBoton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BuyBoton.TabIndex = 0;
            this.BuyBoton.TabStop = false;
            // 
            // RopaLabel
            // 
            this.RopaLabel.AllowParentOverrides = false;
            this.RopaLabel.AutoEllipsis = false;
            this.RopaLabel.AutoSize = false;
            this.RopaLabel.CursorType = System.Windows.Forms.Cursors.Default;
            this.RopaLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RopaLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.RopaLabel.Location = new System.Drawing.Point(19, 15);
            this.RopaLabel.Name = "RopaLabel";
            this.RopaLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RopaLabel.Size = new System.Drawing.Size(327, 41);
            this.RopaLabel.TabIndex = 1;
            this.RopaLabel.Text = "Buzo Evangelion Asuka";
            this.RopaLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.RopaLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuRating1
            // 
            this.bunifuRating1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuRating1.DisabledEmptyFillColor = System.Drawing.Color.Yellow;
            this.bunifuRating1.DisabledRatedFillColor = System.Drawing.Color.Yellow;
            this.bunifuRating1.EmptyBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bunifuRating1.EmptyFillColor = System.Drawing.Color.White;
            this.bunifuRating1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.bunifuRating1.HoverFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.bunifuRating1.InnerRadius = 2F;
            this.bunifuRating1.Location = new System.Drawing.Point(30, 285);
            this.bunifuRating1.Name = "bunifuRating1";
            this.bunifuRating1.OuterRadius = 10F;
            this.bunifuRating1.RatedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.bunifuRating1.RatedFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.bunifuRating1.ReadOnly = false;
            this.bunifuRating1.RightClickToClear = true;
            this.bunifuRating1.Size = new System.Drawing.Size(121, 22);
            this.bunifuRating1.TabIndex = 2;
            this.bunifuRating1.Text = "bunifuRating1";
            this.bunifuRating1.Value = 5;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Lucida Sans Unicode", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuLabel1.Location = new System.Drawing.Point(179, 274);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(120, 37);
            this.bunifuLabel1.TabIndex = 3;
            this.bunifuLabel1.Text = "$ 18.99";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // ProductoPictureBox
            // 
            this.ProductoPictureBox.Location = new System.Drawing.Point(63, 57);
            this.ProductoPictureBox.Name = "ProductoPictureBox";
            this.ProductoPictureBox.Size = new System.Drawing.Size(255, 212);
            this.ProductoPictureBox.TabIndex = 4;
            this.ProductoPictureBox.TabStop = false;
            // 
            // EShopPanels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.BorderColor = System.Drawing.Color.Gray;
            this.BorderRadius = 50;
            this.BorderThickness = 5;
            this.Controls.Add(this.ProductoPictureBox);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.bunifuRating1);
            this.Controls.Add(this.RopaLabel);
            this.Controls.Add(this.BuyBoton);
            this.Name = "EShopPanels";
            this.Size = new System.Drawing.Size(379, 330);
            ((System.ComponentModel.ISupportInitialize)(this.BuyBoton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BuyBoton;
        private Bunifu.UI.WinForms.BunifuLabel RopaLabel;
        private Bunifu.UI.WinForms.BunifuRating bunifuRating1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private System.Windows.Forms.PictureBox ProductoPictureBox;
    }
}
