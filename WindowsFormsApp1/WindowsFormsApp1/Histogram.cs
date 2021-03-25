using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Histogram
    {
        int[,] avg;
        int[] value = new int[256];
        int[] trans = new int[256];

        public int[] Origin_Value (Bitmap inputImg)
        {
            if (inputImg != null)
            {
                avg = new int[inputImg.Width, inputImg.Height];

                for (int j = 0; j < inputImg.Height; j++)
                {
                    for (int i = 0; i < inputImg.Width; i++)
                    {
                        // count original image's average color value
                        Color RGB = inputImg.GetPixel(i, j);
                        int rChannel = Convert.ToInt32(RGB.R);
                        int gChannel = Convert.ToInt32(RGB.G);
                        int bChannel = Convert.ToInt32(RGB.B);
                        avg[i, j] = (rChannel + gChannel + bChannel) / 3;
                        value[avg[i, j]]++;
                    }
                }
                return value;
            }
            return null;
        }

        public int[] Equalize_Value (Bitmap inputImg)
        {
            if (inputImg != null)
            {
                int area = inputImg.Width * inputImg.Height;
                double sum = 0;
                int[] eValue = new int[256];

                // do equalize
                for (int i = 0; i < 256; i++)
                {
                    sum += (double)value[i] / area * 255;
                    trans[i] = (int)sum;
                }

                // count equalize image's average color value
                for (int j = 0; j < inputImg.Height; j++)
                    for (int i = 0; i < inputImg.Width; i++)
                        eValue[trans[avg[i, j]]]++;

                return eValue;
            }
            return null;
        }

        public Bitmap Equalize (Bitmap inputImg)
        {
            if (inputImg != null)
            {
                Bitmap equalize = new Bitmap(inputImg);

                // do equalize color transform
                for (int j = 0; j < inputImg.Height; j++)
                    for (int i = 0; i < inputImg.Width; i++)
                        equalize.SetPixel(i, j, Color.FromArgb(trans[avg[i, j]], trans[avg[i, j]], trans[avg[i, j]]));

                return equalize;
            }
            return null;
        }
    }
}
