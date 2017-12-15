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
        public static Image HistogramEqualization(Image image, bool isSeparatedChannel)
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
                    if (isSeparatedChannel)
                    {
                        bitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                    }
                    else
                    {
                        bitmap.SetPixel(x, y, ColorFromHSV(
                            bitmap.GetPixel(x, y).GetHue(),
                            bitmap.GetPixel(x, y).GetSaturation(),
                            Color.FromArgb(R, G, B).GetBrightness()));
                    }
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
        ///读取医学图像
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

        /// <summary>
        ///HSV转化为RGB
        /// </summary>
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        /// <summary>
        ///限制对比度自适应直方图均衡化
        /// </summary>
        public static Image CLAHE(Image src, int block, double contrastLimit)
        {
            Bitmap srcBitmap = new Bitmap(src);
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
                            int grayValue = (int)(srcBitmap.GetPixel(x, y).GetBrightness() * 255);
                            PDF[xBlockIndex, yBlockIndex, grayValue]++;
                        }
                    }

                    /* 限制对比度 */
                    // 平均分布密度
                    int average = totalPixelCount / 256;
                    // 限制累计分布密度斜率
                    int limit = (int)(contrastLimit * average);
                    // 超出部分
                    int bonus = 0;
                    do
                    {
                        int steal = 0;
                        for (int grayValue = 0; grayValue < 256; grayValue++)
                        {
                            if (PDF[xBlockIndex, yBlockIndex, grayValue] > limit)
                            {
                                steal += PDF[xBlockIndex, yBlockIndex, grayValue] - limit;
                                PDF[xBlockIndex, yBlockIndex, grayValue] = limit;
                            }
                        }
                        bonus = steal / 256;
                        int remainder = steal % 256;
                        // 平均重分布
                        for (int grayValue = 0; grayValue < 256; grayValue++)
                        {
                            PDF[xBlockIndex, yBlockIndex, grayValue] += bonus;
                        }
                        for (int grayValue = 0; grayValue < remainder; grayValue++)
                        {
                            PDF[xBlockIndex, yBlockIndex, grayValue]++;
                        }
                    } while (bonus > 1);

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
                    int srcGrayValue = (int)(srcBitmap.GetPixel(x, y).GetBrightness() * 255);
                    double srcHue = srcBitmap.GetPixel(x, y).GetHue();
                    double srcSaturation = srcBitmap.GetPixel(x, y).GetSaturation();
                    /* corners */
                    // top left corner
                    if (x <= blockWidth / 2 && y <= blockHeight / 2)
                    {
                        double brightness = CDF[0, 0, srcGrayValue];
                        srcBitmap.SetPixel(x, y, ColorFromHSV(srcHue, srcSaturation, brightness));
                    }
                    // top right corner
                    else if (x >= claheWidth - blockWidth / 2 && y <= blockHeight / 2)
                    {
                        double brightness = CDF[block - 1, 0, srcGrayValue];
                        srcBitmap.SetPixel(x, y, ColorFromHSV(srcHue, srcSaturation, brightness));
                    }
                    // bottom left corner
                    else if (x <= blockWidth / 2 && y >= claheHeight - blockHeight / 2)
                    {
                        double brightness = CDF[0, block - 1, srcGrayValue];
                        srcBitmap.SetPixel(x, y, ColorFromHSV(srcHue, srcSaturation, brightness));
                    }
                    // bottom right corner
                    else if (x >= claheWidth - blockWidth / 2 && y >= claheHeight - blockHeight / 2)
                    {
                        double brightness = CDF[block - 1, block - 1, srcGrayValue];
                        srcBitmap.SetPixel(x, y, ColorFromHSV(srcHue, srcSaturation, brightness));
                    }
                    /* edges */
                    // left edge
                    else if (x <= blockWidth / 2)
                    {
                        int xBlockIndex = 0;
                        int yBlockIndex = (y - blockHeight / 2 - 1) / blockHeight;

                        double q = (y - ((double)yBlockIndex * blockHeight + blockHeight / 2)) / blockHeight;
                        double p = 1 - q;

                        double brightness =
                            p * CDF[xBlockIndex, yBlockIndex, srcGrayValue] +
                            q * CDF[xBlockIndex, yBlockIndex + 1, srcGrayValue];
                        srcBitmap.SetPixel(x, y, ColorFromHSV(srcHue, srcSaturation, brightness));
                    }
                    // right edge
                    else if (x >= (claheWidth - blockWidth / 2))
                    {
                        int xBlockIndex = block - 1;
                        int yBlockIndex = (y - blockHeight / 2 - 1) / blockHeight;

                        double q = (y - ((double)yBlockIndex * blockHeight + blockHeight / 2)) / blockHeight;
                        double p = 1 - q;

                        double brightness =
                            p * CDF[xBlockIndex, yBlockIndex, srcGrayValue] +
                            q * CDF[xBlockIndex, yBlockIndex + 1, srcGrayValue];
                        srcBitmap.SetPixel(x, y, ColorFromHSV(srcHue, srcSaturation, brightness));
                    }
                    // top edge
                    else if (y <= blockHeight / 2)
                    {
                        int xBlockIndex = (x - blockWidth / 2 - 1) / blockWidth;
                        int yBlockIndex = 0;

                        double q = (x - ((double)xBlockIndex * blockWidth + blockWidth / 2)) / blockWidth;
                        double p = 1 - q;

                        double brightness =
                            p * CDF[xBlockIndex, yBlockIndex, srcGrayValue] +
                            q * CDF[xBlockIndex + 1, yBlockIndex, srcGrayValue];
                        srcBitmap.SetPixel(x, y, ColorFromHSV(srcHue, srcSaturation, brightness));
                    }
                    // bottom edge
                    else if (y >= (claheHeight - blockHeight / 2))
                    {
                        int xBlockIndex = (x - blockWidth / 2 - 1) / blockWidth;
                        int yBlockIndex = block - 1;

                        double q = (x - ((double)xBlockIndex * blockWidth + blockWidth / 2)) / blockWidth;
                        double p = 1 - q;

                        double brightness =
                            p * CDF[xBlockIndex, yBlockIndex, srcGrayValue] +
                            q * CDF[xBlockIndex + 1, yBlockIndex, srcGrayValue];
                        srcBitmap.SetPixel(x, y, ColorFromHSV(srcHue, srcSaturation, brightness));
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
                        double brightness =
                            qx * qy * CDF[xBlockIndex + 1, yBlockIndex + 1, srcGrayValue] +
                            px * py * CDF[xBlockIndex, yBlockIndex, srcGrayValue] +
                            px * qy * CDF[xBlockIndex, yBlockIndex + 1, srcGrayValue] +
                            qx * py * CDF[xBlockIndex + 1, yBlockIndex, srcGrayValue];
                        srcBitmap.SetPixel(x, y, ColorFromHSV(srcHue, srcSaturation, brightness));
                    }
                }
            }
            return srcBitmap;
        }

        /// <summary>
        ///分离通道的限制对比度自适应直方图均衡化
        /// </summary>
        public static Image SeparatedChannelCLAHE(Image src, int block, double contrastLimit)
        {
            Bitmap srcBitmap = new Bitmap(src);
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
            int[,,,] PDF = new int[3, block, block, 256];
            double[,,,] CDF = new double[3, block, block, 256];
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
                            Color c = srcBitmap.GetPixel(x, y);
                            PDF[0, xBlockIndex, yBlockIndex, c.R]++;
                            PDF[1, xBlockIndex, yBlockIndex, c.G]++;
                            PDF[2, xBlockIndex, yBlockIndex, c.B]++;
                        }
                    }

                    /* 限制对比度 */
                    // 平均分布密度
                    double average = (double)totalPixelCount / 256;
                    // 限制累计分布密度斜率
                    int limit = (int)(contrastLimit * average);
                    // 超出部分
                    int bonus = 0;
                    do
                    {
                        for (int channel = 0; channel < 3; channel++)
                        {
                            int steal = 0;
                            for (int value = 0; value < 256; value++)
                            {
                                if (PDF[channel, xBlockIndex, yBlockIndex, value] > limit)
                                {
                                    steal += PDF[channel, xBlockIndex, yBlockIndex, value] - limit;
                                    PDF[channel, xBlockIndex, yBlockIndex, value] = limit;
                                }
                            }
                            bonus = steal / 256;
                            int remainder = steal % 256;
                            // 平均重分布
                            for ( int value = 0; value < 256; value++)
                            {
                                PDF[channel, xBlockIndex, yBlockIndex, value] += bonus;
                            }
                            for (int value = 0; value < remainder; value++)
                            {
                                PDF[channel, xBlockIndex, yBlockIndex, value]++;
                            }
                        }
                    } while (bonus > 1);

                    //计算累积分布直方图
                    for (int channel = 0; channel < 3; channel++)
                    {
                        for (int value = 0; value < 256; value++)
                        {
                            if (value == 0)
                                CDF[channel, xBlockIndex, yBlockIndex, value] = (double)PDF[channel, xBlockIndex, yBlockIndex, value] / totalPixelCount;
                            else
                                CDF[channel, xBlockIndex, yBlockIndex, value] = CDF[channel, xBlockIndex, yBlockIndex, value - 1] + (double)PDF[channel, xBlockIndex, yBlockIndex, value] / totalPixelCount;
                        }
                    }
                }
            }
            //计算变换后的像素值  
            //根据像素点的位置，选择不同的计算方法  
            for (int y = 0; y < claheHeight; y++)
            {
                for (int x = 0; x < claheWidth; x++)
                {
                    Color c = srcBitmap.GetPixel(x, y);
                    /* corners */
                    // top left corner
                    if (x <= blockWidth / 2 && y <= blockHeight / 2)
                    {
                        int R = (int)(CDF[0, 0, 0, c.R] * 255);
                        int G = (int)(CDF[1, 0, 0, c.G] * 255);
                        int B = (int)(CDF[2, 0, 0, c.B] * 255);
                        srcBitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                    }
                    // top right corner
                    else if (x >= claheWidth - blockWidth / 2 && y <= blockHeight / 2)
                    {
                        int R = (int)(CDF[0, block - 1, 0, c.R] * 255);
                        int G = (int)(CDF[1, block - 1, 0, c.G] * 255);
                        int B = (int)(CDF[2, block - 1, 0, c.B] * 255);
                        srcBitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                    }
                    // bottom left corner
                    else if (x <= blockWidth / 2 && y >= claheHeight - blockHeight / 2)
                    {
                        int R = (int)(CDF[0, 0, block - 1, c.R] * 255);
                        int G = (int)(CDF[1, 0, block - 1, c.G] * 255);
                        int B = (int)(CDF[2, 0, block - 1, c.B] * 255);
                        srcBitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                    }
                    // bottom right corner
                    else if (x >= claheWidth - blockWidth / 2 && y >= claheHeight - blockHeight / 2)
                    {
                        int R = (int)(CDF[0, block - 1, block - 1, c.R] * 255);
                        int G = (int)(CDF[1, block - 1, block - 1, c.G] * 255);
                        int B = (int)(CDF[2, block - 1, block - 1, c.B] * 255);
                        srcBitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                    }
                    /* edges */
                    // left edge
                    else if (x <= blockWidth / 2)
                    {
                        int xBlockIndex = 0;
                        int yBlockIndex = (y - blockHeight / 2 - 1) / blockHeight;

                        double q = (y - ((double)yBlockIndex * blockHeight + blockHeight / 2)) / blockHeight;
                        double p = 1 - q;

                        int R = (int)((p * CDF[0, xBlockIndex, yBlockIndex, c.R] + q * CDF[0, xBlockIndex, yBlockIndex + 1, c.R]) * 255);
                        int G = (int)((p * CDF[1, xBlockIndex, yBlockIndex, c.G] + q * CDF[1, xBlockIndex, yBlockIndex + 1, c.G]) * 255);
                        int B = (int)((p * CDF[2, xBlockIndex, yBlockIndex, c.B] + q * CDF[2, xBlockIndex, yBlockIndex + 1, c.B]) * 255);

                        srcBitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                    }
                    // right edge
                    else if (x >= (claheWidth - blockWidth / 2))
                    {
                        int xBlockIndex = block - 1;
                        int yBlockIndex = (y - blockHeight / 2 - 1) / blockHeight;

                        double q = (y - ((double)yBlockIndex * blockHeight + blockHeight / 2)) / blockHeight;
                        double p = 1 - q;

                        int R = (int)((p * CDF[0, xBlockIndex, yBlockIndex, c.R] + q * CDF[0, xBlockIndex, yBlockIndex + 1, c.R]) * 255);
                        int G = (int)((p * CDF[1, xBlockIndex, yBlockIndex, c.G] + q * CDF[1, xBlockIndex, yBlockIndex + 1, c.G]) * 255);
                        int B = (int)((p * CDF[2, xBlockIndex, yBlockIndex, c.B] + q * CDF[2, xBlockIndex, yBlockIndex + 1, c.B]) * 255);

                        srcBitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                    }
                    // top edge
                    else if (y <= blockHeight / 2)
                    {
                        int xBlockIndex = (x - blockWidth / 2 - 1) / blockWidth;
                        int yBlockIndex = 0;

                        double q = (x - ((double)xBlockIndex * blockWidth + blockWidth / 2)) / blockWidth;
                        double p = 1 - q;

                        int R = (int)((p * CDF[0, xBlockIndex, yBlockIndex, c.R] + q * CDF[0, xBlockIndex + 1, yBlockIndex, c.R]) * 255);
                        int G = (int)((p * CDF[1, xBlockIndex, yBlockIndex, c.G] + q * CDF[1, xBlockIndex + 1, yBlockIndex, c.G]) * 255);
                        int B = (int)((p * CDF[2, xBlockIndex, yBlockIndex, c.B] + q * CDF[2, xBlockIndex + 1, yBlockIndex, c.B]) * 255);

                        srcBitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                    }
                    // bottom edge
                    else if (y >= (claheHeight - blockHeight / 2))
                    {
                        int xBlockIndex = (x - blockWidth / 2 - 1) / blockWidth;
                        int yBlockIndex = block - 1;

                        double q = (x - ((double)xBlockIndex * blockWidth + blockWidth / 2)) / blockWidth;
                        double p = 1 - q;

                        int R = (int)((p * CDF[0, xBlockIndex, yBlockIndex, c.R] + q * CDF[0, xBlockIndex + 1, yBlockIndex, c.R]) * 255);
                        int G = (int)((p * CDF[1, xBlockIndex, yBlockIndex, c.G] + q * CDF[1, xBlockIndex + 1, yBlockIndex, c.G]) * 255);
                        int B = (int)((p * CDF[2, xBlockIndex, yBlockIndex, c.B] + q * CDF[2, xBlockIndex + 1, yBlockIndex, c.B]) * 255);

                        srcBitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
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

                        int R = (int)((qx * qy * CDF[0, xBlockIndex + 1, yBlockIndex + 1, c.R] +
                                       px * py * CDF[0, xBlockIndex, yBlockIndex, c.R] +
                                       px * qy * CDF[0, xBlockIndex, yBlockIndex + 1, c.R] +
                                       qx * py * CDF[0, xBlockIndex + 1, yBlockIndex, c.R]) * 255);
                        int G = (int)((qx * qy * CDF[1, xBlockIndex + 1, yBlockIndex + 1, c.G] +
                                       px * py * CDF[1, xBlockIndex, yBlockIndex, c.G] +
                                       px * qy * CDF[1, xBlockIndex, yBlockIndex + 1, c.G] +
                                       qx * py * CDF[1, xBlockIndex + 1, yBlockIndex, c.G]) * 255);
                        int B = (int)((qx * qy * CDF[2, xBlockIndex + 1, yBlockIndex + 1, c.B] +
                                       px * py * CDF[2, xBlockIndex, yBlockIndex, c.B] +
                                       px * qy * CDF[2, xBlockIndex, yBlockIndex + 1, c.B] +
                                       qx * py * CDF[2, xBlockIndex + 1, yBlockIndex, c.B]) * 255);

                        srcBitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                    }
                }
            }
            return srcBitmap;
        }

        /// <summary>
        ///灰度窗方法
        /// </summary>
        public static Image ImageAdjust(Image src,
            double low_in = 0d, double high_in = 1d,
            double low_out = 0d, double high_out = 1d,
            double gamma = 0d)
        {
            Bitmap bitmap = new Bitmap(src);
            if (high_in - low_in == 0 || gamma == 0)
            {
                return bitmap;
            }
            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    double brightness = bitmap.GetPixel(x, y).GetBrightness();
                    if (brightness < low_in)
                        brightness = 0d;
                    if (brightness > high_in)
                        brightness = 1d;
                    brightness = low_out + Math.Pow((brightness - low_in) / (high_in - low_in), gamma) * (high_out - low_out);
                    Byte val = (Byte)(brightness * 255);
                    bitmap.SetPixel(x, y, Color.FromArgb(val, val, val));
                }
            }
            return bitmap;
        }
    }
}
