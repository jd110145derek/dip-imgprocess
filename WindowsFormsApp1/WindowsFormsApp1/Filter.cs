using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Filter
    {
        public Bitmap Mean(Bitmap inputImg)
        {
            if (inputImg != null)
            {
                Bitmap meanImg = new Bitmap(inputImg);
                int[,] rChannel = new int[inputImg.Width, inputImg.Height];
                int[,] gChannel = new int[inputImg.Width, inputImg.Height];
                int[,] bChannel = new int[inputImg.Width, inputImg.Height];

                // record original image's color
                for (int j = 0; j < inputImg.Height; j++)
                {
                    for (int i = 0; i < inputImg.Width; i++)
                    {
                        Color RGB = inputImg.GetPixel(i, j);
                        rChannel[i, j] = Convert.ToInt32(RGB.R);
                        gChannel[i, j] = Convert.ToInt32(RGB.G);
                        bChannel[i, j] = Convert.ToInt32(RGB.B);
                    }
                }

                for (int j = 1; j < inputImg.Height - 1; j++)
                {
                    for (int i = 1; i < inputImg.Width - 1; i++)
                    {
                        // do mean filter
                        int newR = (rChannel[i - 1, j - 1] + rChannel[i, j - 1] + rChannel[i + 1, j - 1]
                                    + rChannel[i - 1, j] + rChannel[i, j] + rChannel[i + 1, j] +
                                    rChannel[i - 1, j + 1] + rChannel[i, j + 1] + rChannel[i + 1, j + 1]) / 9;
                        int newG = (gChannel[i - 1, j - 1] + gChannel[i, j - 1] + gChannel[i + 1, j - 1]
                                    + gChannel[i - 1, j] + gChannel[i, j] + gChannel[i + 1, j] +
                                    gChannel[i - 1, j + 1] + gChannel[i, j + 1] + gChannel[i + 1, j + 1]) / 9;
                        int newB = (bChannel[i - 1, j - 1] + bChannel[i, j - 1] + bChannel[i + 1, j - 1]
                                    + bChannel[i - 1, j] + bChannel[i, j] + bChannel[i + 1, j] +
                                    bChannel[i - 1, j + 1] + bChannel[i, j + 1] + bChannel[i + 1, j + 1]) / 9;
                        meanImg.SetPixel(i, j, Color.FromArgb(newR, newG, newB));
                    }
                }
                return meanImg;
            }
            return null;
        }

        public Bitmap Median(Bitmap inputImg)
        {
            if (inputImg != null)
            {
                Bitmap medianImg = new Bitmap(inputImg);
                int[,] rChannel = new int[inputImg.Width, inputImg.Height];
                int[,] gChannel = new int[inputImg.Width, inputImg.Height];
                int[,] bChannel = new int[inputImg.Width, inputImg.Height];

                // record original image's color
                for (int j = 0; j < inputImg.Height; j++)
                {
                    for (int i = 0; i < inputImg.Width; i++)
                    {
                        Color RGB = inputImg.GetPixel(i, j);
                        rChannel[i, j] = Convert.ToInt32(RGB.R);
                        gChannel[i, j] = Convert.ToInt32(RGB.G);
                        bChannel[i, j] = Convert.ToInt32(RGB.B);
                    }
                }

                for (int j = 1; j < inputImg.Height - 1; j++)
                {
                    for (int i = 1; i < inputImg.Width - 1; i++)
                    {
                        // do median filter
                        int[] arrayR = { rChannel[i - 1, j - 1], rChannel[i, j - 1], rChannel[i + 1, j - 1]
                                    , rChannel[i - 1, j], rChannel[i, j], rChannel[i + 1, j],
                                    rChannel[i - 1, j + 1], rChannel[i, j + 1], rChannel[i + 1, j + 1]};
                        int[] arrayG = { gChannel[i - 1, j - 1], gChannel[i, j - 1], gChannel[i + 1, j - 1]
                                    , gChannel[i - 1, j], gChannel[i, j], gChannel[i + 1, j],
                                    gChannel[i - 1, j + 1], gChannel[i, j + 1], gChannel[i + 1, j + 1]};
                        int[] arrayB = { bChannel[i - 1, j - 1], bChannel[i, j - 1], bChannel[i + 1, j - 1]
                                    , bChannel[i - 1, j], bChannel[i, j], bChannel[i + 1, j],
                                    bChannel[i - 1, j + 1], bChannel[i, j + 1], bChannel[i + 1, j + 1]};

                        Array.Sort(arrayR);
                        Array.Sort(arrayG);
                        Array.Sort(arrayB);

                        medianImg.SetPixel(i, j, Color.FromArgb(arrayR[4], arrayG[4], arrayB[4]));
                    }
                }
                return medianImg;
            }
            return null;
        }
    }
}
