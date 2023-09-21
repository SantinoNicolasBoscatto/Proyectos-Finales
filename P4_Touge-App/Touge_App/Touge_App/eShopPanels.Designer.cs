
namespace Touge_App
{
    partial class eShopPanels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(eShopPanels));
            this.NombreDelProducto = new System.Windows.Forms.Label();
            this.ProductoImagen = new System.Windows.Forms.PictureBox();
            this.PrecioLabel = new System.Windows.Forms.Label();
            this.BotonComprar = new System.Windows.Forms.Button();
            this.Sold = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductoImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sold)).BeginInit();
            this.SuspendLayout();
            // 
            // NombreDelProducto
            // 
            this.NombreDelProducto.BackColor = System.Drawing.Color.Transparent;
            this.NombreDelProducto.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreDelProducto.ForeColor = System.Drawing.SystemColors.Desktop;
            this.NombreDelProducto.Location = new System.Drawing.Point(30, 0);
            this.NombreDelProducto.Name = "NombreDelProducto";
            this.NombreDelProducto.Size = new System.Drawing.Size(317, 59);
            this.NombreDelProducto.TabIndex = 0;
            this.NombreDelProducto.Text = "Remera Anime Initial D Trueno \r\nAe86 Panda";
            this.NombreDelProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductoImagen
            // 
            this.ProductoImagen.BackColor = System.Drawing.Color.Black;
            this.ProductoImagen.Image = ((System.Drawing.Image)(resources.GetObject("ProductoImagen.Image")));
            this.ProductoImagen.Location = new System.Drawing.Point(45, 60);
            this.ProductoImagen.Name = "ProductoImagen";
            this.ProductoImagen.Size = new System.Drawing.Size(286, 260);
            this.ProductoImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProductoImagen.TabIndex = 1;
            this.ProductoImagen.TabStop = false;
            // 
            // PrecioLabel
            // 
            this.PrecioLabel.BackColor = System.Drawing.Color.Transparent;
            this.PrecioLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.PrecioLabel.Location = new System.Drawing.Point(58, 323);
            this.PrecioLabel.Name = "PrecioLabel";
            this.PrecioLabel.Size = new System.Drawing.Size(190, 47);
            this.PrecioLabel.TabIndex = 2;
            this.PrecioLabel.Text = "$ 9999.99";
            this.PrecioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BotonComprar
            // 
            this.BotonComprar.BackColor = System.Drawing.Color.Transparent;
            this.BotonComprar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonComprar.BackgroundImage")));
            this.BotonComprar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BotonComprar.FlatAppearance.BorderSize = 0;
            this.BotonComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonComprar.Location = new System.Drawing.Point(268, 322);
            this.BotonComprar.Name = "BotonComprar";
            this.BotonComprar.Size = new System.Drawing.Size(54, 51);
            this.BotonComprar.TabIndex = 3;
            this.BotonComprar.UseVisualStyleBackColor = false;
            this.BotonComprar.Click += new System.EventHandler(this.BotonComprar_Click);
            // 
            // Sold
            // 
            this.Sold.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Sold.Image = ((System.Drawing.Image)(resources.GetObject("Sold.Image")));
            this.Sold.Location = new System.Drawing.Point(45, 60);
            this.Sold.Name = "Sold";
            this.Sold.Size = new System.Drawing.Size(286, 260);
            this.Sold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sold.TabIndex = 4;
            this.Sold.TabStop = false;
            this.Sold.Visible = false;
            // 
            // eShopPanels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.Controls.Add(this.Sold);
            this.Controls.Add(this.BotonComprar);
            this.Controls.Add(this.PrecioLabel);
            this.Controls.Add(this.ProductoImagen);
            this.Controls.Add(this.NombreDelProducto);
            this.Name = "eShopPanels";
            this.Size = new System.Drawing.Size(379, 376);
            ((System.ComponentModel.ISupportInitialize)(this.ProductoImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NombreDelProducto;
        private System.Windows.Forms.PictureBox ProductoImagen;
        private System.Windows.Forms.Label PrecioLabel;
        private System.Windows.Forms.Button BotonComprar;
        private System.Windows.Forms.PictureBox Sold;
    }
}
