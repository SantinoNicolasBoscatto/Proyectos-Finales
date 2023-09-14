
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
            this.label1 = new System.Windows.Forms.Label();
            this.BotonComprar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProductoImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // NombreDelProducto
            // 
            this.NombreDelProducto.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreDelProducto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NombreDelProducto.Location = new System.Drawing.Point(3, 0);
            this.NombreDelProducto.Name = "NombreDelProducto";
            this.NombreDelProducto.Size = new System.Drawing.Size(377, 57);
            this.NombreDelProducto.TabIndex = 0;
            this.NombreDelProducto.Text = "Remera Anime Initial D Trueno \r\nAe86 Panda";
            this.NombreDelProducto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ProductoImagen
            // 
            this.ProductoImagen.Image = ((System.Drawing.Image)(resources.GetObject("ProductoImagen.Image")));
            this.ProductoImagen.Location = new System.Drawing.Point(53, 60);
            this.ProductoImagen.Name = "ProductoImagen";
            this.ProductoImagen.Size = new System.Drawing.Size(277, 253);
            this.ProductoImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProductoImagen.TabIndex = 1;
            this.ProductoImagen.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(58, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "$ 9999.99";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BotonComprar
            // 
            this.BotonComprar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonComprar.BackgroundImage")));
            this.BotonComprar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BotonComprar.FlatAppearance.BorderSize = 0;
            this.BotonComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonComprar.Location = new System.Drawing.Point(268, 319);
            this.BotonComprar.Name = "BotonComprar";
            this.BotonComprar.Size = new System.Drawing.Size(54, 51);
            this.BotonComprar.TabIndex = 3;
            this.BotonComprar.UseVisualStyleBackColor = true;
            // 
            // eShopPanels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.BotonComprar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductoImagen);
            this.Controls.Add(this.NombreDelProducto);
            this.Name = "eShopPanels";
            this.Size = new System.Drawing.Size(383, 378);
            ((System.ComponentModel.ISupportInitialize)(this.ProductoImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NombreDelProducto;
        private System.Windows.Forms.PictureBox ProductoImagen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BotonComprar;
    }
}
