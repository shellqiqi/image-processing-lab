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
    public partial class ImageProcessingForm : Form
    {
        public ImageProcessingForm()
        {
            InitializeComponent();

            histogramForm = new HistogramForm();
        }

        public String FilePath { get; set; }
        public Image OriginImage { get; set; }
        public Image ResultImage { get; set; }
        public HistogramForm histogramForm;

        // 打开图片
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "位图|*.bmp|所有文件|*.*",
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePath = ofd.FileName;
                ResultImage = OriginImage = Image.FromFile(FilePath);
                originPictureBox.Image = OriginImage;
                resultPictureBox.Image = ResultImage;

                histogramForm.Init(OriginImage);

                saveToolStripMenuItem.Enabled = true;
                viewToolStripMenuItem.Enabled = true;
                toolToolStripMenuItem.Enabled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "JEPG图片|*.jpg|BMP图片|*.bmp|PNG图片|*.png",
                RestoreDirectory = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                switch (sfd.FilterIndex)
                {
                    case 1:
                        ResultImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        ResultImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        ResultImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }

        // 显示直方图
        private void HistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!histogramForm.Visible)
            {
                histogramForm.Show();
            }
            else
            {
                histogramForm.Hide();
            }
        }

        // 直方图均衡
        private void HistogramEqualizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultImage = ImageProcessing.HistogramEqualization(OriginImage);
            resultPictureBox.Image = ResultImage;
            histogramForm.UpdateHistogram(ResultImage);
        }
    }
}
