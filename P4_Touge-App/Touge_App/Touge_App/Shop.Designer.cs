
namespace Touge_App
{
    partial class Shop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shop));
            this.ImagenProducto = new System.Windows.Forms.PictureBox();
            this.PrecioLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.NombreProductoLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.BotonCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagenProducto
            // 
            this.ImagenProducto.Location = new System.Drawing.Point(49, 49);
            this.ImagenProducto.Name = "ImagenProducto";
            this.ImagenProducto.Size = new System.Drawing.Size(231, 195);
            this.ImagenProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagenProducto.TabIndex = 0;
            this.ImagenProducto.TabStop = false;
            // 
            // PrecioLabel
            // 
            this.PrecioLabel.AllowParentOverrides = false;
            this.PrecioLabel.AutoEllipsis = false;
            this.PrecioLabel.CursorType = System.Windows.Forms.Cursors.Default;
            this.PrecioLabel.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.PrecioLabel.Location = new System.Drawing.Point(147, 253);
            this.PrecioLabel.Name = "PrecioLabel";
            this.PrecioLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PrecioLabel.Size = new System.Drawing.Size(132, 45);
            this.PrecioLabel.TabIndex = 1;
            this.PrecioLabel.Text = "$ 999,99";
            this.PrecioLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.PrecioLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // NombreProductoLabel
            // 
            this.NombreProductoLabel.AllowParentOverrides = false;
            this.NombreProductoLabel.AutoEllipsis = false;
            this.NombreProductoLabel.AutoSize = false;
            this.NombreProductoLabel.CursorType = System.Windows.Forms.Cursors.Default;
            this.NombreProductoLabel.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.NombreProductoLabel.Location = new System.Drawing.Point(18, 3);
            this.NombreProductoLabel.Name = "NombreProductoLabel";
            this.NombreProductoLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NombreProductoLabel.Size = new System.Drawing.Size(293, 45);
            this.NombreProductoLabel.TabIndex = 2;
            this.NombreProductoLabel.Text = "bunifuLabel2";
            this.NombreProductoLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.NombreProductoLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // BotonCompra
            // 
            this.BotonCompra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonCompra.BackgroundImage")));
            this.BotonCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BotonCompra.FlatAppearance.BorderSize = 0;
            this.BotonCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonCompra.Location = new System.Drawing.Point(49, 247);
            this.BotonCompra.Name = "BotonCompra";
            this.BotonCompra.Size = new System.Drawing.Size(59, 57);
            this.BotonCompra.TabIndex = 3;
            this.BotonCompra.UseVisualStyleBackColor = true;
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BorderColor = System.Drawing.Color.Gainsboro;
            this.BorderRadius = 54;
            this.Controls.Add(this.BotonCompra);
            this.Controls.Add(this.NombreProductoLabel);
            this.Controls.Add(this.PrecioLabel);
            this.Controls.Add(this.ImagenProducto);
            this.Name = "Shop";
            this.Size = new System.Drawing.Size(331, 313);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagenProducto;
        private Bunifu.UI.WinForms.BunifuLabel PrecioLabel;
        private Bunifu.UI.WinForms.BunifuLabel NombreProductoLabel;
        private System.Windows.Forms.Button BotonCompra;
    }
}
