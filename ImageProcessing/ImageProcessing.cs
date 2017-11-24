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
    }
}
