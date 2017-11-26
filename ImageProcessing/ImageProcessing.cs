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

        public static Image CLAHE(Image src, int _step = 8)
        {
            Bitmap srcBitmap = new Bitmap(src);
            Bitmap CLAHE_GO = new Bitmap(src);
            int block = _step;//pblock
            int width = src.Height;
            int height = src.Width;
            int width_block = width / block; //每个小格子的长和宽
            int height_block = height / block;
            //存储各个直方图  
            int[,] tmp2 = new int[8 * 8, 256];
            float[,] C2 = new float[8 * 8, 256];
            //分块
            int total = width_block * height_block;
            for (int i = 0; i < block; i++)
            {
                for (int j = 0; j < block; j++)
                {
                    int start_x = i * width_block;
                    int end_x = start_x + width_block;
                    int start_y = j * height_block;
                    int end_y = start_y + height_block;
                    int num = i + block * j;
                    //遍历小块,计算直方图
                    for (int ii = start_x; ii < end_x; ii++)
                    {
                        for (int jj = start_y; jj < end_y; jj++)
                        {
                            int index = srcBitmap.GetPixel(jj, ii).R;
                            tmp2[num, index]++;
                        }
                    }
                    //裁剪和增加操作，也就是clahe中的cl部分
                    //这里的参数 对应《Gem》上面 fCliplimit  = 4  , uiNrBins  = 255
                    int average = width_block * height_block / 255;
                    //关于参数如何选择，需要进行讨论。不同的结果进行讨论
                    //关于全局的时候，这里的这个cl如何算，需要进行讨论 
                    int LIMIT = 40 * average;
                    int steal = 0;
                    for (int k = 0; k < 256; k++)
                    {
                        if (tmp2[num,k] > LIMIT)
                        {
                            steal += tmp2[num,k] - LIMIT;
                            tmp2[num,k] = LIMIT;
                        }
                    }
                    int bonus = steal / 256;
                    //hand out the steals averagely  
                    for (int k = 0; k < 256; k++)
                    {
                        tmp2[num,k] += bonus;
                    }
                    //计算累积分布直方图  
                    for (int k = 0; k < 256; k++)
                    {
                        if (k == 0)
                            C2[num,k] = 1.0f * tmp2[num,k] / total;
                        else
                            C2[num,k] = C2[num,k - 1] + 1.0f * tmp2[num,k] / total;
                    }
                }
            }
            //计算变换后的像素值  
            //根据像素点的位置，选择不同的计算方法  
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //four coners  
                    if (i <= width_block / 2 && j <= height_block / 2)
                    {
                        int num = 0;
                        int gray = (int)(C2[num, CLAHE_GO.GetPixel(j, i).R] * 255);
                        Color color = Color.FromArgb(gray, gray, gray);
                        CLAHE_GO.SetPixel(j, i, color);
                    }
                    else if (i <= width_block / 2 && j >= ((block - 1) * height_block + height_block / 2))
                    {
                        int num = block * (block - 1);
                        int gray = (int)(C2[num, CLAHE_GO.GetPixel(j, i).R] * 255);
                        Color color = Color.FromArgb(gray, gray, gray);
                        CLAHE_GO.SetPixel(j, i, color);
                    }
                    else if (i >= ((block - 1) * width_block + width_block / 2) && j <= height_block / 2)
                    {
                        int num = block - 1;
                        int gray = (int)(C2[num, CLAHE_GO.GetPixel(j, i).R] * 255);
                        Color color = Color.FromArgb(gray, gray, gray);
                        CLAHE_GO.SetPixel(j, i, color);
                    }
                    else if (i >= ((block - 1) * width_block + width_block / 2) && j >= ((block - 1) * height_block + height_block / 2))
                    {
                        int num = block * block - 1;
                        int gray = (int)(C2[num, CLAHE_GO.GetPixel(j, i).R] * 255);
                        Color color = Color.FromArgb(gray, gray, gray);
                        CLAHE_GO.SetPixel(j, i, color);
                    }
                    //four edges except coners  
                    else if (i <= width_block / 2)
                    {
                        //线性插值  
                        int num_i = 0;
                        int num_j = (j - height_block / 2) / height_block;
                        int num1 = num_j * block + num_i;
                        int num2 = num1 + block;
                        float p = (j - (num_j * height_block + height_block / 2)) / (1.0f * height_block);
                        float q = 1 - p;
                        int gray = (int)((q * C2[num1, CLAHE_GO.GetPixel(j, i).R] + p * C2[num2, CLAHE_GO.GetPixel(j, i).R]) * 255);
                        CLAHE_GO.SetPixel(j, i, Color.FromArgb(gray, gray, gray));
                    }
                    else if (i >= ((block - 1) * width_block + width_block / 2))
                    {
                        //线性插值  
                        int num_i = block - 1;
                        int num_j = (j - height_block / 2) / height_block;
                        int num1 = num_j * block + num_i;
                        int num2 = num1 + block;
                        float p = (j - (num_j * height_block + height_block / 2)) / (1.0f * height_block);
                        float q = 1 - p;
                        int gray = (int)((q * C2[num1, CLAHE_GO.GetPixel(j, i).R] + p * C2[num2, CLAHE_GO.GetPixel(j, i).R]) * 255);
                        CLAHE_GO.SetPixel(j, i, Color.FromArgb(gray, gray, gray));
                    }
                    else if (j <= height_block / 2)
                    {
                        //线性插值  
                        int num_i = (i - width_block / 2) / width_block;
                        int num_j = 0;
                        int num1 = num_j * block + num_i;
                        int num2 = num1 + 1;
                        float p = (i - (num_i * width_block + width_block / 2)) / (1.0f * width_block);
                        float q = 1 - p;
                        int gray = (int)((q * C2[num1, CLAHE_GO.GetPixel(j, i).R] + p * C2[num2, CLAHE_GO.GetPixel(j, i).R]) * 255);
                        CLAHE_GO.SetPixel(j, i, Color.FromArgb(gray, gray, gray));
                    }
                    else if (j >= ((block - 1) * height_block + height_block / 2))
                    {
                        //线性插值  
                        int num_i = (i - width_block / 2) / width_block;
                        int num_j = block - 1;
                        int num1 = num_j * block + num_i;
                        int num2 = num1 + 1;
                        float p = (i - (num_i * width_block + width_block / 2)) / (1.0f * width_block);
                        float q = 1 - p;
                        int gray = (int)((q * C2[num1, CLAHE_GO.GetPixel(j, i).R] + p * C2[num2, CLAHE_GO.GetPixel(j, i).R]) * 255);
                        CLAHE_GO.SetPixel(j, i, Color.FromArgb(gray, gray, gray));
                    }
                    //双线性插值
                    else
                    {
                        int num_i = (i - width_block / 2) / width_block;
                        int num_j = (j - height_block / 2) / height_block;
                        int num1 = num_j * block + num_i;
                        int num2 = num1 + 1;
                        int num3 = num1 + block;
                        int num4 = num2 + block;
                        float u = (i - (num_i * width_block + width_block / 2)) / (1.0f * width_block);
                        float v = (j - (num_j * height_block + height_block / 2)) / (1.0f * height_block);
                        int gray = (int)((u * v * C2[num4, CLAHE_GO.GetPixel(j, i).R] +
                                            (1 - v) * (1 - u) * C2[num1, CLAHE_GO.GetPixel(j, i).R] +
                                            u * (1 - v) * C2[num2, CLAHE_GO.GetPixel(j, i).R] +
                                            v * (1 - u) * C2[num3, CLAHE_GO.GetPixel(j, i).R]) * 255);
                        CLAHE_GO.SetPixel(j, i, Color.FromArgb(gray, gray, gray));
                    }
                    //最后这步，类似高斯平滑
                    //int g = CLAHE_GO.GetPixel(j, i).R + (CLAHE_GO.GetPixel(j, i).R << 8) + (CLAHE_GO.GetPixel(j, i).R << 16);
                    //CLAHE_GO.SetPixel(j, i, Color.FromArgb(g, g, g));
                }
            }
            return CLAHE_GO;
        }
    }
}
