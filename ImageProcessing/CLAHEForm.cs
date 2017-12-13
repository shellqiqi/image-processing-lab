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
    public partial class CLAHEForm : Form
    {
        private ImageProcessingForm parentForm;

        public CLAHEForm(ImageProcessingForm p)
        {
            InitializeComponent();
            parentForm = p;
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            int split = (int)splitNumericUpDown.Value;
            double limit = (double)limitNumericUpDown.Value;
            if (separateRGBCheckBox.Checked)
                parentForm.ResultImage = ImageProcessing.SeparatedChannelCLAHE(parentForm.OriginImage, split, limit);
            else
                parentForm.ResultImage = ImageProcessing.CLAHE(parentForm.OriginImage, split, limit);
            parentForm.refreshImage();
            parentForm.refreshHistogram();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void separateRGBCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (separateRGBCheckBox.Checked)
                separateRGBCheckBox.Text = "Yes";
            else
                separateRGBCheckBox.Text = "No";
        }
    }
}
