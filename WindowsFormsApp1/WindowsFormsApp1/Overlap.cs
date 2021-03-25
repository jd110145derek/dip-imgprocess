using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Overlap
    {
        public Bitmap Threshold(Bitmap inputImg, int threshold)
        {
            if (inputImg != null)
            {
                Bitmap transImg = new Bitmap(inputImg);

                for (int j = 0; j < inputImg.Height; j++)
                {
                    for (int i = 0; i < inputImg.Width; i++)
                    {
                        // compute average color value
                        Color RGB = inputImg.GetPixel(i, j);
                        int rChannel = Convert.ToInt32(RGB.R);
                        int gChannel = Convert.ToInt32(RGB.G);
                        int bChannel = Convert.ToInt32(RGB.B);
                        int avg = (rChannel + gChannel + bChannel) / 3;

                        // do thresholding
                        if (avg < threshold)
                            transImg.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        else
                            transImg.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                }

                return transImg;
            }
            return null;
        }

        public Bitmap Overlapping(Bitmap inputImg, Bitmap thresholdImg)
        {
            if (inputImg != null && thresholdImg != null)
            {
                Bitmap overlapImg = new Bitmap(inputImg);

                for (int j = 0; j < inputImg.Height; j++)
                {
                    for (int i = 0; i < inputImg.Width; i++)
                    {
                        // compute average color value
                        Color RGB = thresholdImg.GetPixel(i, j);
                        int rChannel = Convert.ToInt32(RGB.R);
                        int gChannel = Convert.ToInt32(RGB.G);
                        int bChannel = Convert.ToInt32(RGB.B);
                        int value = (rChannel + gChannel + bChannel) / 3;

                        // edge's color transform to green
                        if (value == 255)
                        {
                            overlapImg.SetPixel(i, j, Color.FromArgb(0, 255, 0));
                        }
                    }
                }

                return overlapImg;
            }
            return null;
        }
    }
}
