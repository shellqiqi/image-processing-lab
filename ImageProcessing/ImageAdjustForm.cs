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
            float low_in = (float)lowInNumericUpDown.Value;
            float high_in = (float)highInNumericUpDown.Value;
            float low_out = (float)lowOutNumericUpDown.Value;
            float high_out = (float)highOutNumericUpDown.Value;
            float gamma = (float)gammaNumericUpDown.Value;
            parentForm.ResultImage = parentForm.Data.GetImage(low_in, high_in, low_out, high_out, gamma);
            parentForm.refreshImage();
            parentForm.copyResultToOrigin();
            parentForm.refreshHistogram();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lowInNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (lowInNumericUpDown.Value >= highInNumericUpDown.Value)
            {
                lowInNumericUpDown.Value = highInNumericUpDown.Value;
            }
        }

        private void highInNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (lowInNumericUpDown.Value >= highInNumericUpDown.Value)
            {
                highInNumericUpDown.Value = lowInNumericUpDown.Value;
            }
        }
    }
}
