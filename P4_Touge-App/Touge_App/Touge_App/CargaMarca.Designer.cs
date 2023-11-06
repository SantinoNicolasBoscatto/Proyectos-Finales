
namespace Touge_App
{
    partial class CargaMarca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargaMarca));
            this.NombreLabel = new System.Windows.Forms.Label();
            this.NombreBox = new System.Windows.Forms.TextBox();
            this.ImagenPista = new System.Windows.Forms.Button();
            this.ImagenBox = new System.Windows.Forms.TextBox();
            this.ImgLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.BackColor = System.Drawing.Color.Transparent;
            this.NombreLabel.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreLabel.ForeColor = System.Drawing.Color.AliceBlue;
            this.NombreLabel.Location = new System.Drawing.Point(6, 18);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(98, 30);
            this.NombreLabel.TabIndex = 34;
            this.NombreLabel.Text = "Nombre";
            // 
            // NombreBox
            // 
            this.NombreBox.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreBox.Location = new System.Drawing.Point(114, 19);
            this.NombreBox.MaxLength = 100;
            this.NombreBox.Name = "NombreBox";
            this.NombreBox.Size = new System.Drawing.Size(227, 31);
            this.NombreBox.TabIndex = 59;
            // 
            // ImagenPista
            // 
            this.ImagenPista.BackColor = System.Drawing.Color.LawnGreen;
            this.ImagenPista.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ImagenPista.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImagenPista.ForeColor = System.Drawing.Color.Black;
            this.ImagenPista.Location = new System.Drawing.Point(143, 119);
            this.ImagenPista.Name = "ImagenPista";
            this.ImagenPista.Size = new System.Drawing.Size(173, 28);
            this.ImagenPista.TabIndex = 62;
            this.ImagenPista.Text = "Cargar Imagen";
            this.ImagenPista.UseVisualStyleBackColor = false;
            this.ImagenPista.Click += new System.EventHandler(this.ImagenPista_Click);
            // 
            // ImagenBox
            // 
            this.ImagenBox.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImagenBox.Location = new System.Drawing.Point(114, 79);
            this.ImagenBox.MaxLength = 2500;
            this.ImagenBox.Name = "ImagenBox";
            this.ImagenBox.Size = new System.Drawing.Size(227, 31);
            this.ImagenBox.TabIndex = 66;
            // 
            // ImgLabel
            // 
            this.ImgLabel.AutoSize = true;
            this.ImgLabel.BackColor = System.Drawing.Color.Transparent;
            this.ImgLabel.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImgLabel.ForeColor = System.Drawing.Color.AliceBlue;
            this.ImgLabel.Location = new System.Drawing.Point(6, 78);
            this.ImgLabel.Name = "ImgLabel";
            this.ImgLabel.Size = new System.Drawing.Size(91, 30);
            this.ImgLabel.TabIndex = 65;
            this.ImgLabel.Text = "Imagen";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(133, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 38);
            this.button1.TabIndex = 68;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Agregar
            // 
            this.Agregar.BackColor = System.Drawing.Color.SpringGreen;
            this.Agregar.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.Agregar.FlatAppearance.BorderSize = 2;
            this.Agregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Agregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Agregar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Agregar.ForeColor = System.Drawing.Color.Black;
            this.Agregar.Location = new System.Drawing.Point(240, 186);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(101, 38);
            this.Agregar.TabIndex = 67;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = false;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // CargaMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(351, 242);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.ImagenBox);
            this.Controls.Add(this.ImgLabel);
            this.Controls.Add(this.ImagenPista);
            this.Controls.Add(this.NombreBox);
            this.Controls.Add(this.NombreLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CargaMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CargaMarca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.TextBox NombreBox;
        private System.Windows.Forms.Button ImagenPista;
        private System.Windows.Forms.TextBox ImagenBox;
        private System.Windows.Forms.Label ImgLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Agregar;
    }
}