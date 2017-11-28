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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            int split = (int)splitNumericUpDown.Value;
            parentForm.ResultImage = ImageProcessing.CLAHE(parentForm.OriginImage, split);
            Close();
        }
    }
}
