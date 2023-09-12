using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Winamp.Components;

namespace WinampComponentsUnitTests
{
    [TestClass]
    public class HorizontalTrackBarUnitTests
    {
        public WinampTrackBar GetLargeSymmeticTrackbar(bool showSlider)
        {
            WinampTrackBar wt = new WinampTrackBar();
            wt.Orientation = Orientation.Horizontal;
            wt.ScaleFieldPosition = WinampTrackBar.WinampTrackBarScaleFieldPosition.RightOrBottom;
            wt.Size = new Size(210, 30);
            wt.ShowSlider = showSlider ? WinampTrackBar.WinampTrackBarShowSlider.Always : WinampTrackBar.WinampTrackBarShowSlider.Never;
            wt.SliderButtonSize = new Size(20, 10);

            return wt;
        }

        [TestMethod]
        public void Symmetric_ValueToPixelValue_NoSlider_210x30()
        {
            WinampTrackBar wt = GetLargeSymmeticTrackbar(false);
            WinampTrackBarRenderer r = new HorizontalWinampTrackBarRenderer(wt);

            int pixelValue = 0;

            /* LARGE VALUES */
            wt.Maximum = 15000;
            wt.Minimum = -15000;

            pixelValue = r.ValueToPixelValue(wt.Minimum);
            Assert.AreEqual(2, pixelValue, "15000 - Input: " + wt.Minimum);

            pixelValue = r.ValueToPixelValue(0);
            Assert.AreEqual(104, pixelValue, "15000 - Input: 0");

            pixelValue = r.ValueToPixelValue(wt.Maximum);
            Assert.AreEqual(207, pixelValue, "15000 - Input: " + wt.Maximum);

            /* MEDIUM VALUES */
            wt.Maximum = 150;
            wt.Minimum = -150;

            pixelValue = r.ValueToPixelValue(wt.Minimum);
            Assert.AreEqual(2, pixelValue, "150 - Input: " + wt.Minimum);

            pixelValue = r.ValueToPixelValue(0);
            Assert.AreEqual(104, pixelValue, "150 - Input: 0");

            pixelValue = r.ValueToPixelValue(wt.Maximum);
            Assert.AreEqual(207, pixelValue, "150 - Input: " + wt.Maximum);

            /* SMALL VALUES */
            wt.Maximum = 15;
            wt.Minimum = -15;

            pixelValue = r.ValueToPixelValue(wt.Minimum);
            Assert.AreEqual(2, pixelValue, "15 - Input: " + wt.Minimum);

            pixelValue = r.ValueToPixelValue(0);
            Assert.AreEqual(104, pixelValue, "15 - Input: 0");

            pixelValue = r.ValueToPixelValue(wt.Maximum);
            Assert.AreEqual(207, pixelValue, "15 - Input: " + wt.Maximum);
        }

        [TestMethod]
        public void Symmetric_ValueToPixelValue_Slider_210x30()
        {
            WinampTrackBar wt = GetLargeSymmeticTrackbar(true);
            WinampTrackBarRenderer r = new HorizontalWinampTrackBarRenderer(wt);

            int pixelValue = 0;

            /* LARGE VALUES */
            wt.Maximum = 15000;
            wt.Minimum = -15000;

            pixelValue = r.ValueToPixelValue(wt.Minimum);
            Assert.AreEqual(12, pixelValue, "15000 - Input: " + wt.Minimum);

            pixelValue = r.ValueToPixelValue(0);
            Assert.AreEqual(104, pixelValue, "15000 - Input: 0");

            pixelValue = r.ValueToPixelValue(wt.Maximum);
            Assert.AreEqual(197, pixelValue, "15000 - Input: " + wt.Maximum);

            /* MEDIUM VALUES */
            wt.Maximum = 150;
            wt.Minimum = -150;

            pixelValue = r.ValueToPixelValue(wt.Minimum);
            Assert.AreEqual(12, pixelValue, "150 - Input: " + wt.Minimum);

            pixelValue = r.ValueToPixelValue(0);
            Assert.AreEqual(104, pixelValue, "150 - Input: 0");

            pixelValue = r.ValueToPixelValue(wt.Maximum);
            Assert.AreEqual(197, pixelValue, "150 - Input: " + wt.Maximum);

            /* SMALL VALUES */
            wt.Maximum = 15;
            wt.Minimum = -15;

            pixelValue = r.ValueToPixelValue(wt.Minimum);
            Assert.AreEqual(12, pixelValue, "15 - Input: " + wt.Minimum);

            pixelValue = r.ValueToPixelValue(0);
            Assert.AreEqual(104, pixelValue, "15 - Input: 0");

            pixelValue = r.ValueToPixelValue(wt.Maximum);
            Assert.AreEqual(197, pixelValue, "15 - Input: " + wt.Maximum);
        }

        [TestMethod]
        public void Symmetric_PixelValueToValue_NoSlider_210x30()
        {
            WinampTrackBar wt = GetLargeSymmeticTrackbar(false);
            WinampTrackBarRenderer r = new HorizontalWinampTrackBarRenderer(wt);

            int value = 0;

            /* LARGE VALUES */
            wt.Maximum = 15000;
            wt.Minimum = -15000;

            value = r.PixelValueToValue(2);
            Assert.AreEqual(wt.Minimum, value, "15000 - Input: 2");

            value = r.PixelValueToValue(104);
            Assert.AreEqual(0, value, "15000 - Input: 104");

            value = r.PixelValueToValue(207);
            Assert.AreEqual(wt.Maximum, value, "15000 - Input: 207");

            /* MEDIUM VALUES */
            wt.Maximum = 150;
            wt.Minimum = -150;

            value = r.PixelValueToValue(2);
            Assert.AreEqual(wt.Minimum, value, "150 - Input: 2");

            value = r.PixelValueToValue(104);
            Assert.AreEqual(0, value, "150 - Input: 104");

            value = r.PixelValueToValue(207);
            Assert.AreEqual(wt.Maximum, value, "150 - Input: 207");

            /* SMALL VALUES */
            wt.Maximum = 15;
            wt.Minimum = -15;

            value = r.PixelValueToValue(2);
            Assert.AreEqual(wt.Minimum, value, "15 - Input: 2");

            value = r.PixelValueToValue(104);
            Assert.AreEqual(0, value, "15 - Input: 104");

            value = r.PixelValueToValue(207);
            Assert.AreEqual(wt.Maximum, value, "15 - Input: 207");
        }

        [TestMethod]
        public void Symmetric_PixelValueToValue_Slider_210x30()
        {
            WinampTrackBar wt = GetLargeSymmeticTrackbar(true);
            WinampTrackBarRenderer r = new HorizontalWinampTrackBarRenderer(wt);

            int value = 0;

            /* LARGE VALUES */
            wt.Maximum = 15000;
            wt.Minimum = -15000;

            value = r.PixelValueToValue(2);
            Assert.AreEqual(wt.Minimum, value, "15000 - Input: 2");

            value = r.PixelValueToValue(12);
            Assert.AreEqual(wt.Minimum, value, "15000 - Input: 12");

            value = r.PixelValueToValue(104);
            Assert.AreEqual(0, value, "15000 - Input: 104");

            value = r.PixelValueToValue(197);
            Assert.AreEqual(wt.Maximum, value, "15000 - Input: 197");

            value = r.PixelValueToValue(207);
            Assert.AreEqual(wt.Maximum, value, "15000 - Input: 207");

            /* MEDIUM VALUES */
            wt.Maximum = 150;
            wt.Minimum = -150;

            value = r.PixelValueToValue(2);
            Assert.AreEqual(wt.Minimum, value, "150 - Input: 2");

            value = r.PixelValueToValue(12);
            Assert.AreEqual(wt.Minimum, value, "150 - Input: 12");

            value = r.PixelValueToValue(104);
            Assert.AreEqual(0, value, "150 - Input: 104");

            value = r.PixelValueToValue(197);
            Assert.AreEqual(wt.Maximum, value, "150 - Input: 197");

            value = r.PixelValueToValue(207);
            Assert.AreEqual(wt.Maximum, value, "150 - Input: 207");

            /* SMALL VALUES */
            wt.Maximum = 15;
            wt.Minimum = -15;

            value = r.PixelValueToValue(2);
            Assert.AreEqual(wt.Minimum, value, "15 - Input: 2");

            value = r.PixelValueToValue(12);
            Assert.AreEqual(wt.Minimum, value, "15 - Input: 12");

            value = r.PixelValueToValue(104);
            Assert.AreEqual(0, value, "15 - Input: 104");

            value = r.PixelValueToValue(197);
            Assert.AreEqual(wt.Maximum, value, "15 - Input: 197");

            value = r.PixelValueToValue(207);
            Assert.AreEqual(wt.Maximum, value, "15 - Input: 207");
        }
    }
}
