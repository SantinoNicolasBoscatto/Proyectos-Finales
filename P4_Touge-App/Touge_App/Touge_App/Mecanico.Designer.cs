
namespace Touge_App
{
    partial class Mecanico
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
            this.ImagenMecanico = new System.Windows.Forms.PictureBox();
            this.LabelPrecio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMecanico)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagenMecanico
            // 
            this.ImagenMecanico.BackColor = System.Drawing.Color.Transparent;
            this.ImagenMecanico.Location = new System.Drawing.Point(3, 1);
            this.ImagenMecanico.Name = "ImagenMecanico";
            this.ImagenMecanico.Size = new System.Drawing.Size(625, 344);
            this.ImagenMecanico.TabIndex = 0;
            this.ImagenMecanico.TabStop = false;
            // 
            // LabelPrecio
            // 
            this.LabelPrecio.AutoSize = true;
            this.LabelPrecio.BackColor = System.Drawing.Color.Transparent;
            this.LabelPrecio.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPrecio.ForeColor = System.Drawing.Color.LimeGreen;
            this.LabelPrecio.Location = new System.Drawing.Point(93, 364);
            this.LabelPrecio.Name = "LabelPrecio";
            this.LabelPrecio.Size = new System.Drawing.Size(178, 46);
            this.LabelPrecio.TabIndex = 1;
            this.LabelPrecio.Text = "$ 999.999";
            // 
            // Mecanico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.LabelPrecio);
            this.Controls.Add(this.ImagenMecanico);
            this.Name = "Mecanico";
            this.Size = new System.Drawing.Size(628, 423);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMecanico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagenMecanico;
        private System.Windows.Forms.Label LabelPrecio;
    }
}
