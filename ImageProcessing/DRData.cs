using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ImageProcessing
{
    public class DRData
    {
        public UInt16 Width { get; set; }
        public UInt16 Height { get; set; }
        public UInt16 BBP { get; set; }
        public UInt16 Sign { get; set; }
        public UInt16 MaxVal { get; set; }
        public Byte[] Reserved { get; set; }
        public UInt16[,] RawData { get; set; }

        public DRData(String filePath)
        {
            BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open));
            Width = reader.ReadUInt16();
            Height = reader.ReadUInt16();
            BBP = reader.ReadUInt16();
            Sign = reader.ReadUInt16();
            MaxVal = reader.ReadUInt16();
            Reserved = reader.ReadBytes(6);
            RawData = new UInt16[Width, Height];

            for (uint y = 0; y < Height; y++)
            {
                for (uint x = 0; x < Width; x++)
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
                    RawData[x, y] = (UInt16)val;
                }
            }
            reader.Close();
        }

        /// <summary>
        /// Get image from raw data
        /// </summary>
        /// <param name="low">from 0 to 1</param>
        /// <param name="high">from 0 to 1</param>
        /// <returns>Image</returns>
        public Image GetImage(
            float low_in = 0f, float high_in = 1f,
            float low_out = 0f, float high_out = 1f,
            float gamma = 1f)
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    float brightness = (float)RawData[x, y] / MaxVal;
                    if (brightness <= low_in)
                        brightness = 0f;
                    else if (brightness >= high_in)
                        brightness = 1f;
                    brightness = low_out + (float)Math.Pow((brightness - low_in) / (high_in - low_in), gamma) * (high_out - low_out);
                    Byte val = (Byte)(brightness * 255);
                    bitmap.SetPixel(x, y, Color.FromArgb(val, val, val));
                }
            }
            return bitmap;
        }
    }
}
