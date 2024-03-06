
namespace Touge_App
{
    partial class FiltroPistas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltroPistas));
            this.AutoComboBox = new System.Windows.Forms.ComboBox();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Buscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AutoComboBox
            // 
            this.AutoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.AutoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.AutoComboBox.BackColor = System.Drawing.Color.Orange;
            this.AutoComboBox.DropDownHeight = 150;
            this.AutoComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AutoComboBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoComboBox.ForeColor = System.Drawing.Color.Black;
            this.AutoComboBox.FormattingEnabled = true;
            this.AutoComboBox.IntegralHeight = false;
            this.AutoComboBox.ItemHeight = 25;
            this.AutoComboBox.Location = new System.Drawing.Point(10, 60);
            this.AutoComboBox.MaxDropDownItems = 20;
            this.AutoComboBox.Name = "AutoComboBox";
            this.AutoComboBox.Size = new System.Drawing.Size(400, 33);
            this.AutoComboBox.TabIndex = 133;
            // 
            // NombreLabel
            // 
            this.NombreLabel.BackColor = System.Drawing.Color.Transparent;
            this.NombreLabel.Font = new System.Drawing.Font("Segoe UI", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreLabel.ForeColor = System.Drawing.Color.White;
            this.NombreLabel.Location = new System.Drawing.Point(10, 9);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(400, 38);
            this.NombreLabel.TabIndex = 132;
            this.NombreLabel.Text = "Nombre Pista";
            this.NombreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Cancelar.Location = new System.Drawing.Point(12, 356);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(101, 38);
            this.Cancelar.TabIndex = 134;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = false;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Buscar
            // 
            this.Buscar.BackColor = System.Drawing.Color.SpringGreen;
            this.Buscar.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.Buscar.FlatAppearance.BorderSize = 2;
            this.Buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Buscar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscar.ForeColor = System.Drawing.Color.Black;
            this.Buscar.Location = new System.Drawing.Point(300, 356);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(101, 38);
            this.Buscar.TabIndex = 133;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = false;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // FiltroPistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(418, 412);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.NombreLabel);
            this.Controls.Add(this.AutoComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FiltroPistas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FiltroPistas";
            this.Load += new System.EventHandler(this.FiltroPistas_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxBack_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxBack_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox AutoComboBox;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Buscar;
    }
}