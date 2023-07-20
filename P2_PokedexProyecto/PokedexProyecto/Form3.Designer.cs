
namespace PokedexProyecto
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.HPNumber = new System.Windows.Forms.Label();
            this.EspNumber = new System.Windows.Forms.Label();
            this.AtaqueNumber = new System.Windows.Forms.Label();
            this.DefNumber = new System.Windows.Forms.Label();
            this.VelNumber = new System.Windows.Forms.Label();
            this.EspDefNumber = new System.Windows.Forms.Label();
            this.EspBar = new System.Windows.Forms.ProgressBar();
            this.AtaqueBar = new System.Windows.Forms.ProgressBar();
            this.DefensaBar = new System.Windows.Forms.ProgressBar();
            this.DefEspBar = new System.Windows.Forms.ProgressBar();
            this.VelocidadBar = new System.Windows.Forms.ProgressBar();
            this.HpBar = new System.Windows.Forms.ProgressBar();
            this.SiguienteBoton = new System.Windows.Forms.Button();
            this.AtrasBoton = new System.Windows.Forms.Button();
            this.PokemonBox = new System.Windows.Forms.PictureBox();
            this.CloseStats = new PokedexProyecto.BotonCircular();
            ((System.ComponentModel.ISupportInitialize)(this.PokemonBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "HP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "DefensaEsp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ataque";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "AtaqueEsp ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Defensa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Velocidad";
            // 
            // HPNumber
            // 
            this.HPNumber.AutoSize = true;
            this.HPNumber.BackColor = System.Drawing.Color.Transparent;
            this.HPNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HPNumber.Location = new System.Drawing.Point(479, 193);
            this.HPNumber.Name = "HPNumber";
            this.HPNumber.Size = new System.Drawing.Size(43, 24);
            this.HPNumber.TabIndex = 12;
            this.HPNumber.Text = "000";
            this.HPNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EspNumber
            // 
            this.EspNumber.AutoSize = true;
            this.EspNumber.BackColor = System.Drawing.Color.Transparent;
            this.EspNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EspNumber.Location = new System.Drawing.Point(479, 334);
            this.EspNumber.Name = "EspNumber";
            this.EspNumber.Size = new System.Drawing.Size(43, 24);
            this.EspNumber.TabIndex = 13;
            this.EspNumber.Text = "000";
            // 
            // AtaqueNumber
            // 
            this.AtaqueNumber.AutoSize = true;
            this.AtaqueNumber.BackColor = System.Drawing.Color.Transparent;
            this.AtaqueNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AtaqueNumber.Location = new System.Drawing.Point(479, 238);
            this.AtaqueNumber.Name = "AtaqueNumber";
            this.AtaqueNumber.Size = new System.Drawing.Size(43, 24);
            this.AtaqueNumber.TabIndex = 14;
            this.AtaqueNumber.Text = "000";
            this.AtaqueNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DefNumber
            // 
            this.DefNumber.AutoSize = true;
            this.DefNumber.BackColor = System.Drawing.Color.Transparent;
            this.DefNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefNumber.Location = new System.Drawing.Point(479, 285);
            this.DefNumber.Name = "DefNumber";
            this.DefNumber.Size = new System.Drawing.Size(43, 24);
            this.DefNumber.TabIndex = 15;
            this.DefNumber.Text = "000";
            // 
            // VelNumber
            // 
            this.VelNumber.AutoSize = true;
            this.VelNumber.BackColor = System.Drawing.Color.Transparent;
            this.VelNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VelNumber.Location = new System.Drawing.Point(478, 429);
            this.VelNumber.Name = "VelNumber";
            this.VelNumber.Size = new System.Drawing.Size(48, 25);
            this.VelNumber.TabIndex = 16;
            this.VelNumber.Text = "000";
            this.VelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EspDefNumber
            // 
            this.EspDefNumber.AutoSize = true;
            this.EspDefNumber.BackColor = System.Drawing.Color.Transparent;
            this.EspDefNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EspDefNumber.Location = new System.Drawing.Point(479, 381);
            this.EspDefNumber.Name = "EspDefNumber";
            this.EspDefNumber.Size = new System.Drawing.Size(43, 24);
            this.EspDefNumber.TabIndex = 18;
            this.EspDefNumber.Text = "000";
            // 
            // EspBar
            // 
            this.EspBar.ForeColor = System.Drawing.Color.Red;
            this.EspBar.Location = new System.Drawing.Point(114, 334);
            this.EspBar.Maximum = 200;
            this.EspBar.Name = "EspBar";
            this.EspBar.Size = new System.Drawing.Size(362, 23);
            this.EspBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.EspBar.TabIndex = 20;
            // 
            // AtaqueBar
            // 
            this.AtaqueBar.ForeColor = System.Drawing.Color.Red;
            this.AtaqueBar.Location = new System.Drawing.Point(114, 240);
            this.AtaqueBar.Maximum = 200;
            this.AtaqueBar.Name = "AtaqueBar";
            this.AtaqueBar.Size = new System.Drawing.Size(362, 23);
            this.AtaqueBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.AtaqueBar.TabIndex = 21;
            // 
            // DefensaBar
            // 
            this.DefensaBar.ForeColor = System.Drawing.Color.Red;
            this.DefensaBar.Location = new System.Drawing.Point(114, 286);
            this.DefensaBar.Maximum = 200;
            this.DefensaBar.Name = "DefensaBar";
            this.DefensaBar.Size = new System.Drawing.Size(362, 23);
            this.DefensaBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.DefensaBar.TabIndex = 22;
            // 
            // DefEspBar
            // 
            this.DefEspBar.ForeColor = System.Drawing.Color.Red;
            this.DefEspBar.Location = new System.Drawing.Point(114, 381);
            this.DefEspBar.Maximum = 200;
            this.DefEspBar.Name = "DefEspBar";
            this.DefEspBar.Size = new System.Drawing.Size(362, 23);
            this.DefEspBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.DefEspBar.TabIndex = 23;
            // 
            // VelocidadBar
            // 
            this.VelocidadBar.ForeColor = System.Drawing.Color.Red;
            this.VelocidadBar.Location = new System.Drawing.Point(114, 429);
            this.VelocidadBar.Maximum = 200;
            this.VelocidadBar.Name = "VelocidadBar";
            this.VelocidadBar.Size = new System.Drawing.Size(362, 23);
            this.VelocidadBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.VelocidadBar.TabIndex = 24;
            // 
            // HpBar
            // 
            this.HpBar.ForeColor = System.Drawing.Color.Red;
            this.HpBar.Location = new System.Drawing.Point(114, 194);
            this.HpBar.Maximum = 200;
            this.HpBar.Name = "HpBar";
            this.HpBar.Size = new System.Drawing.Size(362, 23);
            this.HpBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.HpBar.TabIndex = 25;
            // 
            // SiguienteBoton
            // 
            this.SiguienteBoton.BackColor = System.Drawing.Color.OrangeRed;
            this.SiguienteBoton.FlatAppearance.BorderSize = 0;
            this.SiguienteBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.SiguienteBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.SiguienteBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SiguienteBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SiguienteBoton.Location = new System.Drawing.Point(355, 517);
            this.SiguienteBoton.Name = "SiguienteBoton";
            this.SiguienteBoton.Size = new System.Drawing.Size(98, 33);
            this.SiguienteBoton.TabIndex = 26;
            this.SiguienteBoton.Text = "Siguiente";
            this.SiguienteBoton.UseVisualStyleBackColor = false;
            this.SiguienteBoton.Click += new System.EventHandler(this.SiguienteBoton_Click);
            // 
            // AtrasBoton
            // 
            this.AtrasBoton.BackColor = System.Drawing.Color.OrangeRed;
            this.AtrasBoton.FlatAppearance.BorderSize = 0;
            this.AtrasBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.AtrasBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.AtrasBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AtrasBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AtrasBoton.Location = new System.Drawing.Point(83, 517);
            this.AtrasBoton.Name = "AtrasBoton";
            this.AtrasBoton.Size = new System.Drawing.Size(89, 33);
            this.AtrasBoton.TabIndex = 27;
            this.AtrasBoton.Text = "Anterior";
            this.AtrasBoton.UseVisualStyleBackColor = false;
            this.AtrasBoton.Click += new System.EventHandler(this.AtrasBoton_Click);
            // 
            // PokemonBox
            // 
            this.PokemonBox.BackColor = System.Drawing.Color.Transparent;
            this.PokemonBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PokemonBox.Location = new System.Drawing.Point(208, 458);
            this.PokemonBox.Name = "PokemonBox";
            this.PokemonBox.Size = new System.Drawing.Size(120, 110);
            this.PokemonBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PokemonBox.TabIndex = 28;
            this.PokemonBox.TabStop = false;
            this.PokemonBox.Click += new System.EventHandler(this.PokemonBox_Click);
            this.PokemonBox.MouseEnter += new System.EventHandler(this.PokemonBox_MouseEnter);
            this.PokemonBox.MouseLeave += new System.EventHandler(this.PokemonBox_MouseLeave);
            // 
            // CloseStats
            // 
            this.CloseStats.BackColor = System.Drawing.Color.Transparent;
            this.CloseStats.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CloseStats.FlatAppearance.BorderSize = 0;
            this.CloseStats.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.CloseStats.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.CloseStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseStats.ForeColor = System.Drawing.Color.Transparent;
            this.CloseStats.Location = new System.Drawing.Point(170, 48);
            this.CloseStats.Name = "CloseStats";
            this.CloseStats.Size = new System.Drawing.Size(176, 140);
            this.CloseStats.TabIndex = 19;
            this.CloseStats.UseVisualStyleBackColor = false;
            this.CloseStats.Click += new System.EventHandler(this.CloseStats_Click);
            this.CloseStats.MouseEnter += new System.EventHandler(this.CloseStats_MouseEnter);
            this.CloseStats.MouseLeave += new System.EventHandler(this.CloseStats_MouseLeave);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(523, 682);
            this.Controls.Add(this.PokemonBox);
            this.Controls.Add(this.AtrasBoton);
            this.Controls.Add(this.SiguienteBoton);
            this.Controls.Add(this.HpBar);
            this.Controls.Add(this.VelocidadBar);
            this.Controls.Add(this.DefEspBar);
            this.Controls.Add(this.DefensaBar);
            this.Controls.Add(this.AtaqueBar);
            this.Controls.Add(this.EspBar);
            this.Controls.Add(this.CloseStats);
            this.Controls.Add(this.EspDefNumber);
            this.Controls.Add(this.VelNumber);
            this.Controls.Add(this.DefNumber);
            this.Controls.Add(this.AtaqueNumber);
            this.Controls.Add(this.EspNumber);
            this.Controls.Add(this.HPNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stats Base";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form3_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form3_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.PokemonBox)).EndInit();
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
        private System.Windows.Forms.Label HPNumber;
        private System.Windows.Forms.Label EspNumber;
        private System.Windows.Forms.Label AtaqueNumber;
        private System.Windows.Forms.Label DefNumber;
        private System.Windows.Forms.Label VelNumber;
        private System.Windows.Forms.Label EspDefNumber;
        private BotonCircular CloseStats;
        private System.Windows.Forms.ProgressBar EspBar;
        private System.Windows.Forms.ProgressBar AtaqueBar;
        private System.Windows.Forms.ProgressBar DefensaBar;
        private System.Windows.Forms.ProgressBar DefEspBar;
        private System.Windows.Forms.ProgressBar VelocidadBar;
        private System.Windows.Forms.ProgressBar HpBar;
        private System.Windows.Forms.Button SiguienteBoton;
        private System.Windows.Forms.Button AtrasBoton;
        private System.Windows.Forms.PictureBox PokemonBox;
    }
}