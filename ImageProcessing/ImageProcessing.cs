using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    static class ImageProcessing
    {
        /// <summary>
        ///获得输入图片的RGB通道归一化概率密度函数
        /// </summary>
        public static double[,] GetPDF(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            double[,] imagePDF = new double[3, 256];
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    imagePDF[0, bitmap.GetPixel(x, y).R]++;
                    imagePDF[1, bitmap.GetPixel(x, y).G]++;
                    imagePDF[2, bitmap.GetPixel(x, y).B]++;
                }
            }

            for (int channel = 0; channel < 3; channel++)
            {
                for (int scale = 0; scale < 256; scale++)
                {
                    imagePDF[channel, scale] /= (image.Height * image.Width);
                }
            }
            return imagePDF;
        }

        /// <summary>
        ///获得输入图片的RGB通道归一化累积分布函数
        /// </summary>
        public static double[,] GetCDF(Image image)
        {
            double[,] imageCDF = GetPDF(image);
            for (int channel = 0; channel < 3; channel++)
            {
                for (int scale = 1; scale < 256; scale++)
                {
                    imageCDF[channel, scale] += imageCDF[channel, scale - 1];
                }
            }
            return imageCDF;
        }

        /// <summary>
        ///直方图均衡算法
        /// </summary>
        public static Image HistogramEqualization(Image image)
        {
            double[,] imageCDF = GetCDF(image);
            Bitmap bitmap = new Bitmap(image);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int R = (int)(imageCDF[0, bitmap.GetPixel(x, y).R] * 255);
                    int G = (int)(imageCDF[1, bitmap.GetPixel(x, y).G] * 255);
                    int B = (int)(imageCDF[2, bitmap.GetPixel(x, y).B] * 255);
                    bitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
            return bitmap;
        }

        /// <summary>
        ///绘制直方图
        /// </summary>
        public static Image GetHistogram(Image image)
        {
            Bitmap bitmap = new Bitmap(256, 300);
            Graphics graphics = Graphics.FromImage(bitmap);

            double[,] imagePDF = GetPDF(image);

            double maxPossibility = 0;
            foreach (var e in imagePDF)
            {
                maxPossibility = Math.Max(maxPossibility, e);
            }

            for (int clannel = 0; clannel < 3; clannel++)
            {
                for (int scale = 0; scale < 256; scale++)
                {
                    int height = (int)(imagePDF[clannel, scale] / maxPossibility * 99);
                    switch (clannel)
                    {
                        case 0:
                            graphics.DrawLine(
                                Pens.Red,
                                new Point(scale, 99 - 0),
                                new Point(scale, 99 - height));
                            break;
                        case 1:
                            graphics.DrawLine(
                                Pens.Green,
                                new Point(scale, 199 - 0),
                                new Point(scale, 199 - height));
                            break;
                        case 2:
                            graphics.DrawLine(
                                Pens.Blue,
                                new Point(scale, 299 - 0),
                                new Point(scale, 299 - height));
                            break;
                        default:
                            break;
                    }
                }
            }
            return bitmap;
        }

        /// <summary>
        ///读取自定义文件
        /// </summary>
        public static Image GetImageFromDr(string filePath)
        {
            BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open));
            UInt16 width = reader.ReadUInt16();
            UInt16 height = reader.ReadUInt16();
            UInt16 BBP = reader.ReadUInt16();
            UInt16 Sign = reader.ReadUInt16();
            UInt16 MaxVal = reader.ReadUInt16();
            Byte[] reserved = reader.ReadBytes(6);

            Bitmap bitmap = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int val = 0;
                    if (BBP == 8)
                    {
                        if (Sign == 0)
                            val = reader.ReadByte();
                        else
                            val = reader.ReadSByte();
                    }
                    else if (BBP == 16)
                    {
                        if (Sign == 0)
                            val = reader.ReadUInt16();
                        else
                            val = reader.ReadInt16();
                    }
                    if (MaxVal != 255)
                    {
                        val = (int)((double)val / MaxVal * 255);
                    }
                    bitmap.SetPixel(x, y, Color.FromArgb(val, val, val));
                }
            }

            reader.Close();

            return bitmap;
        }

        public static Image CLAHE(Image src, int block = 8)
        {
            Bitmap srcBitmap = new Bitmap(src);
            Bitmap CLAHE_GO = new Bitmap(src);
            // 图像的长和宽
            int width = src.Width;
            int height = src.Height;
            // 每个小格子的长和宽
            int blockWidth = width / block;
            int blockHeight = height / block;
            // 图像分割覆盖的长和宽
            int claheWidth = blockWidth * block;
            int claheHeight = blockHeight * block;
            // 存储各个直方图  
            int[,,] PDF = new int[block, block, 256];
            double[,,] CDF = new double[block, block, 256];
            // 每块的像素数量
            int totalPixelCount = blockWidth * blockHeight;
            for (int yBlockIndex = 0; yBlockIndex < block; yBlockIndex++)
            {
                for (int xBlockIndex = 0; xBlockIndex < block; xBlockIndex++)
                {
                    int start_x = xBlockIndex * blockWidth;
                    int end_x = start_x + blockWidth;
                    int start_y = yBlockIndex * blockHeight;
                    int end_y = start_y + blockHeight;
                    //遍历小块,计算直方图
                    for (int y = start_y; y < end_y; y++)
                    {
                        for (int x = start_x; x < end_x; x++)
                        {
                            int grayValue = srcBitmap.GetPixel(x, y).R;
                            PDF[xBlockIndex, yBlockIndex, grayValue]++;
                        }
                    }
                    ////裁剪和增加操作，也就是clahe中的cl部分
                    ////这里的参数 对应《Gem》上面 fCliplimit  = 4  , uiNrBins  = 255
                    //int average = blockWidth * blockHeight / 255;
                    ////关于参数如何选择，需要进行讨论。不同的结果进行讨论
                    ////关于全局的时候，这里的这个cl如何算，需要进行讨论 
                    //int limit = 40 * average;
                    //int steal = 0;
                    //for (int grayValue = 0; grayValue < 256; grayValue++)
                    //{
                    //    if (PDF[xBlockIndex, yBlockIndex, grayValue] > limit)
                    //    {
                    //        steal += PDF[xBlockIndex, yBlockIndex, grayValue] - limit;
                    //        PDF[xBlockIndex, yBlockIndex, grayValue] = limit;
                    //    }
                    //}
                    //int bonus = steal / 256;
                    ////hand out the steals averagely  
                    //for (int grayValue = 0; grayValue < 256; grayValue++)
                    //{
                    //    PDF[xBlockIndex, yBlockIndex, grayValue] += bonus;
                    //}
                    //计算累积分布直方图  
                    for (int grayValue = 0; grayValue < 256; grayValue++)
                    {
                        if (grayValue == 0)
                            CDF[xBlockIndex, yBlockIndex, grayValue] = (double)PDF[xBlockIndex, yBlockIndex, grayValue] / totalPixelCount;
                        else
                            CDF[xBlockIndex, yBlockIndex, grayValue] = CDF[xBlockIndex, yBlockIndex, grayValue - 1] + (double)PDF[xBlockIndex, yBlockIndex, grayValue] / totalPixelCount;
                    }
                }
            }
            //计算变换后的像素值  
            //根据像素点的位置，选择不同的计算方法  
            for (int y = 0; y < claheHeight; y++)
            {
                for (int x = 0; x < claheWidth; x++)
                {
                    /* corners */
                    // top left corner
                    if (x <= blockWidth / 2 && y <= blockHeight / 2)
                    {
                        int gray = (int)(CDF[0, 0, CLAHE_GO.GetPixel(x, y).R] * 255);
                        CLAHE_GO.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                    // top right corner
                    else if (x >= claheWidth - blockWidth / 2 && y <= blockHeight / 2)
                    {
                        int gray = (int)(CDF[block - 1, 0, CLAHE_GO.GetPixel(x, y).R] * 255);
                        CLAHE_GO.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                    // bottom left corner
                    else if (x <= blockWidth / 2 && y >= claheHeight - blockHeight / 2)
                    {
                        int gray = (int)(CDF[0, block - 1, CLAHE_GO.GetPixel(x, y).R] * 255);
                        CLAHE_GO.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                    // bottom right corner
                    else if (x >= claheWidth - blockWidth / 2 && y >= claheHeight - blockHeight / 2)
                    {
                        int gray = (int)(CDF[block - 1, block - 1, CLAHE_GO.GetPixel(x, y).R] * 255);
                        CLAHE_GO.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                    /* edges */
                    // left edge
                    else if (x <= blockWidth / 2)
                    {
                        int xBlockIndex = 0;
                        int yBlockIndex = (y - blockHeight / 2 - 1) / blockHeight;

                        double q = (y - ((double)yBlockIndex * blockHeight + blockHeight / 2)) / blockHeight;
                        double p = 1 - q;

                        int gray = (int)((p * CDF[xBlockIndex, yBlockIndex, CLAHE_GO.GetPixel(x, y).R] + q * CDF[xBlockIndex, yBlockIndex + 1, CLAHE_GO.GetPixel(x, y).R]) * 255);
                        CLAHE_GO.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                    // right edge
                    else if (x >= (claheWidth - blockWidth / 2))
                    {
                        int xBlockIndex = block - 1;
                        int yBlockIndex = (y - blockHeight / 2 - 1) / blockHeight;

                        double q = (y - ((double)yBlockIndex * blockHeight + blockHeight / 2)) / blockHeight;
                        double p = 1 - q;

                        int gray = (int)((p * CDF[xBlockIndex, yBlockIndex, CLAHE_GO.GetPixel(x, y).R] + q * CDF[xBlockIndex, yBlockIndex + 1, CLAHE_GO.GetPixel(x, y).R]) * 255);
                        CLAHE_GO.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                    // top edge
                    else if (y <= blockHeight / 2)
                    {
                        int xBlockIndex = (x - blockWidth / 2 - 1) / blockWidth;
                        int yBlockIndex = 0;

                        double q = (x - ((double)xBlockIndex * blockHeight + blockWidth / 2)) / blockWidth;
                        double p = 1 - q;

                        int gray = (int)((p * CDF[xBlockIndex, yBlockIndex, CLAHE_GO.GetPixel(x, y).R] + q * CDF[xBlockIndex + 1, yBlockIndex, CLAHE_GO.GetPixel(x, y).R]) * 255);
                        CLAHE_GO.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                    // bottom edge
                    else if (y >= (claheHeight - blockHeight / 2))
                    {
                        int xBlockIndex = (x - blockWidth / 2 - 1) / blockWidth;
                        int yBlockIndex = block - 1;

                        double q = (x - ((double)xBlockIndex * blockHeight + blockWidth / 2)) / blockWidth;
                        double p = 1 - q;

                        int gray = (int)((p * CDF[xBlockIndex, yBlockIndex, CLAHE_GO.GetPixel(x, y).R] + q * CDF[xBlockIndex + 1, yBlockIndex, CLAHE_GO.GetPixel(x, y).R]) * 255);
                        CLAHE_GO.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                    /* Inner */
                    else
                    {
                        int xBlockIndex = (x - blockWidth / 2 - 1) / blockWidth;
                        int yBlockIndex = (y - blockHeight / 2 - 1) / blockHeight;

                        double qx = (x - ((double)xBlockIndex * blockWidth + blockWidth / 2)) / blockWidth;
                        double px = 1 - qx;
                        double qy = (y - ((double)yBlockIndex * blockHeight + blockHeight / 2)) / blockHeight;
                        double py = 1 - qy;
                        int gray = (int)((qx * qy * CDF[xBlockIndex + 1, yBlockIndex + 1, CLAHE_GO.GetPixel(x, y).R] +
                                            px * py * CDF[xBlockIndex, yBlockIndex, CLAHE_GO.GetPixel(x, y).R] +
                                            px * qy * CDF[xBlockIndex, yBlockIndex + 1, CLAHE_GO.GetPixel(x, y).R] +
                                            qx * py * CDF[xBlockIndex + 1, yBlockIndex, CLAHE_GO.GetPixel(x, y).R]) * 255);
                        CLAHE_GO.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                }
            }
            return CLAHE_GO;
        }
    }
}
