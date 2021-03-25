using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Change_Form
    {
        // compute rotate image's size
        private Bitmap Resize(Bitmap inputImg, double radian)
        {
            if (inputImg != null)
            {
                double x1, x2, x3, x4, y1, y2, y3, y4;
                double nx1, nx2, nx3, nx4, ny1, ny2, ny3, ny4;
                double cos = Math.Cos(radian);
                double sin = Math.Sin(radian);

                x1 = 0;
                y1 = 0;
                x2 = inputImg.Width - 1;
                y2 = 0;
                x3 = inputImg.Width - 1;
                y3 = inputImg.Height - 1;
                x4 = 0;
                y4 = inputImg.Height - 1;

                nx1 = x1 * cos - y1 * sin;
                ny1 = x1 * sin + y1 * cos;
                nx2 = x2 * cos - y2 * sin;
                ny2 = x2 * sin + y2 * cos;
                nx3 = x3 * cos - y3 * sin;
                ny3 = x3 * sin + y3 * cos;
                nx4 = x4 * cos - y4 * sin;
                ny4 = x4 * sin + y4 * cos;

                double max_x = Math.Max(nx1, Math.Max(nx2, Math.Max(nx3, nx4)));
                double min_x = Math.Min(nx1, Math.Min(nx2, Math.Min(nx3, nx4)));
                double max_y = Math.Max(ny1, Math.Max(ny2, Math.Max(ny3, ny4)));
                double min_y = Math.Min(ny1, Math.Min(ny2, Math.Min(ny3, ny4)));

                Bitmap image = new Bitmap((int)(max_x - min_x + 0.5), (int)(max_y - min_y + 0.5));
                return image;
            }
            return null;
        }



        // set image's background to black
        private Bitmap Initial(Bitmap inputImg)
        {
            if (inputImg != null)
            {
                for (int j = 0; j < inputImg.Height; j++)
                {
                    for (int i = 0; i < inputImg.Width; i++)
                    {
                        inputImg.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
                return inputImg;
            }
            return null;
        }

        public Bitmap Rotate(Bitmap inputImg, double degree)
        {
            if (inputImg != null)
            {
                double radian = degree * (Math.PI / 180);
                int x, y;
                double diffX, diffY;
                Bitmap rotateImg = Resize(inputImg, radian);
                rotateImg = Initial(rotateImg);

                // compute the displacement
                diffX = (-0.5 * (rotateImg.Width - 1) * Math.Cos(radian)) - (0.5 * (rotateImg.Height - 1) * Math.Sin(radian)) + (0.5 * (inputImg.Width - 1));
                diffY = 0.5 * (rotateImg.Width - 1) * Math.Sin(radian) - (0.5 * (rotateImg.Height - 1) * Math.Cos(radian)) + (0.5 * (inputImg.Height - 1));

                for (int j = 0; j < rotateImg.Height; j++)
                {
                    for (int i = 0; i < rotateImg.Width; i++)
                    {
                        // do inverse rotate
                        x = (int)(i * Math.Cos(radian) + j * Math.Sin(radian) + 0.5 + diffX);
                        y = (int)(-i * Math.Sin(radian) + j * Math.Cos(radian) + 0.5 + diffY);

                        // map color from original image to rotate image
                        if (x >= 0 && x < inputImg.Width && y >= 0 && y < inputImg.Height)
                        {
                            Color RGB = inputImg.GetPixel(x, y);
                            int rChannel = Convert.ToInt32(RGB.R);
                            int gChannel = Convert.ToInt32(RGB.G);
                            int bChannel = Convert.ToInt32(RGB.B);

                            rotateImg.SetPixel(i, j, Color.FromArgb(rChannel, gChannel, bChannel));
                        }
                    }
                }

                return rotateImg;
            }
            return null;
        }

        public Bitmap invRotate(Bitmap inputImg, double degree)
        {
            if (inputImg != null)
            {
                double radian = 360 * (Math.PI / 180);
                int x, y;
                double diffX, diffY;
                Bitmap rotateImg = Resize(inputImg, radian);
                rotateImg = Initial(rotateImg);

                // compute the displacement
                diffX = (-0.5 * (rotateImg.Width - 1) * Math.Cos(radian)) - (0.5 * (rotateImg.Height - 1) * Math.Sin(radian)) + (0.5 * (inputImg.Width - 1));
                diffY = 0.5 * (rotateImg.Width - 1) * Math.Sin(radian) - (0.5 * (rotateImg.Height - 1) * Math.Cos(radian)) + (0.5 * (inputImg.Height - 1));

                for (int j = 0; j < rotateImg.Height; j++)
                {
                    for (int i = 0; i < rotateImg.Width; i++)
                    {
                        // do inverse rotate
                        x = (int)(i * Math.Cos(radian) + j * Math.Sin(radian) + 0.5 + diffX);
                        y = (int)(-i * Math.Sin(radian) + j * Math.Cos(radian) + 0.5 + diffY);

                        // map color from original image to rotate image
                        if (x >= 0 && x < inputImg.Width && y >= 0 && y < inputImg.Height)
                        {
                            Color RGB = inputImg.GetPixel(x, y);
                            int rChannel = Convert.ToInt32(RGB.R);
                            int gChannel = Convert.ToInt32(RGB.G);
                            int bChannel = Convert.ToInt32(RGB.B);

                            rotateImg.SetPixel(i, j, Color.FromArgb(rChannel, gChannel, bChannel));
                        }
                    }
                }

                return rotateImg;
            }
            return null;
        }

        public Bitmap Stretch(Bitmap inputImg, double scale_x, double scale_y)
        {
            if (inputImg != null)
            {
                int n_width = (int)(inputImg.Width * scale_x + 0.5);
                int n_height = (int)(inputImg.Height * scale_y + 0.5);
                int x, y;
                Bitmap stretchImg = new Bitmap(n_width, n_height);

                for (int j = 0; j < stretchImg.Height; j++)
                {
                    for (int i = 0; i < stretchImg.Width; i++)
                    {
                        // do inverse scale
                        x = (int)(i / scale_x + 0.5);
                        y = (int)(j / scale_y + 0.5);

                        // map color from original image to stretch image
                        if (x >= 0 && x < inputImg.Width && y >= 0 && y < inputImg.Height)
                        {
                            Color RGB = inputImg.GetPixel(x, y);
                            int rChannel = Convert.ToInt32(RGB.R);
                            int gChannel = Convert.ToInt32(RGB.G);
                            int bChannel = Convert.ToInt32(RGB.B);

                            stretchImg.SetPixel(i, j, Color.FromArgb(rChannel, gChannel, bChannel));
                        }
                    }
                }

                return stretchImg;
            }
            return null;
        }
    }
}
