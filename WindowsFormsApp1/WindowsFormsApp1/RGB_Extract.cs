using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class RGB_Extract
    {
        public Bitmap R_Extract(Bitmap inputImg)
        {
            if (inputImg != null)
            {
                Bitmap rChannelImg = new Bitmap(inputImg);

                for (int j = 0; j < inputImg.Height; j++)
                {
                    for (int i = 0; i < inputImg.Width; i++)
                    {
                        // extract R channel
                        Color RGB = inputImg.GetPixel(i, j);
                        int rChannel = Convert.ToInt32(RGB.R);

                        rChannelImg.SetPixel(i, j, Color.FromArgb(rChannel, rChannel, rChannel));
                    }
                }
                return rChannelImg;
            }
            return null;
        }

        public Bitmap G_Extract(Bitmap inputImg)
        {
            if (inputImg != null)
            {
                Bitmap gChannelImg = new Bitmap(inputImg);

                for (int j = 0; j < inputImg.Height; j++)
                {
                    for (int i = 0; i < inputImg.Width; i++)
                    {
                        // extract G channel
                        Color RGB = inputImg.GetPixel(i, j);
                        int gChannel = Convert.ToInt32(RGB.G);

                        gChannelImg.SetPixel(i, j, Color.FromArgb(gChannel, gChannel, gChannel));
                    }
                }
                return gChannelImg;
            }
            return null;
        }

        public Bitmap B_Extract(Bitmap inputImg)
        {
            if (inputImg != null)
            {
                Bitmap bChannelImg = new Bitmap(inputImg);

                for (int j = 0; j < inputImg.Height; j++)
                {
                    for (int i = 0; i < inputImg.Width; i++)
                    {
                        // extract B channel
                        Color RGB = inputImg.GetPixel(i, j);
                        int bChannel = Convert.ToInt32(RGB.B);

                        bChannelImg.SetPixel(i, j, Color.FromArgb(bChannel, bChannel, bChannel));
                    }
                }
                return bChannelImg;
            }
            return null;
        }
    }
}
