
namespace Touge_App
{
    partial class Higiene
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Higiene));
            this.NombrePackHigiene = new System.Windows.Forms.Label();
            this.HigienePictureBox = new System.Windows.Forms.PictureBox();
            this.PrecioLabel = new System.Windows.Forms.Label();
            this.ComprarBoton = new System.Windows.Forms.Button();
            this.Sold = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HigienePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sold)).BeginInit();
            this.SuspendLayout();
            // 
            // NombrePackHigiene
            // 
            this.NombrePackHigiene.BackColor = System.Drawing.Color.Transparent;
            this.NombrePackHigiene.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombrePackHigiene.Location = new System.Drawing.Point(5, 0);
            this.NombrePackHigiene.Name = "NombrePackHigiene";
            this.NombrePackHigiene.Size = new System.Drawing.Size(425, 89);
            this.NombrePackHigiene.TabIndex = 0;
            this.NombrePackHigiene.Text = "2 Champu, 2 Cremas de enjuague, 2 Pastas de Dientes, Un Cepillo, Crema de Afeitar" +
    " y Afeitadora.";
            this.NombrePackHigiene.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HigienePictureBox
            // 
            this.HigienePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.HigienePictureBox.Location = new System.Drawing.Point(20, 92);
            this.HigienePictureBox.Name = "HigienePictureBox";
            this.HigienePictureBox.Size = new System.Drawing.Size(394, 338);
            this.HigienePictureBox.TabIndex = 1;
            this.HigienePictureBox.TabStop = false;
            // 
            // PrecioLabel
            // 
            this.PrecioLabel.AutoSize = true;
            this.PrecioLabel.BackColor = System.Drawing.Color.Transparent;
            this.PrecioLabel.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.PrecioLabel.Location = new System.Drawing.Point(36, 439);
            this.PrecioLabel.Name = "PrecioLabel";
            this.PrecioLabel.Size = new System.Drawing.Size(187, 45);
            this.PrecioLabel.TabIndex = 2;
            this.PrecioLabel.Text = "$ 999.999";
            // 
            // ComprarBoton
            // 
            this.ComprarBoton.BackColor = System.Drawing.Color.Transparent;
            this.ComprarBoton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ComprarBoton.BackgroundImage")));
            this.ComprarBoton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ComprarBoton.FlatAppearance.BorderSize = 0;
            this.ComprarBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ComprarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.ComprarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComprarBoton.Location = new System.Drawing.Point(258, 438);
            this.ComprarBoton.Name = "ComprarBoton";
            this.ComprarBoton.Size = new System.Drawing.Size(113, 46);
            this.ComprarBoton.TabIndex = 3;
            this.ComprarBoton.UseVisualStyleBackColor = false;
            // 
            // Sold
            // 
            this.Sold.BackColor = System.Drawing.Color.Transparent;
            this.Sold.Image = ((System.Drawing.Image)(resources.GetObject("Sold.Image")));
            this.Sold.Location = new System.Drawing.Point(20, 92);
            this.Sold.Name = "Sold";
            this.Sold.Size = new System.Drawing.Size(394, 338);
            this.Sold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sold.TabIndex = 4;
            this.Sold.TabStop = false;
            // 
            // Higiene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.Sold);
            this.Controls.Add(this.ComprarBoton);
            this.Controls.Add(this.PrecioLabel);
            this.Controls.Add(this.HigienePictureBox);
            this.Controls.Add(this.NombrePackHigiene);
            this.Name = "Higiene";
            this.Size = new System.Drawing.Size(434, 490);
            ((System.ComponentModel.ISupportInitialize)(this.HigienePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NombrePackHigiene;
        private System.Windows.Forms.PictureBox HigienePictureBox;
        private System.Windows.Forms.Label PrecioLabel;
        private System.Windows.Forms.Button ComprarBoton;
        private System.Windows.Forms.PictureBox Sold;
    }
}
