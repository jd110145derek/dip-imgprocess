using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Sobel_Edge_Detect
    {
        // horizontal sobel matrix
        static int[] horizontal = {-1, 0, 1,
                            -2, 0, 2,
                            -1, 0, 1};
        // vertical sobel matrix
        static int[] vertical = {-1, -2, -1,
                           0, 0, 0,
                           1, 2, 1};

        private int[,] Average(Bitmap image)
        {
            int[,] avg = new int[image.Width, image.Height];

            for (int j = 0; j < image.Height; j++)
            {
                for (int i = 0; i < image.Width; i++)
                {
                    // compute image's average color
                    Color RGB = image.GetPixel(i, j);
                    int rChannel = Convert.ToInt32(RGB.R);
                    int gChannel = Convert.ToInt32(RGB.G);
                    int bChannel = Convert.ToInt32(RGB.B);

                    avg[i, j] = (rChannel + gChannel + bChannel) / 3;
                }
            }

            return avg;
        }

        public Bitmap Vertical(Bitmap inputImg)
        {
            if (inputImg != null)
            {
                Bitmap verticalImg = new Bitmap(inputImg);
                int[,] avg = new int[inputImg.Width, inputImg.Height];
                int value;

                avg = Average(inputImg);
                for (int j = 1; j < inputImg.Height - 1; j++)
                {
                    for (int i = 1; i < inputImg.Width - 1; i++)
                    {
                        // do vertical sobel
                        value = avg[i - 1, j - 1] * vertical[0] + avg[i - 1, j] * vertical[1] + avg[i - 1, j + 1] * vertical[2]
                                + avg[i, j - 1] * vertical[3] + avg[i, j] * vertical[4] + avg[i, j + 1] * vertical[5] +
                                avg[i + 1, j - 1] * vertical[6] + avg[i + 1, j] * vertical[7] + avg[i + 1, j + 1] * vertical[8];
                        value = (int)Math.Pow(value * value, 0.5);

                        if (value > 255)
                            value = 255;
                        if (value < 0)
                            value = 0;

                        verticalImg.SetPixel(i, j, Color.FromArgb(value, value, value));
                    }
                }

                return verticalImg;
            }
            return null;
        }

        public Bitmap Horizontal(Bitmap inputImg)
        {
            if (inputImg != null)
            {
                Bitmap horizontalImg = new Bitmap(inputImg);
                int[,] avg = new int[inputImg.Width, inputImg.Height];
                int value;

                avg = Average(inputImg);
                for (int j = 1; j < inputImg.Height - 1; j++)
                {
                    for (int i = 1; i < inputImg.Width - 1; i++)
                    {
                        // do horizontal sobel
                        value = avg[i - 1, j - 1] * horizontal[0] + avg[i - 1, j] * horizontal[1] + avg[i - 1, j + 1] * horizontal[2]
                                + avg[i, j - 1] * horizontal[3] + avg[i, j] * horizontal[4] + avg[i, j + 1] * horizontal[5] +
                                avg[i + 1, j - 1] * horizontal[6] + avg[i + 1, j] * horizontal[7] + avg[i + 1, j + 1] * horizontal[8];
                        value = (int)Math.Pow(value * value, 0.5);

                        if (value > 255)
                            value = 255;
                        if (value < 0)
                            value = 0;

                        horizontalImg.SetPixel(i, j, Color.FromArgb(value, value, value));
                    }
                }

                return horizontalImg;
            }
            return null;
        }

        public Bitmap Combine(Bitmap inputImg)
        {
            if (inputImg != null)
            {
                Bitmap combineImg = new Bitmap(inputImg);
                int[,] avg = new int[inputImg.Width, inputImg.Height];

                avg = Average(inputImg);
                for (int j = 1; j < inputImg.Height - 1; j++)
                {
                    for (int i = 1; i < inputImg.Width - 1; i++)
                    {
                        // do vertical sobel
                        int verticalValue = avg[i - 1, j - 1] * vertical[0] + avg[i - 1, j] * vertical[1] + avg[i - 1, j + 1] * vertical[2]
                                + avg[i, j - 1] * vertical[3] + avg[i, j] * vertical[4] + avg[i, j + 1] * vertical[5] +
                                avg[i + 1, j - 1] * vertical[6] + avg[i + 1, j] * vertical[7] + avg[i + 1, j + 1] * vertical[8];

                        // do horizontal sobel
                        int horizontalValue = avg[i - 1, j - 1] * horizontal[0] + avg[i - 1, j] * horizontal[1] + avg[i - 1, j + 1] * horizontal[2]
                                + avg[i, j - 1] * horizontal[3] + avg[i, j] * horizontal[4] + avg[i, j + 1] * horizontal[5] +
                                avg[i + 1, j - 1] * horizontal[6] + avg[i + 1, j] * horizontal[7] + avg[i + 1, j + 1] * horizontal[8];

                        // combine vertical and horizontal sobel
                        int value = (int)Math.Pow((verticalValue * verticalValue + horizontalValue * horizontalValue), 0.5);

                        if (value > 255)
                            value = 255;
                        if (value < 0)
                            value = 0;

                        combineImg.SetPixel(i, j, Color.FromArgb(value, value, value));
                    }
                }

                return combineImg;
            }
            return null;
        }
    }
}
