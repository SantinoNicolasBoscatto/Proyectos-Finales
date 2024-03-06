namespace TrackbarTest
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Trackbar2RadioButton = new System.Windows.Forms.RadioButton();
            this.Trackbar1RadioButton = new System.Windows.Forms.RadioButton();
            this.winampTrackBar2 = new Winamp.Components.WinampTrackBar();
            this.winampTrackBar1 = new Winamp.Components.WinampTrackBar();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.Trackbar2RadioButton);
            this.panel1.Controls.Add(this.Trackbar1RadioButton);
            this.panel1.Controls.Add(this.winampTrackBar2);
            this.panel1.Controls.Add(this.winampTrackBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 361);
            this.panel1.TabIndex = 4;
            // 
            // Trackbar2RadioButton
            // 
            this.Trackbar2RadioButton.AutoSize = true;
            this.Trackbar2RadioButton.Location = new System.Drawing.Point(13, 186);
            this.Trackbar2RadioButton.Name = "Trackbar2RadioButton";
            this.Trackbar2RadioButton.Size = new System.Drawing.Size(14, 13);
            this.Trackbar2RadioButton.TabIndex = 3;
            this.Trackbar2RadioButton.UseVisualStyleBackColor = true;
            this.Trackbar2RadioButton.CheckedChanged += new System.EventHandler(this.Trackbar2RadioButton_CheckedChanged);
            // 
            // Trackbar1RadioButton
            // 
            this.Trackbar1RadioButton.AutoSize = true;
            this.Trackbar1RadioButton.Checked = true;
            this.Trackbar1RadioButton.Location = new System.Drawing.Point(13, 21);
            this.Trackbar1RadioButton.Name = "Trackbar1RadioButton";
            this.Trackbar1RadioButton.Size = new System.Drawing.Size(14, 13);
            this.Trackbar1RadioButton.TabIndex = 2;
            this.Trackbar1RadioButton.TabStop = true;
            this.Trackbar1RadioButton.UseVisualStyleBackColor = true;
            this.Trackbar1RadioButton.CheckedChanged += new System.EventHandler(this.Trackbar1RadioButton_CheckedChanged);
            // 
            // winampTrackBar2
            // 
            this.winampTrackBar2.BackColor = System.Drawing.Color.Gray;
            this.winampTrackBar2.EmptyTrackColor = System.Drawing.Color.Black;
            this.winampTrackBar2.Location = new System.Drawing.Point(57, 186);
            this.winampTrackBar2.Name = "winampTrackBar2";
            this.winampTrackBar2.Size = new System.Drawing.Size(139, 67);
            this.winampTrackBar2.SliderButtonSize = new System.Drawing.Size(40, 14);
            this.winampTrackBar2.TabIndex = 1;
            // 
            // winampTrackBar1
            // 
            this.winampTrackBar1.BackColor = System.Drawing.Color.Gray;
            this.winampTrackBar1.EmptyTrackColor = System.Drawing.Color.Black;
            this.winampTrackBar1.Location = new System.Drawing.Point(57, 21);
            this.winampTrackBar1.Name = "winampTrackBar1";
            this.winampTrackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.winampTrackBar1.Size = new System.Drawing.Size(67, 139);
            this.winampTrackBar1.SliderButtonSize = new System.Drawing.Size(14, 40);
            this.winampTrackBar1.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid1.Location = new System.Drawing.Point(279, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid1.SelectedObject = this.winampTrackBar1;
            this.propertyGrid1.Size = new System.Drawing.Size(326, 361);
            this.propertyGrid1.TabIndex = 9;
            this.propertyGrid1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 361);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Winamp TrackBar Test";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Winamp.Components.WinampTrackBar winampTrackBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.RadioButton Trackbar2RadioButton;
        private System.Windows.Forms.RadioButton Trackbar1RadioButton;
        private Winamp.Components.WinampTrackBar winampTrackBar2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

