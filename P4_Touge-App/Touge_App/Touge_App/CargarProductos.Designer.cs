
namespace Touge_App
{
    partial class CargarProductos
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
            this.Cancelar = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.IdBox = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.NombreProductoLabel = new System.Windows.Forms.Label();
            this.NombreBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PrecioBox = new System.Windows.Forms.TextBox();
            this.ImagenLabel = new System.Windows.Forms.Label();
            this.ImagenBox = new System.Windows.Forms.TextBox();
            this.ClaseLabel = new System.Windows.Forms.Label();
            this.CargarProducto = new System.Windows.Forms.Button();
            this.ClaseComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            this.Cancelar.Location = new System.Drawing.Point(203, 444);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(101, 38);
            this.Cancelar.TabIndex = 117;
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
            this.Agregar.Location = new System.Drawing.Point(325, 444);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(101, 38);
            this.Agregar.TabIndex = 116;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = false;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // IdBox
            // 
            this.IdBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.IdBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdBox.Location = new System.Drawing.Point(189, 29);
            this.IdBox.MaxLength = 5;
            this.IdBox.Name = "IdBox";
            this.IdBox.Size = new System.Drawing.Size(237, 33);
            this.IdBox.TabIndex = 118;
            this.IdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IdBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdBox_KeyPress);
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.BackColor = System.Drawing.Color.Transparent;
            this.IdLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.IdLabel.Location = new System.Drawing.Point(6, 26);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(175, 38);
            this.IdLabel.TabIndex = 119;
            this.IdLabel.Text = "ID Producto";
            // 
            // NombreProductoLabel
            // 
            this.NombreProductoLabel.AutoSize = true;
            this.NombreProductoLabel.BackColor = System.Drawing.Color.Transparent;
            this.NombreProductoLabel.Font = new System.Drawing.Font("Segoe UI", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreProductoLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.NombreProductoLabel.Location = new System.Drawing.Point(25, 102);
            this.NombreProductoLabel.Name = "NombreProductoLabel";
            this.NombreProductoLabel.Size = new System.Drawing.Size(131, 40);
            this.NombreProductoLabel.TabIndex = 121;
            this.NombreProductoLabel.Text = "Nombre";
            // 
            // NombreBox
            // 
            this.NombreBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.NombreBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreBox.Location = new System.Drawing.Point(189, 107);
            this.NombreBox.MaxLength = 200;
            this.NombreBox.Name = "NombreBox";
            this.NombreBox.Size = new System.Drawing.Size(237, 33);
            this.NombreBox.TabIndex = 120;
            this.NombreBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(38, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 40);
            this.label1.TabIndex = 123;
            this.label1.Text = "Precio";
            // 
            // PrecioBox
            // 
            this.PrecioBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PrecioBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioBox.Location = new System.Drawing.Point(189, 185);
            this.PrecioBox.MaxLength = 6;
            this.PrecioBox.Name = "PrecioBox";
            this.PrecioBox.Size = new System.Drawing.Size(237, 33);
            this.PrecioBox.TabIndex = 122;
            this.PrecioBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PrecioBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdBox_KeyPress);
            // 
            // ImagenLabel
            // 
            this.ImagenLabel.AutoSize = true;
            this.ImagenLabel.BackColor = System.Drawing.Color.Transparent;
            this.ImagenLabel.Font = new System.Drawing.Font("Segoe UI", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImagenLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ImagenLabel.Location = new System.Drawing.Point(25, 264);
            this.ImagenLabel.Name = "ImagenLabel";
            this.ImagenLabel.Size = new System.Drawing.Size(121, 40);
            this.ImagenLabel.TabIndex = 125;
            this.ImagenLabel.Text = "Imagen";
            // 
            // ImagenBox
            // 
            this.ImagenBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ImagenBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImagenBox.Location = new System.Drawing.Point(189, 269);
            this.ImagenBox.MaxLength = 2500;
            this.ImagenBox.Name = "ImagenBox";
            this.ImagenBox.Size = new System.Drawing.Size(237, 33);
            this.ImagenBox.TabIndex = 124;
            this.ImagenBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ClaseLabel
            // 
            this.ClaseLabel.AutoSize = true;
            this.ClaseLabel.BackColor = System.Drawing.Color.Transparent;
            this.ClaseLabel.Font = new System.Drawing.Font("Segoe UI", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClaseLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ClaseLabel.Location = new System.Drawing.Point(6, 361);
            this.ClaseLabel.Name = "ClaseLabel";
            this.ClaseLabel.Size = new System.Drawing.Size(170, 40);
            this.ClaseLabel.TabIndex = 126;
            this.ClaseLabel.Text = "Clase Prod.";
            // 
            // CargarProducto
            // 
            this.CargarProducto.BackColor = System.Drawing.Color.LawnGreen;
            this.CargarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CargarProducto.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargarProducto.ForeColor = System.Drawing.Color.Black;
            this.CargarProducto.Location = new System.Drawing.Point(239, 308);
            this.CargarProducto.Name = "CargarProducto";
            this.CargarProducto.Size = new System.Drawing.Size(138, 36);
            this.CargarProducto.TabIndex = 127;
            this.CargarProducto.Text = "Cargar Imagen";
            this.CargarProducto.UseVisualStyleBackColor = false;
            this.CargarProducto.Click += new System.EventHandler(this.CargarProducto_Click);
            // 
            // ClaseComboBox
            // 
            this.ClaseComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.ClaseComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ClaseComboBox.BackColor = System.Drawing.Color.Orange;
            this.ClaseComboBox.DropDownHeight = 100;
            this.ClaseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClaseComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClaseComboBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClaseComboBox.ForeColor = System.Drawing.Color.Black;
            this.ClaseComboBox.FormattingEnabled = true;
            this.ClaseComboBox.IntegralHeight = false;
            this.ClaseComboBox.ItemHeight = 25;
            this.ClaseComboBox.Location = new System.Drawing.Point(189, 369);
            this.ClaseComboBox.MaxDropDownItems = 20;
            this.ClaseComboBox.Name = "ClaseComboBox";
            this.ClaseComboBox.Size = new System.Drawing.Size(237, 33);
            this.ClaseComboBox.TabIndex = 128;
            // 
            // CargarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(449, 496);
            this.Controls.Add(this.ClaseComboBox);
            this.Controls.Add(this.CargarProducto);
            this.Controls.Add(this.ClaseLabel);
            this.Controls.Add(this.ImagenLabel);
            this.Controls.Add(this.ImagenBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrecioBox);
            this.Controls.Add(this.NombreProductoLabel);
            this.Controls.Add(this.NombreBox);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.IdBox);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Agregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CargarProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CargarProductos";
            this.Load += new System.EventHandler(this.CargarProductos_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.TextBox IdBox;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label NombreProductoLabel;
        private System.Windows.Forms.TextBox NombreBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PrecioBox;
        private System.Windows.Forms.Label ImagenLabel;
        private System.Windows.Forms.TextBox ImagenBox;
        private System.Windows.Forms.Label ClaseLabel;
        private System.Windows.Forms.Button CargarProducto;
        private System.Windows.Forms.ComboBox ClaseComboBox;
    }
}