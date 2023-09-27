
namespace Touge_App
{
    partial class Comida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comida));
            this.PackNombre = new System.Windows.Forms.Label();
            this.PrecioLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BuyButton = new System.Windows.Forms.Button();
            this.Sold = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sold)).BeginInit();
            this.SuspendLayout();
            // 
            // PackNombre
            // 
            this.PackNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackNombre.Location = new System.Drawing.Point(3, 0);
            this.PackNombre.Name = "PackNombre";
            this.PackNombre.Size = new System.Drawing.Size(603, 81);
            this.PackNombre.TabIndex = 0;
            this.PackNombre.Text = "TEXT TEXT TEXT TEXT TEXT TEXT  TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT " +
    "TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT TEXT " +
    " ";
            this.PackNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrecioLabel
            // 
            this.PrecioLabel.Font = new System.Drawing.Font("Segoe UI Black", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.PrecioLabel.Location = new System.Drawing.Point(115, 320);
            this.PrecioLabel.Name = "PrecioLabel";
            this.PrecioLabel.Size = new System.Drawing.Size(206, 55);
            this.PrecioLabel.TabIndex = 1;
            this.PrecioLabel.Text = "$ 9999.99";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(67, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(476, 233);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // BuyButton
            // 
            this.BuyButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuyButton.BackgroundImage")));
            this.BuyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BuyButton.FlatAppearance.BorderSize = 0;
            this.BuyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BuyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BuyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuyButton.Location = new System.Drawing.Point(375, 320);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Size = new System.Drawing.Size(100, 55);
            this.BuyButton.TabIndex = 3;
            this.BuyButton.UseVisualStyleBackColor = true;
            this.BuyButton.Click += new System.EventHandler(this.BuyButton_Click);
            // 
            // Sold
            // 
            this.Sold.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Sold.Image = ((System.Drawing.Image)(resources.GetObject("Sold.Image")));
            this.Sold.Location = new System.Drawing.Point(67, 84);
            this.Sold.Name = "Sold";
            this.Sold.Size = new System.Drawing.Size(476, 233);
            this.Sold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sold.TabIndex = 5;
            this.Sold.TabStop = false;
            this.Sold.Visible = false;
            // 
            // Comida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.Controls.Add(this.Sold);
            this.Controls.Add(this.BuyButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PrecioLabel);
            this.Controls.Add(this.PackNombre);
            this.Name = "Comida";
            this.Size = new System.Drawing.Size(609, 375);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PackNombre;
        private System.Windows.Forms.Label PrecioLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BuyButton;
        private System.Windows.Forms.PictureBox Sold;
    }
}
