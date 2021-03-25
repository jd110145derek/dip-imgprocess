using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Grayscale
    {
        public Bitmap Transform(Bitmap inputImg)
        {
            if (inputImg != null)
            {
                Bitmap grayImg = new Bitmap(inputImg);

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

                        grayImg.SetPixel(i, j, Color.FromArgb(avg, avg, avg));
                    }
                }
                return grayImg;
            }
            return null;
        }
    }
}
