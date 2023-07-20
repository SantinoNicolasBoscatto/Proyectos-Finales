
namespace AppCodigoDeArticulos
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CodigoBox = new System.Windows.Forms.TextBox();
            this.NombreBox = new System.Windows.Forms.TextBox();
            this.ImagenBox = new System.Windows.Forms.TextBox();
            this.PrecioBox = new System.Windows.Forms.TextBox();
            this.DescripcionBox = new System.Windows.Forms.TextBox();
            this.ImagenPictureBox = new System.Windows.Forms.PictureBox();
            this.AgregarBoton = new System.Windows.Forms.Button();
            this.CancelarBoton = new System.Windows.Forms.Button();
            this.CategoriaCombo = new System.Windows.Forms.ComboBox();
            this.MarcaCombo = new System.Windows.Forms.ComboBox();
            this.CargarPc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo del articulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del articulo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripcion del Art.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(21, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Marca del articulo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Categoria del articulo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Imagen del articulo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(21, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Precio del articulo";
            // 
            // CodigoBox
            // 
            this.CodigoBox.BackColor = System.Drawing.SystemColors.Control;
            this.CodigoBox.Location = new System.Drawing.Point(195, 9);
            this.CodigoBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CodigoBox.MaxLength = 5;
            this.CodigoBox.Name = "CodigoBox";
            this.CodigoBox.Size = new System.Drawing.Size(211, 22);
            this.CodigoBox.TabIndex = 0;
            this.CodigoBox.TextChanged += new System.EventHandler(this.CodigoBox_TextChanged);
            this.CodigoBox.Leave += new System.EventHandler(this.CodigoBox_Leave);
            // 
            // NombreBox
            // 
            this.NombreBox.BackColor = System.Drawing.SystemColors.Control;
            this.NombreBox.Location = new System.Drawing.Point(195, 60);
            this.NombreBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NombreBox.MaxLength = 100;
            this.NombreBox.Name = "NombreBox";
            this.NombreBox.Size = new System.Drawing.Size(211, 22);
            this.NombreBox.TabIndex = 1;
            this.NombreBox.TextChanged += new System.EventHandler(this.NombreBox_TextChanged);
            this.NombreBox.Leave += new System.EventHandler(this.NombreBox_Leave);
            // 
            // ImagenBox
            // 
            this.ImagenBox.BackColor = System.Drawing.SystemColors.Control;
            this.ImagenBox.Location = new System.Drawing.Point(195, 159);
            this.ImagenBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImagenBox.MaxLength = 1000;
            this.ImagenBox.Name = "ImagenBox";
            this.ImagenBox.Size = new System.Drawing.Size(211, 22);
            this.ImagenBox.TabIndex = 3;
            this.ImagenBox.TextChanged += new System.EventHandler(this.ImagenBox_TextChanged);
            this.ImagenBox.Leave += new System.EventHandler(this.ImagenBox_Leave);
            // 
            // PrecioBox
            // 
            this.PrecioBox.BackColor = System.Drawing.SystemColors.Control;
            this.PrecioBox.Location = new System.Drawing.Point(195, 225);
            this.PrecioBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrecioBox.MaxLength = 10;
            this.PrecioBox.Name = "PrecioBox";
            this.PrecioBox.Size = new System.Drawing.Size(211, 22);
            this.PrecioBox.TabIndex = 4;
            this.PrecioBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrecioBox_KeyPress);
            this.PrecioBox.Leave += new System.EventHandler(this.PrecioBox_Leave);
            // 
            // DescripcionBox
            // 
            this.DescripcionBox.BackColor = System.Drawing.SystemColors.Control;
            this.DescripcionBox.Location = new System.Drawing.Point(195, 112);
            this.DescripcionBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DescripcionBox.MaxLength = 250;
            this.DescripcionBox.Name = "DescripcionBox";
            this.DescripcionBox.Size = new System.Drawing.Size(211, 22);
            this.DescripcionBox.TabIndex = 2;
            this.DescripcionBox.TextChanged += new System.EventHandler(this.DescripcionBox_TextChanged);
            this.DescripcionBox.Leave += new System.EventHandler(this.DescripcionBox_Leave);
            // 
            // ImagenPictureBox
            // 
            this.ImagenPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ImagenPictureBox.Location = new System.Drawing.Point(428, 60);
            this.ImagenPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImagenPictureBox.Name = "ImagenPictureBox";
            this.ImagenPictureBox.Size = new System.Drawing.Size(210, 210);
            this.ImagenPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagenPictureBox.TabIndex = 14;
            this.ImagenPictureBox.TabStop = false;
            // 
            // AgregarBoton
            // 
            this.AgregarBoton.BackColor = System.Drawing.Color.Navy;
            this.AgregarBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.AgregarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.AgregarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgregarBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarBoton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AgregarBoton.Location = new System.Drawing.Point(422, 318);
            this.AgregarBoton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AgregarBoton.Name = "AgregarBoton";
            this.AgregarBoton.Size = new System.Drawing.Size(105, 39);
            this.AgregarBoton.TabIndex = 7;
            this.AgregarBoton.Text = "Agregar";
            this.AgregarBoton.UseVisualStyleBackColor = false;
            this.AgregarBoton.Click += new System.EventHandler(this.AgregarBoton_Click);
            // 
            // CancelarBoton
            // 
            this.CancelarBoton.BackColor = System.Drawing.Color.Navy;
            this.CancelarBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CancelarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.CancelarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelarBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarBoton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelarBoton.Location = new System.Drawing.Point(541, 318);
            this.CancelarBoton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelarBoton.Name = "CancelarBoton";
            this.CancelarBoton.Size = new System.Drawing.Size(105, 39);
            this.CancelarBoton.TabIndex = 8;
            this.CancelarBoton.Text = "Cancelar";
            this.CancelarBoton.UseVisualStyleBackColor = false;
            this.CancelarBoton.Click += new System.EventHandler(this.CancelarBoton_Click);
            // 
            // CategoriaCombo
            // 
            this.CategoriaCombo.BackColor = System.Drawing.SystemColors.Control;
            this.CategoriaCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriaCombo.FormattingEnabled = true;
            this.CategoriaCombo.Location = new System.Drawing.Point(195, 276);
            this.CategoriaCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CategoriaCombo.Name = "CategoriaCombo";
            this.CategoriaCombo.Size = new System.Drawing.Size(211, 24);
            this.CategoriaCombo.TabIndex = 5;
            // 
            // MarcaCombo
            // 
            this.MarcaCombo.BackColor = System.Drawing.SystemColors.Control;
            this.MarcaCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MarcaCombo.FormattingEnabled = true;
            this.MarcaCombo.Location = new System.Drawing.Point(195, 323);
            this.MarcaCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MarcaCombo.Name = "MarcaCombo";
            this.MarcaCombo.Size = new System.Drawing.Size(211, 24);
            this.MarcaCombo.TabIndex = 6;
            // 
            // CargarPc
            // 
            this.CargarPc.Location = new System.Drawing.Point(223, 186);
            this.CargarPc.Margin = new System.Windows.Forms.Padding(4);
            this.CargarPc.Name = "CargarPc";
            this.CargarPc.Size = new System.Drawing.Size(159, 28);
            this.CargarPc.TabIndex = 15;
            this.CargarPc.Text = "Cargar Desde la PC";
            this.CargarPc.UseVisualStyleBackColor = true;
            this.CargarPc.Click += new System.EventHandler(this.CargarPc_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(651, 372);
            this.Controls.Add(this.CargarPc);
            this.Controls.Add(this.MarcaCombo);
            this.Controls.Add(this.CategoriaCombo);
            this.Controls.Add(this.CancelarBoton);
            this.Controls.Add(this.AgregarBoton);
            this.Controls.Add(this.ImagenPictureBox);
            this.Controls.Add(this.DescripcionBox);
            this.Controls.Add(this.PrecioBox);
            this.Controls.Add(this.ImagenBox);
            this.Controls.Add(this.NombreBox);
            this.Controls.Add(this.CodigoBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar Articulo";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CodigoBox;
        private System.Windows.Forms.TextBox NombreBox;
        private System.Windows.Forms.TextBox ImagenBox;
        private System.Windows.Forms.TextBox PrecioBox;
        private System.Windows.Forms.TextBox DescripcionBox;
        private System.Windows.Forms.PictureBox ImagenPictureBox;
        private System.Windows.Forms.Button AgregarBoton;
        private System.Windows.Forms.Button CancelarBoton;
        private System.Windows.Forms.ComboBox CategoriaCombo;
        private System.Windows.Forms.ComboBox MarcaCombo;
        private System.Windows.Forms.Button CargarPc;
    }
}