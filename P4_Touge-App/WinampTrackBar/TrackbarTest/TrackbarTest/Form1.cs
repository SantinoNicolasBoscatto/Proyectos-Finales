using System.Windows.Forms;

namespace TrackbarTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Trackbar1RadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (Trackbar1RadioButton.Checked)
                propertyGrid1.SelectedObject = winampTrackBar1;
        }

        private void Trackbar2RadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (Trackbar2RadioButton.Checked)
                propertyGrid1.SelectedObject = winampTrackBar2;
        }
    }
}
