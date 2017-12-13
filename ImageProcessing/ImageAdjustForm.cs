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
    public partial class ImageAdjustForm : Form
    {
        private ImageProcessingForm parentForm;

        public ImageAdjustForm(ImageProcessingForm p)
        {
            InitializeComponent();
            parentForm = p;
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            double low_in = (double)lowInNumericUpDown.Value / 255;
            double high_in = (double)highInNumericUpDown.Value / 255;
            double low_out = (double)lowOutNumericUpDown.Value / 255;
            double high_out = (double)highOutNumericUpDown.Value / 255;
            double gamma = (double)gammaNumericUpDown.Value;
            parentForm.ResultImage = ImageProcessing.ImageAdjust(parentForm.OriginImage, low_in, high_in, low_out, high_out, gamma);
            parentForm.refreshImage();
            parentForm.refreshHistogram();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
