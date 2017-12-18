using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ImageProcessing
{
    public partial class ImageProcessingForm : Form
    {
        public ImageProcessingForm()
        {
            InitializeComponent();
            resultPictureBox.MouseWheel += new MouseEventHandler(resultPictureBox_MouseWheel);
            histogramForm = new HistogramForm();
        }

        public String FilePath { get; set; }
        public DRData Data { get; set; }
        public Image OriginImage { get; set; }
        public Image ResultImage { get; set; }
        public HistogramForm histogramForm;
        private bool isMouseDown;
        private double scaleRatio;
        private double minRatio;
        private Point PreMousePosition;
        private Point PicturePosition;

        // 打开图片
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "医学图像|*.dr",
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePath = ofd.FileName;

                try
                {
                    Data = new DRData(FilePath);
                    ResultImage = OriginImage = Data.GetImage();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (OriginImage == null)
                {
                    MessageBox.Show("无法打开文件\n请检查打开方式", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                minRatio = (double)Math.Min(originPictureBox.Width, originPictureBox.Height) / Math.Max(OriginImage.Width, OriginImage.Height);
                scaleRatio = minRatio;
                isMouseDown = false;
                PreMousePosition = new Point(0, 0);
                PicturePosition = new Point(0, 0);

                originPictureBox.Image = OriginImage;
                refreshImage();

                histogramForm.Init(OriginImage);

                saveToolStripMenuItem.Enabled = true;
                viewToolStripMenuItem.Enabled = true;
                toolToolStripMenuItem.Enabled = true;
            }
        }

        // 保存图片
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

        // 刷新图片
        public void refreshImage()
        {
            Bitmap bitmap = new Bitmap(resultPictureBox.Width, resultPictureBox.Height);
            Rectangle rect = new Rectangle(
                PicturePosition,
                new Size((int)(ResultImage.Width * scaleRatio), (int)(ResultImage.Height * scaleRatio)));
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(ResultImage, rect);
            }
            resultPictureBox.Image = bitmap;
        }

        //刷新直方图
        public void refreshHistogram()
        {
            histogramForm.UpdateHistogram(ResultImage);
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

        // 显示CLAHE配置窗口
        private void CLAHEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CLAHEForm form = new CLAHEForm(this);
            form.ShowDialog();
        }

        // 灰度调整
        private void imageAdjustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageAdjustForm form = new ImageAdjustForm(this);
            form.ShowDialog();
        }

        // 鼠标左键按下
        private void resultPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                PreMousePosition = e.Location;
            }
        }

        // 鼠标左键抬起
        private void resultPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
                PreMousePosition = e.Location;
            }
        }

        // 拖动结果图片
        private void resultPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && ResultImage != null)
            {
                PicturePosition.X += e.Location.X - PreMousePosition.X;
                PicturePosition.Y += e.Location.Y - PreMousePosition.Y;
                PreMousePosition = e.Location;
                refreshImage();
            }
        }

        // 缩放结果图片
        private void resultPictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ResultImage != null)
            {
                if (scaleRatio > minRatio / 2 || e.Delta > 0)
                {
                    double oldRatio = scaleRatio;
                    scaleRatio = oldRatio + Math.Abs(e.Delta) / e.Delta * 0.05d;
                    PicturePosition.X = (int)(e.X - (e.X - PicturePosition.X) * scaleRatio / oldRatio);
                    PicturePosition.Y = (int)(e.Y - (e.Y - PicturePosition.Y) * scaleRatio / oldRatio);
                }
                else
                {
                    scaleRatio = minRatio / 2.1;
                }
                refreshImage();
            }
        }

        // 重置图片大小
        private void fixWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ResultImage != null)
            {
                minRatio = (double)Math.Min(originPictureBox.Width, originPictureBox.Height) / Math.Max(OriginImage.Width, OriginImage.Height);
                scaleRatio = minRatio;
                PreMousePosition = new Point(0, 0);
                PicturePosition = new Point(0, 0);
                refreshImage();
            }
        }

        // 窗口缩放事件响应
        private void ImageProcessingForm_SizeChanged(object sender, EventArgs e)
        {
            fixWindowToolStripMenuItem_Click(sender, e);
        }

        // 只显示原始图片
        private void onlyShowOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OriginResultSplitContainer.Panel1Collapsed = false;
            OriginResultSplitContainer.Panel2Collapsed = true;
        }

        // 只显示结果图片
        private void onlyShowResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OriginResultSplitContainer.Panel1Collapsed = true;
            OriginResultSplitContainer.Panel2Collapsed = false;
        }

        // 原始结果全部显示
        private void showBothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OriginResultSplitContainer.Panel1Collapsed = false;
            OriginResultSplitContainer.Panel2Collapsed = false;
        }

        // 直方图均衡化
        private void histogramEqualizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultImage = ImageProcessing.HistogramEqualization(OriginImage, false);
            refreshImage();
            refreshHistogram();
        }
    }
}
