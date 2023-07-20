
namespace WindowsFormsApp1
{
    partial class Calculadora
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
            this.Division = new System.Windows.Forms.Button();
            this.Suma = new System.Windows.Forms.Button();
            this.Multiplicacion = new System.Windows.Forms.Button();
            this.Resta = new System.Windows.Forms.Button();
            this.Igual = new System.Windows.Forms.Button();
            this.VisorCalculadora = new System.Windows.Forms.RichTextBox();
            this.ClearBox = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Division
            // 
            this.Division.BackColor = System.Drawing.Color.DarkOrange;
            this.Division.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Division.FlatAppearance.BorderSize = 5;
            this.Division.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.Division.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.Division.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Division.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.Division.Location = new System.Drawing.Point(447, 238);
            this.Division.Name = "Division";
            this.Division.Size = new System.Drawing.Size(117, 83);
            this.Division.TabIndex = 0;
            this.Division.Text = "/";
            this.Division.UseVisualStyleBackColor = false;
            this.Division.Click += new System.EventHandler(this.Division_Click);
            // 
            // Suma
            // 
            this.Suma.BackColor = System.Drawing.Color.DarkOrange;
            this.Suma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Suma.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Suma.FlatAppearance.BorderSize = 5;
            this.Suma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.Suma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.Suma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Suma.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.Suma.Location = new System.Drawing.Point(291, 129);
            this.Suma.Name = "Suma";
            this.Suma.Size = new System.Drawing.Size(117, 87);
            this.Suma.TabIndex = 1;
            this.Suma.Text = "+";
            this.Suma.UseVisualStyleBackColor = false;
            this.Suma.Click += new System.EventHandler(this.Suma_Click);
            // 
            // Multiplicacion
            // 
            this.Multiplicacion.BackColor = System.Drawing.Color.DarkOrange;
            this.Multiplicacion.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Multiplicacion.FlatAppearance.BorderSize = 5;
            this.Multiplicacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.Multiplicacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.Multiplicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Multiplicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.Multiplicacion.Location = new System.Drawing.Point(447, 129);
            this.Multiplicacion.Name = "Multiplicacion";
            this.Multiplicacion.Size = new System.Drawing.Size(117, 87);
            this.Multiplicacion.TabIndex = 2;
            this.Multiplicacion.Text = "*";
            this.Multiplicacion.UseVisualStyleBackColor = false;
            this.Multiplicacion.Click += new System.EventHandler(this.Multiplicacion_Click);
            // 
            // Resta
            // 
            this.Resta.BackColor = System.Drawing.Color.DarkOrange;
            this.Resta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Resta.FlatAppearance.BorderSize = 5;
            this.Resta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.Resta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.Resta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Resta.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.Resta.Location = new System.Drawing.Point(291, 238);
            this.Resta.Name = "Resta";
            this.Resta.Size = new System.Drawing.Size(117, 83);
            this.Resta.TabIndex = 3;
            this.Resta.Text = "-";
            this.Resta.UseVisualStyleBackColor = false;
            this.Resta.Click += new System.EventHandler(this.Resta_Click);
            // 
            // Igual
            // 
            this.Igual.BackColor = System.Drawing.Color.LightGreen;
            this.Igual.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Igual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.Igual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Igual.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Igual.Location = new System.Drawing.Point(291, 343);
            this.Igual.Name = "Igual";
            this.Igual.Size = new System.Drawing.Size(117, 77);
            this.Igual.TabIndex = 4;
            this.Igual.Text = "=";
            this.Igual.UseVisualStyleBackColor = false;
            this.Igual.Click += new System.EventHandler(this.Igual_Click);
            // 
            // VisorCalculadora
            // 
            this.VisorCalculadora.BackColor = System.Drawing.SystemColors.Highlight;
            this.VisorCalculadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.VisorCalculadora.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.VisorCalculadora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VisorCalculadora.Location = new System.Drawing.Point(6, 26);
            this.VisorCalculadora.Margin = new System.Windows.Forms.Padding(0);
            this.VisorCalculadora.MaxLength = 15;
            this.VisorCalculadora.Name = "VisorCalculadora";
            this.VisorCalculadora.ReadOnly = true;
            this.VisorCalculadora.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.VisorCalculadora.ShowSelectionMargin = true;
            this.VisorCalculadora.Size = new System.Drawing.Size(558, 69);
            this.VisorCalculadora.TabIndex = 5;
            this.VisorCalculadora.Text = "0";
            this.VisorCalculadora.TextChanged += new System.EventHandler(this.VisorCalculadora_TextChanged);
            this.VisorCalculadora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VisiorCalculadora_KeyDown);
            // 
            // ClearBox
            // 
            this.ClearBox.BackColor = System.Drawing.Color.Red;
            this.ClearBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ClearBox.FlatAppearance.BorderSize = 3;
            this.ClearBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClearBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClearBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearBox.Location = new System.Drawing.Point(447, 343);
            this.ClearBox.Name = "ClearBox";
            this.ClearBox.Size = new System.Drawing.Size(117, 77);
            this.ClearBox.TabIndex = 6;
            this.ClearBox.Text = "Clear";
            this.ClearBox.UseVisualStyleBackColor = false;
            this.ClearBox.Click += new System.EventHandler(this.ClearBox_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Purple;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(6, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 76);
            this.button1.TabIndex = 7;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Purple;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 5;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(95, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 76);
            this.button2.TabIndex = 8;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Purple;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 5;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(184, 339);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 76);
            this.button3.TabIndex = 9;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Purple;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.BorderSize = 5;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.Location = new System.Drawing.Point(6, 238);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 83);
            this.button4.TabIndex = 10;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Purple;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button5.FlatAppearance.BorderSize = 5;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.Location = new System.Drawing.Point(95, 238);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 83);
            this.button5.TabIndex = 11;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Purple;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button6.FlatAppearance.BorderSize = 5;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button6.Location = new System.Drawing.Point(184, 238);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(83, 83);
            this.button6.TabIndex = 12;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Purple;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button7.FlatAppearance.BorderSize = 5;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button7.Location = new System.Drawing.Point(6, 129);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(83, 87);
            this.button7.TabIndex = 13;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Purple;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button8.FlatAppearance.BorderSize = 5;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button8.Location = new System.Drawing.Point(95, 129);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(83, 87);
            this.button8.TabIndex = 14;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Purple;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button9.FlatAppearance.BorderSize = 5;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button9.Location = new System.Drawing.Point(184, 129);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(83, 87);
            this.button9.TabIndex = 15;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Purple;
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button10.FlatAppearance.BorderSize = 5;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button10.Location = new System.Drawing.Point(35, 421);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(205, 60);
            this.button10.TabIndex = 16;
            this.button10.Text = "0";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Calculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(569, 485);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ClearBox);
            this.Controls.Add(this.VisorCalculadora);
            this.Controls.Add(this.Igual);
            this.Controls.Add(this.Resta);
            this.Controls.Add(this.Multiplicacion);
            this.Controls.Add(this.Suma);
            this.Controls.Add(this.Division);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Calculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora";
            this.TransparencyKey = System.Drawing.Color.Gainsboro;
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Division;
        private System.Windows.Forms.Button Suma;
        private System.Windows.Forms.Button Multiplicacion;
        private System.Windows.Forms.Button Resta;
        private System.Windows.Forms.Button Igual;
        private System.Windows.Forms.RichTextBox VisorCalculadora;
        private System.Windows.Forms.Button ClearBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}

