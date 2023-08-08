
namespace Touge_App
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.PictureBoxBack = new System.Windows.Forms.PictureBox();
            this.AutosBoton = new System.Windows.Forms.Button();
            this.BotonPistas = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBack)).BeginInit();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // PictureBoxBack
            // 
            this.PictureBoxBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBoxBack.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PictureBoxBack.Location = new System.Drawing.Point(-1, -4);
            this.PictureBoxBack.Name = "PictureBoxBack";
            this.PictureBoxBack.Size = new System.Drawing.Size(1410, 804);
            this.PictureBoxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxBack.TabIndex = 0;
            this.PictureBoxBack.TabStop = false;
            // 
            // AutosBoton
            // 
            this.AutosBoton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AutosBoton.BackgroundImage")));
            this.AutosBoton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AutosBoton.Location = new System.Drawing.Point(514, 41);
            this.AutosBoton.Name = "AutosBoton";
            this.AutosBoton.Size = new System.Drawing.Size(367, 264);
            this.AutosBoton.TabIndex = 2;
            this.AutosBoton.UseVisualStyleBackColor = true;
            this.AutosBoton.Paint += new System.Windows.Forms.PaintEventHandler(this.AutosBoton_Paint);
            this.AutosBoton.MouseEnter += new System.EventHandler(this.AutosBoton_MouseEnter);
            this.AutosBoton.MouseLeave += new System.EventHandler(this.AutosBoton_MouseLeave);
            // 
            // BotonPistas
            // 
            this.BotonPistas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BotonPistas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonPistas.BackgroundImage")));
            this.BotonPistas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BotonPistas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BotonPistas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.BotonPistas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BotonPistas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonPistas.Location = new System.Drawing.Point(40, 41);
            this.BotonPistas.Name = "BotonPistas";
            this.BotonPistas.Size = new System.Drawing.Size(367, 264);
            this.BotonPistas.TabIndex = 3;
            this.BotonPistas.UseVisualStyleBackColor = true;
            this.BotonPistas.Paint += new System.Windows.Forms.PaintEventHandler(this.BotonPistas_Paint);
            this.BotonPistas.MouseEnter += new System.EventHandler(this.TrackButton_MouseEnter);
            this.BotonPistas.MouseLeave += new System.EventHandler(this.TrackButton_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(988, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(367, 264);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 803);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BotonPistas);
            this.Controls.Add(this.AutosBoton);
            this.Controls.Add(this.PictureBoxBack);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Touge-App";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.PictureBox PictureBoxBack;
        private System.Windows.Forms.Button BotonPistas;
        private System.Windows.Forms.Button AutosBoton;
        private System.Windows.Forms.Button button1;
    }
}

