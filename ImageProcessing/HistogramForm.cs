using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class HistogramForm : Form
    {
        public HistogramForm()
        {
            InitializeComponent();
        }

        public void Init(Image originImage)
        {
            histogramResultPictureBox.Image
                = histogramOriginPictureBox.Image
                = ImageProcessing.GetHistogram(originImage);
        }

        public void UpdateHistogram(Image resultImage)
        {
            histogramResultPictureBox.Image = ImageProcessing.GetHistogram(resultImage);
        }

        private void HistogramForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}