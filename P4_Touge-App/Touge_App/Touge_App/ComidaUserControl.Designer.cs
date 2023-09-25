
namespace Touge_App
{
    partial class ComidaUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComidaUserControl));
            this.ComidaPictureBox = new System.Windows.Forms.PictureBox();
            this.DescripcionPack = new System.Windows.Forms.Label();
            this.PrecioLabel = new System.Windows.Forms.Label();
            this.BuyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ComidaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ComidaPictureBox
            // 
            this.ComidaPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ComidaPictureBox.Location = new System.Drawing.Point(57, 84);
            this.ComidaPictureBox.Name = "ComidaPictureBox";
            this.ComidaPictureBox.Size = new System.Drawing.Size(486, 242);
            this.ComidaPictureBox.TabIndex = 0;
            this.ComidaPictureBox.TabStop = false;
            // 
            // DescripcionPack
            // 
            this.DescripcionPack.BackColor = System.Drawing.Color.Transparent;
            this.DescripcionPack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescripcionPack.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescripcionPack.Location = new System.Drawing.Point(3, 0);
            this.DescripcionPack.Name = "DescripcionPack";
            this.DescripcionPack.Size = new System.Drawing.Size(595, 81);
            this.DescripcionPack.TabIndex = 1;
            this.DescripcionPack.Text = "10 Pack de fideo, 10 Pack  de arroz, 5 gaseosas, 5 Pack de galletas, 3Kg de carne" +
    ", 1 Yerba Mate, 3 Pack de Te, Aderezos, 5 Sopa Instantanea, 2 Pack de Verduras y" +
    " 4 Packs de pan lactal.";
            this.DescripcionPack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PrecioLabel
            // 
            this.PrecioLabel.BackColor = System.Drawing.Color.Transparent;
            this.PrecioLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.PrecioLabel.Location = new System.Drawing.Point(304, 329);
            this.PrecioLabel.Name = "PrecioLabel";
            this.PrecioLabel.Size = new System.Drawing.Size(202, 53);
            this.PrecioLabel.TabIndex = 2;
            this.PrecioLabel.Text = "$ 9999.99";
            this.PrecioLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BuyButton
            // 
            this.BuyButton.BackColor = System.Drawing.Color.Transparent;
            this.BuyButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuyButton.BackgroundImage")));
            this.BuyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BuyButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.BuyButton.FlatAppearance.BorderSize = 0;
            this.BuyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BuyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BuyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuyButton.Location = new System.Drawing.Point(106, 332);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Size = new System.Drawing.Size(106, 50);
            this.BuyButton.TabIndex = 3;
            this.BuyButton.UseVisualStyleBackColor = false;
            // 
            // ComidaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.Controls.Add(this.BuyButton);
            this.Controls.Add(this.PrecioLabel);
            this.Controls.Add(this.DescripcionPack);
            this.Controls.Add(this.ComidaPictureBox);
            this.Name = "ComidaUserControl";
            this.Size = new System.Drawing.Size(601, 382);
            ((System.ComponentModel.ISupportInitialize)(this.ComidaPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ComidaPictureBox;
        private System.Windows.Forms.Label DescripcionPack;
        private System.Windows.Forms.Label PrecioLabel;
        private System.Windows.Forms.Button BuyButton;
    }
}
