
namespace Touge_App
{
    partial class CargarMusica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargarMusica));
            this.ImagenLabel = new System.Windows.Forms.Label();
            this.ImagenBox = new System.Windows.Forms.TextBox();
            this.NombreProductoLabel = new System.Windows.Forms.Label();
            this.NombreBox = new System.Windows.Forms.TextBox();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.MusicaLabel = new System.Windows.Forms.Label();
            this.Mp3Box = new System.Windows.Forms.TextBox();
            this.CargarMp3 = new System.Windows.Forms.Button();
            this.CargarImagen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ImagenLabel
            // 
            this.ImagenLabel.AutoSize = true;
            this.ImagenLabel.BackColor = System.Drawing.Color.Transparent;
            this.ImagenLabel.Font = new System.Drawing.Font("Segoe UI", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImagenLabel.ForeColor = System.Drawing.Color.White;
            this.ImagenLabel.Location = new System.Drawing.Point(10, 86);
            this.ImagenLabel.Name = "ImagenLabel";
            this.ImagenLabel.Size = new System.Drawing.Size(194, 40);
            this.ImagenLabel.TabIndex = 133;
            this.ImagenLabel.Text = "Imagen Tapa";
            // 
            // ImagenBox
            // 
            this.ImagenBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ImagenBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImagenBox.Location = new System.Drawing.Point(219, 94);
            this.ImagenBox.MaxLength = 2500;
            this.ImagenBox.Name = "ImagenBox";
            this.ImagenBox.Size = new System.Drawing.Size(293, 33);
            this.ImagenBox.TabIndex = 132;
            this.ImagenBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NombreProductoLabel
            // 
            this.NombreProductoLabel.AutoSize = true;
            this.NombreProductoLabel.BackColor = System.Drawing.Color.Transparent;
            this.NombreProductoLabel.Font = new System.Drawing.Font("Segoe UI", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreProductoLabel.ForeColor = System.Drawing.Color.White;
            this.NombreProductoLabel.Location = new System.Drawing.Point(24, 19);
            this.NombreProductoLabel.Name = "NombreProductoLabel";
            this.NombreProductoLabel.Size = new System.Drawing.Size(131, 40);
            this.NombreProductoLabel.TabIndex = 131;
            this.NombreProductoLabel.Text = "Nombre";
            // 
            // NombreBox
            // 
            this.NombreBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.NombreBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreBox.Location = new System.Drawing.Point(219, 26);
            this.NombreBox.MaxLength = 150;
            this.NombreBox.Name = "NombreBox";
            this.NombreBox.Size = new System.Drawing.Size(293, 33);
            this.NombreBox.TabIndex = 130;
            this.NombreBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cancelar
            // 
            this.Cancelar.BackColor = System.Drawing.Color.IndianRed;
            this.Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Cancelar.FlatAppearance.BorderSize = 2;
            this.Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelar.ForeColor = System.Drawing.Color.Gainsboro;
            this.Cancelar.Location = new System.Drawing.Point(12, 324);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(101, 38);
            this.Cancelar.TabIndex = 127;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = false;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
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
            this.Agregar.Location = new System.Drawing.Point(426, 324);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(101, 38);
            this.Agregar.TabIndex = 126;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = false;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // MusicaLabel
            // 
            this.MusicaLabel.AutoSize = true;
            this.MusicaLabel.BackColor = System.Drawing.Color.Transparent;
            this.MusicaLabel.Font = new System.Drawing.Font("Segoe UI", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MusicaLabel.ForeColor = System.Drawing.Color.White;
            this.MusicaLabel.Location = new System.Drawing.Point(8, 185);
            this.MusicaLabel.Name = "MusicaLabel";
            this.MusicaLabel.Size = new System.Drawing.Size(193, 40);
            this.MusicaLabel.TabIndex = 135;
            this.MusicaLabel.Text = "Archivo Mp3";
            // 
            // Mp3Box
            // 
            this.Mp3Box.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Mp3Box.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mp3Box.Location = new System.Drawing.Point(219, 192);
            this.Mp3Box.MaxLength = 2500;
            this.Mp3Box.Name = "Mp3Box";
            this.Mp3Box.Size = new System.Drawing.Size(293, 33);
            this.Mp3Box.TabIndex = 134;
            this.Mp3Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CargarMp3
            // 
            this.CargarMp3.BackColor = System.Drawing.Color.LawnGreen;
            this.CargarMp3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CargarMp3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargarMp3.ForeColor = System.Drawing.Color.Black;
            this.CargarMp3.Location = new System.Drawing.Point(303, 231);
            this.CargarMp3.Name = "CargarMp3";
            this.CargarMp3.Size = new System.Drawing.Size(138, 36);
            this.CargarMp3.TabIndex = 136;
            this.CargarMp3.Text = "Cargar Imagen";
            this.CargarMp3.UseVisualStyleBackColor = false;
            this.CargarMp3.Click += new System.EventHandler(this.CargarMp3_Click);
            // 
            // CargarImagen
            // 
            this.CargarImagen.BackColor = System.Drawing.Color.LawnGreen;
            this.CargarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CargarImagen.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargarImagen.ForeColor = System.Drawing.Color.Black;
            this.CargarImagen.Location = new System.Drawing.Point(303, 133);
            this.CargarImagen.Name = "CargarImagen";
            this.CargarImagen.Size = new System.Drawing.Size(138, 36);
            this.CargarImagen.TabIndex = 137;
            this.CargarImagen.Text = "Cargar Imagen";
            this.CargarImagen.UseVisualStyleBackColor = false;
            this.CargarImagen.Click += new System.EventHandler(this.CargarImagen_Click);
            // 
            // CargarMusica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(532, 374);
            this.Controls.Add(this.CargarImagen);
            this.Controls.Add(this.CargarMp3);
            this.Controls.Add(this.MusicaLabel);
            this.Controls.Add(this.Mp3Box);
            this.Controls.Add(this.ImagenLabel);
            this.Controls.Add(this.ImagenBox);
            this.Controls.Add(this.NombreProductoLabel);
            this.Controls.Add(this.NombreBox);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Agregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CargarMusica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CargarMusica";
            this.Load += new System.EventHandler(this.CargarMusica_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxBack_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxBack_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ImagenLabel;
        private System.Windows.Forms.TextBox ImagenBox;
        private System.Windows.Forms.Label NombreProductoLabel;
        private System.Windows.Forms.TextBox NombreBox;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Label MusicaLabel;
        private System.Windows.Forms.TextBox Mp3Box;
        private System.Windows.Forms.Button CargarMp3;
        private System.Windows.Forms.Button CargarImagen;
    }
}