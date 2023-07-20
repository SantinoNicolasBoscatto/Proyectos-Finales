
using System.Drawing;

namespace PokedexProyecto
{
    partial class frmPokemons
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPokemons));
            this.SiguientePokemon = new System.Windows.Forms.Button();
            this.AnteriorPokemon = new System.Windows.Forms.Button();
            this.alphaBlendTextBox1 = new ZBobb.AlphaBlendTextBox();
            this.Buscar = new System.Windows.Forms.Button();
            this.Sprite3d = new System.Windows.Forms.Button();
            this.NumeroBox = new ZBobb.AlphaBlendTextBox();
            this.PictureBoxPokemon = new System.Windows.Forms.PictureBox();
            this.Pokedex = new System.Windows.Forms.PictureBox();
            this.StatsBaseBoton = new System.Windows.Forms.Button();
            this.VerTipoBoton = new System.Windows.Forms.Button();
            this.TipoBox1 = new System.Windows.Forms.PictureBox();
            this.TipoBox2 = new System.Windows.Forms.PictureBox();
            this.ModificarBoton = new System.Windows.Forms.Button();
            this.GritoBoton = new PokedexProyecto.BotonCircular();
            this.Agregar = new PokedexProyecto.BotonCircular();
            this.Apagado = new PokedexProyecto.BotonCircular();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPokemon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pokedex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // SiguientePokemon
            // 
            this.SiguientePokemon.BackColor = System.Drawing.Color.Transparent;
            this.SiguientePokemon.FlatAppearance.BorderSize = 0;
            this.SiguientePokemon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.SiguientePokemon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SiguientePokemon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SiguientePokemon.Location = new System.Drawing.Point(344, 384);
            this.SiguientePokemon.Name = "SiguientePokemon";
            this.SiguientePokemon.Size = new System.Drawing.Size(29, 34);
            this.SiguientePokemon.TabIndex = 3;
            this.SiguientePokemon.UseVisualStyleBackColor = false;
            this.SiguientePokemon.Click += new System.EventHandler(this.SiguientePokemon_Click);
            // 
            // AnteriorPokemon
            // 
            this.AnteriorPokemon.BackColor = System.Drawing.Color.Transparent;
            this.AnteriorPokemon.FlatAppearance.BorderSize = 0;
            this.AnteriorPokemon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.AnteriorPokemon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AnteriorPokemon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnteriorPokemon.Location = new System.Drawing.Point(274, 384);
            this.AnteriorPokemon.Name = "AnteriorPokemon";
            this.AnteriorPokemon.Size = new System.Drawing.Size(29, 34);
            this.AnteriorPokemon.TabIndex = 4;
            this.AnteriorPokemon.UseVisualStyleBackColor = false;
            this.AnteriorPokemon.Click += new System.EventHandler(this.AnteriorPokemon_Click);
            // 
            // alphaBlendTextBox1
            // 
            this.alphaBlendTextBox1.BackAlpha = 10;
            this.alphaBlendTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.alphaBlendTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alphaBlendTextBox1.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaBlendTextBox1.Location = new System.Drawing.Point(487, 54);
            this.alphaBlendTextBox1.Multiline = true;
            this.alphaBlendTextBox1.Name = "alphaBlendTextBox1";
            this.alphaBlendTextBox1.ReadOnly = true;
            this.alphaBlendTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.alphaBlendTextBox1.Size = new System.Drawing.Size(309, 134);
            this.alphaBlendTextBox1.TabIndex = 5;
            // 
            // Buscar
            // 
            this.Buscar.FlatAppearance.BorderSize = 0;
            this.Buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscar.Location = new System.Drawing.Point(529, 420);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(103, 41);
            this.Buscar.TabIndex = 6;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // Sprite3d
            // 
            this.Sprite3d.BackColor = System.Drawing.Color.Transparent;
            this.Sprite3d.FlatAppearance.BorderSize = 0;
            this.Sprite3d.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Sprite3d.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.Sprite3d.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sprite3d.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sprite3d.ForeColor = System.Drawing.Color.White;
            this.Sprite3d.Location = new System.Drawing.Point(503, 215);
            this.Sprite3d.Name = "Sprite3d";
            this.Sprite3d.Size = new System.Drawing.Size(53, 43);
            this.Sprite3d.TabIndex = 10;
            this.Sprite3d.Text = "3D";
            this.Sprite3d.UseVisualStyleBackColor = false;
            this.Sprite3d.Click += new System.EventHandler(this.Sprite3d_Click);
            // 
            // NumeroBox
            // 
            this.NumeroBox.BackAlpha = 10;
            this.NumeroBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NumeroBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumeroBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumeroBox.Location = new System.Drawing.Point(151, 409);
            this.NumeroBox.Multiline = true;
            this.NumeroBox.Name = "NumeroBox";
            this.NumeroBox.Size = new System.Drawing.Size(67, 35);
            this.NumeroBox.TabIndex = 13;
            this.NumeroBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumeroBox.TextChanged += new System.EventHandler(this.NumeroBox_TextChanged);
            this.NumeroBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumeroBox_KeyPress);
            this.NumeroBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumeroBox_KeyUp);
            // 
            // PictureBoxPokemon
            // 
            this.PictureBoxPokemon.BackColor = System.Drawing.Color.DimGray;
            this.PictureBoxPokemon.Location = new System.Drawing.Point(103, 79);
            this.PictureBoxPokemon.Name = "PictureBoxPokemon";
            this.PictureBoxPokemon.Size = new System.Drawing.Size(200, 160);
            this.PictureBoxPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxPokemon.TabIndex = 1;
            this.PictureBoxPokemon.TabStop = false;
            // 
            // Pokedex
            // 
            this.Pokedex.Image = global::PokedexProyecto.Properties.Resources.Poke;
            this.Pokedex.Location = new System.Drawing.Point(-1, 0);
            this.Pokedex.Name = "Pokedex";
            this.Pokedex.Size = new System.Drawing.Size(833, 470);
            this.Pokedex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pokedex.TabIndex = 0;
            this.Pokedex.TabStop = false;
            this.Pokedex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseDown);
            this.Pokedex.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseMove);
            // 
            // StatsBaseBoton
            // 
            this.StatsBaseBoton.FlatAppearance.BorderSize = 0;
            this.StatsBaseBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.StatsBaseBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.StatsBaseBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatsBaseBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatsBaseBoton.Location = new System.Drawing.Point(655, 420);
            this.StatsBaseBoton.Name = "StatsBaseBoton";
            this.StatsBaseBoton.Size = new System.Drawing.Size(103, 41);
            this.StatsBaseBoton.TabIndex = 14;
            this.StatsBaseBoton.Text = "Stats";
            this.StatsBaseBoton.UseVisualStyleBackColor = true;
            this.StatsBaseBoton.Click += new System.EventHandler(this.StatsBaseBoton_Click);
            // 
            // VerTipoBoton
            // 
            this.VerTipoBoton.BackColor = System.Drawing.Color.Transparent;
            this.VerTipoBoton.FlatAppearance.BorderSize = 0;
            this.VerTipoBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.VerTipoBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.VerTipoBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerTipoBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerTipoBoton.ForeColor = System.Drawing.Color.White;
            this.VerTipoBoton.Location = new System.Drawing.Point(503, 259);
            this.VerTipoBoton.Name = "VerTipoBoton";
            this.VerTipoBoton.Size = new System.Drawing.Size(53, 43);
            this.VerTipoBoton.TabIndex = 16;
            this.VerTipoBoton.Text = "Tipo";
            this.VerTipoBoton.UseVisualStyleBackColor = false;
            this.VerTipoBoton.Click += new System.EventHandler(this.VerTipoBoton_Click);
            // 
            // TipoBox1
            // 
            this.TipoBox1.Location = new System.Drawing.Point(557, 86);
            this.TipoBox1.Name = "TipoBox1";
            this.TipoBox1.Size = new System.Drawing.Size(162, 35);
            this.TipoBox1.TabIndex = 17;
            this.TipoBox1.TabStop = false;
            this.TipoBox1.Visible = false;
            // 
            // TipoBox2
            // 
            this.TipoBox2.Location = new System.Drawing.Point(558, 134);
            this.TipoBox2.Name = "TipoBox2";
            this.TipoBox2.Size = new System.Drawing.Size(162, 35);
            this.TipoBox2.TabIndex = 18;
            this.TipoBox2.TabStop = false;
            this.TipoBox2.Visible = false;
            // 
            // ModificarBoton
            // 
            this.ModificarBoton.BackColor = System.Drawing.Color.Transparent;
            this.ModificarBoton.FlatAppearance.BorderSize = 0;
            this.ModificarBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ModificarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.ModificarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModificarBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModificarBoton.ForeColor = System.Drawing.Color.White;
            this.ModificarBoton.Location = new System.Drawing.Point(724, 215);
            this.ModificarBoton.Name = "ModificarBoton";
            this.ModificarBoton.Size = new System.Drawing.Size(53, 43);
            this.ModificarBoton.TabIndex = 19;
            this.ModificarBoton.Text = "Mod";
            this.ModificarBoton.UseVisualStyleBackColor = false;
            this.ModificarBoton.Click += new System.EventHandler(this.ModificarBoton_Click);
            // 
            // GritoBoton
            // 
            this.GritoBoton.BackColor = System.Drawing.Color.Transparent;
            this.GritoBoton.FlatAppearance.BorderSize = 0;
            this.GritoBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.GritoBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.GritoBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GritoBoton.Location = new System.Drawing.Point(93, 258);
            this.GritoBoton.Name = "GritoBoton";
            this.GritoBoton.Size = new System.Drawing.Size(36, 36);
            this.GritoBoton.TabIndex = 12;
            this.GritoBoton.UseVisualStyleBackColor = false;
            this.GritoBoton.Click += new System.EventHandler(this.GritoBoton_Click);
            // 
            // Agregar
            // 
            this.Agregar.BackColor = System.Drawing.Color.Transparent;
            this.Agregar.FlatAppearance.BorderSize = 0;
            this.Agregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Agregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Agregar.Location = new System.Drawing.Point(743, 363);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(33, 39);
            this.Agregar.TabIndex = 7;
            this.Agregar.UseVisualStyleBackColor = false;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // Apagado
            // 
            this.Apagado.BackColor = System.Drawing.Color.Transparent;
            this.Apagado.FlatAppearance.BorderSize = 0;
            this.Apagado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Apagado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Apagado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Apagado.ForeColor = System.Drawing.Color.Transparent;
            this.Apagado.Location = new System.Drawing.Point(34, 344);
            this.Apagado.Name = "Apagado";
            this.Apagado.Size = new System.Drawing.Size(61, 61);
            this.Apagado.TabIndex = 2;
            this.Apagado.UseVisualStyleBackColor = false;
            this.Apagado.Click += new System.EventHandler(this.Apagado_Click);
            // 
            // frmPokemons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 470);
            this.Controls.Add(this.ModificarBoton);
            this.Controls.Add(this.TipoBox2);
            this.Controls.Add(this.TipoBox1);
            this.Controls.Add(this.VerTipoBoton);
            this.Controls.Add(this.StatsBaseBoton);
            this.Controls.Add(this.NumeroBox);
            this.Controls.Add(this.GritoBoton);
            this.Controls.Add(this.Sprite3d);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.alphaBlendTextBox1);
            this.Controls.Add(this.AnteriorPokemon);
            this.Controls.Add(this.SiguientePokemon);
            this.Controls.Add(this.Apagado);
            this.Controls.Add(this.PictureBoxPokemon);
            this.Controls.Add(this.Pokedex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPokemons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPokemons_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPokemon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pokedex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pokedex;
        private System.Windows.Forms.PictureBox PictureBoxPokemon;
        private BotonCircular Apagado;
        private System.Windows.Forms.Button SiguientePokemon;
        private System.Windows.Forms.Button AnteriorPokemon;
        private ZBobb.AlphaBlendTextBox alphaBlendTextBox1;
        private System.Windows.Forms.Button Buscar;
        private BotonCircular Agregar;
        private System.Windows.Forms.Button Sprite3d;
        private BotonCircular GritoBoton;
        private ZBobb.AlphaBlendTextBox NumeroBox;
        private System.Windows.Forms.Button StatsBaseBoton;
        private System.Windows.Forms.Button VerTipoBoton;
        private System.Windows.Forms.PictureBox TipoBox1;
        private System.Windows.Forms.PictureBox TipoBox2;
        private System.Windows.Forms.Button ModificarBoton;
    }
}

